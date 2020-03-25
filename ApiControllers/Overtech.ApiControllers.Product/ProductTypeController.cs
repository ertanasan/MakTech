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
    [RoutePrefix("api/Product/ProductType")]
    public class ProductTypeController : CRUDLApiController<Overtech.DataModels.Product.ProductType, IProductTypeService, Overtech.ViewModels.Product.ProductType>
    {

        private readonly IProductCategoryService _productCategoryService;

        /*Section="Constructor"*/
        public ProductTypeController(
            ILoggerFactory loggerFactory,
            IProductTypeService productTypeService,
            IProductCategoryService productCategoryService
)
            : base(loggerFactory, productTypeService)
        {
            _productCategoryService = productCategoryService;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}