// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Product;
using Overtech.DataModels.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Warehouse
{
    [ServiceContract]
    public interface IStockTakingService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.StockTaking>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized

        [OperationContract]
        IEnumerable<StockTaking> ListStockTakingProducts(long scheduleId);

        [OperationContract]
        void UpdateStockTakings(IEnumerable<StockTaking> stockTakingList);

        [OperationContract]
        DataTable ListCurrentStocks(long storeId);

        [OperationContract]
        DataTable ListStockTransactions(long storeId, long productId, decimal currentStock);

        [OperationContract]
        decimal InsertFromBarcodeReader(long scheduleId, int zoneId, int opCode, string eanCode, decimal manualWeight);

        [OperationContract]
        DataTable ListStocksAtCriticalLevel(long storeId);

        [OperationContract]
        DataTable ListStocktracking(DateTime startDate);

        [OperationContract]
        DataTable ListStocktrackingProducts(long product, DateTime startDate, DateTime endDate);

        [OperationContract]
        DataTable ListDailyStockTrendByStore(long store, DateTime startDate, DateTime endDate);

        [OperationContract]
        void FastEntryUpdate(StockTaking stockTaking);
        
        [OperationContract]
        void MikroTransfer();

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

