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
using System.Data;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class OrderStatusHistoryService : CRUDLDataService<Overtech.DataModels.Warehouse.OrderStatusHistory>, IOrderStatusHistoryService
    {
        /*Section="Constructor-1"*/
        public OrderStatusHistoryService()
        {
        }

        /*Section="Constructor-2"*/
        internal OrderStatusHistoryService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public DataTable ReturnOrderStatusHistory(long returnOrderId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmReturnOrderId = dal.CreateParameter("ReturnOrderId", returnOrderId);
                return dal.ExecuteDataset("WHS_LST_RETORDSTATUSHIST_SP", prmReturnOrderId).Tables[0];
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}