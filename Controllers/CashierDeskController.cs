using Overtech.Core.Logger;
using Overtech.Core.Data;
using Overtech.Service.Authorization;
using Overtech.ServiceContracts.Price;
using Overtech.ServiceContracts.Product;
using Overtech.ServiceContracts.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Overtech.Gateways.OverStore.Controllers
{
    [RoutePrefix("api/CashierDesk")]
    public class CashierDeskController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IStoreCashRegisterService _storeCashRegisterService;
        private readonly IStoreScalesService _storeScaleService;
        private readonly IProductPriceService _productPriceService;
        private readonly ICurrentPricesService _currentPriceService;
        private readonly IStoreService _storeService;
        private readonly IProductService _productService;
        private readonly ICashierService _cashierService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly ISubgroupService _subgroupService;        

        public CashierDeskController(
            ILoggerFactory loggerFactory,
            IStoreCashRegisterService storeCashRegisterService,
            IStoreScalesService storeScaleService,
            IProductPriceService productPriceService,
            ICurrentPricesService currentPriceService,
            IStoreService storeService,
            IProductService productService,
            ICashierService cashierService,
            IProductCategoryService productCategoryService,
            ISubgroupService subgroupService
        )
        {
            _logger = loggerFactory.GetLogger(typeof(CashierDeskController));

            _storeCashRegisterService = storeCashRegisterService;
            _storeScaleService = storeScaleService;
            _productPriceService = productPriceService;
            _currentPriceService = currentPriceService;
            _storeService = storeService;
            _productService = productService;
            _cashierService = cashierService;
            _productCategoryService = productCategoryService;
            _subgroupService = subgroupService;
        }

        [Route("StoreTest/{storeId}")]
        [AllowAuthenticated]
        [HttpGet]
        public string StoreTest(int storeId)
        {
            return $"store test { storeId }.";
        }

        [Route("ListAllCategories")]
        [AllowAuthenticated]
        [HttpGet]
        public List<Overtech.ViewModels.Product.ProductCategory> ListAllCategories()
        {
            try
            {
                return _productCategoryService.List().Map<Overtech.DataModels.Product.ProductCategory, Overtech.ViewModels.Product.ProductCategory>().ToList();
            } 
            catch (Exception ex)
            {
                _logger.Error($"{ex.ToString()}");
                throw ex;
            }
        }

        [Route("ListProductsByCategory/{categoryId}")]
        [AllowAuthenticated]
        [HttpGet]
        public List<Overtech.ViewModels.Product.Product> ListProductsByCategory(long categoryId)
        {
            IEnumerable<Overtech.ViewModels.Product.Product> allProducts = _productService.List().Map<Overtech.DataModels.Product.Product, Overtech.ViewModels.Product.Product>();
            IEnumerable<Overtech.ViewModels.Product.Subgroup> allSubGroups = _subgroupService.List().Map<Overtech.DataModels.Product.Subgroup, Overtech.ViewModels.Product.Subgroup>();
            IEnumerable<Overtech.ViewModels.Product.Subgroup> chosenSubgroups = allSubGroups.Where(sg => sg.Category == categoryId);
            return allProducts.Where(p => p.SuperGroup2 == 1 && chosenSubgroups.Any(c => c.SubgroupID == p.Subgroup)).ToList();
        }

        [Route("GetProductPrice/{productCode}")]
        [AllowAuthenticated]
        [HttpGet]
        public decimal GetProductPrice(string productCode)
        {
            Overtech.ViewModels.Price.CurrentPrices currentPrice = _currentPriceService.GetCurrentPriceByProductCode(productCode).Map<Overtech.DataModels.Price.CurrentPrices, Overtech.ViewModels.Price.CurrentPrices>();
            return currentPrice.SalePrice;
        }

        [Route("ListAllSubGroups")]
        [AllowAuthenticated]
        [HttpGet]
        public List<Overtech.ViewModels.Product.Subgroup> ListAllSubGroups()
        {
            try
            {
                return _subgroupService.List().Map<Overtech.DataModels.Product.Subgroup, Overtech.ViewModels.Product.Subgroup>().ToList();
            }
            catch (Exception ex)
            {
                _logger.Error($"{ex.ToString()}");
                throw ex;
            }
        }

        [Route("ListAllSellableProducts/{storeId}")]
        [AllowAuthenticated]
        [HttpGet]
        public List<Overtech.ViewModels.Product.Product> ListAllSellableProducts(int storeId)
        {
            try
            {
                List<Overtech.ViewModels.Price.CurrentPrices> currentPrices = _currentPriceService.List().Where(cp => cp.StoreID == storeId).Map<Overtech.DataModels.Price.CurrentPrices, Overtech.ViewModels.Price.CurrentPrices>().ToList();
                return _productService.List().Map<Overtech.DataModels.Product.Product, Overtech.ViewModels.Product.Product>().Where(p => currentPrices.Any(cp => cp.ProductCodeName == p.Code)).ToList();
            }
            catch (Exception ex)
            {
                _logger.Error($"{ex.ToString()}");
                throw ex;
            }
        }
    }
}