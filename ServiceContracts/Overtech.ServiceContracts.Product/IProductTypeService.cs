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
    public interface IProductTypeService : ICRUDLServiceContract<Overtech.DataModels.Product.ProductType>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Product.ProductType Find(string subgroup);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

