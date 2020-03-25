// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Sale;
using Overtech.ServiceContracts.Sale;
using System.Data;
using Overtech.Core.Logger;

/*Section="ClassHeader"*/
namespace Overtech.Services.Sale
{
    [OTInspectorBehavior]
    public class SalesService : CRUDLDataService<Overtech.DataModels.Sale.Sales>, ISalesService
    {
        private ILogger _logger;

        /*Section="Constructor-1"*/
        public SalesService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.GetLogger(typeof(SalesService));
        }

        /*Section="Constructor-2"*/
        internal SalesService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public DataTable GetDashboardSaleData()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.ExecuteDataset("STR_LST_STORESALES_SP").Tables[0];
            }
        }

        public DataTable GetDashboardSaleCategoryData()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.ExecuteDataset("STR_LST_CATEGORYSALES_SP").Tables[0];
            }
        }

        #region dashboard procedures
        public DataTable GetDashboardStoreCount()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.ExecuteDataset("SLS_LST_DASHBOARDSTORECOUNT_SP").Tables[0];
            }
        }

        public DataTable GetDashboardMissingSaleStore()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.ExecuteDataset("SLS_LST_MISSINGSALESTORE_SP").Tables[0];
            }
        }

        public DataTable GetRegionManagerSales()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.ExecuteDataset("SLS_LST_REGIONMANAGERPERF_SP").Tables[0];
            }
        }

        public DataTable GetDashboardZCompare(int period, DateTime baseDate, bool termDetail)
        {
            using (IDAL dal = this.DAL)
            {
                DateTime dt = baseDate;
                switch (period)
                {
                    case 2: dt = dt.AddDays(-6); break;
                    case 3: dt = dt.AddMonths(-1).AddDays(1); break;
                }
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", dt);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", baseDate);
                IUniParameter prmTermDetail = dal.CreateParameter("TermDetail", termDetail?1:0);
                return dal.ExecuteDataset("SLS_LST_DASHBOARDZETCOMPARE_SP", prmStartDate, prmEndDate, prmTermDetail).Tables[0];
            }
        }

        public DataTable GetMissingZet()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.ExecuteDataset("SLS_LST_MISSINGZET_SP").Tables[0];
            }
        }
        
        #endregion

        public DataTable GetDashboardStoreData()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.ExecuteDataset("SLS_LST_STORECOUNTMONTHLY_SP").Tables[0];
            }
        }


        public DataTable GetCategoryStoreData(string categoryName, int productId, DateTime endDate, int dayGroup)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmCategoryName = dal.CreateParameter("CategoryName", categoryName);
                IUniParameter prmProductId = dal.CreateParameter("ProductId", productId);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);
                IUniParameter prmDayGroup = dal.CreateParameter("DayGroup", dayGroup);

                return dal.ExecuteDataset("SLS_LST_CATEGORYSTORE_SP", prmCategoryName, prmProductId, prmEndDate, prmDayGroup).Tables[0];
            }
        }

        public DataTable GetCategoryProductData(string categoryName, int storeId,DateTime endDate, int dayGroup)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmCategoryName = dal.CreateParameter("CategoryName", categoryName);
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);
                IUniParameter prmDayGroup = dal.CreateParameter("DayGroup", dayGroup);

                return dal.ExecuteDataset("SLS_LST_CATEGORYPRODUCT_SP", prmCategoryName, prmStoreId, prmEndDate, prmDayGroup).Tables[0];
            }
        }

        public DataTable GetSaleByCategoryName(string categoryName, int storeId, DateTime endDate, int productId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmCategoryName = dal.CreateParameter("Category", categoryName);
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);
                IUniParameter prmProductId = dal.CreateParameter("ProductId", productId);

                return dal.ExecuteDataset("SLS_LST_SALESBYCATEGORYNAME_SP", prmCategoryName, prmStoreId, prmEndDate, prmProductId).Tables[0];
            }
        }

        public DataTable StockOutSummary(DateTime startDate, DateTime endDate, int storeCountSold, int categoryId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);
                IUniParameter prmStoreCountSold = dal.CreateParameter("StoreCountSold", storeCountSold);
                IUniParameter prmCategoryId = dal.CreateParameter("CategoryId", categoryId);

                return dal.ExecuteDataset("SLS_LST_STOCKOUTSUMMARY_SP", prmStartDate, prmEndDate, prmStoreCountSold, prmCategoryId).Tables[0];
            }
        }

        public DataTable StockOutStore(DateTime startDate, DateTime endDate, int storeCountSold, int storeId, int categoryId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);
                IUniParameter prmStoreCountSold = dal.CreateParameter("StoreCountSold", storeCountSold);
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmCategoryId = dal.CreateParameter("CategoryId", categoryId);

                return dal.ExecuteDataset("SLS_LST_STOCKOUTPRODUCTS_SP", prmStartDate, prmEndDate, prmStoreCountSold, prmStoreId, prmCategoryId).Tables[0];
            }
        }

        public IEnumerable<Sales> ListDateStore(DateTime transactionDate, long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmTransactionDate = dal.CreateParameter("TransactionDate", transactionDate);
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IEnumerable<Sales> sale = dal.List<Sales>("SLS_LST_SALE_SP", prmTransactionDate, prmStoreId).ToList();
                return sale;
            }
        }

        public DataTable ListSalesComparison(long? storeId, DateTime startDate, DateTime endDate, DateTime comparingStartDate, DateTime comparingEndDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);
                IUniParameter prmComparingStartDate = dal.CreateParameter("ComparingStartDate", comparingStartDate);
                IUniParameter prmComparingEndDate = dal.CreateParameter("ComparingEndDate", comparingEndDate);

                return dal.ExecuteDataset("SLS_LST_SALESCOMPARISON_SP", prmStoreId, prmStartDate, prmEndDate, prmComparingStartDate, prmComparingEndDate).Tables[0];
            }
        }

        public DataTable ListSalesSummaryReport(long? storeId, DateTime startDate, DateTime endDate, string aggregationFlag)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("Store", storeId);
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);
                IUniParameter prmAggregationFlag = dal.CreateParameter("AggregationFlag", aggregationFlag);

                return dal.ExecuteDataset("SLS_LST_SALESUMMARYREPORT_SP", prmStoreId, prmStartDate, prmEndDate, prmAggregationFlag).Tables[0];
            }
        }

        public DataTable ListMikroData( DateTime startDate, DateTime endDate, int checkDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);
                IUniParameter prmcheckDate = dal.CreateParameter("checkDate", checkDate);

                return dal.ExecuteDataset("SLS_LST_MIKROTRANSFERDATA_SP", prmStartDate, prmEndDate, prmcheckDate).Tables[0];
            }
        }


        public void LoadMikro(DateTime transactionDate, int storeId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    
                    IUniParameter prmTransactionDate = dal.CreateParameter("date", transactionDate);
                    IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                  
                    dal.ExecuteNonQuery("MIK_INS_FILLWORKDATATABLES_SP", prmTransactionDate, prmStoreId);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Store Dashboardda tepedeki özet değerlerin dönmesi için... 
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public DataTable StoreDashboardSaleInfo(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                return dal.ExecuteDataset("SLS_LST_STORESALE_SP", prmStoreId).Tables[0];
            }
        }

        /// <summary>
        /// Store Dashboardda stock değerlerini göstermek için... 
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public DataTable StoreDashboardStockInfo(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                return dal.ExecuteDataset("INV_LST_STORESTOCK_SP", prmStoreId).Tables[0];
            }
        }

        /// <summary>
        /// Store Dashboardda günlük stock out değişimini göstermek için.
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="dayCount"></param>
        /// <returns></returns>
        public DataTable StoreDashboardDailyStockOut(long storeId, int dayCount)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmDayCount = dal.CreateParameter("DayCount", dayCount);
                return dal.ExecuteDataset("INV_LST_DAILYSTOCKOUT_SP", prmStoreId, prmDayCount).Tables[0];
            }
        }

        
        /// <summary>
        /// Bir güne ait stock out ürünleri verir. 
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="dayCount"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public DataTable StoreDashboardDayStockOut(long storeId, int dayCount, DateTime day)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmDayCount = dal.CreateParameter("DayCount", dayCount);
                IUniParameter prmDate = dal.CreateParameter("Date", day);
                return dal.ExecuteDataset("INV_LST_STOCKOUTDAY_SP", prmStoreId, prmDayCount, prmDate).Tables[0];
            }
        }

        public DataTable StoreCategorySale(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                return dal.ExecuteDataset("SLS_LST_STORECATEGORYSALE_SP", prmStoreId).Tables[0];
            }
        }

        public DataTable StoreCategoryProductSale(long storeId, int categoryId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmCategoryId = dal.CreateParameter("CategoryId", categoryId);
                return dal.ExecuteDataset("SLS_LST_STOREPRODUCTSALE_SP", prmStoreId, prmCategoryId).Tables[0];
            }
        }

        public DataTable ListStoreSales()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.ExecuteDataset("STR_LST_STORESALESDET_SP").Tables[0];
            }
        }

        public DataTable DailySaleTrendByStore(long storeId, DateTime startDate, DateTime endDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);
                IUniParameter prmStore = dal.CreateParameter("Store", storeId);
                return dal.ExecuteDataset("SLS_LST_DAILYSALETREND_SP", prmStartDate, prmEndDate, prmStore).Tables[0];
            }
        }

        public IEnumerable<Refund> ListRefunds(long storeId, int productId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmProductId = dal.CreateParameter("ProductId", productId);

                return dal.List<Refund>("SLS_LST_REFUND_SP", prmStoreId, prmProductId).ToList();
            }
        }

        public Refund ReadRefund(long saleDetailId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmSaleDetailId = dal.CreateParameter("SaleDetailId", saleDetailId);

                return dal.Read<Refund>("SLS_SEL_REFUND_SP", prmSaleDetailId);
            }
        }

        public void LogDeviceInfo(string deviceInfo)
        {
            
            using (IDAL dal = this.DAL)
            { 
                try
                {
                    dal.BeginTransaction();
                    IUniParameter prmDeviceInfo = dal.CreateParameter("DeviceInfo", deviceInfo);
                    dal.ExecuteNonQuery("SYS_INS_DEVICEINFO_SP", prmDeviceInfo);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    _logger.Error($"serviceName : SalesService, methodName : LogDeviceInfo, DeviceInfo : {deviceInfo}, Exception : {ex.ToString()}");
                }
            }
            
        }

        public IEnumerable<Sales> ListCancelledSale(int storeId, DateTime startDate, DateTime endDate)
        {
            using (IDAL dal = this.DAL)
            {
                try
                {
                    IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                    IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                    IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);
                    return dal.List<Sales>("SLS_LST_CANCELLEDSALE_SP", prmStoreId, prmStartDate, prmEndDate).ToList();
                }
                catch (Exception ex)
                {
                    _logger.Debug($"ListCancelledSale storeId : {storeId.ToString()}, startDate : {startDate.ToString()}, endDate : {endDate.ToString()}, exception : {ex.ToString()}");
                    throw ex;
                }
            }
        }

        public IEnumerable<SaleCustomer> ListSaleCustomers(long saleId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmSaleId = dal.CreateParameter("Sale", saleId);
                return dal.List<SaleCustomer>("SLS_LST_SALECUSTOMER_SP", prmSaleId).ToList();
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}