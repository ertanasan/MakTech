// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Sale;
using Overtech.ServiceContracts.Sale;

/*Section="ClassHeader"*/
namespace Overtech.Services.Sale
{
    [OTInspectorBehavior]
    public class SaleDailySummaryService : CRUDLDataService<Overtech.DataModels.Sale.SaleDailySummary>, ISaleDailySummaryService
    {
        /*Section="Constructor-1"*/
        public SaleDailySummaryService()
        {
        }

        /*Section="Constructor-2"*/
        internal SaleDailySummaryService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<SaleDailySummary> ListDate(DateTime transactionDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmTransactionDate = dal.CreateParameter("TransactionDate", transactionDate);
                IEnumerable<SaleDailySummary> zet = dal.List<SaleDailySummary>("SLS_LST_SALEZET_SP", prmTransactionDate).ToList();
                return zet;
            }
        }

        public IEnumerable<SaleDailySummary> StoreZet(DateTime transactionDate, long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmTransactionDate = dal.CreateParameter("TransactionDate", transactionDate);
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IEnumerable<SaleDailySummary> zet = dal.List<SaleDailySummary>("SLS_LST_STORESALEZET_SP", prmTransactionDate, prmStoreId).ToList();
                return zet;
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}