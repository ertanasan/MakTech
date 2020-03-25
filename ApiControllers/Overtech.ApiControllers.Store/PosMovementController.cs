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
using Overtech.ServiceContracts.Store;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Store
{
    [RoutePrefix("api/Store/PosMovement")]
    public class PosMovementController : CRUDLApiController<Overtech.DataModels.Store.PosMovement, IPosMovementService, Overtech.ViewModels.Store.PosMovement>
    {
        /*Section="Constructor"*/
        public PosMovementController(
            ILoggerFactory loggerFactory,
            IPosMovementService posMovementService)
            : base(loggerFactory, posMovementService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpPost]
        [OTControllerAction("List")]
        [Route("PosMoveInitial")]
        public void PosMoveInitial()
        {
            _dataService.PosMoveInitial();
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}