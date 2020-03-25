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
    [RoutePrefix("api/Store/Pos")]
    public class PosController : CRUDLApiController<Overtech.DataModels.Store.Pos, IPosService, Overtech.ViewModels.Store.Pos>
    {
        private readonly IPosService _posService;


        /*Section="Constructor"*/
        public PosController(
            ILoggerFactory loggerFactory,
            IPosService posService)
            : base(loggerFactory, posService)
        {
            _posService = posService;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.

        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Store.Pos> ListByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Store.Pos> dataModel = _posService.ListStorePos(masterId);
            IEnumerable<Overtech.ViewModels.Store.Pos> viewModel = dataModel.Map<Overtech.DataModels.Store.Pos, Overtech.ViewModels.Store.Pos>();
            return viewModel;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}