// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Sale;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Sale
{
    [RoutePrefix("api/Sale/SalePayment")]
    public class SalePaymentController : CRUDLApiController<Overtech.DataModels.Sale.SalePayment, ISalePaymentService, Overtech.ViewModels.Sale.SalePayment>
    {
        /*Section="Constructor"*/
        public SalePaymentController(
            ILoggerFactory loggerFactory,
            ISalePaymentService salePaymentService)
            : base(loggerFactory, salePaymentService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}