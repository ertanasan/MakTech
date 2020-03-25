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
    public interface IProductCategoryService : ICRUDLServiceContract<Overtech.DataModels.Product.ProductCategory>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Product.ProductCategory Find(string category);

        /*Section="Method-ListSubgroups"*/
        [OperationContract]
        IEnumerable<Subgroup> ListSubgroups(long categoryID);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

