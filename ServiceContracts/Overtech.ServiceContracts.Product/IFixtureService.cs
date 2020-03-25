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
    public interface IFixtureService : ICRUDLServiceContract<Overtech.DataModels.Product.Fixture>
    {

        /*Section="Method-ListFixtureBrands"*/
        [OperationContract]
        IEnumerable<FixtureBrand> ListFixtureBrands(long fixtureId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

