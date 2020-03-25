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
    public interface IStoreAccountsService : ICRUDLServiceContract<Overtech.DataModels.Store.StoreAccounts>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        IEnumerable<StoreAccounts> ListStoreAccounts(long storeId);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

