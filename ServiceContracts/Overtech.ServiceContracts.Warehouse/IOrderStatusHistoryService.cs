// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Warehouse
{
    [ServiceContract]
    public interface IOrderStatusHistoryService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.OrderStatusHistory>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        DataTable ReturnOrderStatusHistory(long returnOrderId);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

