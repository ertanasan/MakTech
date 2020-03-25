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
using Overtech.Mutual.Parameter;
using Overtech.Core.DependencyInjection;
using Overtech.Core.Logger;
using Overtech.Mutual.Accounting;
using Overtech.Core.Application;
using System.Data;

/*Section="ClassHeader"*/
namespace Overtech.Services.Accounting
{
    [OTInspectorBehavior]
    public class LoomisService : CRUDLDataService<Overtech.DataModels.Accounting.Loomis>, ILoomisService
    {
        IParameterReader _parameterReader;
        IOTResolver _resolver;
        private ILogger _logger;

        /*Section="Constructor-1"*/
        public LoomisService(IParameterReader parameterReader,
            IOTResolver resolver,
            ILoggerFactory loggerFactory)
        {
            this._parameterReader = parameterReader;
            _resolver = resolver;
            _logger = loggerFactory.GetLogger(typeof(BankPosTransactionsService));
        }

        /*Section="Constructor-2"*/
        internal LoomisService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public void LoadLoomisFile(byte[] formData)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    _logger.Debug($"Loomis Transfer file read started : {DateTime.Now.ToLongTimeString()}");
                    ExcelOperations exOp = new ExcelOperations(dal);
                    long eventId = _parameterReader.ReadEventId("System");
                    long organizationId = OTApplication.Context.Organization.Id;
                    string result = exOp.ReadExceltoDataTable(formData, "Loomis", 1);
                    DataTable dt = exOp.ExcelTable;
                    if (result.Length == 0 && dt.Rows.Count > 0) // if no error and there are records in excel
                    {
                        
                        // find min max dates from excel datatable
                        DateTime minDate, maxDate;
                        minDate = (DateTime)dt.Rows[0]["SAYIMTARIHI"];
                        maxDate = (DateTime)dt.Rows[0]["SAYIMTARIHI"];
                        foreach (DataRow dr in dt.Rows)
                        {
                            DateTime saleDate = (DateTime)dr["SAYIMTARIHI"];
                            if (saleDate < minDate)
                            {
                                minDate = saleDate;
                            }
                            if (saleDate > maxDate)
                            {
                                maxDate = saleDate;
                            }
                        }
                        _logger.Debug($"Min and Max Dates found in excel file minDate = {minDate.ToString("dd.MM.yyyy")} maxDate = {maxDate.ToString("dd.MM.yyyy")}: {DateTime.Now.ToLongTimeString()}");

                        // read current records in Maktech DB
                        IUniParameter prmStartDate = dal.CreateParameter("StartDate", minDate);
                        IUniParameter prmEndDate = dal.CreateParameter("EndDate", maxDate);
                        IList<Loomis> maktechRecords = dal.List<Loomis>("ACC_LST_LOOMISALL_SP", prmStartDate, prmEndDate).ToList();
                        _logger.Debug($"Maktech records was read: {DateTime.Now.ToLongTimeString()}");


                        // process all rows to Maktech DB
                        foreach (DataRow dr in dt.Rows)
                        {
                            DateTime saleDate = (DateTime)dr["SAYIMTARIHI"];
                            int store = int.Parse(dr["HNKODU"].ToString());
                            decimal actualAmount = (decimal)dr["SAYILAN"];
                            string sealNo = dr["MUHURNO"].ToString().Trim();

                            if (sealNo == "0" || sealNo.Length == 0) continue;

                            var storedayrec = maktechRecords.Where(o => (o.Store == store && o.LoomisDate == saleDate));
                            
                            /* update aynı tarih ve mağazalı 2 kayıtın toplamını değil, sonuncusunu aldığından problem oluyor, kapatıyorum. Taylan - 2020-01-20                                
                            // Taylan - 2020-01-17 : Bu kısım kapalıydı, niye kapattığımı hatırlamıyorum ama güncellenmesi gerektiğinden tekrar açıyorum.
                            if (storedayrec.Count() > 0)
                            {
                                Loomis updateRec = storedayrec.First();
                                if (updateRec.ActualAmount != actualAmount)
                                {
                                    updateRec.ActualAmount = actualAmount;
                                    dal.Update(updateRec);
                                }
                            }
                            */

                            if (storedayrec.Count() == 0)
                            {
                                Loomis createRec = new Loomis();
                                createRec.SaleDate = saleDate.AddDays(-1);
                                createRec.LoomisDate = saleDate;
                                createRec.Store = store;
                                createRec.ActualAmount = actualAmount;
                                if (dr["BEYANEDILEN"] != DBNull.Value) createRec.DeclaredAmount = (decimal)dr["BEYANEDILEN"]; else createRec.DeclaredAmount = null;
                                createRec.FakeAmount = (decimal)dr["GECERSIZ"];
                                createRec.SealNo = sealNo;
                                createRec.Explanation = dr["ACIKLAMA"].ToString();
                                createRec.MikroStatusCode = 0;
                                createRec.Organization = organizationId;
                                createRec.Event = eventId;
                                dal.Create(createRec);
                            }
                        }
                        _logger.Debug($"All rows processed : {DateTime.Now.ToLongTimeString()}");

                        dal.CommitTransaction();
                    }
                    else if (result.Length > 0)
                    {
                        throw new Exception(result);
                    }
                    
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    _logger.Error($" ServiceName : LoomisService, MethodName : LoadLoomisFile, Exception : {ex.Message}");
                    throw ex;
                }
            }

        }

        public IEnumerable<Loomis> ListDay(DateTime saleDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", saleDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", saleDate);
                return dal.List<Loomis>("ACC_LST_LOOMIS_SP", prmStartDate, prmEndDate).ToList();
            }
        }

        public void MikroTransfer(DateTime saleDate, long[] LoomisIdList)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    string loomisIdList = "";
                    foreach (long id in LoomisIdList)
                    {
                        if (loomisIdList.Length > 0)
                        {
                            loomisIdList += $",{id}";
                        }
                        else
                        {
                            loomisIdList += $"{id}";
                        }
                    }

                    IUniParameter prmDay = dal.CreateParameter("Day", saleDate);
                    IUniParameter prmLoomisId = dal.CreateParameter("LoomisIdList", loomisIdList);
                    dal.ExecuteNonQuery("MIK_INS_LOOMIS_SP", prmDay, prmLoomisId);

                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    _logger.Error($" ServiceName : LoomisService, MethodName : MikroTransfer, SaleDate : {saleDate.ToString("dd.MM.yyyy")} LoomisIdList : {Newtonsoft.Json.JsonConvert.SerializeObject(LoomisIdList)} Exception : {ex.Message}");
                    throw ex;
                }

            }
        }

        public void CancelMikroTransfer(DateTime SaleDate)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmTransferDate = dal.CreateParameter("TransferDate", SaleDate);
                    dal.ExecuteNonQuery("MIK_DEL_LOOMIS_SP", prmTransferDate);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _logger.Error($"serviceName : LoomisService, methodName : CancelMikroTransfer, blockedDate : {SaleDate.ToString()}, Exception : {ex.ToString()}");
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
        }

        public void ClearDate(DateTime SaleDate)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmSaleDate = dal.CreateParameter("SaleDate", SaleDate);
                    dal.ExecuteNonQuery("ACC_DEL_LOOMISDATE_SP", prmSaleDate);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _logger.Error($"serviceName : LoomisService, methodName : ClearDate, SaleDate : {SaleDate.ToString()}, Exception : {ex.ToString()}");
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}