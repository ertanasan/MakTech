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
    [RoutePrefix("api/Store/UsersStores")]
    public class UsersStoresController : OTRelationApiController<Overtech.DataModels.Store.UsersStores, IUsersStoresService, Overtech.ViewModels.Store.UsersStores>
    {
        /*Section="Constructor"*/
        public UsersStoresController(
            ILoggerFactory loggerFactory,
            IUsersStoresService usersStoresService)
            : base(loggerFactory, usersStoresService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}