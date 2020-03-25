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
    public interface IPricePackageService : ICRUDLServiceContract<Overtech.DataModels.Price.PricePackage>
    {

        /*Section="Method-ListPackageVersions"*/
        [OperationContract]
        IEnumerable<PackageVersion> ListPackageVersions(long packageId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        PackagePerformance GetPackagePerformance(long packageId);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

