// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Store;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Store
{
    [ServiceContract]
    public interface IStoreScalesService : ICRUDLServiceContract<Overtech.DataModels.Store.StoreScales>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        IEnumerable<StoreScales> StoreScales(long storeId);
        [OperationContract]
        IEnumerable<StoreScales> GetUserScale();
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

