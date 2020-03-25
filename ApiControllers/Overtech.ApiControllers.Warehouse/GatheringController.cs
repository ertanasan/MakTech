// Created by OverGenerator
/*Section="Usings"*/
using System;
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
using System.Net.Http;
using System.Web;
using System.Net;
using System.Data;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{
    [RoutePrefix("api/Warehouse/Gathering")]
    public class GatheringController : CRUDLApiController<Overtech.DataModels.Warehouse.Gathering, IGatheringService, Overtech.ViewModels.Warehouse.Gathering>
    {
        /*Section="Constructor"*/
        public GatheringController(
            ILoggerFactory loggerFactory,
            IGatheringService gatheringService)
            : base(loggerFactory, gatheringService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized

        // Keep your custom code in this region.
        [HttpGet]
        [Route("GetPendingGathering")]
        [OTControllerAction("Read")]
        public Overtech.ViewModels.Warehouse.Gathering GetPendingGathering(int productGroup)
        {
            return _dataService.GetPendingGathering(productGroup).Map<Overtech.DataModels.Warehouse.Gathering, Overtech.ViewModels.Warehouse.Gathering>();
        }

        [HttpGet]
        [Route("GetGatheringPoolStats")]
        [OTControllerAction("Read")]
        public ViewModels.Warehouse.GatheringStats GetGatheringPoolStats(string purpose)
        {
            return _dataService.GetGatheringPoolStats(purpose).Map<Overtech.DataModels.Warehouse.GatheringStats, Overtech.ViewModels.Warehouse.GatheringStats>();
        }

        [HttpPost]
        [Route("StartGathering/{gatheringId}/{allowReGather}")]
        [OTControllerAction("Update")]
        public int StartGathering(long gatheringId, string allowReGather)
        {
            return _dataService.StartGathering(gatheringId, (allowReGather == "Y"));
        }

        [HttpPut]
        [Route("CompleteGathering")]
        [OTControllerAction("Update")]
        public void CompleteGathering(ViewModels.Warehouse.Gathering gathering)
        {
            _dataService.CompleteGathering(gathering.GatheringId);
        }

        [HttpPut]
        [Route("AbortGathering")]
        [OTControllerAction("Update")]
        public void AbortGathering(ViewModels.Warehouse.Gathering gathering)
        {
            _dataService.AbortGathering(gathering.GatheringId);
        }

        [HttpGet]
        [Route("GetGatheringByStoreOrder")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Warehouse.Gathering> GetGatheringByStoreOrder(long storeOrderId)
        {
            return _dataService.GetGatheringByStoreOrder(storeOrderId).Map<Overtech.DataModels.Warehouse.Gathering, Overtech.ViewModels.Warehouse.Gathering>();
        }

        [HttpGet]
        [Route("ListByShipmentDate")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Warehouse.Gathering> ListByShipmentDate(DateTime startDate, DateTime endDate)
        {
            return _dataService.ListByShipmentDate(startDate, endDate).Map<Overtech.DataModels.Warehouse.Gathering, Overtech.ViewModels.Warehouse.Gathering>();
        }

        [HttpGet]
        [Route("ListActiveGatherings")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Warehouse.Gathering> ListActiveGatherings(int productGroup, int gatheringStatus)
        {
            return _dataService.ListActiveGatherings(productGroup, gatheringStatus).Map<Overtech.DataModels.Warehouse.Gathering, Overtech.ViewModels.Warehouse.Gathering>();
        }

        [HttpGet]
        [Route("GetGatheringControlList")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Warehouse.GatheringControlList> GetGatheringControlList(DateTime ShipmentDate)
        {
            return _dataService.GetGatheringControlList(ShipmentDate).Map<Overtech.DataModels.Warehouse.GatheringControlList, Overtech.ViewModels.Warehouse.GatheringControlList>();
        }

        [HttpGet]
        [Route("ListOrderGathering")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Warehouse.OrderGathering> ListOrderGathering(long storeOrderId)
        {
            return _dataService.ListOrderGathering(storeOrderId).Map<Overtech.DataModels.Warehouse.OrderGathering, Overtech.ViewModels.Warehouse.OrderGathering>();
        }

        [HttpPost]
        [Route("TransferGathering/{storeOrderId}")]
        [OTControllerAction("Update")]
        public HttpResponseMessage TransferGathering(long storeOrderId)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _dataService.TransferGathering(storeOrderId);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent(ex.Message);
            }
            return response;

        }

        [HttpGet]
        [Route("WarehouseDashboard")]
        [OTControllerAction("List")]
        public ViewModels.Warehouse.WHDashboard WarehouseDashboard()
        {
            return _dataService.GetDashboardInfo().Map<DataModels.Warehouse.WHDashboard, ViewModels.Warehouse.WHDashboard>();
        }

        [HttpGet]
        [Route("DashboardHourGathering")]
        [OTControllerAction("List")]
        public DataSourceResult DashboardHourGathering()
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.DashboardHourGathering();
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("WDashboardOrder")]
        [OTControllerAction("List")]
        public ViewModels.Warehouse.WDashboardOrder WDashboardOrder()
        {
            IMapperConfig mapperConfig = MapperConfig.Init()
                                                     .CreateMap<DataModels.Warehouse.WDashboardOrder, ViewModels.Warehouse.WDashboardOrder>()
                                                     .CreateMap<DataModels.Warehouse.WDWidgetData, ViewModels.Warehouse.WDWidgetData>()
                                                     .CreateMap<DataModels.Warehouse.WDGatheringDifference, ViewModels.Warehouse.WDGatheringDifference>()
                                                     .CreateMap<DataModels.Warehouse.OrderTrend, ViewModels.Warehouse.OrderTrend>();
            return _dataService.GetWDashboardOrderInfo().Map<DataModels.Warehouse.WDashboardOrder, ViewModels.Warehouse.WDashboardOrder>(mapperConfig);
        }

        [HttpGet]
        [Route("WDOrderTrendData")]
        [OTControllerAction("List")]
        public IEnumerable<ViewModels.Warehouse.OrderTrend> WDOrderTrendData(string trendDataType, int dayCount)
        {
            return _dataService.WDOrderTrendData(trendDataType, dayCount).Map<DataModels.Warehouse.OrderTrend, ViewModels.Warehouse.OrderTrend>();
        }

        [HttpGet]
        [Route("WDashboardGathering")]
        [OTControllerAction("List")]
        public ViewModels.Warehouse.WDashboardGathering WDashboardGathering(int gatheringType)
        {
            IMapperConfig mapperConfig = MapperConfig.Init()
                                                     .CreateMap<DataModels.Warehouse.WDashboardGathering, ViewModels.Warehouse.WDashboardGathering>()
                                                     .CreateMap<DataModels.Warehouse.WDGatherPerformanceSummary, ViewModels.Warehouse.WDGatherPerformanceSummary>()
                                                     .CreateMap<DataModels.Warehouse.WDGatheringTrend, ViewModels.Warehouse.WDGatheringTrend>();
            return _dataService.GetWDashboardGatheringInfo(gatheringType).Map<DataModels.Warehouse.WDashboardGathering, ViewModels.Warehouse.WDashboardGathering>(mapperConfig);
        }

        [HttpGet]
        [Route("WDGatheringTrendData")]
        [OTControllerAction("List")]
        public IEnumerable<ViewModels.Warehouse.WDGatheringTrend> WDGatheringTrendData(int gatheringType, int trendDataType, int dayCount, int gatheringUserId)
        {
            return _dataService.WDGatheringTrendData(gatheringType, trendDataType, dayCount, gatheringUserId).Map<DataModels.Warehouse.WDGatheringTrend, ViewModels.Warehouse.WDGatheringTrend>();
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}