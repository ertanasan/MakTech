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
using Overtech.ServiceContracts.Product;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Product
{
    [RoutePrefix("api/Product/BarcodeTypeInt")]
    public class BarcodeTypeIntController : CRUDLApiController<Overtech.DataModels.Product.BarcodeTypeInt, IBarcodeTypeIntService, Overtech.ViewModels.Product.BarcodeTypeInt>
    {
        /*Section="Constructor"*/
        public BarcodeTypeIntController(
            ILoggerFactory loggerFactory,
            IBarcodeTypeIntService barcodeTypeIntService)
            : base(loggerFactory, barcodeTypeIntService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}