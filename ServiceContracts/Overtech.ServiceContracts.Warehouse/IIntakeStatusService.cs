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
    public interface IIntakeStatusService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.IntakeStatus>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        void TransferToMikro(long[] storeOrderDetailIds);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

