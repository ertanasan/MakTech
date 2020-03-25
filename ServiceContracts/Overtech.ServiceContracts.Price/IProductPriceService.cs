// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Price;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Price
{
    [ServiceContract]
    public interface IProductPriceService : ICRUDLServiceContract<Overtech.DataModels.Price.ProductPrice>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Price.ProductPrice Find(string productPriceId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        void updatePackagePrices(IEnumerable<ProductPrice> productPrices);

        [OperationContract]
        IEnumerable<Overtech.DataModels.Price.ProductPrice> GetPackagePrices(int packageId);

        [OperationContract]
        IEnumerable<Tuple<int, string>> ListPriceVersions();

        [OperationContract]
        IEnumerable<ProductPrice> getNewPrices(int groupCode, int storeId, int wincor);

        [OperationContract]
        DataTable PriceLoadStatus();

        [OperationContract]
        DataTable GetDeListProducts();

        [OperationContract]
        DataTable ListSalesByPriceGroups(long storeId, long productId, DateTime startDate, DateTime endDate);

        [OperationContract]
        DataTable ListSalesTrendWithPriceChanges(long? storeId, long productId, DateTime startDate, DateTime endDate);

        #endregion Customized



        /*Section="ClassFooter"*/
    }
}

