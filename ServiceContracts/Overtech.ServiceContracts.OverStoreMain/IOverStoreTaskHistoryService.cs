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
    public interface IOverStoreTaskHistoryService : ICRUDLServiceContract<Overtech.DataModels.OverStoreMain.OverStoreTaskHistory>
    {
        /*Section="Method-Search"*/
        [OperationContract]
        IEnumerable<Overtech.DataModels.OverStoreMain.OverStoreTaskHistory> Search(long? overStoreTask);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

