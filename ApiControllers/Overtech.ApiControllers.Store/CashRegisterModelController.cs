// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Store;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Store
{
    [RoutePrefix("api/Store/CashRegisterModel")]
    public class CashRegisterModelController : CRUDLApiController<Overtech.DataModels.Store.CashRegisterModel, ICashRegisterModelService, Overtech.ViewModels.Store.CashRegisterModel>
    {

        private readonly ICashRegisterBrandService _cashRegisterBrandService;

        /*Section="Constructor"*/
        public CashRegisterModelController(
            ILoggerFactory loggerFactory,
            ICashRegisterModelService cashRegisterModelService,
            ICashRegisterBrandService cashRegisterBrandService
)
            : base(loggerFactory, cashRegisterModelService)
        {
            _cashRegisterBrandService = cashRegisterBrandService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Store.CashRegisterModel> ListByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Store.CashRegisterModel> dataModel = _cashRegisterBrandService.ListCashRegisterModels(masterId);
            IEnumerable<Overtech.ViewModels.Store.CashRegisterModel> viewModel = dataModel.Map<Overtech.DataModels.Store.CashRegisterModel, Overtech.ViewModels.Store.CashRegisterModel>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}