// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Product;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Product
{
    [ServiceContract]
    public interface IFixtureBrandService : ICRUDLServiceContract<Overtech.DataModels.Product.FixtureBrand>
    {

        /*Section="Method-ListFixtureModels"*/
        [OperationContract]
        IEnumerable<FixtureModel> ListFixtureModels(long fixtureBrandId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

