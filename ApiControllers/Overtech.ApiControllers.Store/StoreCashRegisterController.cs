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
    [RoutePrefix("api/Store/StoreCashRegister")]
    public class StoreCashRegisterController : CRUDLApiController<Overtech.DataModels.Store.StoreCashRegister, IStoreCashRegisterService, Overtech.ViewModels.Store.StoreCashRegister>
    {

        private readonly IStoreService _storeService;

        /*Section="Constructor"*/
        public StoreCashRegisterController(
            ILoggerFactory loggerFactory,
            IStoreCashRegisterService storeCashRegisterService,
            IStoreService storeService
)
            : base(loggerFactory, storeCashRegisterService)
        {
            _storeService = storeService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Store.StoreCashRegister> ListByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Store.StoreCashRegister> dataModel = _storeService.ListStoreCashRegisters(masterId);
            IEnumerable<Overtech.ViewModels.Store.StoreCashRegister> viewModel = dataModel.Map<Overtech.DataModels.Store.StoreCashRegister, Overtech.ViewModels.Store.StoreCashRegister>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [OTControllerAction("List")]
        [Route("GetUserCashRegister")]
        public IEnumerable<Overtech.DataModels.Store.StoreCashRegister> GetUserCashRegister()
        {
            return _dataService.GetUserCashRegister();
        }

        [HttpPost]
        [OTControllerAction("Read")]
        [Route("CreateCashRegister")]
        public Overtech.ViewModels.Store.StoreCashRegister CreateCashRegister([FromBody] Overtech.ViewModels.Store.StoreCashRegister viewModel)
        {
            return base.Create(viewModel);
        }

        [HttpPut]
        [OTControllerAction("Read")]
        [Route("UpdateCashRegister")]
        public void UpdateCashRegister(Overtech.ViewModels.Store.StoreCashRegister viewModel)
        {
            base.Update(viewModel);
        }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}