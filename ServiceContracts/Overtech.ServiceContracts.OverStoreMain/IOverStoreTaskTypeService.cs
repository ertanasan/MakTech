// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.OverStoreMain;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.OverStoreMain
{
    [ServiceContract]
    public interface IOverStoreTaskTypeService : ICRUDLServiceContract<Overtech.DataModels.OverStoreMain.OverStoreTaskType>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.OverStoreMain.OverStoreTaskType Find(string taskType);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

