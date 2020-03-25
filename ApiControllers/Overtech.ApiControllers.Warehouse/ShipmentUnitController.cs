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
    [RoutePrefix("api/Warehouse/ShipmentUnit")]
    public class ShipmentUnitController : CRUDLApiController<Overtech.DataModels.Warehouse.ShipmentUnit, IShipmentUnitService, Overtech.ViewModels.Warehouse.ShipmentUnit>
    {
        /*Section="Constructor"*/
        public ShipmentUnitController(
            ILoggerFactory loggerFactory,
            IShipmentUnitService shipmentUnitService)
            : base(loggerFactory, shipmentUnitService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}