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
using Overtech.ServiceContracts.Price;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Price
{
    [RoutePrefix("api/Price/StorePackage")]
    public class StorePackageController : CRUDLApiController<Overtech.DataModels.Price.StorePackage, IStorePackageService, Overtech.ViewModels.Price.StorePackage>
    {
        /*Section="Constructor"*/
        public StorePackageController(
            ILoggerFactory loggerFactory,
            IStorePackageService storePackageService)
            : base(loggerFactory, storePackageService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpPost]
        [Route("CreateStorePackage")]
        [OTControllerAction("Create")]
        public void CreateStorePackage([FromBody] Overtech.ViewModels.Price.StorePackage viewModel)
        {
            _dataService.CreateStorePackage(viewModel.Map<Overtech.DataModels.Price.StorePackage, Overtech.ViewModels.Price.StorePackage>());

        }

        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public DataSourceResult ListByMaster(long masterId, [System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))] DataSourceRequest request = null)
        {
            IEnumerable<Overtech.DataModels.Price.StorePackage> dataModel = _dataService.ListStorePackagesByStoreId(masterId);
            IEnumerable<Overtech.ViewModels.Price.StorePackage> viewModel = dataModel.Map<Overtech.DataModels.Price.StorePackage, Overtech.ViewModels.Price.StorePackage>();

            if (request == null)
            {
                request = new DataSourceRequest();
            }
            return viewModel.ToDataSourceResult(request);
        }

        [HttpGet, ActionName("ListAllByMaster")]
        [Route("ListAllByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Price.StorePackage> ListAllByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Price.StorePackage> dataModel = _dataService.ListStorePackagesByStoreId(masterId);
            IEnumerable<Overtech.ViewModels.Price.StorePackage> viewModel = dataModel.Map<Overtech.DataModels.Price.StorePackage, Overtech.ViewModels.Price.StorePackage>();
            return viewModel;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}