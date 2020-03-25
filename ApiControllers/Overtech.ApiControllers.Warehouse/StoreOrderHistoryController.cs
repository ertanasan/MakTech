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

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{
    [RoutePrefix("api/Warehouse/StoreOrderHistory")]
    public class StoreOrderHistoryController : CRUDLApiController<Overtech.DataModels.Warehouse.StoreOrderHistory, IStoreOrderHistoryService, Overtech.ViewModels.Warehouse.StoreOrderHistory>
    {
        /*Section="Constructor"*/
        public StoreOrderHistoryController(
            ILoggerFactory loggerFactory,
            IStoreOrderHistoryService storeOrderHistoryService)
            : base(loggerFactory, storeOrderHistoryService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [OTControllerAction("List")]
        [Route("ListStoreOrderHistory")]
        public IEnumerable<Overtech.DataModels.Warehouse.StoreOrderHistory> WarehouseProductUnits(long storeOrderId)
        {
            return _dataService.ListStoreOrderHistory(storeOrderId);
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}