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
using System.Data;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{
    [RoutePrefix("api/Warehouse/StockTakingSchedule")]
    public class StockTakingScheduleController : CRUDLApiController<Overtech.DataModels.Warehouse.StockTakingSchedule, IStockTakingScheduleService, Overtech.ViewModels.Warehouse.StockTakingSchedule>
    {
        /*Section="Constructor"*/
        public StockTakingScheduleController(
            ILoggerFactory loggerFactory,
            IStockTakingScheduleService stockTakingScheduleService)
            : base(loggerFactory, stockTakingScheduleService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [Route("ActiveSchedules")]
        [OTControllerAction("List")]
        public virtual IEnumerable<Overtech.ViewModels.Warehouse.StockTakingSchedule> ActiveSchedules()
        {
            return _dataService.ActiveSchedules().Map<Overtech.DataModels.Warehouse.StockTakingSchedule, Overtech.ViewModels.Warehouse.StockTakingSchedule>();
        }

        [HttpGet]
        [Route("CountedStores")]
        [OTControllerAction("List")]
        public virtual IEnumerable<ViewModels.Store.Store> CountedStores()
        {
            return _dataService.CountedStores().Map<Overtech.DataModels.Store.Store, Overtech.ViewModels.Store.Store>();
        }

        [HttpGet]
        [Route("DrillCountPerformance")]
        [OTControllerAction("List")]
        public DataSourceResult DrillCountPerformance()
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.DrillCountPerformance();
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("DrillCountPerformanceDetail")]
        [OTControllerAction("List")]
        public DataSourceResult DrillCountPerformanceDetail(int storeId)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.DrillCountPerformanceDetail(storeId);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}