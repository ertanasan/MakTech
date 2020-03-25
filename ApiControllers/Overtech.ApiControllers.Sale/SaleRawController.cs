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
    [RoutePrefix("api/Sale/SaleRaw")]
    public class SaleRawController : CRUDLApiController<Overtech.DataModels.Sale.SaleRaw, ISaleRawService, Overtech.ViewModels.Sale.SaleRaw>
    {
        /*Section="Constructor"*/
        public SaleRawController(
            ILoggerFactory loggerFactory,
            ISaleRawService saleRawService)
            : base(loggerFactory, saleRawService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}