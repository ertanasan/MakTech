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
using System.Web.Http.ModelBinding;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{
    [RoutePrefix("api/Warehouse/StoreOrderDetail")]
    public class StoreOrderDetailController : CRUDLApiController<Overtech.DataModels.Warehouse.StoreOrderDetail, IStoreOrderDetailService, Overtech.ViewModels.Warehouse.StoreOrderDetail>
    {
        /*Section="Constructor"*/
        public StoreOrderDetailController(
            ILoggerFactory loggerFactory,
            IStoreOrderDetailService storeOrderDetailService)
            : base(loggerFactory, storeOrderDetailService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [OTControllerAction("List")]
        [Route("ListWarehouseProductUnits")]
        public IEnumerable<Overtech.DataModels.Warehouse.WarehouseProductUnit> WarehouseProductUnits()
        {
            return _dataService.getWarehouseProductUnits();
        }

        [HttpGet]
        [Route("StoreOrderDetails")]
        [OTControllerAction("List")]
        public virtual IEnumerable<Overtech.ViewModels.Warehouse.StoreOrderDetail> ListStoreOrderDetails(long storeOrderId)
        {
            return _dataService.listStoreOrderDetails(storeOrderId).Map<Overtech.DataModels.Warehouse.StoreOrderDetail, Overtech.ViewModels.Warehouse.StoreOrderDetail>();
        }

        [HttpPut]
        [Route("PostStoreOrderDetails")]
        [OTControllerAction("Update")]
        public void PostStoreOrderDetails(IEnumerable<Overtech.ViewModels.Warehouse.StoreOrderDetail> orderDetails)
        {
            _dataService.updateOrderDetails(orderDetails.Map<Overtech.DataModels.Warehouse.StoreOrderDetail, Overtech.ViewModels.Warehouse.StoreOrderDetail>());
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}