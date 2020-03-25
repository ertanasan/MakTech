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
using Overtech.ServiceContracts.Sale;
using System.Web.Http.ModelBinding;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Sale
{
    [RoutePrefix("api/Sale/SaleDailySummary")]
    public class SaleDailySummaryController : CRUDLApiController<Overtech.DataModels.Sale.SaleDailySummary, ISaleDailySummaryService, Overtech.ViewModels.Sale.SaleDailySummary>
    {
        /*Section="Constructor"*/
        public SaleDailySummaryController(
            ILoggerFactory loggerFactory,
            ISaleDailySummaryService saleDailySummaryService)
            : base(loggerFactory, saleDailySummaryService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [Route("ListDate")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Sale.SaleDailySummary> ListDate(System.DateTime transactionDate)
        {
            return _dataService.ListDate(transactionDate).Map<Overtech.DataModels.Sale.SaleDailySummary, Overtech.ViewModels.Sale.SaleDailySummary>();
        }

        [HttpGet]
        [Route("StoreZet")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Sale.SaleDailySummary> StoreZet(System.DateTime transactionDate, long storeId)
        {
            return _dataService.StoreZet(transactionDate, storeId).Map<Overtech.DataModels.Sale.SaleDailySummary, Overtech.ViewModels.Sale.SaleDailySummary>();
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}