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
    [RoutePrefix("api/Warehouse/ProductShipmentUnit")]
    public class ProductShipmentUnitController : CRUDLApiController<Overtech.DataModels.Warehouse.ProductShipmentUnit, IProductShipmentUnitService, Overtech.ViewModels.Warehouse.ProductShipmentUnit>
    {
        private readonly IProductShipmentUnitService _productShipmentUnitService;

        /*Section="Constructor"*/
        public ProductShipmentUnitController(
            ILoggerFactory loggerFactory,
            IProductShipmentUnitService productShipmentUnitService)
            : base(loggerFactory, productShipmentUnitService)
        {
            _productShipmentUnitService = productShipmentUnitService;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.

        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Warehouse.ProductShipmentUnit> ListByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Warehouse.ProductShipmentUnit> dataModel = _productShipmentUnitService.ListProductShipmentUnit(masterId);
            IEnumerable<Overtech.ViewModels.Warehouse.ProductShipmentUnit> viewModel = dataModel.Map<Overtech.DataModels.Warehouse.ProductShipmentUnit, Overtech.ViewModels.Warehouse.ProductShipmentUnit>();
            return viewModel;
        }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}