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
    public interface IStorePropertyService : ICRUDLServiceContract<Overtech.DataModels.Store.StoreProperty>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized

        [OperationContract]
        IEnumerable<StoreProperty> ListStoreProperties(long storeId);

        [OperationContract]
        int CreateStorePropertyForAllStores(long propertyTypeId, string value);

        [OperationContract]
        int UpdateStorePropertiyForAllStores(long propertyTypeId, string value);

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

