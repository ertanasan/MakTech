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

/*Section="ClassHeader"*/
namespace Overtech.Services.Reconciliation
{
    [OTInspectorBehavior]
    public class AdjustmentService : CRUDLDataService<Overtech.DataModels.Reconciliation.Adjustment>, IAdjustmentService
    {
        /*Section="Constructor-1"*/
        public AdjustmentService()
        {
        }

        /*Section="Constructor-2"*/
        internal AdjustmentService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public decimal Adjustment(long storeId, DateTime date)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmDate = dal.CreateParameter("RecDate", date);
                DataTable dt = dal.ExecuteDataset("RCL_SEL_ADJUSTMENTDATE_SP", prmStoreId, prmDate).Tables[0];
                return (decimal) dt.Rows[0][0];
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}