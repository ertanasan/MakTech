using Overtech.Core.Logger;
using Overtech.Core;
using Overtech.Core.Threading;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Overtech.Core.Compression;
using System.Diagnostics;
using Overtech.DataModels.Price;
using Newtonsoft.Json;
using Overtech.DataModels.Store;
using System.Data;
using System.Configuration;
using System.Security;
using Overtech.Core.Application;
using Overtech.UI.Web;
using Overtech.Core.OverStore;
using System.Data.OleDb;
using System.Globalization;
using uDefine;

namespace Overtech.Shared.Daemon.OverStore
{
    public static class MyExtensions
    {
        public static void Times(this int count, Action action)
        {
            for (int i = 0; i < count; i++)
            {
                action();
            }
        }
    }


    public class TextPrint : DualWorker<object>
    {
        private const int TOKEN_EXPIRATION_LAG = 60;

        private readonly int _storeId;
        private readonly string _restClientAddress;
        private readonly string _tmpDocFolder;
        private string _userName;
        private SecureString _password;
        private AuthenticationToken _token;
        private DateTime _tokenTime;
        private string baseApiRef = "api/OverStore/";
        private IList<long> _printList;


        public TextPrint(ILoggerFactory loggerFactory, IDictionary<string, string> parameters, string name
            , IDeflateCompressor deflateCompressor)
            : base(loggerFactory, parameters, name)
        {
            _restClientAddress = parameters.TryGetOrDefault("RestClientAddress", "http://localhost:61435");
            _tmpDocFolder = parameters.TryGetOrDefault("TempDocumentFolder", @"C:\SSRS\");
            var credentialSource = parameters.TryGetOrDefault("CredentialSource", "Credentials");

            if (ConfigurationManager.ConnectionStrings[credentialSource] == null)
            {
                _logger.FatalError("Credential connection string is not defined. Further operation will fail.");
                throw new Exception("Credential connection string is not defined. Further operation will fail.");
            }
            string credentials = ConfigurationManager.ConnectionStrings[credentialSource].ConnectionString;
            if (String.IsNullOrEmpty(credentials))
            {
                _logger.FatalError("Credential connection string is not missing or empty. Operation will fail.");
                throw new Exception("Credential connection string is not missing or empty. Operation will fail.");
            }
            Dictionary<string, string> credentialParts = credentials.Split(';')
                .Select(t => t.Split(new char[] { '=' }, 2))
                .ToDictionary(t => t[0].Trim(), t => t[1].Trim(), StringComparer.InvariantCultureIgnoreCase);

            _userName = credentialParts["User Name"];
            _password = new SecureString();
            credentialParts["Password"].ToCharArray().ForEach(c => _password.AppendChar(c));

            // login
            login();

        }

        #region Login Utility
        private bool login()
        {
            var credentials = new NetworkCredential(_userName, _password);

            // Call authentication api
            var client = new RestClient(_restClientAddress);
            var request = new RestRequest("api/Authenticate/login", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new LoginViewModel
            {
                Username = credentials.UserName,
                Password = credentials.Password
            });
            var response = client.Execute<AuthenticationToken>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                if (response.Data.UserId > 0)
                {
                    _logger.Debug($"Login succeeded.");
                    _token = response.Data;
                    _tokenTime = DateTime.Now;
                    return true;
                }
                else
                {
                    _logger.Debug($"Login failed { response.Data.UserId }.");
                    return false;
                }
            }
            else
            {
                _logger.Error($"Login failed with content= '{response.Content}', and message= '{response.ErrorMessage}'", response.ErrorException);
                return false;
            }
        }

        private void refreshToken()
        {
            if (_token == null)
            {
                if (!login())
                {
                    throw new OTException(OTErrors.RestLoginFailed);
                }
            }
            if (_tokenTime.AddSeconds(_token.ExpireInSeconds - TOKEN_EXPIRATION_LAG) > DateTime.Now)
            {
                // No need to refresh
                return;
            }

            // Call authentication api
            var client = new RestClient(_restClientAddress);
            var request = new RestRequest("api/Authenticate/refreshToken", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer { _token.RefreshToken }");
            request.AddHeader("Referer", $"{ _restClientAddress }/Home/Index");
            var response = client.Execute<AuthenticationToken>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                _logger.Debug($"Refresh token succeeded.");
                _token = response.Data;
                _tokenTime = DateTime.Now;
            }
            else
            {
                _logger.Error($"Refresh token failed content= '{response.Content}', and message= '{response.ErrorMessage}'", response.ErrorException);
                _token = null;
                _tokenTime = DateTime.MinValue;
                if (!login())
                {
                    throw new OTException(OTErrors.RestLoginFailed);
                }
            }
        }

        private void addHeaders(RestRequest request)
        {
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer { _token.AccessToken }");
            request.AddHeader("Referer", $"{ _restClientAddress }/Home/Index");
        }
        #endregion Login Utility

        private void getPrintList()
        {
            refreshToken();
            var client = new RestClient(_restClientAddress);
            _logger.Debug($"getPrintList : GetPrintList");
            var request = new RestRequest(baseApiRef + "GetPrintList", Method.GET);
            addHeaders(request);
            var retJson = client.Execute(request).Content;
            _printList = JsonConvert.DeserializeObject<List<long>>(retJson);
            _logger.Debug($"getPrintList : _printList : {_printList.Count()}");
        }

        private void updatePrinted(long storeOrderId)
        {
            refreshToken();
            var client = new RestClient(_restClientAddress);
            var request = new RestRequest(baseApiRef + "UpdatePrinted/{storeOrderId}", Method.GET);
            addHeaders(request);
            request.AddUrlSegment("storeOrderId", storeOrderId.ToString());
            var retJson = client.Execute(request).Content;
            _logger.Debug($"updatePrinted : retJson : {retJson.ToString()}");
        }

        private DataTable getWaybillInfo(long storeOrderId)
        {
            refreshToken();
            var client = new RestClient(_restClientAddress);
            var request = new RestRequest(baseApiRef + "GetWaybillInfo/{storeOrderId}", Method.GET);
            addHeaders(request);
            request.AddUrlSegment("storeOrderId", storeOrderId.ToString());
            var retJson = client.Execute(request).Content;
            return JsonConvert.DeserializeObject<DataTable>(retJson);
        }

        

        private void createWaybillTextFile(DataTable dt)
        {
            IList<string> lines = new List<string>();
            int rowCount = dt.Rows.Count;
            int pageRowCount = 38;
            int pageCount = ((int)(rowCount / pageRowCount))+1;
            int startEmptyRowCount = 1;
            int afterHeaderEmptyRowCount = 2;
            int endEmptyRowCount = 2;

            string storeName = "", address = "";
            DateTime shipmentDate = DateTime.Now;
            long storeOrderId = 0;
            string addressLine1 = "";
            string addressLine2 = "";
            string waybillName = "Depolar Arası Sevk Fişi";
            string taxOffice = "Şahinbey Vergi Dairesi";
            string taxNumber = "6141016672";

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                storeName = dr["STORE_NM"].ToString();
                address = dr["ADDRESS_TXT"].ToString();
                foreach (string s in address.Split(' '))
                {
                    if (addressLine1.Length + s.Length < 30)
                    {
                        if (addressLine1.Length == 0) addressLine1 = s; else addressLine1 += " " + s;
                    } else if (addressLine2.Length + s.Length < 30)
                    {
                        if (addressLine2.Length == 0) addressLine2 = s; else addressLine2 += " " + s;
                    }
                }
                shipmentDate = (DateTime) dr["SHIPMENT_DT"];
                storeOrderId = long.Parse(dr["STOREORDERID"].ToString());
                for (int i = 0; i < pageCount; i++)
                {
                    startEmptyRowCount.Times(() => lines.Add(""));
                    lines.Add($"{" ".PadRight(6)}{storeName}");
                    // lines.Add($"{" ".PadRight(73)}{DateTime.Now.ToString("dd.MM.yyyy")}");
                    if (addressLine1.Length > 0)
                    {
                        lines.Add($"{addressLine1.PadRight(36)}{waybillName.PadRight(37)}{DateTime.Now.ToString("dd.MM.yyyy")}");
                    } else
                    {
                        lines.Add($"{" ".PadRight(36)}{waybillName.PadRight(37)}{DateTime.Now.ToString("dd.MM.yyyy")}");
                    }

                    if (addressLine2.Length > 1)
                    {
                        lines.Add($"{addressLine2.PadRight(73)}{shipmentDate.ToString("dd.MM.yyyy")}");
                    }
                    else
                    {
                        lines.Add($"{" ".PadRight(73)}{shipmentDate.ToString("dd.MM.yyyy")} ");
                    }
                    lines.Add($"{" ".PadRight(6)}{taxOffice}");
                    lines.Add($"{" ".PadRight(6)}{taxNumber.PadRight(67)}{storeOrderId.ToString()}");

                    afterHeaderEmptyRowCount.Times(() => lines.Add(""));

                    for (int j=0; j<pageRowCount; j++)
                    {
                        int rowno = i * pageRowCount + j;
                        if (dt.Rows.Count > rowno)
                        {
                            DataRow drow = dt.Rows[rowno];
                            string pallet = drow["PALLET_NO"].ToString();
                            string rowNumber = drow["ROWNO"].ToString();
                            string barcode = drow["BARCODE_TXT"].ToString();
                            string productcode = drow["PRODUCTCODE_NM"].ToString();
                            string productname = drow["PRODUCT_NM"].ToString();
                            string quantity = (decimal.Parse(drow["SHIPPED_QTY"].ToString())).ToString("0#.00#;(0#.00#)").Replace('.',',');
                            string unit = (dr["UNIT"].ToString() == "1") ? "KG" : "ADET";
                            lines.Add($"{pallet.PadRight(6)}{rowNumber.PadRight(3)}{barcode.PadRight(15)}{productcode.PadRight(12)}{productname.PadRight(35)}{quantity.PadLeft(8)} {unit}");
                        }
                    }

                    endEmptyRowCount.Times(() => lines.Add(""));

                }
            }

            RawPrinterHelper.SendStringToPrinter("OKI Dot-Matrix 9Pin ESC/P Class Driver", String.Join("\r\n", lines));
            

            
            // using (FileStream fs = File.Create(@"\\OTPC-TERVERDI2\OKI"))
            // {
            //     byte[] lineArray = ASCIIEncoding.UTF8.GetBytes(String.Join("\r\n", lines));
            //     fs.Write(lineArray, 0, lineArray.Length);
            //     fs.Close();
            // }

            // if (lines.Count > 0)
            // {
            //     File.WriteAllText($"{_tmpDocFolder}{storeOrderId}.txt", String.Join("\r\n", lines), Encoding.GetEncoding(1252));
            // }

        }


        private void ExecuteCommand(string command)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            command = command.Replace(@"\\", @"\");
            Console.WriteLine(command);
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = false;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            // Warning: This approach can lead to deadlocks, see Edit #2
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close();
        }

        private void runScript(long waybillId)
        {
            ExecuteCommand($"START /MIN NOTEPAD /P {_tmpDocFolder}{waybillId.ToString()}.txt");
        }

        public override bool TryFetchItem(out object item)
        {
            DataTable dt = getWaybillInfo(110944);

            createWaybillTextFile(dt);
            // runScript(110944);
            item = null;
            return false;
        }

        public override void ProcessItem(object item)
        {
            throw new NotSupportedException("Processing is not supported by this worker.");
        }
    }
}
