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
using Overtech.ServiceContracts.Accounting;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Accounting
{
    [RoutePrefix("api/Accounting/ExcelFileColumns")]
    public class ExcelFileColumnsController : CRUDLApiController<Overtech.DataModels.Accounting.ExcelFileColumns, IExcelFileColumnsService, Overtech.ViewModels.Accounting.ExcelFileColumns>
    {

        private readonly IExcelFileService _excelFileService;

        /*Section="Constructor"*/
        public ExcelFileColumnsController(
            ILoggerFactory loggerFactory,
            IExcelFileColumnsService excelFileColumnsService,
            IExcelFileService excelFileService
)
            : base(loggerFactory, excelFileColumnsService)
        {
            _excelFileService = excelFileService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public DataSourceResult ListByMaster([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request, long masterId)
        {
            IEnumerable<Overtech.DataModels.Accounting.ExcelFileColumns> dataModel = _excelFileService.ListExcelFileColumnss(masterId);
            IEnumerable<Overtech.ViewModels.Accounting.ExcelFileColumns> viewModel = dataModel.Map<Overtech.DataModels.Accounting.ExcelFileColumns, Overtech.ViewModels.Accounting.ExcelFileColumns>();
            return viewModel.ToDataSourceResult(request);
        }

        /*Section="Method-ListAllByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListAllByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Accounting.ExcelFileColumns> ListAllByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Accounting.ExcelFileColumns> dataModel = _excelFileService.ListExcelFileColumnss(masterId);
            IEnumerable<Overtech.ViewModels.Accounting.ExcelFileColumns> viewModel = dataModel.Map<Overtech.DataModels.Accounting.ExcelFileColumns, Overtech.ViewModels.Accounting.ExcelFileColumns>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}