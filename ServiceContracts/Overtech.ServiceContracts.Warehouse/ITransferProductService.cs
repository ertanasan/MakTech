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
    public interface ITransferProductService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.TransferProduct>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        void TakeAction(DataModels.Warehouse.TransferProduct dataObject, long actionId, string choice, string comment);

        [OperationContract]
        void TriggerTransferProcess(DataModels.Warehouse.TransferProduct dataObject);

        [OperationContract]
        void UpdateStatus(long transferProductId,long statusId);

        [OperationContract]
        void TransferToMikro(long transferProductId, long statusId, bool toWarehouse);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

