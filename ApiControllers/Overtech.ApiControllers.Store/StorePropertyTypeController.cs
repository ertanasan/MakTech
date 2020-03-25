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
    [RoutePrefix("api/Store/StorePropertyType")]
    public class StorePropertyTypeController : CRUDLApiController<Overtech.DataModels.Store.StorePropertyType, IStorePropertyTypeService, Overtech.ViewModels.Store.StorePropertyType>
    {
        /*Section="Constructor"*/
        public StorePropertyTypeController(
            ILoggerFactory loggerFactory,
            IStorePropertyTypeService storePropertyTypeService)
            : base(loggerFactory, storePropertyTypeService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [Route("RemainingPropertyTypes")]
        [OTControllerAction("List")]
        public virtual IEnumerable<Overtech.ViewModels.Store.StorePropertyType> ListRemainingProducts(long storeId)
        {
            return _dataService.ListRemaningPropertyTypes(storeId).Map<Overtech.DataModels.Store.StorePropertyType, Overtech.ViewModels.Store.StorePropertyType>();
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}