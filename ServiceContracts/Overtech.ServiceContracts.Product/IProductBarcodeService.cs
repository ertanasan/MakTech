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
    public interface IProductBarcodeService : ICRUDLServiceContract<Overtech.DataModels.Product.ProductBarcode>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Product.ProductBarcode Find(string barcodeText);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.

        [OperationContract]
        IEnumerable<Overtech.DataModels.Product.ProductBarcode> ListBarcodeByProductId(long productId);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

