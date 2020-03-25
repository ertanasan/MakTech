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
    public class HotKey
    {
        public int HotKeyId { get; set; }
        public int Code { get; set; }
        public string ProductName { get; set; }
    }

    public class StoreCreatePriceFile : DualWorker<object>
    {
        private const int TOKEN_EXPIRATION_LAG = 60;

        private readonly int _storeId;
        private readonly string _restClientAddress;
        private readonly IDeflateCompressor _deflateCompressor;
        private string _userName;
        private SecureString _password;
        private AuthenticationToken _token;
        private DateTime _tokenTime;
        private string baseApiRef = "api/OverStore/";
        private string digiFolder = @"D:\DAEMON\Digi";
        private IEnumerable<ProductPrice> _cashRegisterPrices;
        private IEnumerable<Cashier> _cashiers;
        private IEnumerable<CashRegisterBrand> _cashRegisterBrands;
        private IEnumerable<ProductPrice> _scalePrices;
        private List<HotKey> _hotkeys;
        private List<HotKey> _hotkeys32;
        private List<HotKey> _hotkeys56;
        private IEnumerable<ScaleBrand> _scaleBrands;
        private IEnumerable<StoreScales> _storeScales;
        private DataTable _delistProducts;


        public StoreCreatePriceFile(ILoggerFactory loggerFactory, IDictionary<string, string> parameters, string name
            , IDeflateCompressor deflateCompressor)
            : base(loggerFactory, parameters, name)
        {
            _deflateCompressor = deflateCompressor;

            _restClientAddress = parameters.TryGetOrDefault("RestClientAddress", "http://localhost:61435");
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

            _storeId = parameters.TryGetOrDefault("StoreId", 0);
            if (_storeId == 0)
            {
                _logger.FatalError("Store Id parameter missing in config file");
                throw new Exception("Store Id parameter missing in config file");
            }

            
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

        private void readStoreCashRegisterPrices()
        {
            refreshToken();
            var client = new RestClient(_restClientAddress);
            _logger.Debug($"readStoreCashRegisterPrices : CashRegisterSalePrices/{_storeId}");
            var request = new RestRequest(baseApiRef + "CashRegisterSalePrices/{storeId}", Method.GET);
            addHeaders(request);
            request.AddUrlSegment("storeId", _storeId.ToString());
            var retJson = client.Execute(request).Content;
            _cashRegisterPrices =  JsonConvert.DeserializeObject<List<ProductPrice>>(retJson);
            _logger.Debug($"readStoreCashRegisterPrices : _cashRegisterPrices : {_cashRegisterPrices.Count()}");
        }

        private void readCashiers()
        {
            refreshToken();
            var client = new RestClient(_restClientAddress);
            var request = new RestRequest(baseApiRef + "Cashiers/{storeId}", Method.GET);
            addHeaders(request);
            request.AddUrlSegment("storeId", _storeId.ToString());
            var retJson = client.Execute(request).Content;
            _cashiers = JsonConvert.DeserializeObject<List<Cashier>>(retJson);
            Cashier admin = new Cashier();
            admin.CashierId = 53;
            admin.CashierName = "Yetkili Servis";
            admin.CashierTemplateNumber = 9998;
            admin.Password = 200200;
            Cashier IT = new Cashier();
            IT.CashierId = 500;
            IT.CashierName = "Bilgi İşlem";
            IT.CashierTemplateNumber = 8000;
            IT.Password = 1447;
            Cashier[] extList = new Cashier[2];
            extList[0] = admin;
            extList[1] = IT;
            _cashiers = _cashiers.Concat(extList);

            _logger.Debug($"cashiers read : _cashiers : {_cashiers.Count()}");
        }

        private void readStoreScalePrices()
        {
            refreshToken();
            var client = new RestClient(_restClientAddress);
            var request = new RestRequest(baseApiRef + "ScaleSalePrices/{storeId}", Method.GET);
            addHeaders(request);
            request.AddUrlSegment("storeId", _storeId.ToString());
            var retJson = client.Execute(request).Content;
            _scalePrices = JsonConvert.DeserializeObject<List<ProductPrice>>(retJson);
        }

        private void readDeListProducts()
        {
            refreshToken();
            var client = new RestClient(_restClientAddress);
            var request = new RestRequest(baseApiRef + "GetDeListProducts", Method.GET);
            addHeaders(request);
            var retJson = client.Execute(request).Content;
            _delistProducts = JsonConvert.DeserializeObject<DataTable>(retJson);
        }

        private List<HotKey> readHotKeys()
        {
            refreshToken();
            var client = new RestClient(_restClientAddress);
            var request = new RestRequest(baseApiRef + "HotKeys", Method.GET);
            addHeaders(request);
            var retJson = client.Execute(request).Content;
            return JsonConvert.DeserializeObject<List<HotKey>>(retJson);
        }

        private List<HotKey> readHotKeys32()
        {
            refreshToken();
            var client = new RestClient(_restClientAddress);
            var request = new RestRequest(baseApiRef + "HotKeys32", Method.GET);
            addHeaders(request);
            var retJson = client.Execute(request).Content;
            return JsonConvert.DeserializeObject<List<HotKey>>(retJson);
        }

        private List<HotKey> readHotKeys56()
        {
            refreshToken();
            var client = new RestClient(_restClientAddress);
            var request = new RestRequest(baseApiRef + "HotKeys56", Method.GET);
            addHeaders(request);
            var retJson = client.Execute(request).Content;
            return JsonConvert.DeserializeObject<List<HotKey>>(retJson);
        }

        private IEnumerable<CurrentPrices> readStoreCurrentPrices(int groupCode)
        {
            refreshToken();
            var client = new RestClient(_restClientAddress);
            var request = new RestRequest(baseApiRef + "StoreCurrentPrices/{storeId}/{groupCode}", Method.GET);
            addHeaders(request);
            request.AddUrlSegment("storeId", _storeId.ToString());
            request.AddUrlSegment("groupCode", groupCode.ToString());
            var retJson = client.Execute(request).Content;
            return JsonConvert.DeserializeObject<List<CurrentPrices>>(retJson);
        }

        private IEnumerable<CashRegisterBrand> readStoreCashRegisterBrands()
        {
            refreshToken();
            var client = new RestClient(_restClientAddress);
            var request = new RestRequest(baseApiRef + "StoreCashRegisterBrands/{storeId}", Method.GET);
            addHeaders(request);
            request.AddUrlSegment("storeId", _storeId.ToString());
            var retJson = client.Execute(request).Content;
            return JsonConvert.DeserializeObject<List<CashRegisterBrand>>(retJson);
        }

        private IEnumerable<ScaleBrand> readStoreScaleBrands()
        {
            refreshToken();
            var client = new RestClient(_restClientAddress);
            var request = new RestRequest(baseApiRef + "StoreScaleBrands/{storeId}", Method.GET);
            addHeaders(request);
            request.AddUrlSegment("storeId", _storeId.ToString());
            var retJson = client.Execute(request).Content;
            return JsonConvert.DeserializeObject<List<ScaleBrand>>(retJson);
        }

        private IEnumerable<StoreScales> readStoreScales()
        {
            refreshToken();
            var client = new RestClient(_restClientAddress);
            var request = new RestRequest(baseApiRef + "StoreScales/{storeId}", Method.GET);
            addHeaders(request);
            request.AddUrlSegment("storeId", _storeId.ToString());
            var retJson = client.Execute(request).Content;
            return JsonConvert.DeserializeObject<List<StoreScales>>(retJson);
        }

        private void createNCRPriceFile(string filePath)
        {
            IList<string> lines = new List<string>();
            foreach (var line in _cashRegisterPrices)
            {
                string line1 = $"10{line.ProductCodeName.PadRight(20)}{line.ProductName.PadRight(20).Substring(0, 20)}";
                line1 += $"0{line.Plu1.PadLeft(20, '0')}0{line.Plu2.PadLeft(20, '0')}0{line.Plu3.PadLeft(20, '0')}";
                line1 += "0".PadLeft(43, '0');
                lines.Add(line1);

                string line2 = $"2{line.ProductName.PadRight(50).Substring(0, 50)}{Math.Round(line.PriceAmount * 100).ToString().PadLeft(12, '0')}";
                line2 += "0".PadLeft(44, '0');
                line2 += "1111" + "0".PadLeft(12, '0');
                switch (line.SaleVATRate)
                {
                    case 1:
                        line2 += "02"; break;
                    case 8:
                        line2 += "03"; break;
                    case 18:
                        line2 += "04"; break;
                    default:
                        line2 += "00"; break;
                }
                switch (line.Unit)
                {
                    case 1:
                        line2 += "1"; break; //kg
                    case 2:
                        line2 += "0"; break; //adet
                }
                line2 += "0".PadLeft(22, '0');
                lines.Add(line2);
            }
            // kasiyer bilgileri
            // string cashierLine = "";
            // int ind = 1;
            foreach (var line in _cashiers)
            {
                string cashierLine = $"9{line.CashierId.ToString().PadLeft(8, '0')}{line.CashierName.PadRight(20).Substring(0, 20)}";
                switch(line.CashierTemplateNumber)
                {
                    case 0: cashierLine += $"{line.Password.ToString().PadLeft(8, '0')}1000"; break;
                    case 1: cashierLine += $"{line.Password.ToString().PadLeft(8, '0')}4000"; break;
                    case 2: cashierLine += $"{line.Password.ToString().PadLeft(8, '0')}6000"; break;
                    case 3: cashierLine += $"{line.Password.ToString().PadLeft(8, '0')}7000"; break;
                    default: cashierLine += $"{line.Password.ToString().PadLeft(8, '0')}{line.CashierTemplateNumber.ToString().PadLeft(4, '0')}"; break;
                }
                
                cashierLine += " ".PadLeft(8, ' ');
                cashierLine += "0".PadLeft(48, '0');
                cashierLine += "0".PadLeft(48, '0');
                cashierLine += "0".PadLeft(3, '0');
                lines.Add(cashierLine);
                /*
                if (ind % 3 == 0)
                {
                    cashierLine += " ".PadLeft(3, ' ');
                    lines.Add(cashierLine);
                }
                ind++;*/
            }
            lines.Add("");
            File.WriteAllText(filePath, String.Join("\r\n", lines), Encoding.GetEncoding(1252));
        }

        private void ExecuteCommand(string command)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
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

        private void createToshibaPriceFile(string filePath)
        {
            IList<string> lines = new List<string>();
            lines.Add("SIGNATURE=GNDPLU.GDF");
            string line1 = "";
            foreach (var line in _cashRegisterPrices)
            {
                try
                {
                    // işlem türü, stok kodu, eski stok kodu
                    line1 = $"{"01".PadRight(4)}{1}{line.ToshibaId.PadRight(24)}{line.ToshibaId.PadRight(24)}";
                    // sc001, sc002
                    line1 += $"{line.ProductName.PadRight(40).Substring(0, 40)}{line.ProductName.PadRight(40).Substring(0, 40)}";
                    // sc003-sc005
                    line1 += $"{line.ProductName.PadRight(20).Substring(0, 20)}{line.ProductName.PadRight(20).Substring(0, 20)}{line.ProductName.PadRight(16).Substring(0, 16)}";
                    // sc006-sc014
                    line1 += $"{" ".PadLeft(32, ' ')}0{"0,00".PadRight(15)}{"0,00".PadRight(15)}{"0".PadRight(6)}{" ".PadRight(24)}";
                    // sc015 - sc017
                    switch (line.Unit)
                    {
                        case 1:
                            line1 += "1" + "1000".PadRight(15) + "1".PadRight(15); break; //kg
                        case 2:
                            line1 += "0" + "1".PadRight(15) + "1".PadRight(15); break; //adet
                    }
                    // sc018 - sc023
                    line1 += " ".PadRight(16) + "0".PadRight(12) + "0".PadRight(12) + "00";
                    // sc024
                    line1 += line.PriceAmount.ToString("n2").PadRight(15).Replace(".", ",");
                    // sc025- sc028
                    line1 += "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15);
                    // sc029- sc033
                    line1 += "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(15);
                    // sc034 - sc044
                    line1 += "0 0 0 0 0 0 0 0 0 0 1023  ";
                    // sc045 - sc046
                    switch (line.SaleVATRate)
                    {
                        case 1:
                            line1 += "1  1  "; break;
                        case 8:
                            line1 += "2  2  "; break;
                        case 18:
                            line1 += "3  3  "; break;
                        default:
                            line1 += "0  0  "; break;
                    }

                    // sc047- sc051
                    line1 += "0" + "0".PadRight(15) + "0".PadRight(15) + "0".PadRight(3) + "0".PadRight(15);

                    // sc052 - sc058
                    line1 += "00000021";

                    // sc076
                    line1 += " ".PadRight(20) + "0".PadRight(72, '0');

                    switch (line.Unit)
                    {
                        case 1:
                            line1 += "1"; break; //kg
                        case 2:
                            line1 += "0"; break; //adet
                    }

                    line1 += "0".PadRight(156, '0');

                    lines.Add(line1);
                }
                catch (Exception ex)
                {
                    _logger.Error($"createToshibaPriceFile ProductName:{line.ProductName}, line1:{line1}", ex);
                }

            }

            string line2 = "";
            foreach (var line in _cashRegisterPrices)
            {
                try
                {
                    line2 = $"{"02".PadRight(4)}{1}{line.ToshibaId.PadRight(24)}" +
                        $"{line.Plu1.PadRight(24)}{line.Plu1.PadRight(24)}{"1".PadRight(6)}{"001"}";
                    lines.Add(line2);
                }
                catch (Exception ex)
                {
                    _logger.Error($"createToshibaPriceFile ProductName:{line.ProductName}, line2:{line2}", ex);
                }
            }

            File.WriteAllText(filePath, String.Join("\r\n", lines), Encoding.GetEncoding(1252));

            _logger.Debug($"Toshiba run GeniusOPA and GeniusPCN started : {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
            string path = Directory.GetCurrentDirectory();
            try
            {
                _logger.Debug($"Toshiba run GeniusOPA and GeniusPCN set current directory : {path}\\IBMScript");
                Directory.SetCurrentDirectory($"{path}\\IBMScript");
                ExecuteCommand(@"GeniusPLU.BAT");
                Directory.SetCurrentDirectory(path);
            }
            catch (Exception ex)
            {
                _logger.Error($"Toshiba run GeniusOPA and GeniusPCN : {ex.ToString()}");
                Directory.SetCurrentDirectory(path);
            }
            _logger.Debug($"Toshiba run GeniusOPA and GeniusPCN ended {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");

        }

        private void sendDeListtoDigi()
        {
            if (!Directory.Exists(digiFolder))
            {
                ExecuteCommand($"md {digiFolder}");
            }

            string s = "";

            foreach (DataRow dr in _delistProducts.Rows)
            {
                string barcode = dr[0].ToString();
                string productname = "XXDELISTXX";
                if (barcode.Left(3) != "290") continue;

                s += barcode.Replace("290", "000").PadLeft(8, '0');

                if (productname.Length > 20) productname = productname.Substring(0, 20);

                productname = String.Join("", productname.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)).Replace("ı", "i");

                int plulength = 50 - (20 - productname.Length);
                s += plulength.ToString("X").PadLeft(4, '0');

                s += "74001D2000";

                decimal price = 0;
                s += price.ToString().PadLeft(8, '0');

                s += "1105";
                s += barcode.PadRight(13, '0');
                s += "1000007";

                s += productname.Length.ToString("X").PadLeft(2, '0');

                s += BitConverter.ToString(Encoding.Default.GetBytes(productname)).Replace("-", "");

                s += "0C00";

            }
            if (_scalePrices.Count() > 0)
            {
                File.WriteAllText($"{digiFolder}\\DELIST.DAT", s, Encoding.GetEncoding(1252));
                sendtoDigiScales(true);
            }
        }

        private void createDigiPluDatFile()
        {
            if (!Directory.Exists(digiFolder))
            {
                ExecuteCommand($"md {digiFolder}");
            }

            string s = "";

            foreach (var line in _scalePrices)
            {
                if (line.Plu1.Left(3) != "290") continue;
                string barcode = line.Plu1;

                s += barcode.Replace("290", "000").PadLeft(8, '0');

                string productname = line.ProductName.ToUpper();
                if (productname.Length > 20) productname = productname.Substring(0, 20);

                productname = String.Join("", productname.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)).Replace("ı", "i");

                int plulength = 50 - (20 - productname.Length);
                s += plulength.ToString("X").PadLeft(4, '0');

                s += "74001D2000";

                decimal price = Math.Round(((decimal)line.PriceAmount * 100), 0);
                s += price.ToString().PadLeft(8, '0');

                s += "1105";
                s += barcode.PadRight(13, '0');
                s += "1000007";

                s += productname.Length.ToString("X").PadLeft(2, '0');

                s += BitConverter.ToString(Encoding.Default.GetBytes(productname)).Replace("-", "");

                s += "0C00";

            }
            _logger.Debug($"_scalePrices.length : {_scalePrices.Count()}");
            if (_scalePrices.Count() > 0)
            {
                File.WriteAllText($"{digiFolder}\\PLU.DAT", s, Encoding.GetEncoding(1252));
                sendtoDigiScales(false);
            }
        }



        private void createDigiPresetKeyFile()
        {
            if (!Directory.Exists(digiFolder))
            {
                ExecuteCommand($"md {digiFolder}");
            }

            string s56 = "";
            string s32 = "";
            int[] conv32 = new int[32] { 13, 14, 15, 16, 17, 18, 9, 10, 26, 27, 28, 29, 11, 12, 19, 20, 38, 39, 21, 22, 23, 24, 25, 30, 31, 32, 33, 34, 35, 36, 37, 40 };

            foreach (var line in _hotkeys56)
            {
                s56 += line.HotKeyId.ToString().PadLeft(8, '0');
                s56 += "0024";
                s56 += line.Code.ToString().PadLeft(8, '0');
                s56 += "00";
                s56 += "2E2E2E20202020202020202020202020202020202020202020";
            }

            foreach (var line in _hotkeys32)
            {
                s32 += conv32[line.HotKeyId - 1].ToString().PadLeft(8, '0');
                s32 += "0024";
                s32 += line.Code.ToString().PadLeft(8, '0');
                s32 += "00";
                s32 += "2E2E2E20202020202020202020202020202020202020202020";
            }

            //if (_hotkeys.Count() > 0)
            //{
                File.WriteAllText($"{digiFolder}\\KEY56.DAT", s56, Encoding.GetEncoding(1252));
                File.WriteAllText($"{digiFolder}\\KEY32.DAT", s32, Encoding.GetEncoding(1252));
                sendPresetstoDigiScales();
            //}
        }

        private void sendPresetstoDigiScales()
        {
            string datName;
            foreach (StoreScales sc in _storeScales)
            {
                if (sc.ModelName == "Digi")
                {
                    datName = "KEY32.DAT";
                } else
                {
                    datName = "KEY56.DAT";
                }
                string path = Directory.GetCurrentDirectory();
                try
                {
                    if (!Directory.Exists($"{digiFolder}\\{sc.IpAdress}\\HotKey"))
                        ExecuteCommand($"md {digiFolder}\\{sc.IpAdress}\\HotKey");

                    if (!File.Exists($"{digiFolder}\\{sc.IpAdress}\\HotKey\\digiwtcp.exe"))
                        ExecuteCommand($"COPY Digi\\digiwtcp.exe {digiFolder}\\{sc.IpAdress}\\HotKey\\digiwtcp.exe");

                    ExecuteCommand($"COPY {digiFolder}\\{datName} {digiFolder}\\{sc.IpAdress}\\HotKey\\sm{sc.IpAdress}F65.dat");

                    Directory.SetCurrentDirectory($"{digiFolder}\\{sc.IpAdress}\\HotKey");

                    string s;
                    s = $"digiwtcp.exe WR 65 {sc.IpAdress}";
                    File.WriteAllText(@"SendPreset.BAT", s, Encoding.GetEncoding(1252));

                    ExecuteCommand(@"SendPreset");
                    _logger.Debug($"Digi hotkeys sent : ModelName : {sc.ModelName} IpAddress : {sc.IpAdress} record.");
                    Directory.SetCurrentDirectory(path);
                }
                catch (Exception ex)
                {
                    _logger.Error($"sendPresetstoDigiScales : {ex.ToString()}");
                    Directory.SetCurrentDirectory(path);
                }
            }
        }


        private bool createPerkonPriceFile(string filePath)
        {
            try
            {
                IList<string> lines = new List<string>();
                foreach (var line in _scalePrices)
                {
                    string line1 = $"{line.Plu1.PadRight(20).Substring(0, 7)}{line.ProductName.PadRight(60).Substring(0, 25)}";
                    line1 += $"{line.PriceAmount.ToString("n2").Replace(".", ",")}  60";
                    lines.Add(line1);
                }
                File.WriteAllText(filePath, String.Join("\r\n", lines), Encoding.GetEncoding(1252));
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"sendPresetstoDigiScales : {ex.ToString()}");
                return false;
            }
        }

        private void createCashRegisterFile()
        {
            try
            {
                _logger.Debug($"StoreCreatePriceFile CR process : StoreId : {_storeId.ToString()} Started : {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");

                readStoreCashRegisterPrices();

                _logger.Debug($"StoreCreatePriceFile CR process : StoreId : {_storeId.ToString()} prices read. {_cashRegisterPrices.Count()} record.");

                if (_cashRegisterPrices.Count() > 0)
                {
                    readCashiers();
                    foreach (CashRegisterBrand cr in _cashRegisterBrands)
                    {
                        switch (cr.Name)
                        {
                            case "NCR":
                                _logger.Debug($"NCR File Created, StoreId : {_storeId.ToString()} FileName : {cr.PriceFilePath}");
                                createNCRPriceFile(cr.PriceFilePath);
                                break;
                            case "Toshiba": createToshibaPriceFile(cr.PriceFilePath); break;
                        }
                    }
                   
                    _logger.Debug($"StoreCreatePriceFile CR process : StoreId : {_storeId.ToString()} text file created");
                }
                

            }
            catch (Exception ex)
            {
                _logger.Error($"StoreCreatePriceFile CR process : StoreId : {_storeId.ToString()} Unexpected processing exception.", ex);
                _cancelSpinEvent.WaitOne(30000);
            }
        }

        private string perkonFilePath()
        {
            string perkonFile = @"C:\Program Files (x86)\Perkon\PerkonScale.exe";
            if (File.Exists(perkonFile)) return perkonFile;
            perkonFile = @"C:\Program Files\Perkon\PerkonScale.exe";
            if (File.Exists(perkonFile)) return perkonFile;
            return "";
        }

        private void checkPerkonScale()
        {
            Process[] pname = Process.GetProcessesByName("PerkonScale");
            if (pname.Length == 0)
            {
                Process perkon = new Process();

                try
                {
                    perkon.StartInfo.UseShellExecute = false;
                    perkon.StartInfo.FileName = perkonFilePath();
                    
                    perkon.StartInfo.CreateNoWindow = true;
                    perkon.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                    if (perkon.StartInfo.FileName != "")
                    {
                        perkon.Start();
                    }
                    else
                    {
                        _logger.Error($"Perkon Scale is not installed");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            

        }

        private bool UpdateScaleStatus(bool newStatus, string newStatusText, StoreScales sc)
        {
            refreshToken();
            var client = new RestClient(_restClientAddress);
            var request = new RestRequest(baseApiRef + "UpdateScaleStatus", Method.POST);
            addHeaders(request);

            sc.Status = newStatus;
            sc.StatusText = newStatusText;
            sc.CreatePriceFileFlag = false;
            request.AddJsonBody(sc);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                _logger.Error($"Failed with content= '{response.Content}', and message= '{response.ErrorMessage}'", response.ErrorException);
                return false;
            }
        }

        private void sendtoDigiScales(bool deList)
        {
            string datName = deList ? "DELIST.DAT" : "PLU.DAT";
            foreach (StoreScales sc in _storeScales)
            {
                if (sc.BrandName == "Digi")
                {
                    string path = Directory.GetCurrentDirectory();
                    try
                    {
                        //_logger.Debug($"Directory create : {digiFolder}\\{sc.IpAdress}");
                        if (!Directory.Exists($"{digiFolder}\\{sc.IpAdress}"))
                            ExecuteCommand($"md {digiFolder}\\{sc.IpAdress}");

                        //_logger.Debug($"Copy file digiwtcp to : {digiFolder}\\{sc.IpAdress}\\digiwtcp.exe");
                        if (!File.Exists($"{digiFolder}\\{sc.IpAdress}\\digiwtcp.exe"))
                            ExecuteCommand($"COPY Digi\\digiwtcp.exe {digiFolder}\\{sc.IpAdress}\\digiwtcp.exe");

                        //_logger.Debug($"Copy plu.dat to folder : COPY {digiFolder}\\PLU.DAT {digiFolder}\\{sc.IpAdress}\\sm{sc.IpAdress}F37.dat");
                        ExecuteCommand($"COPY {digiFolder}\\{datName} {digiFolder}\\{sc.IpAdress}\\sm{sc.IpAdress}F37.dat");

                        //_logger.Debug($"Get current directory : {path}");
                        Directory.SetCurrentDirectory($"{digiFolder}\\{sc.IpAdress}");
                        //_logger.Debug($"Set current directory : {digiFolder}\\{sc.IpAdress}");

                        string s;
                        if (deList)
                            s = $"digiwtcp.exe DEL 37 {sc.IpAdress}";
                        else
                            s = $"digiwtcp.exe WR 37 {sc.IpAdress}";
                        File.WriteAllText(@"SendPLU.BAT", s, Encoding.GetEncoding(1252));

                        //_logger.Debug($"Create SendPLU.BAT file ");

                        ExecuteCommand(@"SendPLU");
                        //_logger.Debug($"Run SendPLU.BAT ");

                        if (!deList)
                        {
                            string text = File.ReadAllText("result");
                            string[] result = text.Split(':');
                            text += " " + DateTime.Now.ToString("MM-dd HH:mm");
                            //_logger.Debug($"Read result : {result[1]}, {text}");

                            sc.CreatePriceFileFlag = false;
                            UpdateScaleStatus((result[1] == "0"), text, sc);
                            //_logger.Debug($"Scale status updated");
                        }

                        Directory.SetCurrentDirectory(path);
                        //_logger.Debug($"Set directory : {path}");
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"sendtoDigiScales : {ex.ToString()}");
                        Directory.SetCurrentDirectory(path);
                    }
                }
            }
        }

        public void scaletryAgain()
        {
            foreach (StoreScales sc in _storeScales)
            {
                if (!sc.Status && sc.ModelName == "Digi")
                {
                    string path = Directory.GetCurrentDirectory();
                    try
                    {
                        Directory.SetCurrentDirectory($"{digiFolder}\\{sc.IpAdress}");
                        ExecuteCommand(@"SendPLU");
                        string text = File.ReadAllText("result");
                        string[] result = text.Split(':');
                        text += " " + DateTime.Now.ToString("MM-dd HH:mm");
                        UpdateScaleStatus((result[1] == "0"), text, sc);

                        sendPresetstoDigiScales();
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"scaletryAgain : {ex.ToString()}");
                        Directory.SetCurrentDirectory(path);
                    }
                    finally
                    {
                        Directory.SetCurrentDirectory(path);
                    }
                } else if (!sc.Status && sc.ModelName == "Densi")
                {
                    IEnumerable<CurrentPrices> cp = readStoreCurrentPrices(2);
                    tryAgainDensiScale(sc, cp);
                }
                    
            }
        }

        
        private void sendtoDensiScale(StoreScales sc) 
        {
            int iRtn = -1;
            try
            {
                string RefLFZKFileName = "";
                string RefCFGFileName = "";
                iRtn = rtsdrv.rtscaleConnectEx(RefLFZKFileName, RefCFGFileName, sc.IpAdress);
                if (iRtn < 0)
                {
                    UpdateScaleStatus(false, $"Connection Error : {iRtn} {DateTime.Now.ToString("MM - dd HH: mm")}", sc);
                    return;
                };
                rtsdrv.rtscaleClearPLUData();
                PLU[] plu = new PLU[4];
                int i = 0;
                bool processResult = true;
                foreach (var line in _scalePrices)
                {
                    // if (line.Plu1 == "2902011") continue;
                    int k = i % 4;
                    string productname = line.ProductName.ToUpper();
                    if (productname.Length > 20) productname = productname.Substring(0, 20);
                    productname = String.Join("", productname.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)).Replace("ı", "i");

                    int price = Convert.ToInt32(Math.Round(((decimal)line.PriceAmount * 100), 0));
                    int barcode = int.Parse(line.Plu1.Replace("290", "000"));

                    plu[k].Name = productname;
                    plu[k].LFCode = barcode;
                    plu[k].Code = barcode.ToString();
                    plu[k].BarCode = 40;
                    plu[k].UnitPrice = price;
                    plu[k].WeightUnit = 4;
                    plu[k].Deptment = 29;
                    plu[k].ShlefTime = 30;

                    i++;

                    if (i % 4 == 0)
                    {
                        int result = rtsdrv.rtscaleTransferPLUCluster(plu);
                        if (result != 0)
                        {
                            UpdateScaleStatus(false, $"Process Error : {result} {DateTime.Now.ToString("MM - dd HH: mm")}", sc);
                            processResult = false;
                        }
                        plu = new PLU[4];
                    }
                }

                if (i > 0 && i % 4 != 0)
                {
                    int result = rtsdrv.rtscaleTransferPLUCluster(plu);
                    if (result != 0)
                    {
                        UpdateScaleStatus(false, $"Process Error : {result} {DateTime.Now.ToString("MM - dd HH: mm")}", sc);
                        processResult = false;
                    }
                }
                if (i > 0 && processResult)
                {
                    UpdateScaleStatus(true, $"OK : {DateTime.Now.ToString("MM - dd HH: mm")}", sc);
                }

                // send hotkeys
                _logger.Debug($"hotkeys sent started");
                int[] pHotKeys = new int[84];
                int index = 0;
                int tableIndex = 0;
                foreach (HotKey h in _hotkeys)
                {
                    pHotKeys[index++] = h.Code;
                    if (index == 84)
                    {
                        rtsdrv.rtscaleTransferHotkey(pHotKeys, tableIndex++);
                        _logger.Debug($"hotkeys sent : { Newtonsoft.Json.JsonConvert.SerializeObject(pHotKeys)}");
                        index = 0;
                        pHotKeys = new int[84];
                    }
                }
                if (pHotKeys.Length > 0)
                {
                    rtsdrv.rtscaleTransferHotkey(pHotKeys, tableIndex++);
                    _logger.Debug($"hotkeys sent : { Newtonsoft.Json.JsonConvert.SerializeObject(pHotKeys)}");
                }

                rtsdrv.rtscaleDisConnectEx(sc.IpAdress);
            }
            catch (Exception ex)
            {
                _logger.Error($"sendtoDensiScale error : {ex.Message}");
                if (iRtn >= 0) // connection exist
                {
                    rtsdrv.rtscaleDisConnectEx(sc.IpAdress);
                }
            }
        }
        
        private void tryAgainDensiScale(StoreScales sc, IEnumerable<CurrentPrices> cp)
        {
            int iRtn = -1;
            try
            {
                string RefLFZKFileName = "";
                string RefCFGFileName = "";
                iRtn = rtsdrv.rtscaleConnectEx(RefLFZKFileName, RefCFGFileName, sc.IpAdress);
                if (iRtn < 0)
                {
                    UpdateScaleStatus(false, $"Connection Error : {iRtn} {DateTime.Now.ToString("MM - dd HH: mm")}", sc);
                    return;
                };
                rtsdrv.rtscaleClearPLUData();
                PLU[] plu = new PLU[4];
                int i = 0;
                bool processResult = true;
                foreach (var line in cp)
                {
                    int k = i % 4;
                    string productname = line.ProductName.ToUpper();
                    if (productname.Length > 20) productname = productname.Substring(0, 20);
                    productname = String.Join("", productname.Normalize(NormalizationForm.FormD).Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)).Replace("ı", "i");

                    int price = Convert.ToInt32(Math.Round(((decimal)line.SalePrice * 100), 0));
                    int barcode = int.Parse(line.Barcode.Replace("290", "000"));

                    plu[k].Name = productname;
                    plu[k].LFCode = barcode;
                    plu[k].Code = barcode.ToString();
                    plu[k].BarCode = 40;
                    plu[k].UnitPrice = price;
                    plu[k].WeightUnit = 4;
                    plu[k].Deptment = 29;
                    plu[k].ShlefTime = 30;

                    i++;

                    if (i % 4 == 0)
                    {
                        int result = rtsdrv.rtscaleTransferPLUCluster(plu);
                        if (result != 0)
                        {
                            UpdateScaleStatus(false, $"Process Error : {result} {DateTime.Now.ToString("MM - dd HH: mm")}", sc);
                            processResult = false;
                        }
                        plu = new PLU[4];
                    }
                }

                if (i > 0 && i % 4 != 0)
                {
                    int result = rtsdrv.rtscaleTransferPLUCluster(plu);
                    if (result != 0)
                    {
                        UpdateScaleStatus(false, $"Process Error : {result} {DateTime.Now.ToString("MM - dd HH: mm")}", sc);
                        processResult = false;
                    }
                }

                if (i > 0 && processResult)
                {
                    UpdateScaleStatus(true, $"OK : {DateTime.Now.ToString("MM - dd HH: mm")}", sc);
                }
                rtsdrv.rtscaleDisConnectEx(sc.IpAdress);
            }
            catch (Exception ex)
            {
                _logger.Error($"tryAgainDensiScale error : {ex.Message}");
                if (iRtn >= 0) // connection exist
                {
                    rtsdrv.rtscaleDisConnectEx(sc.IpAdress);
                }
            }
        }

        private void sendtoDensiScales()
        {
            foreach (StoreScales sc in _storeScales)
            {
                if (sc.BrandName == "Densi")
                {
                    sendtoDensiScale(sc);
                }
            }
        }

        private void createScaleFile()
        {
            try
            {
                _logger.Debug($"StoreCreatePriceFile Scale process : StoreId : {_storeId.ToString()} Started : {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                readStoreScalePrices();
                _logger.Debug($"StoreCreatePriceFile Scale process : StoreId : {_storeId.ToString()} prices read. {_scalePrices.Count()} record.");

                _hotkeys = readHotKeys();
                _hotkeys32 = readHotKeys32();
                _hotkeys56 = readHotKeys56();
                _logger.Debug($"Hotkeys read. {_hotkeys.Count} record.");

                readDeListProducts();

                if (_scalePrices.Count() > 0)
                {
                    string priceFilePath = _scalePrices.First<ProductPrice>().PriceFilePath;
                    foreach (ScaleBrand sb in _scaleBrands)
                    {
                        switch (sb.Name)
                        {
                            case "Digi":
                                sendDeListtoDigi();
                                _logger.Debug($"Digi delist created and sent: StoreId : {_storeId.ToString()} time : {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");

                                createDigiPluDatFile();
                                _logger.Debug($"Digi plu created and sent: StoreId : {_storeId.ToString()} time : {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");

                                createDigiPresetKeyFile();
                                _logger.Debug($"createDigiPresetKeyFile: StoreId : {_storeId.ToString()} time : {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");

                                if (createPerkonPriceFile(priceFilePath))
                                {
                                    _logger.Debug($"Perkon price file created: StoreId : {_storeId.ToString()} time : {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                                }
                                break;
                            case "Densi":
                                sendtoDensiScales();
                                _logger.Debug($"Prices sent to densi scale: StoreId : {_storeId.ToString()} time : {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");

                                if (createPerkonPriceFile(priceFilePath))
                                {
                                    _logger.Debug($"Perkon price file created: StoreId : {_storeId.ToString()} time : {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                                }

                                //checkPerkonScale();
                                break;
                        }
                    }
                    


                }


            }
            catch (Exception ex)
            {
                _logger.Error($"StoreCreatePriceFile Scale process : StoreId : {_storeId.ToString()} Unexpected processing exception.", ex);
                _cancelSpinEvent.WaitOne(30000);
            }
        }

  

        public override bool TryFetchItem(out object item)
        {

            _cashRegisterBrands = readStoreCashRegisterBrands();
            _storeScales = readStoreScales();

            _scaleBrands = readStoreScaleBrands();

            createCashRegisterFile();

            createScaleFile();

            scaletryAgain();

            item = null;
            return false;
        }

        public override void ProcessItem(object item)
        {
            throw new NotSupportedException("Processing is not supported by this worker.");
        }
    }
}
