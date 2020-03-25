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
    public class FakeOrderService : CRUDLDataService<Overtech.DataModels.Warehouse.FakeOrder>, IFakeOrderService
    {
        /*Section="Constructor-1"*/
        public FakeOrderService()
        {
        }

        /*Section="Constructor-2"*/
        internal FakeOrderService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public override FakeOrder Create(FakeOrder fakeOrder)
        {
            if (fakeOrder.StoreList.Length > 0)
            {
                using (IDAL dal = this.DAL)
                {
                    dal.BeginTransaction();
                    try
                    {
                        foreach (int storeId in fakeOrder.StoreList)
                        {
                            FakeOrder tmpOrder = fakeOrder;
                            tmpOrder.Store = storeId;
                            dal.Create<FakeOrder>(tmpOrder);
                        }
                        dal.CommitTransaction();
                        return fakeOrder;
                    } catch (Exception ex)
                    {
                        dal.RollbackTransaction();
                        throw ex;
                    }
                }
            } else
            {
                return base.Create(fakeOrder);
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}