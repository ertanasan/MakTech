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
    public class StoreOrderHistoryService : CRUDLDataService<Overtech.DataModels.Warehouse.StoreOrderHistory>, IStoreOrderHistoryService
    {
        /*Section="Constructor-1"*/
        public StoreOrderHistoryService()
        {
        }

        /*Section="Constructor-2"*/
        internal StoreOrderHistoryService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<StoreOrderHistory> ListStoreOrderHistory(long storeOrderId)
        {
            IEnumerable<StoreOrderHistory> _history;
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreOrderId = dal.CreateParameter("StoreOrderId", storeOrderId);
                _history = dal.List<StoreOrderHistory>("WHS_LST_STOREORDERHISTORY_SP", prmStoreOrderId).ToList();
            }
            return _history;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}