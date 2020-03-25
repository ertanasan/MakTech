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
using Overtech.Core.Logger;
using Overtech.Mutual.Accounting;
using Overtech.Mutual.Parameter;
using Overtech.Core.Application;
using System.Data;
using Overtech.Core.DependencyInjection;
using System.Threading;

/*Section="ClassHeader"*/
namespace Overtech.Services.Accounting
{
    [OTInspectorBehavior]
    public class BankStatementService : CRUDLDataService<Overtech.DataModels.Accounting.BankStatement>, IBankStatementService
    {
        IParameterReader _parameterReader;
        IOTResolver _resolver;
        private ILogger _logger;

        /*Section="Constructor-1"*/
        public BankStatementService(IParameterReader parameterReader,
            IOTResolver resolver,
            ILoggerFactory loggerFactory)
        {
            this._parameterReader = parameterReader;
            _resolver = resolver;
            _logger = loggerFactory.GetLogger(typeof(BankPosTransactionsService));
        }

        /*Section="Constructor-2"*/
        internal BankStatementService(IDAL dal)
            : base(dal)
        {
        }


        /*Section="CustomCodeRegion"*/
        #region Customized

        public string LoadBankStatementFile(byte[] formData, string bankName)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("tr-TR");

            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    //_logger.Debug($"Bank Statement file read started : {DateTime.Now.ToLongTimeString()}");
                    ExcelOperations exOp = new ExcelOperations(dal);
                    long eventId = _parameterReader.ReadEventId("System");
                    long organizationId = OTApplication.Context.Organization.Id;
                    string result = "";
                    int bankId = -1;

                    switch (bankName)
                    {
                        case "TEB": bankId = 1; exOp.ReadExceltoDataTable(formData, "TEB Bank Statement", 1); break;
                        case "Vakıfbank": bankId = 2; result = exOp.ReadExceltoDataTable(formData, "Vakıf Bank Statement", 1); break;
                        case "ING Bank": bankId = 3; result = exOp.ReadExceltoDataTable(formData, "ING Bank Statement", 1); break;
                    }


                    //if (result.Length == 0)
                    //{
                        DataTable dt = exOp.ExcelTable;
                        IList<BankStatement> t = new List<BankStatement>();

                        foreach (DataRow dr in dt.Rows)
                        {
                        if (dr["Tarih"].GetType().Equals(System.Type.GetType("System.DateTime")))
                        {
                            BankStatement pt = new BankStatement();

                            pt.Bank = bankId; //Vakifbank ID
                            pt.Date = (DateTime)dr["Tarih"];
                            pt.Description = dr["Açıklama"].ToString();
                            pt.TransactionAmount = (decimal)dr["Tutar"];
                            pt.Balance = (decimal)dr["Bakiye"];
                            pt.Channel = dr["Kanal"].ToString();
                            pt.Event = eventId;
                            pt.Organization = organizationId;

                            t.Add(pt);
                        }

                            //_logger.Debug($"File read to dataobject array : {DateTime.Now.ToLongTimeString()}");
                        }

                        foreach (BankStatement rec in t)
                        {
                            dal.Create<BankStatement>(rec);
                        }
                        

                        if (result.Length == 0)
                        {
                            dal.CommitTransaction();
                        }
                        else
                        {
                            dal.RollbackTransaction();
                            throw new Exception(result);
                        }
                    //}
                    return "";
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    _logger.Error($"servicename : BankStatementService method : LoadINGBankStatementFile exception : {ex.ToString()}");
                    throw ex;
                    // return "Dosyayı kontrol ediniz";
                }
            }
        }

        public IEnumerable<BankStatement> ListDay(DateTime transactionDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmTransactionDate = dal.CreateParameter("transactionDate", transactionDate);
                return dal.List<BankStatement>("ACC_LST_BANKSTATEMENT_SP", prmTransactionDate).ToList();
            }
        }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}