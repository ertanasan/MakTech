// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Warehouse
{
    [ServiceContract]
    public interface IStoreOrderDetailService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.StoreOrderDetail>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        IEnumerable<WarehouseProductUnit> getWarehouseProductUnits();

        [OperationContract]
        IEnumerable<StoreOrderDetail> listStoreOrderDetails(long storeOrderId);

        [OperationContract]
        void updateOrderDetails(IEnumerable<StoreOrderDetail> orderDetailList);

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

