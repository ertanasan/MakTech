// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Reconciliation;
using Overtech.ServiceContracts.Reconciliation;
using System.Data;
using Overtech.Mutual.DocumentManagement;
using Overtech.Core.DependencyInjection;
using Overtech.DataModels.Document;

/*Section="ClassHeader"*/
namespace Overtech.Services.Reconciliation
{
    [OTInspectorBehavior]
    public class ReconciliationService : CRUDLDataService<Overtech.DataModels.Reconciliation.Reconciliation>, IReconciliationService
    {

        /*Section="Constructor-1"*/
        public ReconciliationService()
        {
        }
            
        /*Section="Constructor-2"*/
        internal ReconciliationService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Reconciliation.Reconciliation Find(string storeReconciliationId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreReconciliationId = dal.CreateParameter("StoreReconciliationId", storeReconciliationId);
                return dal.Read<Overtech.DataModels.Reconciliation.Reconciliation>("RCL_SEL_FINDSTORE_SP", prmStoreReconciliationId);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        
        public DataTable NotReconStores(DateTime startDate, DateTime endDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);
                DataTable dt = dal.ExecuteDataset("RCL_LST_NORCL_SP", prmStartDate, prmEndDate).Tables[0];
                return dt;
            }
        }

        public Overtech.DataModels.Reconciliation.Reconciliation ReconciliationDate(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                return dal.Read<Overtech.DataModels.Reconciliation.Reconciliation>("RCL_SEL_LASTRCLDATE_SP", prmStoreId);
            }
        }

        public override DataModels.Reconciliation.Reconciliation Read(long objectId)
        {
            Overtech.DataModels.Reconciliation.Reconciliation rec = base.Read(objectId);
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmRecId = dal.CreateParameter("StoreRecId", objectId);
                rec.CashDist = dal.List<Overtech.DataModels.Reconciliation.CashDistribution>("RCL_LST_CASHDIST_SP", prmRecId).ToList();
                rec.CardDist = dal.List<Overtech.DataModels.Reconciliation.CardDistribution>("RCL_LST_CARDDIST_SP", prmRecId).ToList();
                rec.RecLog = dal.List<Overtech.DataModels.Reconciliation.RecLog>("RCL_LST_LOG_SP", prmRecId).ToList();
                rec.CancelReasons = dal.List<Overtech.DataModels.Sale.CancelReason>("SLS_LST_CANCELREASON_SP", prmRecId).ToList();
                return rec;
            }
        }

        public IEnumerable<Overtech.DataModels.Reconciliation.Reconciliation> ReconciliationStoreDate(long storeId, DateTime startDate, DateTime endDate)
        {
            using (IDAL dal = this.DAL)
            {
                IEnumerable<Overtech.DataModels.Reconciliation.Reconciliation> rec;
                

                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);
                rec = dal.List<Overtech.DataModels.Reconciliation.Reconciliation>("RCL_LST_STOREDATE_SP", prmStoreId, prmStartDate, prmEndDate).ToList();

                /*
                foreach (Overtech.DataModels.Reconciliation.Reconciliation r in rec)
                {
                    IUniParameter prmRecId = dal.CreateParameter("StoreRecId", r.StoreReconciliationId);
                    r.CashDist = dal.List<Overtech.DataModels.Reconciliation.CashDistribution>("RCL_LST_CASHDIST_SP", prmRecId).ToList();
                    r.CardDist = dal.List<Overtech.DataModels.Reconciliation.CardDistribution>("RCL_LST_CARDDIST_SP", prmRecId).ToList();
                    r.RecLog = dal.List<Overtech.DataModels.Reconciliation.RecLog>("RCL_LST_LOG_SP", prmRecId).ToList();
                    r.CancelReasons = dal.List<Overtech.DataModels.Sale.CancelReason>("SLS_LST_CANCELREASON_SP", prmRecId).ToList();
                }*/
                return rec;
            }
        }

        public void Recalculate(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                dal.ExecuteNonQuery("RCL_UPD_RECALCULATE_SP", prmStoreId);
            }
        }

        public Overtech.DataModels.Reconciliation.Reconciliation ReadDetails(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                DataTable dt = dal.ExecuteDataset("RCL_LST_LASTUNCOMPLETEID_SP", prmStoreId).Tables[0];
                Overtech.DataModels.Reconciliation.Reconciliation rec = new Overtech.DataModels.Reconciliation.Reconciliation();
                if (dt.Rows.Count > 0)
                {
                    long recId = long.Parse(dt.Rows[0][0].ToString());
                    IUniParameter prmStoreRecId = dal.CreateParameter("StoreReconciliationId", recId);
                    rec = dal.Read<Overtech.DataModels.Reconciliation.Reconciliation>("RCL_SEL_STORE_SP", prmStoreRecId);

                    IUniParameter prmRecId = dal.CreateParameter("StoreRecId", recId);
                    rec.CashDist = dal.List<Overtech.DataModels.Reconciliation.CashDistribution>("RCL_LST_CASHDIST_SP", prmRecId).ToList();
                    rec.CardDist = dal.List<Overtech.DataModels.Reconciliation.CardDistribution>("RCL_LST_CARDDIST_SP", prmRecId).ToList();
                    rec.RecLog = dal.List<Overtech.DataModels.Reconciliation.RecLog>("RCL_LST_LOG_SP", prmRecId).ToList();
                    rec.CancelReasons = dal.List<Overtech.DataModels.Sale.CancelReason>("SLS_LST_CANCELREASON_SP", prmRecId).ToList();
                }
                else
                {
                    rec = new DataModels.Reconciliation.Reconciliation();
                }
                return rec;
            }
        }

        public long SaveReconciliation(Overtech.DataModels.Reconciliation.Reconciliation rec)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                long recId;
                try
                {
                    if (rec.StoreReconciliationId > 0)
                    {
                        dal.Update(rec);
                        recId = rec.StoreReconciliationId;
                    } else
                    {
                        recId = dal.Create(rec);
                    }
                    foreach (CashDistribution cd in rec.CashDist)
                    {
                        cd.StoreReconciliation = recId;
                        if (cd.CashDistributionId > 0)
                            dal.Update(cd);
                        else
                            dal.Create(cd);
                    }
                    foreach (CardDistribution cd in rec.CardDist)
                    {
                        cd.StoreRec = recId;
                        if (cd.CardDistributionId > 0)
                            dal.Update(cd);
                        else
                            dal.Create(cd);
                    }
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw (ex);
                }
                return recId;
            }
        }

        public long createZControlLog(ZControlLog rec)
        {
            long returnValue = 0;
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmZControlLogId = dal.CreateParameter("ZControlLogId", 4, ParameterDirection.Output, 0);
                    IUniParameter prmStore = dal.CreateParameter("Store", rec.Store);
                    IUniParameter prmReconciliationDate = dal.CreateParameter("ReconciliationDate", rec.ReconciliationDate);
                    IUniParameter prmZetAmount = dal.CreateParameter("ZetAmount", rec.ZetAmount);
                    dal.ExecuteNonQuery("RCL_INS_ZCONTROLLOG_SP", prmZControlLogId, prmStore, prmReconciliationDate, prmZetAmount);
                    returnValue = prmZControlLogId.Value.To<long>();
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                }
                return returnValue;
            }
        }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}