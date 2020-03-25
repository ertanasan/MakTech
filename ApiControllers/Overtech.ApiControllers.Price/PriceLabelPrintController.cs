// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Data;
using Overtech.Core.DataSource;
using Overtech.UI.DataSource;

using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Price;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Price
{
    [RoutePrefix("api/Price/PriceLabelPrint")]
    public class PriceLabelPrintController : CRUDLApiController<Overtech.DataModels.Price.PriceLabelPrint, IPriceLabelPrintService, Overtech.ViewModels.Price.PriceLabelPrint>
    {
        /*Section="Constructor"*/
        public PriceLabelPrintController(
            ILoggerFactory loggerFactory,
            IPriceLabelPrintService priceLabelPrintService)
            : base(loggerFactory, priceLabelPrintService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [HttpPost]
        [Route("InsertPrintedLabels")]
        [OTControllerAction("Create")]
        public virtual void InsertPrintedLabels(IEnumerable<Overtech.ViewModels.Price.PriceLabelPrint> viewModel)
        {

            _dataService.InsertPrintedLabels(viewModel.Map<Overtech.DataModels.Price.PriceLabelPrint, Overtech.ViewModels.Price.PriceLabelPrint>());

        }

        [HttpGet]
        [Route("ListPrintedLabels")]
        [OTControllerAction("GetReport")]
        public DataSourceResult ListPrintedLabels([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request)
        {
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListPrintedLabels();
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ListPrintedLabelDetailsByStore")]
        [OTControllerAction("GetReport")]
        public DataSourceResult ListPrintedLabelDetailsByStore(long storeId)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListPrintedLabelDetailsByStore(storeId);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }
        
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}