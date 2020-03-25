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
    public interface IReturnOrderService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.ReturnOrder>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        void UpdateStatus(long requestId, long statusId);
        [OperationContract]
        void TakeAction(DataModels.Warehouse.ReturnOrder dataObject, long actionId, string choice, string comment);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

