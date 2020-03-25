// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Store;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Store
{
    [RoutePrefix("api/Store/ScaleModel")]
    public class ScaleModelController : CRUDLApiController<Overtech.DataModels.Store.ScaleModel, IScaleModelService, Overtech.ViewModels.Store.ScaleModel>
    {

        private readonly IScaleBrandService _scaleBrandService;

        /*Section="Constructor"*/
        public ScaleModelController(
            ILoggerFactory loggerFactory,
            IScaleModelService scaleModelService,
            IScaleBrandService scaleBrandService
)
            : base(loggerFactory, scaleModelService)
        {
            _scaleBrandService = scaleBrandService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Store.ScaleModel> ListByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Store.ScaleModel> dataModel = _scaleBrandService.ListScaleModels(masterId);
            IEnumerable<Overtech.ViewModels.Store.ScaleModel> viewModel = dataModel.Map<Overtech.DataModels.Store.ScaleModel, Overtech.ViewModels.Store.ScaleModel>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}