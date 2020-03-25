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
    [RoutePrefix("api/Warehouse/OrderStatusHistory")]
    public class OrderStatusHistoryController : CRUDLApiController<Overtech.DataModels.Warehouse.OrderStatusHistory, IOrderStatusHistoryService, Overtech.ViewModels.Warehouse.OrderStatusHistory>
    {
        /*Section="Constructor"*/
        public OrderStatusHistoryController(
            ILoggerFactory loggerFactory,
            IOrderStatusHistoryService orderStatusHistoryService)
            : base(loggerFactory, orderStatusHistoryService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [Route("ReturnOrderStatusHistory")]
        [OTControllerAction("List")]
        public DataSourceResult ReturnOrderStatusHistory(long returnOrderId)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ReturnOrderStatusHistory(returnOrderId);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}