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
    public interface IPackageTypeService : ICRUDLServiceContract<Overtech.DataModels.Price.PackageType>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Price.PackageType Find(string packageTypeName);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

