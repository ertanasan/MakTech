// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using Overtech.Core.DataSource;
using Overtech.UI.DataSource;
using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Sale;
using System.Data;
using System;
using Overtech.ViewModels.Sale;
using System.Runtime.Serialization;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Sale
{
    public class DeviceInfoModel
    {
        [DataMember]
        public string DeviceInfo { get; set; }
    }

    [RoutePrefix("api/Sale/Sales")]
    public class SalesController : CRUDLApiController<Overtech.DataModels.Sale.Sales, ISalesService, Overtech.ViewModels.Sale.Sales>
    {
        /*Section="Constructor"*/
        public SalesController(
            ILoggerFactory loggerFactory,
            ISalesService salesService)
            : base(loggerFactory, salesService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [Route("GetDashboardData")]
        [OTControllerAction("GetReport")]
        public DataSourceResult GetDashboardData([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request)
        {
            DataSourceResult result;    
            DataTable dtReport = null;
            dtReport = _dataService.GetDashboardSaleData();
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("GetDashboardCategoryData")]
        [OTControllerAction("GetReport")]
        public DataSourceResult GetDashboardCategoryData([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request)
        {
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.GetDashboardSaleCategoryData();
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("GetDashboardStoreCount")]
        [OTControllerAction("GetReport")]
        public DataSourceResult GetDashboardStoreCount([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request)
        {
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.GetDashboardStoreCount();
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("GetDashboardMissingSaleStore")]
        [OTControllerAction("GetReport")]
        public DataSourceResult GetDashboardMissingSaleStore([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request)
        {
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.GetDashboardMissingSaleStore();
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("GetDashboardZCompare")]
        [OTControllerAction("GetReport")]
        public DataSourceResult GetDashboardZCompare(int period, DateTime baseDate, bool termDetail)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.GetDashboardZCompare(period, baseDate, termDetail);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("GetMissingZet")]
        [OTControllerAction("GetReport")]
        public DataSourceResult GetMissingZet()
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.GetMissingZet();
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("GetRegionManagerSales")]
        [OTControllerAction("GetReport")]
        public DataSourceResult GetRegionManagerSales([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request)
        {
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.GetRegionManagerSales();
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("GetDashboardStoreData")]
        [OTControllerAction("GetReport")]
        public DataSourceResult GetDashboardStoreData([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request)
        {
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.GetDashboardStoreData();
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("GetCategoryStoreData")]
        [OTControllerAction("GetReport")]
        public DataSourceResult GetCategoryStoreData(string categoryName, int productId, DateTime endDate, int dayGroup)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.GetCategoryStoreData(categoryName, productId, endDate, dayGroup);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("GetCategoryProductData")]
        [OTControllerAction("GetReport")]
        public DataSourceResult GetCategoryProductData(string categoryName, int storeId, DateTime endDate, int dayGroup)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.GetCategoryProductData(categoryName, storeId, endDate, dayGroup);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("GetSaleByCategoryName")]
        [OTControllerAction("GetReport")]
        public DataSourceResult GetSaleByCategoryName(string categoryName, int storeId, DateTime endDate, int productId)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.GetSaleByCategoryName (categoryName, storeId, endDate, productId);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("StockOutSummary")]
        [OTControllerAction("List")]
        public DataSourceResult StockOutSummary(DateTime startDate, DateTime endDate, int storeCountSold, int categoryId)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.StockOutSummary(startDate, endDate, storeCountSold, categoryId);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("StockOutStore")]
        [OTControllerAction("List")]
        public DataSourceResult StockOutStore(DateTime startDate, DateTime endDate, int storeCountSold, int storeId, int categoryId)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.StockOutStore(startDate, endDate, storeCountSold, storeId, categoryId);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ListDateStore")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Sale.Sales> ListDate(System.DateTime transactionDate, long storeId)
        {
            return _dataService.ListDateStore(transactionDate, storeId).Map<Overtech.DataModels.Sale.Sales, Overtech.ViewModels.Sale.Sales>();
        }

        [HttpGet]
        [Route("ListSalesComparison")]
        [OTControllerAction("List")]
        public DataSourceResult ListSalesComparison(long? storeId, DateTime startDate, DateTime endDate, DateTime comparingStartDate, DateTime comparingEndDate)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListSalesComparison(storeId, startDate, endDate, comparingStartDate, comparingEndDate);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ListSalesSummaryReport")]
        [OTControllerAction("List")]
        public DataSourceResult ListSalesSummaryReport(long? storeId, DateTime startDate, DateTime endDate, string aggregationFlag)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListSalesSummaryReport(storeId, startDate, endDate, aggregationFlag);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }


        [HttpGet]
        [Route("ListMikroData")]
        [OTControllerAction("List")]
        public DataSourceResult ListMikroData( DateTime startDate, DateTime endDate, int checkDate)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListMikroData( startDate, endDate, checkDate);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpPost]
        [Route("LoadMikro/{transactionDate}/{storeId}")]
        [OTControllerAction("Create")]
        public void LoadMikro(DateTime transactionDate,int storeId)
        {
            
            _dataService.LoadMikro(transactionDate, storeId);
          
        }

        [HttpGet]
        [Route("StoreDashboardSaleInfo")]
        [OTControllerAction("List")]
        public DataSourceResult StoreDashboardSaleInfo(long storeId)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.StoreDashboardSaleInfo(storeId);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("StoreDashboardStockInfo")]
        [OTControllerAction("List")]
        public DataSourceResult StoreDashboardStockInfo(long storeId)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.StoreDashboardStockInfo(storeId);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("StoreDashboardDailyStockOut")]
        [OTControllerAction("List")]
        public DataSourceResult StoreDashboardDailyStockOut(long storeId, int dayCount)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.StoreDashboardDailyStockOut(storeId, dayCount);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("StoreDashboardDayStockOut")]
        [OTControllerAction("List")]
        public DataSourceResult StoreDashboardDayStockOut(long storeId, int dayCount, DateTime day)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.StoreDashboardDayStockOut(storeId, dayCount, day);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ListStoreSales")]
        [OTControllerAction("List")]
        public DataSourceResult ListStoreSales([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request)
        {
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListStoreSales();
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ListStoreCategorySale")]
        [OTControllerAction("List")]
        public DataSourceResult ListStoreCategorySale(long storeId)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.StoreCategorySale(storeId);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ListStoreCategoryProductSale")]
        [OTControllerAction("List")]
        public DataSourceResult ListStoreCategoryProductSale(long storeId, int categoryId)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.StoreCategoryProductSale(storeId, categoryId);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("DailySaleTrendByStore")]
        [OTControllerAction("List")]
        public DataSourceResult DailySaleTrendByStore(long storeId, DateTime startDate, DateTime endDate)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.DailySaleTrendByStore(storeId, startDate, endDate);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ListRefunds")]
        [OTControllerAction("List")]
        public IEnumerable<Refund> ListRefunds(long storeId, int productId)
        {
            return _dataService.ListRefunds(storeId, productId).Map<Overtech.DataModels.Sale.Refund, Refund>();
        }

        [HttpGet]
        [Route("ReadRefund")]
        [OTControllerAction("List")]
        public Refund ReadRefund(long saleDetailId)
        {
            return _dataService.ReadRefund(saleDetailId).Map<Overtech.DataModels.Sale.Refund, Refund>();
        }

        [HttpPost]
        [Route("LogDeviceInfo")]
        [OTControllerAction("GetReport")]
        public void LogDeviceInfo(DeviceInfoModel viewModel)
        {
            _dataService.LogDeviceInfo(viewModel.DeviceInfo);
        }

        [HttpGet]
        [Route("ListCancelledSale")]
        [OTControllerAction("List")]
        public IEnumerable<Sales> ListCancelledSale(int storeId, DateTime startDate, DateTime endDate)
        {
            try
            {
                IEnumerable<Sales> result = _dataService.ListCancelledSale(storeId, startDate, endDate).Map<Overtech.DataModels.Sale.Sales, Sales>();
                return result;
            }
            catch (Exception ex)
            {
                _logger.Debug($"ListCancelledSale Exception : {ex.ToString()}");
                throw ex;
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}