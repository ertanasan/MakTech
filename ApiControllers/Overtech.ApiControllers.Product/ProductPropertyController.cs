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
    [RoutePrefix("api/Product/ProductProperty")]
    public class ProductPropertyController : CRUDLApiController<Overtech.DataModels.Product.ProductProperty, IProductPropertyService, Overtech.ViewModels.Product.ProductProperty>
    {

        private readonly IProductService _productService;

        /*Section="Constructor"*/
        public ProductPropertyController(
            ILoggerFactory loggerFactory,
            IProductPropertyService productPropertyService,
            IProductService productService
)
            : base(loggerFactory, productPropertyService)
        {
            _productService = productService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Product.ProductProperty> ListByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Product.ProductProperty> dataModel = _productService.ListProductProperties(masterId);
            IEnumerable<Overtech.ViewModels.Product.ProductProperty> viewModel = dataModel.Map<Overtech.DataModels.Product.ProductProperty, Overtech.ViewModels.Product.ProductProperty>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}