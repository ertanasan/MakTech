// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using Overtech.Core.DataSource;
using Overtech.UI.DataSource;
using Overtech.ViewModels.Product;
using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Product;
using Overtech.Core.Application;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Product
{
    [RoutePrefix("api/Product/Product")]
    public class ProductController : CRUDLApiController<Overtech.DataModels.Product.Product, IProductService, Overtech.ViewModels.Product.Product>
    {
        private IProductBarcodeService _productBarcodeService;
        private IStorageConditionService _storageConditionService;
        private ICountryService _countryService;
        private IUnitService _unitService;

        /*Section="Constructor"*/
        public ProductController(
            IProductBarcodeService productBarcodeService,
            ILoggerFactory loggerFactory,
            IProductService productService,
            IStorageConditionService storageConditionService,
            ICountryService countryService,
            IUnitService unitService)
            : base(loggerFactory, productService)
        {
            _productBarcodeService = productBarcodeService;
            _storageConditionService = storageConditionService;
            _countryService = countryService;
            _unitService = unitService;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized

        [HttpGet]
        [Route("ListConsignmentGoods")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Product.Product> ListConsignmentGoods()
        {
            
            return _dataService.ListConsignmentGoods().Map<Overtech.DataModels.Product.Product, Overtech.ViewModels.Product.Product>();
        }

        [HttpGet]
        [Route("GetProductInfo")]
        [AllowAnonymous]
        public Overtech.ViewModels.Product.Product GetProductInfo(int productId)
        {
            return _dataService.Read(productId).Map<Overtech.DataModels.Product.Product, Overtech.ViewModels.Product.Product>();
        }

        [HttpGet]
        [Route("ListAllStorageConditions")]
        [AllowAnonymous]
        public IEnumerable<Overtech.ViewModels.Product.StorageCondition> ListAllStorageConditions()
        {
            return _storageConditionService.List().Map<Overtech.DataModels.Product.StorageCondition, Overtech.ViewModels.Product.StorageCondition>();
        }

        [HttpGet]
        [Route("ListAllCountries")]
        [AllowAnonymous]
        public IEnumerable<Overtech.ViewModels.Product.Country> ListAllCountries()
        {
            return _countryService.List().Map<Overtech.DataModels.Product.Country, Overtech.ViewModels.Product.Country>();
        }

        [HttpGet]
        [Route("ListAllUnits")]
        [AllowAnonymous]
        public IEnumerable<Overtech.ViewModels.Product.Unit> ListAllUnits()
        {
            return _unitService.List().Map<Overtech.DataModels.Product.Unit, Overtech.ViewModels.Product.Unit>();
        }

        [HttpGet]
        [Route("ListBarcodeByProductId")]
        [AllowAnonymous]
        public IEnumerable<Overtech.ViewModels.Product.ProductBarcode> ListBarcodeByProductId(long productId)
        {
            var a = _productBarcodeService.ListBarcodeByProductId(productId).Map<Overtech.DataModels.Product.ProductBarcode, Overtech.ViewModels.Product.ProductBarcode>();
            return a;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}