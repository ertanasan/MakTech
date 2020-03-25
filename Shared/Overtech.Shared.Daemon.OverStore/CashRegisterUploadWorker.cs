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
using Overtech.DataModels.StoreUpload;
using System.Data;
using System.Configuration;
using System.Security;
using Overtech.Core.Application;
using Overtech.UI.Web;
using Overtech.Core.OverStore;
using System.Data.OleDb;

namespace Overtech.Shared.Daemon.OverStore
{
    public class CashRegisterUploadWorker : DualWorker<object>
    {
        private const int TOKEN_EXPIRATION_LAG = 60;

        private readonly long _cashRegisterId;
        private readonly int _storeId;
        private readonly string _saleFileFolder, _restClientAddress, _additionalFileFolder; 
        private readonly IDeflateCompressor _deflateCompressor;
        private string _userName;
        private SecureString _password;
        private AuthenticationToken _token;
        private DateTime _tokenTime;
        private string baseApiRef = "api/OverStore/";
        private IEnumerable<StoreMissingDays> _missingDays;
        private int _ncrUploadTypeId = 1;
        private int _toshibaUploadTypeId = 2;
        private int _toshibaCancelledTypeId = 4;
        private int encodingCode = 1254;

        public CashRegisterUploadWorker(ILoggerFactory loggerFactory, IDictionary<string, string> parameters, string name
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

            _cashRegisterId = parameters.TryGetOrDefault("CashRegisterId", 0);
            if (_cashRegisterId == 0)
            {
                _logger.FatalError("Cash register Id parameter missing in config file");
                throw new Exception("Cash register Id parameter missing in config file");
            }

            _storeId = parameters.TryGetOrDefault("StoreId", 0);
            if (_storeId == 0)
            {
                _logger.FatalError("Store Id parameter missing in config file");
                throw new Exception("Store Id parameter missing in config file");
            }

            _saleFileFolder = parameters.TryGetOrDefault("SaleFileFolder", @"");
            _additionalFileFolder = parameters.TryGetOrDefault("AdditionalFileFolder", @"D:\Daemon\LoadFile");
            

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

        private void getMissingDays()
        {
            refreshToken();
            var client = new RestClient(_restClientAddress);
            var request = new RestRequest(baseApiRef + "GetMissingDays/{storeId}", Method.GET);
            addHeaders(request);
            request.AddUrlSegment("storeId", _storeId.ToString());
            var retJson = client.Execute(request).Content;
            _missingDays =  JsonConvert.DeserializeObject<List<StoreMissingDays>>(retJson);
        }

        private IList<string> readNCRFile(string fileName, string vDate)
        {
            IList<string> lines = new List<string>();
            try
            {

                using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var sr = new StreamReader(fs, Encoding.GetEncoding(encodingCode)))
                {
                    string l;
                    bool started = false;
                    while (!sr.EndOfStream)
                    {
                        l = sr.ReadLine();
                        if (l.Length > 40 && l.Substring(0, 1) == "H" && l.Substring(26, 6) == vDate)
                            started = true;
                        if (l.Length > 40 && l.Substring(0, 1) == "H" && l.Substring(26, 6) != vDate)
                            started = false;
                        if (started) lines.Add(l);
                    }

                    //Console.Write("File Content:" + sr.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Unexpected error - ReadNCRFile procedure", ex);
            }
            return lines;

        }

        private bool loadData(byte[] data, string file, int uploadTypeId)
        {
            try
            {
                _logger.Debug($"send process refreshing token...");
                refreshToken();
                _logger.Debug($"send process token refreshed.");
                var client = new RestClient(_restClientAddress);
                var request = new RestRequest(baseApiRef + "UploadCashRegisterData/{cashRegisterId}/{uploadTypeId}", Method.POST);
                addHeaders(request);

                request.AddUrlSegment("cashRegisterId", _storeId.ToString());
                request.AddUrlSegment("uploadTypeId", uploadTypeId.ToString());
                request.AddJsonBody(data);

                _logger.Debug($"{file} send process started : {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    _logger.Debug($"{file} succesfully sent to document system : {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                    return true;
                }
                else
                {
                    _logger.Error($"Failed with content= '{response.Content}', status= {response.StatusCode}, and message= '{response.ErrorMessage}'", response.ErrorException);
                    // Wait a little to prevent high CPU situations
                    _cancelSpinEvent.WaitOne(30000);
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"{file} Unexpected processing exception.", ex);
                // Wait a little to prevent high CPU situations
                _cancelSpinEvent.WaitOne(30000);
                return false;
            }
        }

        private void sendAdditionalFile(int uploadTypeId)
        {
            try
            {
                foreach (string file in Directory.EnumerateFiles(_additionalFileFolder, "*.*"))
                {
                    byte[] data = _deflateCompressor.Compress(System.IO.File.ReadAllBytes(file));

                    if (loadData(data, file, uploadTypeId))
                        File.Delete(file);
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"sendAdditionalFile Unexpected processing exception.", ex);
                // Wait a little to prevent high CPU situations
                _cancelSpinEvent.WaitOne(30000);
            }
        }

        private byte[] documentArray (IList<string> lines)
        {
            Encoding iso = Encoding.GetEncoding(1254);
            Encoding utf8 = Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes(String.Join("\n", lines));
            byte[] isoBytes = _deflateCompressor.Compress(Encoding.Convert(utf8, iso, utfBytes));
            return isoBytes;
        }

        private void sendLogFile(DateTime _date)
        {
            string logFileFolder = @"D:\ROOT\Database\Log";

            DateTime today = DateTime.Now;
            try
            {
                foreach (string file in Directory.EnumerateFiles(logFileFolder, "CONLG*.DAT"))
                {
                    DateTime modification = File.GetLastWriteTime(file);
                    if (modification.Date == today.Date)
                    {
                        var lines = readNCRFile(file, _date.ToString("yyMMdd"));
                        byte[] data = _deflateCompressor.Compress(Encoding.GetEncoding(encodingCode).GetBytes(String.Join("\n", lines)));
                        loadData(data, $"ConLgAll-{today.ToString("yyMMdd")}", _ncrUploadTypeId);
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.Error($"sendLogFile Unexpected processing exception.", ex);
                // Wait a little to prevent high CPU situations
                _cancelSpinEvent.WaitOne(30000);
            }
        }

        private bool checkZet(long storeId, DateTime transactionDate)
        {
            refreshToken();
            var client = new RestClient(_restClientAddress);
            var request = new RestRequest(baseApiRef + "CheckStoreZet/{storeId}/{transactionDate}", Method.GET);
            addHeaders(request);
            request.AddUrlSegment("storeId", storeId.ToString());
            request.AddUrlSegment("transactionDate", transactionDate.ToString("yyyy-MM-dd"));
            bool result = client.Execute<bool>(request).Data;
            return result;
        }

        private void insertTraceLog(string traceText)
        {
            try
            {
                refreshToken();
                var client = new RestClient(_restClientAddress);
                var request = new RestRequest(baseApiRef + "InsertStoreTraceLog/{storeId}/{traceText}", Method.GET);
                addHeaders(request);
                request.AddUrlSegment("storeId", _storeId.ToString());
                request.AddUrlSegment("traceText", traceText);
                client.Execute(request);
            }
            catch
            {
                insertTraceLog("Hata");
            }
        }

        private void sendDay(int dayDiff)
        {
            try
            {
                DateTime y = DateTime.Now.Date.AddDays(dayDiff);

                if (!checkZet(_storeId, y))
                {
                    var lines = readNCRFile(_saleFileFolder, y.ToString("yyMMdd"));
                    byte[] data = _deflateCompressor.Compress(Encoding.GetEncoding(encodingCode).GetBytes(String.Join("\n", lines)));
                    loadData(data, $"ConLgAll-{y.ToString("yyMMdd")}", _ncrUploadTypeId);

                    sendLogFile(y);
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"sendYesterday Unexpected processing exception.", ex);
                _cancelSpinEvent.WaitOne(30000);
            }

        }

        private Boolean sendNCRDay(string sday, string filename)
        {
            var lines = readNCRFile(filename, sday);
            if (lines.Count() > 0)
            {
                byte[] data = _deflateCompressor.Compress(Encoding.GetEncoding(encodingCode).GetBytes(String.Join("\n", lines)));
                loadData(data, $"ConLgAll-{sday}", _ncrUploadTypeId);
                return true;
            } else
            {
                _logger.Debug($"No records found from file : {filename} day : {sday}");
                return false;
            }
        }
        private void sendNCRSaleFile(DateTime day, string saleFilePath1, string saleFilePath2)
        {
            bool sendAdditionalLogs = false;
            string sday = day.ToString("yyMMdd");
            // conlgAll.dat dosyası yeni mi?
            DateTime modification = File.GetLastWriteTime(saleFilePath1);
            TimeSpan dtDiff = (DateTime.Now).Subtract(modification);
            if (dtDiff.Hours < 1)
            {
                _logger.Debug($"NCR File sent from main log file : {saleFilePath1}");
                if (!sendNCRDay(sday, saleFilePath1))
                {
                    sendAdditionalLogs = true;
                }
            }
            else
            {
                sendAdditionalLogs = true;
            }

            if (sendAdditionalLogs)
            {
                foreach (string file in Directory.EnumerateFiles(saleFilePath2, "*.*"))
                {
                    _logger.Debug($"NCR File sent from extra log file : {file}");
                    sendNCRDay(sday, file);
                }
            }

        }

        private DataTable FillTable(String sql, DateTime _date, OleDbConnection conn)
        {
            DataTable table = new DataTable();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("alan1", _date);

            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
            {
                da.Fill(table);
            }

            return table;
        }

        private void sendOldToshibaSaleFiles(string mdbFilePath, string mdwFilePath)
        {
            try
            {
                DateTime y = DateTime.Now.Date;

                bool fileSent = false;
                bool zControl = false;
                do
                {
                    zControl = false;
                    fileSent = false;
                    y = y.AddDays(-1);
                    _logger.Debug($"storeId : {_storeId} _date : {y.ToString("yyyy-MM-dd")}");
                    zControl = checkZet(_storeId, y);
                    if (!zControl)
                    {
                        fileSent = sendToshibaSaleFile(y, mdbFilePath, mdwFilePath);
                    }
                    _logger.Debug($"zControl : {zControl.ToString()} fileSent : {fileSent.ToString()}");

                } while (!zControl && fileSent);

            }
            catch (Exception ex)
            {
                _logger.Error($"sendYesterday Unexpected processing exception.", ex);
                _cancelSpinEvent.WaitOne(30000);
            }
        }

        private string convertAmountString(string value)
        {
            try
            {
                return Convert.ToInt32(decimal.Parse(value) * 100).ToString().PadLeft(12, '0');
            }
            catch (Exception ex)
            {
                _logger.Error($"{value} not able to convert int32");
                return "1".PadLeft(12,'0');
            }
        }

        private bool sendToshibaSaleFile(DateTime transactionDate, string mdbFilePath, string mdwFilePath)
        {
            string myConnectionString = $"Provider=Microsoft.Jet.OLEDB.4.0; Data Source={mdbFilePath}; Jet OLEDB:System Database = {mdwFilePath}; Jet OLEDB:Database Password = P0S2382q; User ID = POS; Password = OzYaMa2001;";
            IList<string> lines = new List<string>();

            using (OleDbConnection conn = new OleDbConnection())
            {
                conn.ConnectionString = myConnectionString;
                conn.Open();

                string vsql = @"SELECT POS_NO, TRANSACTION_DATE, RECEIPT_NO, TRANSACTION_TIME, STORE_NO,
                                       DOCUMENT_TYPE, TRANSACTION_TYPE, SALE_END_TIME, NOF_LINES, 
                                       GROSS_TOTAL, GROSS_TOTAL_VAT, GROSS_DISC_TOTALS, LINE_DISC_TOTALS,
                                       CUSTUMER_NO
                                  FROM TRANSACTION_HEADERS H WHERE H.TRANSACTION_DATE = ?";
                DataTable dt = FillTable(vsql, transactionDate.Date, conn);
                foreach (DataRow dr in dt.Rows)
                {
                    string line = "H";
                    line += dr[0].ToString().PadLeft(6); // POS_NO - 6 {1,6}
                    line += ((DateTime)dr[1]).ToString("yyyyMMdd"); // TRANSACTION_DATE - 8 {7,8}
                    line += dr[2].ToString().PadLeft(6, '0'); // RECEIPT_NO - 6 {15,6}
                    line += dr[3].ToString().PadLeft(6, '0'); // TRANSACTION_TIME - 6 {21,6}
                    line += dr[4].ToString().PadLeft(6, '0'); // STORE_NO - 6 {27,6}
                    line += dr[5].ToString().PadLeft(2, '0'); // DOCUMENT_TYPE - 2 {33,2}
                    line += dr[6].ToString().PadLeft(2, '0'); // TRANSACTION_TYPE - 2 {35,2}
                    line += dr[7].ToString().PadLeft(6, '0'); // SALE_END_TIME - 6 {37,6}
                    line += dr[8].ToString().PadLeft(3, '0'); // NOF_LINES - 3 {43,3}
                    line += convertAmountString(dr[9].ToString()); // GROSS_TOTAL - 12 {46,12}
                    line += convertAmountString(dr[10].ToString()); // GROSS_TOTAL_VAT - 12 {58,12}
                    line += convertAmountString(dr[11].ToString()); // GROSS_DISC_TOTALS - 12 {70,12}
                    line += convertAmountString(dr[12].ToString()); // LINE_DISC_TOTALS - 12 {82,12}
                    line += dr[13].ToString().PadLeft(12, '0'); // CUSTOMER_NO - 13 {94,12}
                    lines.Add(line);
                }

                vsql = @"SELECT POS_NO, TRANSACTION_DATE, RECEIPT_NO, TRANSACTION_TIME, STORE_NO, 
                                DOCUMENT_TYPE, LINE_NUMBER, STOCK_CODE, TRANSACTION_TYPE,
                                VAT_PERCENT, AMOUNT, UNIT, UNIT_PRICE, LINE_TOTAL_VALUE,
                                LINE_TOTAL_VAT, LINE_TOTL_DISCOUNT, STOCK_BARCODE
                           FROM TRANSACTION_LINES L WHERE L.TRANSACTION_DATE = ?";
                dt = FillTable(vsql, transactionDate.Date, conn);
                foreach (DataRow dr in dt.Rows)
                {
                    string line = "L";
                    line += dr[0].ToString().PadLeft(6); // POS_NO - 6
                    line += ((DateTime)dr[1]).ToString("yyyyMMdd"); // TRANSACTION_DATE - 8
                    line += dr[2].ToString().PadLeft(6, '0'); // RECEIPT_NO - 6
                    line += dr[3].ToString().PadLeft(6, '0');  // TRANSACTION_TIME - 6
                    line += dr[4].ToString().PadLeft(6, '0'); // STORE_NO - 6
                    line += dr[5].ToString().PadLeft(2, '0'); // DOCUMENT_TYPE - 2
                    line += dr[6].ToString().PadLeft(3, '0'); // LINE_NUMBER - 3
                    line += dr[7].ToString().PadLeft(6, '0'); // STOCK_CODE - 6
                    line += dr[8].ToString().PadLeft(2, '0'); // TRANSACTION_TYPE - 2
                    line += dr[9].ToString().PadLeft(3, '0'); // VAT_PERCENT - 3
                    line += dr[10].ToString().PadLeft(6, '0'); // AMOUNT - 6
                    line += dr[11].ToString().PadLeft(2, '0'); // UNIT - 2
                    line += convertAmountString(dr[12].ToString()); // UNIT_PRICE - 12
                    line += convertAmountString(dr[13].ToString()); // LINE_TOTAL_VALUE - 12
                    line += convertAmountString(dr[14].ToString()); // LINE_TOTAL_VAT- 12
                    line += convertAmountString(dr[15].ToString()); // LINE_TOTAL_DISC- 12
                    line += dr[16].ToString().PadLeft(20, '0'); // STOCK_BARCODE - 20
                    lines.Add(line);
                }

                vsql = @"SELECT POS_NO, TRANSACTION_DATE, RECEIPT_NO, TRANSACTION_TIME, STORE_NO,
                                LINE_NUMBER, PAYMENT_REF, PAYMENT_REF_DETAIL, PAYMENT_TYPE,
                                PAYMENT_TOTAL, CREDIT_CARD, KEY_USED, CANCELED    
                           FROM TRANSACTION_PAYMENTS P WHERE P.TRANSACTION_DATE = ?";
                dt = FillTable(vsql, transactionDate.Date, conn);
                foreach (DataRow dr in dt.Rows)
                {
                    string line = "P";
                    line += dr[0].ToString().PadLeft(6); // POS_NO - 6 (1)
                    line += ((DateTime)dr[1]).ToString("yyyyMMdd"); // TRANSACTION_DATE - 8 (7)
                    line += dr[2].ToString().PadLeft(6, '0'); // RECEIPT_NO - 6 (15)
                    line += dr[3].ToString().PadLeft(6, '0'); // TRANSACTION_TIME - 6 (21)
                    line += dr[4].ToString().PadLeft(6, '0'); // STORE_NO - 6 (27)
                    line += dr[5].ToString().PadLeft(2, '0'); // LINE_NUMBER - 2 (33)
                    line += dr[6].ToString().PadLeft(2, '0'); // PAYMENT_REF - 2 (35)
                    line += dr[7].ToString().PadLeft(6, '0'); // PAYMENT_REF_DETAIL - 6 (37)
                    line += dr[8].ToString().PadLeft(2, '0'); // PAYMENT_TYPE - 2 (43)
                    line += convertAmountString(dr[9].ToString()); // PAYMENT_TOTAL - 12 (45)
                    line += dr[10].ToString().PadLeft(24); // CREDIT_CARD - 24 (57)
                    line += dr[11].ToString().PadLeft(2, '0'); // KEY_USED - 2 (81)
                    line += (bool)dr[12]?"1":"0"; // CANCELED- 1 (83)
                    lines.Add(line);
                }

                vsql = @"SELECT H.POS_NO, H.TRANSACTION_DATE, H.RECEIPT_NO, H.TRANSACTION_TIME, H.STORE_NO, 
                                D.LINE_NUMBER, D.CODE, D.CARD_NO, D.STOCK_CODE, D.PARAMETER_3
                           FROM TRANSACTION_HEADERS H, TRANSACTION_DISCOUNTS D
                          WHERE H.POS_NO = D.POS_NO AND H.TRANSACTION_DATE = D.TRANSACTION_DATE AND H.RECEIPT_NO = D.RECEIPT_NO
                            AND H.TRANSACTION_DATE = ?
                            AND CUSTUMER_NO <> ''
                            AND CANCELED = FALSE";
                dt = FillTable(vsql, transactionDate.Date, conn);
                foreach (DataRow dr in dt.Rows)
                {
                    string line = "D";
                    line += dr[0].ToString().PadLeft(6); // POS_NO - 6
                    line += ((DateTime)dr[1]).ToString("yyyyMMdd"); // TRANSACTION_DATE - 8
                    line += dr[2].ToString().PadLeft(6, '0'); // RECEIPT_NO - 6
                    line += dr[3].ToString().PadLeft(6, '0');  // TRANSACTION_TIME - 6
                    line += dr[4].ToString().PadLeft(6, '0'); // STORE_NO - 6
                    line += dr[5].ToString().PadLeft(2, '0'); // LINE_NUMBER - 2 (33)
                    line += dr[6].ToString().PadLeft(6, '0'); // CODE - 6 (35)
                    line += dr[7].ToString().PadRight(15, ' '); // CARD_NO - 15 (41)
                    line += dr[8].ToString().PadRight(15, ' '); // STOCK_CODE - 15 (56)
                    line += dr[9].ToString().PadRight(20, ' '); // PARAMETERS - 20 (71)
                    lines.Add(line);
                }

                vsql = @"SELECT Z_NUMBER, STORE_NO, POS_NO, TRANSACTION_DATE, TRANSACTION_TIME, 
                                GROSS_TOTAL, GROSS_TOTAL_VAT, LEGAL_DOCUMENT_COUNT, CANCELLED_DOCUMET_COUNT,  
                                INVOICE_TOTAL, INVOICE_TOTAL_VAT, INVOICE_TOTAL_CANCELLED, LEGAL_INVOICE_COUNT, CANCELLED_INVOICE_COUNT, 
                                RETURN_TOTAL, RETURN_TOTAL_VAT, RETURN_TOTAL_CANCELLED, LEGAL_RETURN_COUNT, 
                                CANCELLED_RETURN_COUNT, DEPARTMENT_TOTAL1, DEPARTMENT_TOTAL2, DEPARTMENT_TOTAL3,
                                DEPARTMENT_TOTAL4, DEPARTMENT_TOTAL5, VAT_TOTAL1, VAT_TOTAL2, VAT_TOTAL3, VAT_TOTAL4, 
                                VAT_TOTAL5, DAILY_TOTAL, DAILY_TOTAL_VAT
                           FROM Z_DETAILS Z WHERE Z.TRANSACTION_DATE = ?";
                dt = FillTable(vsql, transactionDate.Date, conn);
                foreach (DataRow dr in dt.Rows)
                {
                    string line = "Z";
                    line += dr[0].ToString().PadLeft(6, '0'); // Z_NUMBER - 6 (1)
                    line += dr[1].ToString().PadLeft(6, '0'); // STORE_NO - 6 (7)
                    line += dr[2].ToString().PadLeft(6); // POS_NO - 6 (13)
                    line += ((DateTime)dr[3]).ToString("yyyyMMdd"); // TRANSACTION_DATE - 8 (21)
                    line += dr[4].ToString().PadLeft(6, '0');  // TRANSACTION_TIME - 6 (27)
                    line += convertAmountString(dr[5].ToString()); // GROSS_TOTAL - 12 (33)
                    line += convertAmountString(dr[6].ToString()); // GROSS_TOTAL_VAT - 12 (45)
                    line += dr[7].ToString().PadLeft(6, '0'); // LEGAL_DOCUMENT_COUNT - 6 (57)
                    line += dr[8].ToString().PadLeft(6, '0'); // CANCELLED_DOCUMENT_COUNT - 6 (63)
                    line += convertAmountString(dr[9].ToString()); // INVOICE_TOTAL - 12 (69)
                    line += convertAmountString(dr[10].ToString()); // INVOICE_TOTAL_VAT - 12 (81)
                    line += convertAmountString(dr[11].ToString()); // INVOICE_TOTAL_CANCELLED - 12 (93)
                    line += dr[12].ToString().PadLeft(6, '0'); // LEGAL_INVOICE_COUNT - 6 (105)
                    line += dr[13].ToString().PadLeft(6, '0'); // CANCELLED_INVOICE_COUNT - 6 (111)
                    line += convertAmountString(dr[14].ToString()); // RETURN_TOTAL - 12 (117)
                    line += convertAmountString(dr[15].ToString()); // RETURN_TOTAL_VAT - 12 (129)
                    line += convertAmountString(dr[16].ToString()); // RETURN_TOTAL_CANCELLED - 12 (141)
                    line += dr[17].ToString().PadLeft(6, '0'); // LEGAL_RETURN_COUNT - 6 (153)
                    line += dr[18].ToString().PadLeft(6, '0'); // CANCELLED_RETURN_COUNT - 6 (159)
                    int dt1 = Convert.ToInt32(decimal.Parse(dr[19].ToString()) * 100);
                    int dt2 = Convert.ToInt32(decimal.Parse(dr[20].ToString()) * 100);
                    int dt3 = Convert.ToInt32(decimal.Parse(dr[21].ToString()) * 100);
                    int dt4 = Convert.ToInt32(decimal.Parse(dr[22].ToString()) * 100);
                    int dt5 = Convert.ToInt32(decimal.Parse(dr[23].ToString()) * 100);
                    line += (dt1+dt2+dt3+dt4+dt5).ToString().PadLeft(12, '0'); // TOTAL OF DEP TOTALS - 12 (165)
                    line += convertAmountString(dr[29].ToString()); // DAILY_TOTAL - 12 (177)
                    lines.Add(line);
                }

                conn.Close();

                
            }

            if (lines.Count > 0)
            {
                byte[] data = _deflateCompressor.Compress(Encoding.GetEncoding(encodingCode).GetBytes(String.Join("\n", lines)));
                loadData(data, $"Genius-{transactionDate.ToString("yyMMdd")}", _toshibaUploadTypeId);
                return true;
            }
            else
                return false;
            
        }

        private bool sendToshibaCancelFile(string mdbFilePath, string mdwFilePath)
        {
            try
            {
                // if (_storeId == 122) { insertTraceLog($"sendToshibaCancelFile Started mdbFilePath : {mdbFilePath} mdwFilePath : {mdwFilePath}"); }
                // if (_storeId == 122) { insertTraceLog("1"); }
                string myConnectionString = $"Provider=Microsoft.Jet.OLEDB.4.0; Data Source={mdbFilePath}; Jet OLEDB:System Database = {mdwFilePath}; Jet OLEDB:Database Password = P0S2382q; User ID = POS; Password = OzYaMa2001;";
                // if (_storeId == 122) { insertTraceLog("1-1"); }
                IList<string> lines = new List<string>();

                DateTime startDate = new DateTime(2019, 1, 1);

                using (OleDbConnection conn = new OleDbConnection())
                {
                    // if (_storeId == 122) { insertTraceLog("1-2"); }
                    conn.ConnectionString = myConnectionString;
                    conn.Open();

                    // if (_storeId == 122) { insertTraceLog("1-3"); }
                    string vsql = @"SELECT POS_NO, TRANSACTION_DATE, RECEIPT_NO, TRANSACTION_TIME, STORE_NO,
                                           DOCUMENT_TYPE, TRANSACTION_TYPE, SALE_END_TIME, NOF_LINES, 
                                           GROSS_TOTAL, GROSS_TOTAL_VAT, GROSS_DISC_TOTALS, LINE_DISC_TOTALS,
                                           CUSTUMER_NO
                                      FROM C_TRANSACTION_HEADERS H WHERE H.TRANSACTION_DATE >= ?";
                    DataTable dt = FillTable(vsql, startDate.Date, conn);
                    // if (_storeId == 122) { insertTraceLog($"cancel header rows read, rowcount : {dt.Rows.Count.ToString()}"); }
                    // if (_storeId == 122) { insertTraceLog("2"+ dt.Rows.Count.ToString()); }
                    foreach (DataRow dr in dt.Rows)
                    {
                        string line = "H";  
                        line += dr[0].ToString().PadLeft(6); // POS_NO - 6 {1,6}
                        line += ((DateTime)dr[1]).ToString("yyyyMMdd"); // TRANSACTION_DATE - 8 {7,8}
                        line += dr[2].ToString().PadLeft(6, '0'); // RECEIPT_NO - 6 {15,6}
                        line += dr[3].ToString().PadLeft(6, '0'); // TRANSACTION_TIME - 6 {21,6}
                        line += dr[4].ToString().PadLeft(6, '0'); // STORE_NO - 6 {27,6}
                        line += dr[5].ToString().PadLeft(2, '0'); // DOCUMENT_TYPE - 2 {33,2}
                        line += dr[6].ToString().PadLeft(2, '0'); // TRANSACTION_TYPE - 2 {35,2}
                        line += dr[7].ToString().PadLeft(6, '0'); // SALE_END_TIME - 6 {37,6}
                        line += dr[8].ToString().PadLeft(3, '0'); // NOF_LINES - 3 {43,3}
                        line += convertAmountString(dr[9].ToString()); // {46,12}
                        line += convertAmountString(dr[10].ToString()); // {58,12}
                        line += convertAmountString(dr[11].ToString()); // {70,12}
                        line += convertAmountString(dr[12].ToString()); // {82,12}
                        line += dr[13].ToString().PadLeft(12, '0'); // CUSTOMER_NO - 13 {94,12}
                        
                        lines.Add(line);
                    }

                    vsql = @"SELECT POS_NO, TRANSACTION_DATE, RECEIPT_NO, TRANSACTION_TIME, STORE_NO, 
                                    DOCUMENT_TYPE, LINE_NUMBER, STOCK_CODE, TRANSACTION_TYPE,
                                    VAT_PERCENT, AMOUNT, UNIT, UNIT_PRICE, LINE_TOTAL_VALUE,
                                    LINE_TOTAL_VAT, LINE_TOTL_DISCOUNT, STOCK_BARCODE
                               FROM C_TRANSACTION_LINES L WHERE L.TRANSACTION_DATE >= ?";
                    dt = FillTable(vsql, startDate.Date, conn);
                    // if (_storeId == 122) { insertTraceLog($"cancel lines read, rowcount : {dt.Rows.Count.ToString()}"); }
                    // if (_storeId == 122) { insertTraceLog("3"); }
                    foreach (DataRow dr in dt.Rows)
                    {
                        string line = "L";
                        line += dr[0].ToString().PadLeft(6); // POS_NO - 6
                        line += ((DateTime)dr[1]).ToString("yyyyMMdd"); // TRANSACTION_DATE - 8
                        line += dr[2].ToString().PadLeft(6, '0'); // RECEIPT_NO - 6
                        line += dr[3].ToString().PadLeft(6, '0');  // TRANSACTION_TIME - 6
                        line += dr[4].ToString().PadLeft(6, '0'); // STORE_NO - 6
                        line += dr[5].ToString().PadLeft(2, '0'); // DOCUMENT_TYPE - 2
                        line += dr[6].ToString().PadLeft(3, '0'); // LINE_NUMBER - 3
                        line += dr[7].ToString().PadLeft(6, '0'); // STOCK_CODE - 6
                        line += dr[8].ToString().PadLeft(2, '0'); // TRANSACTION_TYPE - 2
                        line += dr[9].ToString().PadLeft(3, '0'); // VAT_PERCENT - 3
                        line += dr[10].ToString().PadLeft(6, '0'); // AMOUNT - 6
                        line += dr[11].ToString().PadLeft(2, '0'); // UNIT - 2
                        line += convertAmountString(dr[12].ToString()); // Convert.ToInt32(decimal.Parse(dr[12].ToString()) * 100).ToString().PadLeft(12, '0'); // UNIT_PRICE - 12
                        line += convertAmountString(dr[13].ToString()); // Convert.ToInt32(decimal.Parse(dr[13].ToString()) * 100).ToString().PadLeft(12, '0'); // LINE_TOTAL_VALUE - 12
                        line += convertAmountString(dr[14].ToString()); // Convert.ToInt32(decimal.Parse(dr[14].ToString()) * 100).ToString().PadLeft(12, '0'); // LINE_TOTAL_VAT- 12
                        line += convertAmountString(dr[15].ToString()); // Convert.ToInt32(decimal.Parse(dr[15].ToString()) * 100).ToString().PadLeft(12, '0'); // LINE_TOTAL_DISC- 12
                        line += dr[16].ToString().PadLeft(20, '0'); // STOCK_BARCODE - 20
                        lines.Add(line);
                    }

                    vsql = @"SELECT POS_NO, TRANSACTION_DATE, RECEIPT_NO, TRANSACTION_TIME, STORE_NO,
                                    LINE_NUMBER, PAYMENT_REF, PAYMENT_REF_DETAIL, PAYMENT_TYPE,
                                    PAYMENT_TOTAL, CREDIT_CARD, KEY_USED, CANCELED    
                               FROM C_TRANSACTION_PAYMENTS P WHERE P.TRANSACTION_DATE >= ?";
                    dt = FillTable(vsql, startDate.Date, conn);
                    // if (_storeId == 122) { insertTraceLog($"cancel payments read, rowcount : {dt.Rows.Count.ToString()}"); }
                    // if (_storeId == 122) { insertTraceLog("4"); }
                    foreach (DataRow dr in dt.Rows)
                    {
                        string line = "P";
                        line += dr[0].ToString().PadLeft(6); // POS_NO - 6 (1)
                        line += ((DateTime)dr[1]).ToString("yyyyMMdd"); // TRANSACTION_DATE - 8 (7)
                        line += dr[2].ToString().PadLeft(6, '0'); // RECEIPT_NO - 6 (15)
                        line += dr[3].ToString().PadLeft(6, '0'); // TRANSACTION_TIME - 6 (21)
                        line += dr[4].ToString().PadLeft(6, '0'); // STORE_NO - 6 (27)
                        line += dr[5].ToString().PadLeft(2, '0'); // LINE_NUMBER - 2 (33)
                        line += dr[6].ToString().PadLeft(2, '0'); // PAYMENT_REF - 2 (35)
                        line += dr[7].ToString().PadLeft(6, '0'); // PAYMENT_REF_DETAIL - 6 (37)
                        line += dr[8].ToString().PadLeft(2, '0'); // PAYMENT_TYPE - 2 (43)
                        line += convertAmountString(dr[9].ToString()); // Convert.ToInt32(decimal.Parse(dr[9].ToString()) * 100).ToString().PadLeft(12, '0'); // PAYMENT_TOTAL - 12 (45)
                        line += dr[10].ToString().PadLeft(24); // CREDIT_CARD - 24 (57)
                        line += dr[11].ToString().PadLeft(2, '0'); // KEY_USED - 2 (81)
                        line += (bool)dr[12] ? "1" : "0"; // CANCELED- 1 (83)
                        lines.Add(line);
                    }

                    conn.Close();


                }

                // if (_storeId == 122) { insertTraceLog($"cancel read ended lines.Count : {lines.Count.ToString()}"); }
                if (lines.Count > 0)
                {
                    byte[] data = _deflateCompressor.Compress(Encoding.GetEncoding(encodingCode).GetBytes(String.Join("\n", lines)));
                    loadData(data, $"GeniusCancelled-{DateTime.Now.ToString("yyMMddHHmmss")}", _toshibaCancelledTypeId);
                    // if (_storeId == 122) { insertTraceLog($"data loaded"); }
                    return true;
                }
                else
                    return false;
            } catch (Exception ex)
            {
                // if (_storeId == 122) { insertTraceLog("hata " + ex.Message.Left(100) ); }
                return false;
            }
        }

        private void sendSaleFile()
        {
            getMissingDays();
            // if (_storeId == 122) { insertTraceLog("missingdays okundu"); }
            _logger.Debug($"missing days found : {_missingDays.Count()}");

            foreach (var r in _missingDays)
            {
                _logger.Debug($"Day : {r.MissingDay.ToString("yyyy-MM-dd")}, BrandName : {r.CashRegisterType}");
                switch (r.CashRegisterType)
                {
                    case "NCR":
                        sendNCRSaleFile(r.MissingDay, r.SaleFilePath1, r.SaleFilePath2);
                        break;
                    case "Toshiba":
                        sendToshibaSaleFile(r.MissingDay, r.SaleFilePath1, r.SaleFilePath2);
                        // if (_storeId == 122) { insertTraceLog("sendToshibaSaleFile"); }
                        break;
                }
            }


            if (_missingDays.Count() > 0)
            {
                // if (_storeId == 122) { insertTraceLog("missingdayscount > 0"); }
                StoreMissingDays firstRow = _missingDays.First();
                
                // if (_storeId == 122) { insertTraceLog(firstRow.CashRegisterType); }

                switch (firstRow.CashRegisterType)
                {
                    case "NCR":
                        sendAdditionalFile(1);
                        break;
                    case "Toshiba":
                        // sendAdditionalFile(3);
                        _logger.Debug($"Toshiba cancel file started : {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                        sendToshibaCancelFile(firstRow.SaleFilePath1, firstRow.SaleFilePath2);
                        // if (_storeId == 122) { insertTraceLog("sendToshibaCancelFile"); }
                        _logger.Debug($"Toshiba cancel file ended : {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                        break;

                }
                
            }

        }

        public override bool TryFetchItem(out object item)
        {
            try
            {
                _logger.Debug($"Process started : {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");

                sendSaleFile();

            }
            catch (Exception ex)
            {
                _logger.Error($"Unexpected processing exception.", ex);
                _cancelSpinEvent.WaitOne(30000);
            }

            item = null;
            return false;
        }

        public override void ProcessItem(object item)
        {
            throw new NotSupportedException("Processing is not supported by this worker.");
        }
    }
}
