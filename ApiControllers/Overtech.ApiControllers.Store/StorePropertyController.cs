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
    [RoutePrefix("api/Store/StoreProperty")]
    public class StorePropertyController : CRUDLApiController<Overtech.DataModels.Store.StoreProperty, IStorePropertyService, Overtech.ViewModels.Store.StoreProperty>
    {
        private readonly IStorePropertyService _storePropertyService;

        /*Section="Constructor"*/
        public StorePropertyController(
            ILoggerFactory loggerFactory,
            IStorePropertyService storePropertyService)
            : base(loggerFactory, storePropertyService)
        {
            _storePropertyService = storePropertyService;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Store.StoreProperty> ListByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Store.StoreProperty> dataModel = _storePropertyService.ListStoreProperties(masterId);
            IEnumerable<Overtech.ViewModels.Store.StoreProperty> viewModel = dataModel.Map<Overtech.DataModels.Store.StoreProperty, Overtech.ViewModels.Store.StoreProperty>();
            return viewModel;
        }

        [HttpPost]
        [Route("CreateStorePropertyForAllStores/{propertyTypeId}/{value}")]
        // [Route("CreateStorePropertyForAllStores")]
        [OTControllerAction("Create")]
        public int CreateStorePropertyForAllStores(long propertyTypeId, string value)
        {
            return _storePropertyService.CreateStorePropertyForAllStores(propertyTypeId, value);
        }

        [HttpPut]
        [Route("UpdateStorePropertyForAllStores/{propertyTypeId}/{value}")]
        // [Route("UpdateStorePropertyForAllStores")]
        [OTControllerAction("Update")]
        public int UpdateStorePropertiyForAllStores(long propertyTypeId, string value)
        {
            return _storePropertyService.UpdateStorePropertiyForAllStores(propertyTypeId, value);
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}