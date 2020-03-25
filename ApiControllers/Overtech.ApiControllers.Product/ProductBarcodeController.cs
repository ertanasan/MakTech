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
    [RoutePrefix("api/Product/ProductBarcode")]
    public class ProductBarcodeController : CRUDLApiController<Overtech.DataModels.Product.ProductBarcode, IProductBarcodeService, Overtech.ViewModels.Product.ProductBarcode>
    {

        private readonly IProductService _productService;

        /*Section="Constructor"*/
        public ProductBarcodeController(
            ILoggerFactory loggerFactory,
            IProductBarcodeService productBarcodeService,
            IProductService productService
)
            : base(loggerFactory, productBarcodeService)
        {
            _productService = productService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Product.ProductBarcode> ListByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Product.ProductBarcode> dataModel = _productService.ListProductBarcodes(masterId);
            IEnumerable<Overtech.ViewModels.Product.ProductBarcode> viewModel = dataModel.Map<Overtech.DataModels.Product.ProductBarcode, Overtech.ViewModels.Product.ProductBarcode>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}