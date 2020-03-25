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
    [RoutePrefix("api/Warehouse/GatheringStatus")]
    public class GatheringStatusController : CRUDLApiController<Overtech.DataModels.Warehouse.GatheringStatus, IGatheringStatusService, Overtech.ViewModels.Warehouse.GatheringStatus>
    {
        /*Section="Constructor"*/
        public GatheringStatusController(
            ILoggerFactory loggerFactory,
            IGatheringStatusService gatheringStatusService)
            : base(loggerFactory, gatheringStatusService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}