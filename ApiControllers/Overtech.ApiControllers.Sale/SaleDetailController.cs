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
using Overtech.Core.DataSource;
using Overtech.UI.DataSource;
using System.Data;
using System;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Sale
{
    [RoutePrefix("api/Sale/SaleDetail")]
    public class SaleDetailController : CRUDLApiController<Overtech.DataModels.Sale.SaleDetail, ISaleDetailService, Overtech.ViewModels.Sale.SaleDetail>
    {
        /*Section="Constructor"*/
        public SaleDetailController(
            ILoggerFactory loggerFactory,
            ISaleDetailService saleDetailService)
            : base(loggerFactory, saleDetailService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [Route("ListSaleDetail")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Sale.SaleDetail> ListSaleDetail(long saleId)
        {
            return _dataService.ListSaleDetail(saleId).Map<Overtech.DataModels.Sale.SaleDetail, Overtech.ViewModels.Sale.SaleDetail>();
        }

        [HttpGet]
        [Route("CancelDetails/{start}/{end}")]
        [OTControllerAction("GetReport")]
        public DataSourceResult GetCancelData([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request, DateTime start, DateTime end, string storeId)
        {
            DataSourceResult result;
            DataTable dtReport = null;


            dtReport = _dataService.GetCancelData(start, end, Convert.ToInt32(storeId));
            result = dtReport.ToDataSourceResult(request);
            return result;
        }


        [HttpGet]
        [Route("CancelDetails/{start}/{end}")]
        [OTControllerAction("GetReport")]
        public DataSourceResult GetCancelDetailData([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request, DateTime start,DateTime end)
        {
            DataSourceResult result;
            DataTable dtReport = null;
           
           
            dtReport = _dataService.GetCancelDetailData(start,end);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("WeeklyCancels")]
        [OTControllerAction("GetReport")]
        public DataSourceResult WeeklyCancels(DateTime startDate, DateTime endDate)
        {
            DataSourceResult result;
            DataSourceRequest request = new DataSourceRequest();
            DataTable dtReport = null;

            dtReport = _dataService.WeeklyCancels(startDate, endDate);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }


        #endregion Customized

        /*Section="ClassFooter"*/
    }
}