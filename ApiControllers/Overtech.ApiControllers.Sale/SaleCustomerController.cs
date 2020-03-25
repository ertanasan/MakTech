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
using Overtech.ServiceContracts.Sale;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Sale
{
    [RoutePrefix("api/Sale/SaleCustomer")]
    public class SaleCustomerController : CRUDLApiController<Overtech.DataModels.Sale.SaleCustomer, ISaleCustomerService, Overtech.ViewModels.Sale.SaleCustomer>
    {

        private readonly ISalesService _salesService;

        /*Section="Constructor"*/
        public SaleCustomerController(
            ILoggerFactory loggerFactory,
            ISaleCustomerService saleCustomerService,
            ISalesService salesService
)
            : base(loggerFactory, saleCustomerService)
        {
            _salesService = salesService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public DataSourceResult ListByMaster([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request, long masterId)
        {
            IEnumerable<Overtech.DataModels.Sale.SaleCustomer> dataModel = _salesService.ListSaleCustomers(masterId);
            IEnumerable<Overtech.ViewModels.Sale.SaleCustomer> viewModel = dataModel.Map<Overtech.DataModels.Sale.SaleCustomer, Overtech.ViewModels.Sale.SaleCustomer>();
            return viewModel.ToDataSourceResult(request);
        }

        /*Section="Method-ListAllByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListAllByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Sale.SaleCustomer> ListAllByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Sale.SaleCustomer> dataModel = _salesService.ListSaleCustomers(masterId);
            IEnumerable<Overtech.ViewModels.Sale.SaleCustomer> viewModel = dataModel.Map<Overtech.DataModels.Sale.SaleCustomer, Overtech.ViewModels.Sale.SaleCustomer>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}