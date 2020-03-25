// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Sale;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Sale
{
    [ServiceContract]
    public interface ISalesService : ICRUDLServiceContract<Overtech.DataModels.Sale.Sales>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        DataTable GetDashboardSaleData();

        [OperationContract]
        DataTable GetDashboardSaleCategoryData();

        [OperationContract]
        DataTable GetDashboardStoreData();

        [OperationContract]
        DataTable GetDashboardStoreCount();

        [OperationContract]
        DataTable GetDashboardMissingSaleStore();

        [OperationContract]
        DataTable GetDashboardZCompare(int period, DateTime baseDate, bool termDetail);

        [OperationContract]
        DataTable GetMissingZet();

        [OperationContract]
        DataTable GetCategoryStoreData(string categoryName, int productId, DateTime endDate, int dayGroup);

        [OperationContract]
        DataTable GetCategoryProductData(string categoryName, int storeId, DateTime endDate, int dayGroup);
        
        [OperationContract]
        DataTable GetSaleByCategoryName(string categoryName, int storeId, DateTime endDate, int productId);

        [OperationContract]
        DataTable StockOutSummary(DateTime startDate, DateTime endDate, int storeCountSold, int categoryId);

        [OperationContract]
        DataTable StockOutStore(DateTime startDate, DateTime endDate, int storeCountSold, int storeId, int categoryId);
        
        [OperationContract]
        IEnumerable<Sales> ListDateStore(DateTime transactionDate, long storeId);

        [OperationContract]
        DataTable ListSalesComparison(long? storeId, DateTime startDate, DateTime endDate, DateTime comparingStartDate, DateTime comparingEndDate);

        [OperationContract]
        DataTable ListSalesSummaryReport(long? storeId, DateTime startDate, DateTime endDate, string aggregationFlag);

        [OperationContract]
        DataTable ListMikroData(DateTime startDate, DateTime endDate, int checkDate);

        [OperationContract]
        void LoadMikro(DateTime transactionDate, int storeId);

        [OperationContract]
        DataTable StoreDashboardSaleInfo(long storeId);

        [OperationContract]
        DataTable StoreDashboardStockInfo(long storeId);

        [OperationContract]
        DataTable StoreDashboardDailyStockOut(long storeId, int dayCount);

        [OperationContract]
        DataTable StoreDashboardDayStockOut(long storeId, int dayCount, DateTime day);

        [OperationContract]
        DataTable ListStoreSales();

        [OperationContract]
        DataTable StoreCategorySale(long storeId);

        [OperationContract]
        DataTable StoreCategoryProductSale(long storeId, int categoryId);

        [OperationContract]
        DataTable DailySaleTrendByStore(long storeId, DateTime startDate, DateTime endDate);

        [OperationContract]
        IEnumerable<Refund> ListRefunds(long storeId, int productId);

        [OperationContract]
        Refund ReadRefund(long saleDetailId);

        [OperationContract]
        void LogDeviceInfo(string deviceInfo);

        [OperationContract]
        DataTable GetRegionManagerSales();

        [OperationContract]
        IEnumerable<Sales> ListCancelledSale(int storeId, DateTime startDate, DateTime endDate);

        [OperationContract]
        IEnumerable<SaleCustomer> ListSaleCustomers(long saleId);

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

