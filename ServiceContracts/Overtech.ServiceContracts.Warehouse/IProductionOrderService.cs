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
    public interface IProductionOrderService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.ProductionOrder>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        void UpdateStatus(long requestId, int statusId);

        [OperationContract]
        void TakeAction(DataModels.Warehouse.ProductionOrder dataObject, long actionId, string choice, string comment);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

