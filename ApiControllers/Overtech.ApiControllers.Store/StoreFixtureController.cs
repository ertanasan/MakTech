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
    [RoutePrefix("api/Store/StoreFixture")]
    public class StoreFixtureController : CRUDLApiController<Overtech.DataModels.Store.StoreFixture, IStoreFixtureService, Overtech.ViewModels.Store.StoreFixture>
    {

        private readonly IStoreService _storeService;

        /*Section="Constructor"*/
        public StoreFixtureController(
            ILoggerFactory loggerFactory,
            IStoreFixtureService storeFixtureService,
            IStoreService storeService
)
            : base(loggerFactory, storeFixtureService)
        {
            _storeService = storeService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public DataSourceResult ListByMaster([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request, long masterId)
        {
            IEnumerable<Overtech.DataModels.Store.StoreFixture> dataModel = _storeService.ListStoreFixtures(masterId);
            IEnumerable<Overtech.ViewModels.Store.StoreFixture> viewModel = dataModel.Map<Overtech.DataModels.Store.StoreFixture, Overtech.ViewModels.Store.StoreFixture>();
            return viewModel.ToDataSourceResult(request);
        }

        /*Section="Method-ListAllByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListAllByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Store.StoreFixture> ListAllByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Store.StoreFixture> dataModel = _storeService.ListStoreFixtures(masterId);
            IEnumerable<Overtech.ViewModels.Store.StoreFixture> viewModel = dataModel.Map<Overtech.DataModels.Store.StoreFixture, Overtech.ViewModels.Store.StoreFixture>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [OTControllerAction("List")]
        [Route("GetUserFixture")]
        public IEnumerable<Overtech.DataModels.Store.StoreFixture> GetUserFixture()
        {
            return _dataService.GetUserFixture();
        }

        [HttpPost]
        [OTControllerAction("Read")]
        [Route("CreateFixture")]
        public Overtech.ViewModels.Store.StoreFixture CreateCashRegister([FromBody] Overtech.ViewModels.Store.StoreFixture viewModel)
        {
            return base.Create(viewModel);
        }

        [HttpPut]
        [OTControllerAction("Read")]
        [Route("UpdateFixture")]
        public void UpdateCashRegister(Overtech.ViewModels.Store.StoreFixture viewModel)
        {
            base.Update(viewModel);
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}