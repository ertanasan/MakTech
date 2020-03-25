// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Warehouse;
using Overtech.ServiceContracts.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class IntakeStatusService : CRUDLDataService<Overtech.DataModels.Warehouse.IntakeStatus>, IIntakeStatusService
    {
        /*Section="Constructor-1"*/
        public IntakeStatusService()
        {
        }

        /*Section="Constructor-2"*/
        internal IntakeStatusService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public void TransferToMikro(long[] storeOrderDetailIds)
        {
            foreach (int id in storeOrderDetailIds)
            {
                using (IDAL dal = this.DAL)
                {
                    dal.BeginTransaction();
                    try
                    {
                        IUniParameter prmStoreOrderDetailId = dal.CreateParameter("StoreOrderDetailId", id);
                        dal.ExecuteNonQuery("WHS_INS_WAYBILLBYORDERDETAILID_SP", prmStoreOrderDetailId);
                        dal.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        dal.RollbackTransaction();
                        throw ex;
                    }
                }
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}