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
using Overtech.ServiceContracts.Warehouse;
using System;
using System.Data;
using System.Net.Http;
using Overtech.ViewModels.Warehouse;
using System.Net;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{
    [RoutePrefix("api/Warehouse/StockTaking")]
    public class StockTakingController : CRUDLApiController<Overtech.DataModels.Warehouse.StockTaking, IStockTakingService, Overtech.ViewModels.Warehouse.StockTaking>
    {
        /*Section="Constructor"*/
        public StockTakingController(
            ILoggerFactory loggerFactory,
            IStockTakingService stockTakingService)
            : base(loggerFactory, stockTakingService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized

        [HttpPut]
        [Route("UpdateRow")]
        [OTControllerAction("Update")]
        public HttpResponseMessage UpdateRow(StockTaking viewModel)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _dataService.Update(viewModel.Map<Overtech.DataModels.Warehouse.StockTaking, StockTaking>());
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent(ex.Message);
            }
            return response;

        }

        [HttpGet]
        [Route("ListStockTakingProducts")]
        [OTControllerAction("List")]
        public virtual IEnumerable<Overtech.ViewModels.Warehouse.StockTaking> ListStoreOrderDetails(long scheduleId)
        {
            return _dataService.ListStockTakingProducts(scheduleId).Map<Overtech.DataModels.Warehouse.StockTaking, Overtech.ViewModels.Warehouse.StockTaking>();
        }

        [HttpPut]
        [Route("PostStoreTakingDetails")]
        [OTControllerAction("Update")]
        public void PostStoreOrderDetails(IEnumerable<Overtech.ViewModels.Warehouse.StockTaking> stockTakings)
        {
            _dataService.UpdateStockTakings(stockTakings.Map<Overtech.DataModels.Warehouse.StockTaking, Overtech.ViewModels.Warehouse.StockTaking>());
        }

        [HttpPut]
        [Route("FastEntryUpdate")]
        [OTControllerAction("Update")]
        public void FastEntryUpdate(Overtech.ViewModels.Warehouse.StockTaking stockTaking)
        {
            _dataService.FastEntryUpdate(stockTaking.Map<Overtech.DataModels.Warehouse.StockTaking, Overtech.ViewModels.Warehouse.StockTaking>());
        }

        [HttpGet]
        [Route("InsertFromBarcodeReader")]
        [OTControllerAction("Update")]
        public decimal InsertFromBarcodeReader(long scheduleId, int zoneId, int opCode, string eanCode, decimal manualWeight)
        {
            return _dataService.InsertFromBarcodeReader(scheduleId, zoneId, opCode, eanCode, manualWeight);
        }

        [HttpGet]
        [Route("ListCurrentStocks")]
        [OTControllerAction("List")]
        public DataSourceResult ListCurrentStocks(long storeId)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListCurrentStocks(storeId);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ListStockTransactions")]
        [OTControllerAction("List")]
        public DataSourceResult ListStockTransactions(long storeId, long productId, decimal currentStock)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListStockTransactions(storeId, productId, currentStock);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ListStocksAtCriticalLevel")]
        [OTControllerAction("List")]
        public DataSourceResult ListStocksAtCriticalLevel(long storeId)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListStocksAtCriticalLevel(storeId);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ListStocktracking")]
        [OTControllerAction("List")]
        public DataSourceResult ListStocktracking(DateTime startDate)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListStocktracking(startDate);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }


        [HttpGet]
        [Route("ListStocktrackingProducts")]
        [OTControllerAction("List")]
        public DataSourceResult ListStocktrackingProducts(long product, DateTime startDate , DateTime endDate)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListStocktrackingProducts(product, startDate, endDate);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ListDailyStockTrendByStore")]
        [OTControllerAction("List")]
        public DataSourceResult ListDailyStockTrendByStore(long store, DateTime startDate, DateTime endDate)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListDailyStockTrendByStore(store, startDate, endDate);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpPost]
        [Route("MikroTransfer")]
        [OTControllerAction("Create")]
        public HttpResponseMessage MikroTransfer()
        {

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _dataService.MikroTransfer();
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent(ex.Message);
            }
            return response;

        }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}