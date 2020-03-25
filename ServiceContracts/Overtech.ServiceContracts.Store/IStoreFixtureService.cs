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
    public interface IStoreFixtureService : ICRUDLServiceContract<Overtech.DataModels.Store.StoreFixture>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        IEnumerable<StoreFixture> GetUserFixture();
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

