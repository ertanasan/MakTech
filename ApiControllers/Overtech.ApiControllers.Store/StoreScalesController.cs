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

using System.Reflection;
using Overtech.Core;
using System;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Store
{
    [RoutePrefix("api/Store/StoreScales")]
    public class StoreScalesController : CRUDLApiController<Overtech.DataModels.Store.StoreScales, IStoreScalesService, Overtech.ViewModels.Store.StoreScales>
    {

        private readonly IStoreService _storeService;

        /*Section="Constructor"*/
        public StoreScalesController(
            ILoggerFactory loggerFactory,
            IStoreScalesService storeScalesService,
            IStoreService storeService
)
            : base(loggerFactory, storeScalesService)
        {
            _storeService = storeService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Store.StoreScales> ListByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Store.StoreScales> dataModel = _storeService.ListStoreScaless(masterId);
            IEnumerable<Overtech.ViewModels.Store.StoreScales> viewModel = dataModel.Map<Overtech.DataModels.Store.StoreScales, Overtech.ViewModels.Store.StoreScales>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [OTControllerAction("List")]
        [Route("GetUserScale")]
        public IEnumerable<Overtech.DataModels.Store.StoreScales> GetUserScale()
        {
            return _dataService.GetUserScale();
        }

        [HttpPost]
        [OTControllerAction("Read")]
        [Route("CreateScale")]
        public Overtech.ViewModels.Store.StoreScales CreateScale([FromBody] Overtech.ViewModels.Store.StoreScales viewModel)
        {
            return base.Create(viewModel);
        }

        [HttpPut]
        [OTControllerAction("Read")]
        [Route("UpdateScale")]
        public void UpdateScale(Overtech.ViewModels.Store.StoreScales viewModel)
        {
            base.Update(viewModel);
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}