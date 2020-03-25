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
    public interface IPropertyTypeService : ICRUDLServiceContract<Overtech.DataModels.Product.PropertyType>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Product.PropertyType Find(string name);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

