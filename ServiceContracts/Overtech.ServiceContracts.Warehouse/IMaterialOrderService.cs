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
    public interface IMaterialOrderService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.MaterialOrder>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        void UpdateStatus(int StatusCode, long[] MaterialOrderIdList);

        [OperationContract]
        void TakeOrderAction(int ActionCode, long[] MaterialOrderIdList);

        [OperationContract]
        IEnumerable<MaterialOrder> ListOrders(DateTime StartDate, Boolean AllRecords);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

