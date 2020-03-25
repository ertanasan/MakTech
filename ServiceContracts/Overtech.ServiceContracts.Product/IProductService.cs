// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Product;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Product
{
    [ServiceContract]
    public interface IProductService : ICRUDLServiceContract<Overtech.DataModels.Product.Product>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Product.Product Find(string name);

        /*Section="Method-ListProductProperties"*/
        [OperationContract]
        IEnumerable<ProductProperty> ListProductProperties(long productId);


        /*Section="Method-ListProductBarcodes"*/
        [OperationContract]
        IEnumerable<ProductBarcode> ListProductBarcodes(long productId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        DataTable ListHotKeys();

        [OperationContract]
        DataTable ListHotKeys32();

        [OperationContract]
        DataTable ListHotKeys56();

        [OperationContract]
        IEnumerable<Overtech.DataModels.Product.Product> ListConsignmentGoods();
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

