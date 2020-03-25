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
    [RoutePrefix("api/Product/FixtureBrand")]
    public class FixtureBrandController : CRUDLApiController<Overtech.DataModels.Product.FixtureBrand, IFixtureBrandService, Overtech.ViewModels.Product.FixtureBrand>
    {

        private readonly IFixtureService _fixtureService;

        /*Section="Constructor"*/
        public FixtureBrandController(
            ILoggerFactory loggerFactory,
            IFixtureBrandService fixtureBrandService,
            IFixtureService fixtureService
)
            : base(loggerFactory, fixtureBrandService)
        {
            _fixtureService = fixtureService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public DataSourceResult ListByMaster([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request, long masterId)
        {
            IEnumerable<Overtech.DataModels.Product.FixtureBrand> dataModel = _fixtureService.ListFixtureBrands(masterId);
            IEnumerable<Overtech.ViewModels.Product.FixtureBrand> viewModel = dataModel.Map<Overtech.DataModels.Product.FixtureBrand, Overtech.ViewModels.Product.FixtureBrand>();
            return viewModel.ToDataSourceResult(request);
        }

        /*Section="Method-ListAllByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListAllByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Product.FixtureBrand> ListAllByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Product.FixtureBrand> dataModel = _fixtureService.ListFixtureBrands(masterId);
            IEnumerable<Overtech.ViewModels.Product.FixtureBrand> viewModel = dataModel.Map<Overtech.DataModels.Product.FixtureBrand, Overtech.ViewModels.Product.FixtureBrand>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}