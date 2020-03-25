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
    [RoutePrefix("api/Store/StoreAccounts")]
    public class StoreAccountsController : CRUDLApiController<Overtech.DataModels.Store.StoreAccounts, IStoreAccountsService, Overtech.ViewModels.Store.StoreAccounts>
    {
        private readonly IStoreAccountsService _storeAccountsService;
        /*Section="Constructor"*/
        public StoreAccountsController(
            ILoggerFactory loggerFactory,
            IStoreAccountsService storeAccountsService)
            : base(loggerFactory, storeAccountsService)
        {
            _storeAccountsService = storeAccountsService;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Store.StoreAccounts> ListByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Store.StoreAccounts> dataModel = _storeAccountsService.ListStoreAccounts(masterId);
            IEnumerable<Overtech.ViewModels.Store.StoreAccounts> viewModel = dataModel.Map<Overtech.DataModels.Store.StoreAccounts, Overtech.ViewModels.Store.StoreAccounts>();
            return viewModel;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}