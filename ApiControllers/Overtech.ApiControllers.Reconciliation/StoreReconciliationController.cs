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
using Overtech.ServiceContracts.Reconciliation;
using System;
using Overtech.ViewModels.Reconciliation;
using Overtech.Core.Application;
using System.Runtime.Serialization;
using System.Web.Http.ModelBinding;
using System.Net.Http;
using System.Net;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Reconciliation
{
    [RoutePrefix("api/Reconciliation/StoreReconciliation")]
    public class StoreReconciliationController : CRUDLApiController<Overtech.DataModels.Reconciliation.StoreReconciliation, IStoreReconciliationService, Overtech.ViewModels.Reconciliation.StoreReconciliation>
    {

        public StoreReconciliationController(
            ILoggerFactory loggerFactory,
            IStoreReconciliationService StoreReconciliationService)
            : base(loggerFactory, StoreReconciliationService)
        {
        }

        #region Customized

        [HttpPost]
        [Route("Create")]
        public override StoreReconciliation Create([FromBody] StoreReconciliation viewModel)
        {
            if (ModelState.IsValid)
            {
                return base.Create(viewModel);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);
                throw CreateUserException(new Core.OTException(Core.OTErrors.ModelStateInvalid, true, null, errors));
            }
        }

        [HttpGet]
        [Route("StoreReconciliationDelete")]
        [OTControllerAction("Delete")]
        public void ReconciliationDelete(long reconciliationID)
        {
            _dataService.DeleteReconciliation(reconciliationID);
        }

        [HttpGet]
        [Route("StoreReconciliationList")]
        [OTControllerAction("List")]
        public IEnumerable<StoreReconciliation> ReconciliationList(DateTime transactionDate)
        {
            return _dataService.ListReconciliation(transactionDate).Map<DataModels.Reconciliation.StoreReconciliation, StoreReconciliation>();
        }

        [HttpGet]
        [Route("StoreReconciliationIncome")]
        [OTControllerAction("List")]
        public IEnumerable<StoreReconciliationIncome> ReconciliationIncome(DateTime transactionDate)
        {
            var result = _dataService.ListReconciliationIncome(transactionDate).Map<DataModels.Reconciliation.StoreReconciliationIncome, StoreReconciliationIncome>();
            return result;
        }

        [HttpGet]
        [Route("StoreReconciliation")]
        [OTControllerAction("List")]
        public StoreReconciliation GetStoreReconciliation(DateTime transactionDate)
        {
            return _dataService.GetReconciliation(transactionDate).Map<DataModels.Reconciliation.StoreReconciliation, StoreReconciliation>();
        }

        [HttpPost]
        [Route("StoreReconciliationSave")]
        [OTControllerAction("Create")]
        public void SaveReconciliation(StoreReconciliation reconciliation)
        {
            var StoreReconciliation = (reconciliation as StoreReconciliation).Map<DataModels.Reconciliation.StoreReconciliation, StoreReconciliation>();
            _dataService.SaveReconciliation(StoreReconciliation /*, expenses*/);
        }

        [HttpGet]
        [Route("ApproveReconciliations")]
        [OTControllerAction("Create")]
        public void ApproveReconciliations(DateTime transactionDate, int reconciliationID)
        {
            _dataService.ApproveReconciliations(transactionDate, reconciliationID);
        }

        [HttpGet]
        [Route("ReconciliationStoreData")]
        [OTControllerAction("GetReport")]
        public DataSourceResult GetReconciliationStoreData(int dayGroup)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.GetReconciliationStoreData(dayGroup);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        
        //[HttpPost]
        //[Route("ExportReconciliations")]
        //[OTControllerAction("List")]
        //public IHttpActionResult ExportReconciliationList(StoreReconciliation[] reconciliations)
        //{
        //    //[ModelBinder(typeof(WebApiDataSourceRequestModelBinder))] DataSourceRequest request = null

        //    IEnumerable<DataModels.Reconciliation.StoreReconciliation> r;

        //    r = reconciliations.Map<DataModels.Reconciliation.StoreReconciliation, StoreReconciliation>();


        //    byte[] excelData = _dataService.ExportReconciliationList(r);
        //    var result = new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new ByteArrayContent(excelData)
        //    };

        //    result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
        //    {
        //        FileName = $"Export_{"Mutabakat"}_{DateTime.Now:yyyyMMddHHmmss}.xlsx"
        //    };
        //    result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.ms-excel");

        //    return ResponseMessage(result);
        //}

        #endregion Customized

    }
}