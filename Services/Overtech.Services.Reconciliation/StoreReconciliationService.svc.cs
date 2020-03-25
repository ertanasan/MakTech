/*Section="Usings"*/
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Reconciliation;
using Overtech.ServiceContracts.Reconciliation;
using Overtech.Core.Application;
using Overtech.Core.Document;
using Overtech.Mutual.Store;
using Overtech.DataModels.Store;
using System.IO;

/*Section="ClassHeader"*/
namespace Overtech.Services.Reconciliation
{
    [OTInspectorBehavior]
    public class StoreReconciliationService : CRUDLDataService<StoreReconciliation>, IStoreReconciliationService
    {
        /*Section="Constructor-1"*/
        public StoreReconciliationService()
        {
        }

        /*Section="Constructor-2"*/
        internal StoreReconciliationService(IDAL dal)
            : base(dal)
        {
        }


        #region Customized

        public void DeleteReconciliation(long reconciliationID)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prm = dal.CreateParameter("StoreReconciliationId", reconciliationID);
                try
                {
                    dal.BeginTransaction();
                    dal.ExecuteNonQuery("RCL_DEL_RECONCILIATION_SP", prm);
                    dal.CommitTransaction();
                }
                catch { dal.RollbackTransaction(); }
            }
        }

        public IEnumerable<StoreReconciliationIncome>ListReconciliationIncome(DateTime transactionDate)
        {
            using (IDAL dal = this.DAL)
            {
                StoreOperations storeOperations = new StoreOperations(dal);
                Store store = storeOperations.getStore(OTApplication.Context.Branch.Id);

                IUniParameter prmBranch = dal.CreateParameter("StoreID", store.StoreId);
                IUniParameter prmTransactionDate = dal.CreateParameter("TransactionDate", transactionDate);
                IUniParameter prmSaleTotal = dal.CreateParameter("SaleTotal", 0);
                var result = dal.List<StoreReconciliationIncome>("RCL_LST_RECONCILIATIONINCOME_SP", prmBranch, prmTransactionDate, prmSaleTotal).ToList();
                return result;
            }
        }

        public StoreReconciliation GetReconciliation(DateTime transactionDate)
        {
            using (IDAL dal = this.DAL)
            {
                StoreOperations storeOperations = new StoreOperations(dal);
                Store store = storeOperations.getStore(OTApplication.Context.Branch.Id);

                IUniParameter prmBranch = dal.CreateParameter("StoreID", store.StoreId);
                IUniParameter prmTransactionDate = dal.CreateParameter("TransactionDate", transactionDate);
                var reconInfo = dal.Read<StoreReconciliation>("RCL_SEL_RECONCILIATIONINFO_SP", prmBranch, prmTransactionDate);
                return reconInfo;
            }
        }

        public IEnumerable<StoreReconciliation> ListReconciliation(DateTime transactionDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmTransactionDate = dal.CreateParameter("TransactionDate", transactionDate);
                var result = dal.List<StoreReconciliation>("RCL_LST_RECONCILIATIONS_SP", prmTransactionDate).ToList();
                return result;
            }
        }

        public void SaveReconciliation(StoreReconciliation storeReconciliation/*, IEnumerable<Expense> expenses*/)
        {

            using (IDAL dal = this.DAL)
            {
                StoreOperations storeOperations = new StoreOperations(dal);
                Store store = storeOperations.getStore(OTApplication.Context.Branch.Id);

                dal.BeginTransaction();
                try
                {
                    storeReconciliation.Event = 1;
                    storeReconciliation.Organization = OTApplication.Context.Organization.Id;
                    storeReconciliation.StoreID = store.StoreId;

                    if (storeReconciliation.StoreReconciliationId == 0)
                    {
                        dal.Create(storeReconciliation);
                    }
                    else
                    {
                        dal.Update(storeReconciliation);
                    }

                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public void ApproveReconciliations(DateTime transactionDate, int reconciliationID)
        {
            using (IDAL dal = this.DAL)
            {
                try
                {
                    dal.BeginTransaction();
                    IUniParameter prmTransactionDate = dal.CreateParameter("TransactionDate", transactionDate);
                    IUniParameter prmReconciliationID = dal.CreateParameter("ReconciliationID", reconciliationID);
                    dal.ExecuteNonQuery("RCL_UPD_RECONCILIATIONAPPROVE_SP", prmTransactionDate, prmReconciliationID);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public DataTable GetReconciliationStoreData(int dayGroup)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmDayGroup = dal.CreateParameter("DayGroup", dayGroup);
                return dal.ExecuteDataset("RCL_LST_STOREDATA_SP", prmDayGroup).Tables[0];
            }
        }


        //public byte[] ExportReconciliationList(IEnumerable<StoreReconciliation> reconciliations)
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("ID");
        //    dt.Columns.Add("SubeKodu");
        //    dt.Columns.Add("SubeAdi");
        //    dt.Columns.Add("IslemTarihi");
        //    dt.Columns.Add("Mutabakatli");
        //    dt.Columns.Add("Onayli");
        //    dt.Columns.Add("OncekGunAvansi");
        //    dt.Columns.Add("SatisToplami");
        //    dt.Columns.Add("NakitToplami");
        //    dt.Columns.Add("KartToplami");
        //    dt.Columns.Add("Bankaya");
        //    dt.Columns.Add("Fark");
        //    dt.Columns.Add("FarkAciklamasi");
        //    dt.Columns.Add("Tamamlanan");
        //    dt.Columns.Add("DevredenAvans");

        //    foreach (Overtech.DataModels.Reconciliation.StoreReconciliation item in reconciliations)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr["ID"] = item.StoreReconciliationId;
        //        dr["SubeKodu"] = item.StoreID;
        //        dr["SubeAdi"] = "";
        //        dr["IslemTarihi"] = item.TransactionDate.ToString("dd.MM.yyyy");
        //        dr["Mutabakatli"] = item.Reconciliated;
        //        dr["Onayli"] = item.Approved;
        //        dr["OncekGunAvansi"] = item.PreviousDayAmount;
        //        dr["SatisToplami"] = item.SaleTotal;
        //        dr["NakitToplami"] = item.CashTotal;
        //        dr["KartToplami"] = item.CardTotal;
        //        dr["Bankaya"] = item.ToBank;
        //        dr["Fark"] = item.Difference;
        //        dr["FarkAciklamasi"] = item.DifferenceExplanation;
        //        dr["Tamamlanan"] = item.Completed;
        //        dr["DevredenAvans"] = item.EodAdvance;

        //        dt.Rows.Add(dr);
        //    }

        //    byte[] excelData;
        //    using (var ms = new MemoryStream())
        //    {
        //        dt.ExportToExcel(ms);
        //        excelData = ms.ToArray();
        //    }

        //    return excelData;
        //}


        #endregion Customized

    }
}