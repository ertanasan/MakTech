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
    [RoutePrefix("api/Warehouse/ShipmentSchedule")]
    public class ShipmentScheduleController : CRUDLApiController<Overtech.DataModels.Warehouse.ShipmentSchedule, IShipmentScheduleService, Overtech.ViewModels.Warehouse.ShipmentSchedule>
    {
        private readonly IShipmentScheduleService _shipmentScheduleService;

        /*Section="Constructor"*/
        public ShipmentScheduleController(
            ILoggerFactory loggerFactory,
            IShipmentScheduleService shipmentScheduleService)
            : base(loggerFactory, shipmentScheduleService)
        {
            _shipmentScheduleService = shipmentScheduleService;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Warehouse.ShipmentSchedule> ListByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Warehouse.ShipmentSchedule> dataModel = _shipmentScheduleService.ListShipmentSchedules(masterId);
            IEnumerable<Overtech.ViewModels.Warehouse.ShipmentSchedule> viewModel = dataModel.Map<Overtech.DataModels.Warehouse.ShipmentSchedule, Overtech.ViewModels.Warehouse.ShipmentSchedule>();
            return viewModel;
        }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}