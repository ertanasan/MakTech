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
using Overtech.ServiceContracts.Price;
using System;
using System.Data;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Price
{
    [RoutePrefix("api/Price/ProductPrice")]
    public class ProductPriceController : CRUDLApiController<Overtech.DataModels.Price.ProductPrice, IProductPriceService, Overtech.ViewModels.Price.ProductPrice>
    {
        /*Section="Constructor"*/
        public ProductPriceController(
            ILoggerFactory loggerFactory,
            IProductPriceService productPriceService)
            : base(loggerFactory, productPriceService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [HttpPut]
        [Route("UpdateAll")]
        [OTControllerAction("Update")]
        public virtual void UpdateAll(IEnumerable<Overtech.ViewModels.Price.ProductPrice> viewModel)
        {

            _dataService.updatePackagePrices(viewModel.Map<Overtech.DataModels.Price.ProductPrice, Overtech.ViewModels.Price.ProductPrice>());
            
        }

        [HttpGet]
        [Route("PackagePrices")]
        [OTControllerAction("List")]
        public virtual IEnumerable<Overtech.ViewModels.Price.ProductPrice> GetPackagePrices(int packageId)
        {

            return _dataService.GetPackagePrices(packageId).Map<Overtech.DataModels.Price.ProductPrice, Overtech.ViewModels.Price.ProductPrice>();

        }


        [HttpGet]
        [Route("PriceVersions")]
        [OTControllerAction("List")]
        public IEnumerable<Tuple<int, string>> GetPriceVersions()
        {
            return _dataService.ListPriceVersions();
        }

        [HttpGet]
        [Route("PriceLoadStatus")]
        [OTControllerAction("List")]
        public DataSourceResult PriceLoadStatus()
        {
            try
            {
                DataSourceResult result;
                DataSourceRequest request = new DataSourceRequest();
                DataTable dtReport = null;
                dtReport = _dataService.PriceLoadStatus();
                result = dtReport.ToDataSourceResult(request);
                return result;
            }
            catch
            {
                throw;        
            }
        }

        [HttpGet]
        [Route("ListSalesByPriceGroups")]
        [OTControllerAction("List")]
        public DataSourceResult ListSalesByPriceGroups(long storeId, long productId, DateTime startDate, DateTime endDate)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListSalesByPriceGroups(storeId, productId, startDate, endDate);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ListSalesTrendWithPriceChanges")]
        [OTControllerAction("List")]
        public DataSourceResult ListSalesTrendWithPriceChanges(long? storeId, long productId, DateTime startDate, DateTime endDate)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListSalesTrendWithPriceChanges(storeId, productId, startDate, endDate);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}