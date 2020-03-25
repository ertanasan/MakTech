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
    public interface IStorePropertyTypeService : ICRUDLServiceContract<Overtech.DataModels.Store.StorePropertyType>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        IEnumerable<StorePropertyType> ListRemaningPropertyTypes(long storeId);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

