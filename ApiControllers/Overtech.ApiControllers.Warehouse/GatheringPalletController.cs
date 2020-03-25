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
using Overtech.ViewModels.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{
    [RoutePrefix("api/Warehouse/GatheringPallet")]
    public class GatheringPalletController : CRUDLApiController<Overtech.DataModels.Warehouse.GatheringPallet, IGatheringPalletService, Overtech.ViewModels.Warehouse.GatheringPallet>
    {
        /*Section="Constructor"*/
        public GatheringPalletController(
            ILoggerFactory loggerFactory,
            IGatheringPalletService gatheringPalletService)
            : base(loggerFactory, gatheringPalletService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [Route("ActiveControlPallets")]
        [OTControllerAction("List")]
        public IEnumerable<GatheringPallet> GetTolerancePct()
        {
            return _dataService.ActiveControlPallets().Map<Overtech.DataModels.Warehouse.GatheringPallet, GatheringPallet>();
        }

        [HttpPost]
        [Route("StartControl/{gatheringPalletId}/{allowReControl}")]
        [OTControllerAction("Update")]
        public int StartControl(long gatheringPalletId, string allowReControl)
        {
            return _dataService.StartControl(gatheringPalletId, (allowReControl == "Y"));
        }

        [HttpGet]
        [Route("GetPalletByGatheringId")]
        [OTControllerAction("Read")]
        public GatheringPallet GetPalletByGatheringId(long gatheringId, int palletNo)
        {
            return _dataService.GetPalletByGatheringId(gatheringId, palletNo).Map<Overtech.DataModels.Warehouse.GatheringPallet, GatheringPallet>();
        }

        [HttpGet]
        [Route("ListPalletByGatheringId")]
        [OTControllerAction("Read")]
        public IEnumerable<GatheringPallet> ListPalletByGatheringId(long gatheringId)
        {
            return _dataService.ListPalletByGatheringId(gatheringId).Map<Overtech.DataModels.Warehouse.GatheringPallet, GatheringPallet>();
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}