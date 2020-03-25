// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Price;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Price
{
    [ServiceContract]
    public interface IStorePackageService : ICRUDLServiceContract<Overtech.DataModels.Price.StorePackage>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        void CreateStorePackage(StorePackage storePackage);

        [OperationContract]
        IEnumerable<StorePackage> ListStorePackagesByStoreId(long packageId);
        
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

