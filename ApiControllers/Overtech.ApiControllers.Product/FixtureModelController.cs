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
using Overtech.ServiceContracts.Product;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Product
{
    [RoutePrefix("api/Product/FixtureModel")]
    public class FixtureModelController : CRUDLApiController<Overtech.DataModels.Product.FixtureModel, IFixtureModelService, Overtech.ViewModels.Product.FixtureModel>
    {

        private readonly IFixtureBrandService _fixtureBrandService;

        /*Section="Constructor"*/
        public FixtureModelController(
            ILoggerFactory loggerFactory,
            IFixtureModelService fixtureModelService,
            IFixtureBrandService fixtureBrandService
)
            : base(loggerFactory, fixtureModelService)
        {
            _fixtureBrandService = fixtureBrandService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public DataSourceResult ListByMaster([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request, long masterId)
        {
            IEnumerable<Overtech.DataModels.Product.FixtureModel> dataModel = _fixtureBrandService.ListFixtureModels(masterId);
            IEnumerable<Overtech.ViewModels.Product.FixtureModel> viewModel = dataModel.Map<Overtech.DataModels.Product.FixtureModel, Overtech.ViewModels.Product.FixtureModel>();
            return viewModel.ToDataSourceResult(request);
        }

        /*Section="Method-ListAllByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListAllByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Product.FixtureModel> ListAllByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Product.FixtureModel> dataModel = _fixtureBrandService.ListFixtureModels(masterId);
            IEnumerable<Overtech.ViewModels.Product.FixtureModel> viewModel = dataModel.Map<Overtech.DataModels.Product.FixtureModel, Overtech.ViewModels.Product.FixtureModel>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}