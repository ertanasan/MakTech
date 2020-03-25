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
    public interface IStoreOrderHistoryService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.StoreOrderHistory>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        IEnumerable<StoreOrderHistory> ListStoreOrderHistory(long storeOrderId);

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

