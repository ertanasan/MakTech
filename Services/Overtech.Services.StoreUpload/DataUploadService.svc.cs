// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Core.Application;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.StoreUpload;
using Overtech.ServiceContracts.StoreUpload;
using Overtech.Mutual.DocumentManagement;
using Overtech.Core.DependencyInjection;
using Overtech.ServiceContracts.Document;
using Overtech.Core.Compression;
using Overtech.DataModels.Document;
using System.Text;
using System.Globalization;
using Overtech.DataModels.Sale;
using Overtech.Mutual.Parameter;
using Overtech.DataModels.Product;
using Overtech.Core.OverStore;
using System.IO;
using Overtech.Core.Logger;
using System.ComponentModel;
using Overtech.DataModels.Store;
using System.Data;


/*Section="ClassHeader"*/
namespace Overtech.Services.StoreUpload
{

    public class ZetReport
    {
        public int zetNo { get; set; }
        public DateTime transactionDate { get; set; }
        public int store { get; set; }
        public int cashRegister { get; set; }
        public int receiptCount { get; set; }
        public decimal totalAmount { get; set; }
        public int refundCount { get; set; }
        public decimal refundAmount { get; set; }
        public decimal cashAmount { get; set; }
        public decimal cardAmount { get; set; }
        public decimal slpAmount { get; set; }
        public int slpCount { get; set; }
    }

    public class _salePayment
    {
        public string paymentType { get; set; }
        public decimal paid { get; set; }
        public decimal cardAmount { get; set; }
        public decimal refund { get; set; }
        public int bankType { get; set; }
        public int trxType { get; set; }
        public string accountNo { get; set; }
        public bool isDebit { get; set; }
    }

    public class SaleItem
    {
        public string itemCode { get; set; }
        public int vatCode { get; set; }
        public int vatRate { get; set; }
        public decimal price { get; set; }
        public bool isCancelled { get; set; }
        public bool weighedProduct { get; set; }
        public decimal salePrice { get; set; }
        public int unit { get; set; }
        public decimal quantity { get; set; }
        public string stockCode { get; set; }
    }

    public class Sale
    {
        public string tranNo { get; set; }
        public int storeNo { get; set; }
        public int termNo { get; set; }
        public int tranType { get; set; }
        public DateTime tranTime { get; set; }
        public decimal total { get; set; }
        public decimal itemDisc { get; set; }
        public decimal totalDisc { get; set; }
        public int totalTime { get; set; }
        public int numItems { get; set; }
        public bool isCancelled { get; set; }
        public string cashier { get; set; }
        public string InvoiceNo { get; set; }
        public string CustomerNo { get; set; }

        public _salePayment salePayment { get; set; }
        public IList<SaleItem> soldItems { get; set; }
        public IList<String> rawData { get; set; }
        public _saleCustomer saleCustomer { get; set; }

    }

    public class _saleCustomer
    {
        public Boolean eInvoice { get; set; }
        public string customerName { get; set; }
        public string addressText { get; set; }
        public string taxCenterName { get; set; }
        public string identityNo { get; set; }
        public string eMail { get; set; }
        public string phoneNumber { get; set; }
        public string fiscalSerial { get; set; }
        public int eInvoiceZetNo { get; set; }
        public int eInvoiceReceiptNo { get; set; }
    }

    [OTInspectorBehavior]
    public class DataUploadService : CRUDLDataService<Overtech.DataModels.StoreUpload.DataUpload>, IDataUploadService
    {
        private readonly IOTResolver _resolver;
        private readonly IDeflateCompressor _deflateCompressor;
        private readonly IParameterReader _parameterReader;
        private IList<ZetReport> _zetReport;
        private long _dataUploadId;

        public object OTApplication { get; private set; }

        /*Section="Constructor-1"*/
        private ILogger _logger;
        public DataUploadService(
            IOTResolver resolver,
            IDeflateCompressor deflateCompressor,
            IParameterReader parameterReader,
            ILoggerFactory loggerFactory)
        {
            _resolver = resolver;
            _deflateCompressor = deflateCompressor;
            _parameterReader = parameterReader;
            _logger = loggerFactory.GetLogger(typeof(DataUploadService));
        }

        /*Section="Constructor-2"*/
        internal DataUploadService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.

        public override DataUpload Create(DataUpload dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    DocumentOperations documentOperations = new DocumentOperations(dal, _resolver);
                    var documentType = documentOperations.ReadDocumentTypeByName("CashRegisterData");

                    dataObject.Document = documentOperations.CreateDocument(dataObject.Organization, dataObject.Event, null, null, documentType.DocumentTypeId,
                        $"{dataObject.SourceRef}_{DateTime.Now}", documentType.Extention, _deflateCompressor.Decompress(dataObject.CompressedData));

                    dataObject.DataUploadId = dal.Create(dataObject);

                    dal.CommitTransaction();

                    return dataObject;
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public IEnumerable<DataUpload> ListNewToProcess()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.List<DataUpload>("SUP_LST_NEWTOPROCESS_SP").ToList();
            }
        }

        public IEnumerable<StoreMissingDays> GetMissingDays(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                return dal.List<StoreMissingDays>("SUP_LST_STOREMISSINGDAYS_SP", prmStoreId).ToList();
            }
        }

        private void processLineH(Sale s, string line)
        {
            s.tranNo = line.Substring(1, 5).Trim() + "-" + line.Substring(6, 3).Trim() + "-" + line.Substring(26, 12) + "-" + line.Substring(9, 6);
            s.storeNo = int.Parse(line.Substring(1, 5).Trim());
            s.termNo = int.Parse(line.Substring(6, 3).Trim());
            s.cashier = line.Substring(15, 8).Trim();
            s.tranType = int.Parse(line.Substring(23, 2).Trim());
            s.tranTime = DateTime.ParseExact("20" + line.Substring(26, 6) + line.Substring(32, 6), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            s.total = decimal.Parse(line.Substring(42, 13)) / 100;
            s.isCancelled = (line.Substring(55, 1) == "1");
            
        }

        private void processLineB(Sale s, string line)
        {
            s.itemDisc = decimal.Parse(line.Substring(1, 13)) / 100;
            s.totalDisc = decimal.Parse(line.Substring(14, 13)) / 100;
            s.totalTime = int.Parse(line.Substring(31, 3));
            s.numItems = int.Parse(line.Substring(37, 4));
            s.InvoiceNo = line.Substring(63, 10);
            s.CustomerNo = line.Substring(47, 16);
        }

        private void processLineS(SaleItem si, string line)
        {
            si.itemCode = line.Substring(1, 20);
            si.vatCode = int.Parse(line.Substring(21, 2));
            si.vatRate = int.Parse(line.Substring(23, 4)) / 100;
            si.price = decimal.Parse(line.Substring(39, 13)) / 100;
            si.isCancelled = (line.Substring(55, 1) == "1");
            si.weighedProduct = (line.Substring(57, 1) == "1");
        }

        private void processLineE(SaleItem si, string line)
        {
            si.salePrice = decimal.Parse(line.Substring(1, 13)) / 100;
            si.unit = int.Parse(line.Substring(14, 1));
            si.quantity = decimal.Parse(line.Substring(15, 6));
            si.stockCode = line.Substring(49, 20).Trim();

        }

        private void processLineZ(string line, int store, int cashRegister, DateTime transactionDate)
        {
            ZetReport z = new ZetReport();
            if (store != 0)
            {
                z.cashRegister = cashRegister;
                z.transactionDate = transactionDate;
                z.store = store;
                z.zetNo = int.Parse(line.Substring(66, 5));
                z.totalAmount = decimal.Parse(line.Substring(1, 9)) / 100;
                z.receiptCount = int.Parse(line.Substring(10, 4));
                z.refundAmount = decimal.Parse(line.Substring(53, 9)) / 100;
                z.refundCount = int.Parse(line.Substring(62, 4));
                z.slpAmount = decimal.Parse(line.Substring(14, 9)) / 100;
                z.slpCount = int.Parse(line.Substring(23, 4));
                _zetReport.Add(z);
            }
        }

        private void processLineP(_salePayment sp, string line)
        {

            bool isCancelled = (line.Substring(56, 1) == "1");
            bool isPayment = (line.Substring(16, 3) == "000");

            if (isPayment && !isCancelled)
            {
                sp.paymentType = line.Substring(1, 2);

                bool isRefund = (line.Substring(59, 1) == "1");
                if (!isRefund)
                {
                    if (sp.paymentType == "00") // nakit
                        sp.paid = sp.paid + decimal.Parse(line.Substring(3, 13)) / 100;
                    else // kredi kartı
                        sp.cardAmount = sp.cardAmount + decimal.Parse(line.Substring(3, 13)) / 100;
                }
                else
                {
                    sp.refund = decimal.Parse(line.Substring(3, 13)) / 100;
                }
                sp.accountNo = line.Substring(32, 24).Trim();
            }
            
        }

        private void processLinep(_salePayment sp, string line)
        {
            sp.bankType = int.Parse(line.Substring(1, 2));
            sp.trxType = int.Parse(line.Substring(3, 1));
            sp.isDebit = (line.Substring(8, 1) == "1");
            // sp.paymentType = "1"; // p satırı gelmişse pos'dan ödemedir. 
        }

        private void processLinee(_saleCustomer sc, string line)
        {
            sc.eInvoice = true;
            sc.fiscalSerial = line.Substring(1, 20).Trim();
            sc.eInvoiceZetNo = int.Parse(line.Substring(21, 4).Trim());
            sc.eInvoiceReceiptNo = int.Parse(line.Substring(25, 4).Trim());
            sc.identityNo = line.Substring(29, 11).Trim();
        }

        private void processLineC(_saleCustomer sc, string line)
        {
            sc.customerName= line.Substring(17, 20).Trim()+" "+ line.Substring(37, 20).Trim();
            sc.addressText = line.Substring(57, 20).Trim();
        }

        private void processLineM(_saleCustomer sc, string line)
        {
            sc.addressText += " " + line.Substring(1, 20).Trim();
            sc.addressText += " " + line.Substring(21, 20).Trim();
            sc.taxCenterName = line.Substring(41, 20).Trim();
            sc.identityNo = line.Substring(61, 11).Trim();
        }

        private void processLinec(_saleCustomer sc, string line)
        {
            sc.eMail = line.Substring(1, 40).Trim();
            sc.phoneNumber = line.Substring(41, 10).Trim();
        }

        private void processLineR(_saleCustomer sc, string line)
        {
            switch (line.Substring(76,2))
            {
                case "1E": if (!sc.eInvoice) sc.eInvoice = false;
                           sc.customerName = line.Substring(21, 40).Trim(); break;
                case "2E": sc.identityNo = line.Substring(1, 11).Trim();
                           sc.taxCenterName = line.Substring(15, 25).Trim(); 
                           sc.fiscalSerial = line.Substring(40, 36); break;
                case "3E": sc.phoneNumber = line.Substring(1, 15).Trim();
                           sc.eMail = line.Substring(16, 40).Trim(); break;
                case "8E": sc.eInvoiceReceiptNo = int.Parse(line.Substring(1, 4)); break;
            }
        }

        private IList<Sale> processNCRText(string text)
        {
            string currentLine="";
            try
            {
                IList<Sale> sales = new List<Sale>();
                Sale s = new Sale();
                s.soldItems = new List<SaleItem>();
                SaleItem si = new SaleItem();
                _zetReport = new List<ZetReport>();
                int zetCashRegisterId = 0, zetStoreId = 0;
                Boolean saleAdded = true;
                DateTime zetTransactionDate = DateTime.Now.Date;

                string[] lines = text.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    currentLine = line;

                    string vRecType = line.Substring(0, 1);

                    switch (vRecType)
                    {
                        case "H":
                            if (!saleAdded && s.tranNo != null)
                            {
                                sales.Add(s);
                                saleAdded = true;
                            }
                            string vTranType = line.Substring(23, 2);
                            if (vTranType == "01" || vTranType == "02" || vTranType == "03" || vTranType == "04" || vTranType == "05")
                            {
                                s = new Sale();
                                saleAdded = false ;
                                s.soldItems = new List<SaleItem>();
                                s.rawData = new List<String>();
                                s.salePayment = new _salePayment();
                                s.rawData.Add(line);
                                processLineH(s, line);
                            }
                            else if (vTranType == "84" || vTranType == "80") // Kapanış veya Z Report
                            {
                                // get cashregister, store and transaction date in order to process Z line.
                                zetStoreId = int.Parse(line.Substring(1, 5).Trim());
                                zetCashRegisterId = int.Parse(line.Substring(6, 3).Trim());
                                zetTransactionDate = DateTime.ParseExact("20" + line.Substring(26, 6) + line.Substring(32, 6), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                            }
                            break;
                        case "B":
                            s.rawData.Add(line);
                            processLineB(s, line);
                            break;
                        case "S":
                            si = new SaleItem();
                            processLineS(si, line);
                            s.rawData.Add(line);
                            break;
                        case "E":
                            processLineE(si, line);
                            s.soldItems.Add(si);
                            s.rawData.Add(line);
                            break;
                        case "P":
                            if (s != null && s.salePayment != null)
                            {
                                processLineP(s.salePayment, line);
                                s.rawData.Add(line);
                            }
                            break;
                        case "p":
                            processLinep(s.salePayment, line);
                            s.rawData.Add(line);
                            break;
                        case "V":
                            s.rawData.Add(line);
                            break;
                        case "Z":
                            processLineZ(line, zetStoreId, zetCashRegisterId, zetTransactionDate);
                            break;
                        case "e":
                            if (s.saleCustomer == null) { s.saleCustomer = new _saleCustomer(); }
                            processLinee(s.saleCustomer, line);
                            s.rawData.Add(line);
                            break;
                        case "C":
                            if (s.saleCustomer == null) { s.saleCustomer = new _saleCustomer(); }
                            processLineC(s.saleCustomer, line);
                            s.rawData.Add(line);
                            break;
                        case "M":
                            if (s.saleCustomer == null) { s.saleCustomer = new _saleCustomer(); }
                            processLineM(s.saleCustomer, line);
                            s.rawData.Add(line);
                            break;
                        case "c":
                            if (s.saleCustomer == null) { s.saleCustomer = new _saleCustomer(); }
                            processLinec(s.saleCustomer, line);
                            s.rawData.Add(line);
                            break;
                        case "R":
                            if (s.saleCustomer == null) { s.saleCustomer = new _saleCustomer(); }
                            processLineR(s.saleCustomer, line);
                            s.rawData.Add(line);
                            break;
                        default:
                            if (s != null && s.rawData != null && s.soldItems != null && s.salePayment != null) s.rawData.Add(line);
                            break;
                    }


                }
                if (!saleAdded && s.tranNo != null)
                {
                    sales.Add(s);
                    saleAdded = true;
                }

                return sales;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                _logger.Error($"DataUploadId : {_dataUploadId} Current Line : {currentLine}");
                //_logger.Error(text);
                throw ex;
            }
            
            

        }

        private DataTable getToshibaCustomerData (long identityNo)
        {
            IDAL tdal = new DAL();
            IUniParameter prmIdentityNo = tdal.CreateParameter("IdentityNo", identityNo.ToString());
            return tdal.ExecuteDataset("IBM_SEL_IDENTITYINFO_SP", prmIdentityNo).Tables[0];
        }

        private void processToshibaLineH(Sale s, string line)
        {
            s.tranNo = line.Substring(27, 6).TrimStart('0') + "-" + line.Substring(1, 6).Trim() + "-" + line.Substring(9, 6) + line.Substring(21, 6) + "-" + line.Substring(15, 6).Trim('0');
            s.storeNo = int.Parse(line.Substring(27, 6).TrimStart('0'));
            s.termNo = int.Parse(line.Substring(1, 6));
            switch (int.Parse(line.Substring(33, 2).Trim()))
            {
                case 0: s.tranType = 1; break;
                case 1: s.tranType = 2; break;
                case 2: s.tranType = 5; break;
                case 3: s.tranType = 4; break;
                case 4: s.tranType = 3; break;
            }
            s.tranTime = DateTime.ParseExact(line.Substring(7, 8) + line.Substring(21, 6), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            s.total = decimal.Parse(line.Substring(46, 12)) / 100;
            if (s.tranType == 5) s.total = -1 * s.total;
            s.isCancelled = false; //  (int.Parse(line.Substring(35, 2).Trim()) == 1);

            s.itemDisc = decimal.Parse(line.Substring(82, 12)) / 100;
            s.totalDisc = decimal.Parse(line.Substring(70, 12)) / 100;
            s.totalTime = int.Parse(line.Substring(37, 6));
            s.numItems = int.Parse(line.Substring(43, 3));

            try
            {
                long identityNo = long.Parse(line.Substring(94, 12));
                if (identityNo > 0)
                {
                    // _logger.Debug($"Toshiba new identityNo : {identityNo} totalamount : {s.total}");
                    s.saleCustomer = new _saleCustomer();
                    s.saleCustomer.eInvoice = (s.tranType == 3);
                    s.saleCustomer.identityNo = identityNo.ToString();
                    /*
                    
                    DataTable dt = getToshibaCustomerData(identityNo);
                    if (dt.Rows.Count > 0)
                    {
                        // _logger.Debug($"processToshibaLineH : {identityNo}");
                        DataRow dr = dt.Rows[0];
                        s.saleCustomer = new _saleCustomer();
                        s.saleCustomer.eInvoice = (s.tranType == 3);
                        s.saleCustomer.customerName = dr["CUSTOMER_NM"].ToString();
                        s.saleCustomer.addressText = dr["ADDRESS_TXT"].ToString();
                        s.saleCustomer.taxCenterName = dr["TAX_OFFICE"].ToString();
                        s.saleCustomer.identityNo = identityNo.ToString();
                        s.saleCustomer.eMail = dr["ALIAS_DSC"].ToString();
                        s.saleCustomer.phoneNumber = dr["TEL_NO"].ToString();
                    }
                    */
                }
            }
            catch { }
        }

        private void processToshibaLineL(IList<Sale> sales, string line)
        {
            string key = line.Substring(27, 6).TrimStart('0') + "-" + line.Substring(1, 6).Trim() + "-" + line.Substring(9, 6) + line.Substring(21, 6) + "-" + line.Substring(15, 6).Trim('0');
            foreach (Sale s in sales)
            {
                if (s.tranNo == key)
                {
                    if (s.soldItems == null)
                        s.soldItems = new List<SaleItem>();
                    SaleItem si = new SaleItem();

                    si.itemCode = line.Substring(105, 20);
                    si.vatRate = int.Parse(line.Substring(46, 3));
                    si.price = decimal.Parse(line.Substring(69, 12)) / 100;
                    si.isCancelled = (int.Parse(line.Substring(44, 2).ToString()) == 1);
                    si.weighedProduct = (int.Parse(line.Substring(55, 2).ToString()) == 1);

                    si.salePrice = decimal.Parse(line.Substring(57, 12)) / 100;
                    si.unit = si.weighedProduct?1:2;
                    si.quantity = decimal.Parse(line.Substring(49, 6));
                    si.stockCode = line.Substring(38, 6).Trim();

                    s.soldItems.Add(si);
                }
            }
        }

        private void processToshibaLineD(IList<Sale> sales, string line)
        {
            // store - pos - transactiondate(ilk 2 basamak haric) - transactiontime - receiptno
            string key = line.Substring(27, 6).TrimStart('0') + "-" + line.Substring(1, 6).Trim() + "-" + line.Substring(9, 6) + line.Substring(21, 6) + "-" + line.Substring(15, 6).Trim('0');
            foreach (Sale s in sales)
            {
                if (s.tranNo == key)
                {
                    
                    if (s.saleCustomer == null)
                        s.saleCustomer = new _saleCustomer();

                    int code = int.Parse(line.Substring(35, 6));
                    switch (code)
                    {
                        case 2101:
                            // _logger.Debug($"Toshiba customerName: {line.Substring(71, 20).Trim()} identity No : {s.saleCustomer.identityNo} totalamount : {s.total}");
                            s.saleCustomer.customerName = line.Substring(71, 20).Trim(); 
                            break;
                        case 2102: s.saleCustomer.taxCenterName = line.Substring(71, 20).Trim(); break;
                        case 2104: 
                            if (s.saleCustomer.addressText != null && s.saleCustomer.addressText.Length > 0) s.saleCustomer.addressText += " " + line.Substring(71, 20).Trim();
                            else s.saleCustomer.addressText = line.Substring(71, 20).Trim(); 
                            break;
                        case 2108:
                            if (s.saleCustomer.addressText != null && s.saleCustomer.addressText.Length > 0) s.saleCustomer.addressText += " " + line.Substring(71, 20).Trim();
                            else s.saleCustomer.addressText = line.Substring(71, 20).Trim();
                            break;
                        case 2107:
                            if (s.saleCustomer.addressText != null && s.saleCustomer.addressText.Length > 0) s.saleCustomer.addressText += " " + line.Substring(71, 20).Trim();
                            else s.saleCustomer.addressText = line.Substring(71, 20).Trim();
                            break;
                        case 2110: s.saleCustomer.phoneNumber = line.Substring(71, 20).Trim(); break;
                    }
                }
            }
        }


        private void processToshibaLineP(IList<Sale> sales, string line)
        {
            string key = line.Substring(27, 6).TrimStart('0') + "-" + line.Substring(1, 6).Trim() + "-" + line.Substring(9, 6) + line.Substring(21, 6) + "-" + line.Substring(15, 6).Trim('0');
            foreach (Sale s in sales)
            {
                if (s.tranNo == key)
                {
                    if (s.salePayment == null)
                        s.salePayment = new _salePayment();

                    bool creditcard = (line.Substring(57, 24).Trim().Length > 1);

                    s.salePayment.paymentType = creditcard?"01":"00";

                    bool isRefund = (int.Parse(line.Substring(43, 2)) == 1);
                    decimal amount = decimal.Parse(line.Substring(45, 12)) / 100;
                    if (s.tranType == 5) amount = -1 * amount; // iade ise
                    if (line.Substring(83, 1) == "1") amount = -1 * amount; // payment cancel ise

                    if (!isRefund)
                    {
                        if (!creditcard) // nakit
                            s.salePayment.paid = s.salePayment.paid + amount;
                        else // kredi kartı
                            s.salePayment.cardAmount = s.salePayment.cardAmount + amount;
                    }
                    else
                    {
                        s.salePayment.refund = amount;
                    }
                    if (line.Substring(57, 24).Trim().Length > 0)
                        s.salePayment.accountNo = line.Substring(57, 24).Trim();
                }
            }
        }

        private void processToshibaLineZ(string line)
        {

            if (_zetReport == null)
                _zetReport = new List<ZetReport>();
            ZetReport z = new ZetReport();
            z.cashRegister = int.Parse(line.Substring(13,6));
            z.transactionDate = DateTime.ParseExact(line.Substring(19, 14), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            z.store = int.Parse(line.Substring(7, 6));
            z.zetNo = int.Parse(line.Substring(1, 6));
            decimal grossTotal = decimal.Parse(line.Substring(33, 12)) / 100;
            decimal depTotal = decimal.Parse(line.Substring(165, 12)) / 100;
            decimal dailyTotal = decimal.Parse(line.Substring(177, 12)) / 100;
            Boolean fromDepTotal = false;
            if (depTotal == dailyTotal || depTotal == grossTotal)
            {
                fromDepTotal = true;
                z.totalAmount = depTotal;
            }
            else
            {
                fromDepTotal = false;
                z.totalAmount = grossTotal;
            }
            z.receiptCount = int.Parse(line.Substring(57, 6)) + int.Parse(line.Substring(63, 6)) - 1;
            z.refundAmount = decimal.Parse(line.Substring(117, 12)) / 100;
            z.refundCount = int.Parse(line.Substring(153, 6));
            z.slpAmount = decimal.Parse(line.Substring(69, 12)) / 100;
            z.slpCount = int.Parse(line.Substring(105, 6));
            // zet tablosuna atarken receiptotal'ı atarken faturayı çıkarıp at. depTotal'dan gelmiyorsa
            if (!fromDepTotal)
                z.totalAmount -= z.slpAmount;
            _zetReport.Add(z);
        }

        private IList<Sale> processToshibaText(string text)
        {
            string currentLine = "";
            try
            {
                IList<Sale> sales = new List<Sale>();
                Sale s = new Sale();
                DateTime zetTransactionDate = DateTime.Now.Date;

                string[] lines = text.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    currentLine = line;

                    string vRecType = line.Substring(0, 1);

                    switch (vRecType)
                    {
                        case "H":
                            s = new Sale();
                            processToshibaLineH(s, line);
                            sales.Add(s);
                            break;
                        case "L":
                            processToshibaLineL(sales, line);
                            break;
                        case "P":
                            processToshibaLineP(sales, line);
                            break;
                        case "D":
                            processToshibaLineD(sales, line);
                            break;
                        case "Z":
                            processToshibaLineZ(line);
                            break;
                    }
                }
                return sales;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                _logger.Error($"DataUploadId : {_dataUploadId} Current Line : {currentLine}");
                //_logger.Error(text);
                throw ex;
            }
        }

        private IList<Sale> processToshibaCancelText(string text)
        {
            string currentLine = "";
            try
            {
                IList<Sale> sales = new List<Sale>();
                Sale s = new Sale();
                DateTime zetTransactionDate = DateTime.Now.Date;

                string[] lines = text.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    currentLine = line;

                    string vRecType = line.Substring(0, 1);

                    switch (vRecType)
                    {
                        case "H":
                            s = new Sale();
                            processToshibaLineH(s, line);
                            s.isCancelled = true;
                            sales.Add(s);
                            break;
                        case "L":
                            processToshibaLineL(sales, line);
                            break;
                        case "P":
                            processToshibaLineP(sales, line);
                            break;
                    }
                }
                return sales;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                _logger.Error($"DataUploadId : {_dataUploadId} Current Line : {currentLine}");
                // _logger.Error(text);
                throw ex;
            }
        }

        private bool checkIfStoreExists(IDAL dal, long storeId)
        {
            IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
            var store = dal.Read<Store>("STR_SEL_STORE_SP", prmStoreId);
            if (store != null)
            {
                return true;
            } else
            {
                return false;
            }
        }

        private void insertLines(IDAL dal, IList<Sale> lines)
        {

            // get default productid
            IUniParameter prmDefaultProduct = dal.CreateParameter("ProductCode", "11.11.11");
            var defaultProduct = dal.Read<Product>("PRD_SEL_SEARCHPRODUCTCODE_SP", prmDefaultProduct);

            long eventId = _parameterReader.ReadEventId("StoreDataUpload", 1);
            long organizationId = Overtech.Core.Application.OTApplication.Context.Organization.Id;

            try
            {
                int count = 0;
                foreach (Sale line in lines)
                {
                    try
                    {
                        if (checkIfStoreExists(dal, line.storeNo))
                        {
                            IUniParameter prmName = dal.CreateParameter("TransactionCode", line.tranNo);
                            var sale = dal.Read<Sales>("SLS_SEL_SALETRANSACTION_SP", prmName);

                            if (sale == null && line.soldItems != null)
                            {
                                long saleId = -1;
                                try
                                {
                                    Sales s = new Sales
                                    {
                                        Event = eventId,
                                        Organization = organizationId,
                                        TransactionCode = line.tranNo,
                                        Store = line.storeNo,
                                        CashRegister = line.termNo,
                                        TransactionDate = line.tranTime.Date,
                                        TransactionType = line.tranType,
                                        TransactionTime = line.tranTime,
                                        Total = line.total,
                                        ProductDiscount = line.itemDisc,
                                        TotalDiscount = line.totalDisc,
                                        ProcessDuration = line.totalTime,
                                        ProductCount = line.numItems,
                                        Cancelled = line.isCancelled,
                                        CashierCode = (line.cashier == null) ? "00000000" : line.cashier
                                    };
                                    saleId = dal.Create(s);
                                    // sonradan alınmaya karar verilen bu değerler başka bir tabloya alındı. 
                                    IUniParameter prmSaleId = dal.CreateParameter("SaleId", saleId);
                                    IUniParameter prmCustomerNo = dal.CreateParameter("CustomerNo", line.CustomerNo);
                                    IUniParameter prmInvoiceNo = dal.CreateParameter("InvoiceNo", line.InvoiceNo);
                                    dal.ExecuteNonQuery("SLS_UPD_SALEINFO_SP", prmSaleId, prmCustomerNo, prmInvoiceNo);
                                }
                                catch (Exception ex)
                                {
                                    _logger.Error($"DataUploadId : {_dataUploadId} Sale insert error : {ex.ToString()}");
                                    _logger.Error(Newtonsoft.Json.JsonConvert.SerializeObject(line));
                                    throw ex;
                                }

                                foreach (var si in line.soldItems)
                                {
                                    // get productid
                                    // get default productid
                                    IUniParameter prmSearchProduct = dal.CreateParameter("Barcode", si.itemCode.TrimStart('0'));
                                    var p = dal.Read<Product>("PRD_SEL_SEARCHBARCODE_SP", prmSearchProduct);

                                    try
                                    {
                                        SaleDetail sd = new SaleDetail
                                        {
                                            Event = eventId,
                                            Organization = organizationId,
                                            SaleID = saleId,
                                            TransactionID = line.tranNo,
                                            TransactionDate = line.tranTime.Date,
                                            Barcode = si.itemCode,
                                            ProductCode = si.stockCode,
                                            ProductID = (p == null ? defaultProduct.ProductId : p.ProductId),
                                            Store = line.storeNo,
                                            Price = ((line.tranType == 5) ? -1 : 1) * Math.Abs(si.price),
                                            VATRate = si.vatRate,
                                            Quantity = (int)(si.quantity),
                                            Unit = (si.unit == 0 ? 2 : si.unit),
                                            CancelFlag = si.isCancelled,
                                            UnitPrice = si.salePrice
                                        };
                                        dal.Create(sd);
                                    }
                                    catch (Exception ex)
                                    {
                                        _logger.Error($"DataUploadId : {_dataUploadId} SaleDetail insert error : {ex.ToString()}");
                                        _logger.Error(Newtonsoft.Json.JsonConvert.SerializeObject(line.soldItems));
                                        throw ex;
                                    }
                                }

                                if (line.salePayment != null && line.salePayment.paymentType != null)
                                {
                                    try
                                    {
                                        SalePayment sp = new SalePayment
                                        {
                                            Event = eventId,
                                            Organization = organizationId,
                                            SaleID = saleId,
                                            TransactionID = line.tranNo,
                                            TransactionDate = line.tranTime.Date,
                                            Store = line.storeNo,
                                            PaymentType = line.salePayment.paymentType,
                                            PaidAmount = line.salePayment.paid,
                                            CreditCardAmount = line.salePayment.cardAmount,
                                            RefundAmount = line.salePayment.refund,
                                            PosBankType = line.salePayment.bankType,
                                            PosTrxType = line.salePayment.trxType,
                                            IsDebitCard = line.salePayment.isDebit,
                                            CreditCardNo = line.salePayment.accountNo
                                        };
                                        dal.Create(sp);
                                    }
                                    catch (Exception ex)
                                    {
                                        _logger.Error($"DataUploadId : {_dataUploadId} SalePayment insert error : {ex.ToString()}");
                                        _logger.Error(Newtonsoft.Json.JsonConvert.SerializeObject(line.salePayment));
                                        throw ex;
                                    }
                                }

                                if (line.saleCustomer != null)
                                {
                                    try
                                    {
                                        // _logger.Debug($"line.saleCustomer not null : {line.saleCustomer.identityNo.ToString()}");

                                        SaleCustomer sc = new SaleCustomer
                                        {
                                            Event = eventId,
                                            Organization = organizationId,
                                            Sale = saleId,
                                            EInvoiceFlag = line.saleCustomer.eInvoice,
                                            CustomerName = line.saleCustomer.customerName,
                                            Address = line.saleCustomer.addressText,
                                            TaxCenterName = line.saleCustomer.taxCenterName,
                                            TaxIdentityNo = line.saleCustomer.identityNo,
                                            Email = line.saleCustomer.eMail,
                                            PhoneNumber = line.saleCustomer.phoneNumber,
                                            FiscalSerial = line.saleCustomer.fiscalSerial,
                                            EInvoiceZetNumber = line.saleCustomer.eInvoiceZetNo,
                                            EInvoiceReceiptNumber = line.saleCustomer.eInvoiceReceiptNo
                                        };
                                        dal.Create(sc);
                                    }
                                    catch (Exception ex)
                                    {
                                        _logger.Error($"DataUploadId : {_dataUploadId} SaleCustomer insert error : {ex.ToString()}");
                                        _logger.Error(Newtonsoft.Json.JsonConvert.SerializeObject(line.saleCustomer));
                                        throw ex;
                                    }
                                }

                                if (line.rawData != null)
                                {
                                    var index = 1;
                                    foreach (var rawline in line.rawData)
                                    {
                                        try
                                        {
                                            SaleRaw sr = new SaleRaw
                                            {
                                                Event = eventId,
                                                Organization = organizationId,
                                                SaleID = saleId,
                                                Line = rawline,
                                                Position = index++
                                            };
                                            dal.Create(sr);
                                        }
                                        catch (Exception ex)
                                        {
                                            _logger.Error($"DataUploadId : {_dataUploadId} SaleRaw insert error : {ex.ToString()}");
                                            _logger.Error(Newtonsoft.Json.JsonConvert.SerializeObject(line.rawData));
                                            throw ex;
                                        }
                                    }
                                }

                            }
                            count++;
                            if (count > 100)
                            {
                                dal.CommitTransaction();
                                dal.BeginTransaction();
                                count = 0;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"DataUploadId : {_dataUploadId} Sale line insert error : {ex.ToString()}");
                        _logger.Error(Newtonsoft.Json.JsonConvert.SerializeObject(line));
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"DataUploadId : {_dataUploadId} Sale lines insert error : {ex.ToString()}");
                //_logger.Error(Newtonsoft.Json.JsonConvert.SerializeObject(lines));
                throw ex;
            }

            try
            {
                if (_zetReport != null && _zetReport.Count() > 0)
                {
                    

                    foreach (ZetReport z in _zetReport)
                    {
                        
                        // önceki zet verilerini sil.
                        IUniParameter prmStoreId = dal.CreateParameter("StoreId", z.store);
                        IUniParameter prmTransactionDate = dal.CreateParameter("TransactionDate", z.transactionDate);
                        IUniParameter prmCashRegister = dal.CreateParameter("CashRegisterId", z.cashRegister);
                        IUniParameter prmZetNo = dal.CreateParameter("ZetNo", z.zetNo);
                        var storezet = dal.List<SaleDailySummary>("SLS_LST_CHECKSTOREZET_SP", prmStoreId, prmTransactionDate, prmCashRegister, prmZetNo).ToList();

                        // transactionTime'ı update et, bir süreliğine eski verileri güncellemek için kullanılacak. 
                        dal.ExecuteNonQuery("SLS_UPD_ZETTRANTIME_SP", prmStoreId, prmTransactionDate, prmCashRegister, prmZetNo);


                        if (storezet.Count() > 0)
                        {
                            SaleDailySummary zet = storezet.First();

                            /*
                            if (zet.ReceiptCount != z.receiptCount || zet.ReceiptTotal != z.totalAmount || zet.RefundAmount != z.refundAmount || zet.RefundCount != z.refundCount
                                || zet.SlpTotal != z.slpAmount || zet.SlpCount != z.slpCount)
                            {
                                zet.ReceiptCount = z.receiptCount;
                                zet.ReceiptTotal = z.totalAmount;
                                zet.RefundAmount = z.refundAmount;
                                zet.RefundCount = z.refundCount;
                                zet.SlpTotal = z.slpAmount;
                                zet.SlpCount = z.slpCount;
                                dal.Update(zet);
                            }
                            */
                        }
                        else
                        {
                            // if (z.totalAmount > 0)
                            // {

                                SaleDailySummary zet = new SaleDailySummary
                                {
                                    Event = eventId,
                                    Organization = organizationId,
                                    StoreID = z.store,
                                    CashRegister = z.cashRegister,
                                    TransactionDate = z.transactionDate,
                                    ZetNo = z.zetNo,
                                    ReceiptCount = z.receiptCount,
                                    ReceiptTotal = z.totalAmount,
                                    RefundAmount = z.refundAmount,
                                    RefundCount = z.refundCount,
                                    SlpTotal = z.slpAmount,
                                    SlpCount = z.slpCount
                                };
                                dal.Create(zet);

                            //}
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"SaleDailySummary insert error : {ex.ToString()}");
                _logger.Error(Newtonsoft.Json.JsonConvert.SerializeObject(_zetReport));
                throw ex;
            }
                       
            
        }
            

        public void ProcessFile(DataUpload upload)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    _dataUploadId = upload.DataUploadId;

                    DocumentOperations documentOperations = new DocumentOperations(dal, _resolver);
                    var document = dal.Read<Document>(upload.Document);
                    var data = documentOperations.GetDocumentBody(document);
                    var text = Encoding.GetEncoding(1254).GetString(data);

                    // string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    // File.WriteAllText(Path.Combine(mydocpath, "ncrkasa65.dat"), text);
                    IList <Sale> lines = new List<Sale>();
                    switch (upload.UploadType)
                    {
                        case 1: lines = processNCRText(text); break;
                        case 2: lines = processToshibaText(text); break;
                        case 4:
                            lines = processToshibaCancelText(text);
                            // _logger.Debug($"{upload.DataUploadId} : cancel text {Newtonsoft.Json.JsonConvert.SerializeObject(lines)}");
                            break;
                    }

                    // decimal total = lines.Sum(item => item.total);
                    // int count = lines.Count();

                    if (lines != null)
                        insertLines(dal, lines);
                    else
                        _logger.Error($"lines oluşmadı : {text}");

                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _logger.Error($"DataUploadId : {_dataUploadId} ProcessFile Error : {ex.ToString()}");
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
        }

        public SaleDailySummary GetZetData (int cashRegisterId, DateTime transactionDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("CASHREGISTERID", cashRegisterId);
                IUniParameter prmTransactionDate = dal.CreateParameter("TRANSACTIONDATE", transactionDate);

                var storezet = dal.Read<SaleDailySummary>("SLS_SEL_FINDSTOREDAILYZET_SP", prmStoreId, prmTransactionDate);
                return storezet;
            }
        }

        public SaleDailySummary CheckStoreZet(int storeId, DateTime transactionDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("STOREID", storeId);
                IUniParameter prmTransactionDate = dal.CreateParameter("TRANSACTIONDATE", transactionDate);

                var storezet = dal.Read<SaleDailySummary>("SLS_LST_CHECKSTOREZET_SP", prmStoreId, prmTransactionDate);
                return storezet;
            }
        }

        public void InsertStoreTraceLog(int storeId, string traceText)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                    IUniParameter prmTraceText = dal.CreateParameter("TraceText", traceText);
                    dal.ExecuteNonQuery("SUP_INS_TRACE_SP", prmStoreId, prmTraceText);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _logger.Error($"InsertStoreTraceLog, storeId : {storeId} traceText : {traceText}, exception : {ex.ToString()}");
                    dal.RollbackTransaction();
                }

            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}