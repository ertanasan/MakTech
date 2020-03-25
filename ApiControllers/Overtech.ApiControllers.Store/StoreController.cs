// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Data;
using Overtech.Core.DataSource;
using Overtech.UI.DataSource;

using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Store;
using Overtech.ServiceContracts.Security;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Store
{
    [RoutePrefix("api/Store/Store")]
    public class StoreController : CRUDLApiController<Overtech.DataModels.Store.Store, IStoreService, Overtech.ViewModels.Store.Store>
    {
        ITitleService _titleService;

        /*Section="Constructor"*/
        public StoreController(
            ILoggerFactory loggerFactory,
            IStoreService storeService,
            ITitleService titleService)
            : base(loggerFactory, storeService)
        {
            _titleService = titleService;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [OTControllerAction("List")]
        [Route("ListProduction")]
        public IEnumerable<Overtech.DataModels.Store.Store> ListProduction()
        {
            return _dataService.ListOverStores();
        }

        [HttpGet]
        [OTControllerAction("List")]
        [Route("ListUserStores")]
        public IEnumerable<Overtech.DataModels.Store.Store> UserStores()
        {
            return _dataService.UserStores();
        }

        [HttpGet]
        [OTControllerAction("List")]
        [Route("ListAllTitles")]
        public IEnumerable<Overtech.DataModels.Security.Title> Titles()
        {
            return _titleService.ListByOrganization(1);
        }

        [HttpGet]
        [Route("ListUserPrivilegesByScreen")]
        [OTControllerAction("List")]
        public DataSourceResult ListUserPrivilegesByScreen(long screenId, long programId)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListUserPrivilegesByScreen(screenId, programId);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ListScreenActionsByUser")]
        [OTControllerAction("List")]
        public DataSourceResult ListScreenActionsByUser(long userId, long programId)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListScreenActionsByUser(userId, programId);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ListAllPrograms")]
        [OTControllerAction("List")]
        public DataSourceResult ListAllPrograms()
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListAllPrograms();
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("GetDashboardOutdatedCodeStore")]
        [OTControllerAction("GetReport")]
        public DataSourceResult GetDashboardOutdatedCodeStore([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request)
        {
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.GetDashboardOutdatedCodeStore();
            result = dtReport.ToDataSourceResult(request);
            return result;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}