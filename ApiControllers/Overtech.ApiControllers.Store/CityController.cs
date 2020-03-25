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
    [RoutePrefix("api/Store/StoreCity")]
    public class StoreCityController : CRUDLApiController<Overtech.DataModels.Store.City, ICityService, Overtech.ViewModels.Store.City>
    {
        /*Section="Constructor"*/
        public StoreCityController(
            ILoggerFactory loggerFactory,
            ICityService cityService)
            : base(loggerFactory, cityService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}