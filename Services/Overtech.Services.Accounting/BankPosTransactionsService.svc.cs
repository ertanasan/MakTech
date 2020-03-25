// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Accounting;
using Overtech.ServiceContracts.Accounting;
using System.Web;
using System.Data;
using OfficeOpenXml;
using System.IO;
using Overtech.Mutual.Accounting;
using Overtech.Core.Application;
using Overtech.Mutual.Parameter;
using Overtech.Core.DependencyInjection;
using Overtech.Core.Logger;

/*Section="ClassHeader"*/
namespace Overtech.Services.Accounting
{
    [OTInspectorBehavior]
    public class BankPosTransactionsService : CRUDLDataService<Overtech.DataModels.Accounting.BankPosTransactions>, IBankPosTransactionsService
    {
        IParameterReader _parameterReader;
        IOTResolver _resolver;
        private ILogger _logger;

        /*Section="Constructor-1"*/
        public BankPosTransactionsService(IParameterReader parameterReader, 
            IOTResolver resolver,
            ILoggerFactory loggerFactory)
        {
            this._parameterReader = parameterReader;
            _resolver = resolver;
            _logger = loggerFactory.GetLogger(typeof(BankPosTransactionsService));
        }

        /*Section="Constructor-2"*/
        internal BankPosTransactionsService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        private BankPosTransactions readRow(BankPosTransactions rec, int MikroStatusCode, IDAL dal)
        {
            IUniParameter prmStoreRef = dal.CreateParameter("StoreRef", rec.StoreRef);
            IUniParameter prmPosRef = dal.CreateParameter("PosRef", rec.PosRef);
            IUniParameter prmBlockedDate = dal.CreateParameter("BlockedDate", rec.BlockedDate);
            IUniParameter prmValueDate = dal.CreateParameter("ValueDate", rec.ValueDate);
            IUniParameter prmMikroStatusCode = dal.CreateParameter("MikroStatusCode", MikroStatusCode);
            BankPosTransactions checkrec = dal.Read<BankPosTransactions>("ACC_SEL_POSMIKROTRANSFERCONTROL_SP", prmStoreRef, prmPosRef, prmBlockedDate, prmValueDate, prmMikroStatusCode);
            return checkrec;
        }
        private int checkIfMikroTransferred (IList<BankPosTransactions> trans, IDAL dal)
        {
            int result = 0;
            foreach (BankPosTransactions rec in trans)
            {
                BankPosTransactions checkrec = readRow(rec, 1, dal);
                if (checkrec != null)
                {
                    result++;
                }
            }
            return result;
        }

        public string ZiraatLoadBankPOSFile(byte[] formData)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    _logger.Debug($"Ziraat Pos Transfer file read started : {DateTime.Now.ToLongTimeString()}");
                    ExcelOperations exOp = new ExcelOperations(dal);
                    long eventId = _parameterReader.ReadEventId("System");
                    long organizationId = OTApplication.Context.Organization.Id;
                    string result = exOp.ReadExceltoDataTable(formData, "Ziraat POS", 2); // filetype 2: csv
                    if (result.Length == 0)
                    {
                        DataTable dt = exOp.ExcelTable;
                        dt.Columns.Add("ADET", typeof(decimal));
                        dt.Columns.Add("BORCTUTARI", typeof(decimal));
                        dt.Columns.Add("KOMISYON", typeof(decimal));

                        var newDt = dt.AsEnumerable()
                        .GroupBy(r => new { TERMID = r.Field<string>("TERMID"), UYENO = r.Field<string>("UYENO"), BLOKETARIHI = r.Field<DateTime>("BLOKETARIHI"), BLOKEVALORU = r.Field<DateTime>("BLOKEVALORU")})
                        .Select(g =>
                        {
                            var row = dt.NewRow();
                            

                            row["UYENO"] = g.Key.UYENO;
                            row["TERMID"] = g.Key.TERMID.TrimStart(new Char[] { '0' });
                            row["BLOKETARIHI"] = g.Key.BLOKETARIHI;
                            row["BLOKEVALORU"] = g.Key.BLOKEVALORU;
                            row["ALACAKTUTARI"] = g.Sum(r => r.Field<decimal>("ALACAKTUTARI"));
                            row["ADET"] = g.Count();
                            row["BORCTUTARI"] = 0;
                            row["KOMISYON"] = 0;

                            return row;
                        }).CopyToDataTable();

                        result = insertDataTabletoPOSTable(newDt, dal, 4);
                    }
                    if (result.Length == 0)
                    {
                        dal.CommitTransaction();
                    }
                    else
                    {
                        dal.RollbackTransaction();
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
        }

        private string insertDataTabletoPOSTable (DataTable dt, IDAL dal, int bankNumber)
        {
            long eventId = _parameterReader.ReadEventId("System");
            long organizationId = OTApplication.Context.Organization.Id;
            string result = "";
            IList<BankPosTransactions> t = new List<BankPosTransactions>();

            foreach (DataRow dr in dt.Rows)
            {
                BankPosTransactions pt = new BankPosTransactions();
                bool found = false;
                foreach (BankPosTransactions rec in t)
                {
                    if (rec.StoreRef == dr["UYENO"].ToString() &&
                        rec.PosRef == dr["TERMID"].ToString() &&
                        rec.BlockedDate == (DateTime)dr["BLOKETARIHI"] &&
                        rec.ValueDate == (DateTime)dr["BLOKEVALORU"])
                    {
                        found = true;
                        pt = rec;
                    }
                }

                if (found)
                {
                    pt.Quantity += int.Parse(Math.Round((decimal)dr["ADET"], 0).ToString());
                    pt.DebitAmount += (decimal)dr["ALACAKTUTARI"];
                    pt.CreditAmount += (decimal)dr["BORCTUTARI"];
                    pt.CommissionAmount += (decimal)dr["KOMISYON"];
                }
                else
                {
                    pt.Bank = bankNumber;
                    pt.MikroStatusCode = 0;
                    pt.Organization = organizationId;
                    pt.Event = eventId;
                    pt.StoreRef = dr["UYENO"].ToString();
                    pt.PosRef = dr["TERMID"].ToString();
                    pt.BlockedDate = (DateTime)dr["BLOKETARIHI"];
                    pt.ValueDate = (DateTime)dr["BLOKEVALORU"];
                    pt.Quantity = int.Parse(Math.Round((decimal)dr["ADET"], 0).ToString());
                    pt.DebitAmount = (decimal)dr["ALACAKTUTARI"];
                    pt.CreditAmount = (decimal)dr["BORCTUTARI"];
                    pt.CommissionAmount = (decimal)dr["KOMISYON"];
                    t.Add(pt);
                }
            }
            _logger.Debug($"File read to dataobject array : {DateTime.Now.ToLongTimeString()}");
            int mikroTransferredCount = checkIfMikroTransferred(t, dal);
            if (mikroTransferredCount == 0)
            {
                _logger.Debug($"Data checked if transferred to Mikro no error : {DateTime.Now.ToLongTimeString()}");

                foreach (BankPosTransactions rec in t)
                {
                    BankPosTransactions oldrec = readRow(rec, 0, dal);
                    if (oldrec == null)
                    {
                        dal.Create<BankPosTransactions>(rec);
                    }
                    else
                    {
                        oldrec.Quantity = rec.Quantity;
                        oldrec.DebitAmount = rec.DebitAmount;
                        oldrec.CreditAmount = rec.CreditAmount;
                        oldrec.CommissionAmount = rec.CommissionAmount;
                        dal.Update<BankPosTransactions>(oldrec);
                    }

                }
                _logger.Debug($"Pos Transfer operation completed : {DateTime.Now.ToLongTimeString()}");
            }
            else
            {
                _logger.Debug($"Data checked if transferred to Mikro with error : {DateTime.Now.ToLongTimeString()}");
                result = $"{t.Count} kaydın {mikroTransferredCount} adedi Mikro'ya aktarılmış. Tekrar yükleme yapamazsınız.";
            }
            return result;
        }

        public string LoadBankPOSFile(byte[] formData)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    _logger.Debug($"Pos Transfer file read started : {DateTime.Now.ToLongTimeString()}");
                    ExcelOperations exOp = new ExcelOperations(dal);
                    
                    string result = exOp.ReadExceltoDataTable(formData, "Pos Transfer", 1); // filetype 1: xlsx
                    if (result.Length == 0)
                    {
                        DataTable dt = exOp.ExcelTable;
                        result = insertDataTabletoPOSTable(dt, dal, 1);
                    }
                    if (result.Length == 0)
                    {
                        dal.CommitTransaction();
                    } else
                    {
                        dal.RollbackTransaction();
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
            
        }

        public IEnumerable<BankPosTransactions> ListDay (DateTime blockedDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmBlockedDate = dal.CreateParameter("BlockDate", blockedDate);
                return dal.List<BankPosTransactions>("ACC_LST_BANKPOSTRAN_SP", prmBlockedDate).ToList();
            }
        }

        public void MikroTransfer(DateTime BlockedDate, long[] BankPosTransactionsIdList)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    string posIdList = "";
                    foreach (long id in BankPosTransactionsIdList)
                    {
                        if (posIdList.Length > 0)
                        {
                            posIdList += $",{id}";
                        } else
                        {
                            posIdList += $"{id}";
                        }
                    }

                    IUniParameter prmDay = dal.CreateParameter("Day", BlockedDate);
                    IUniParameter prmRMId = dal.CreateParameter("PosIdList", posIdList);
                    dal.ExecuteNonQuery("MIK_INS_POS_SP", prmDay, prmRMId);

                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _logger.Error($"serviceName : BankPosTransactionsService, methodName : MikroTransfer, blockedDate : {BlockedDate.ToString()}, Exception : {ex.ToString()}");
                    dal.RollbackTransaction();
                    throw ex;
                }

            }
        }

        public void CancelMikroTransfer(DateTime BlockedDate)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmTransferDate = dal.CreateParameter("TransferDate", BlockedDate);
                    dal.ExecuteNonQuery("MIK_DEL_POSTRANSFER_SP", prmTransferDate);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _logger.Error($"serviceName : BankPosTransactionsService, methodName : CancelMikroTransfer, blockedDate : {BlockedDate.ToString()}, Exception : {ex.ToString()}");
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
        }

        public void ClearDate(DateTime BlockedDate)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmBlockedDate = dal.CreateParameter("BlockedDate", BlockedDate);
                    dal.ExecuteNonQuery("ACC_DEL_BANKPOSTRANDATE_SP", prmBlockedDate);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _logger.Error($"serviceName : BankPosTransactionsService, methodName : ClearDate, BlockedDate : {BlockedDate.ToString()}, Exception : {ex.ToString()}");
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}