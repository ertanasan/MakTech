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
    public interface IReturnReasonService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.ReturnReason>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Warehouse.ReturnReason Find(string reasonName);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

