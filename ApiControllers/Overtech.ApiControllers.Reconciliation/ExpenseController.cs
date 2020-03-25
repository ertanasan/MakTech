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
using Overtech.ServiceContracts.Reconciliation;
using System;
using System.Data;
using Overtech.ViewModels.Reconciliation;
using System.Runtime.Serialization;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Reconciliation
{
    public class MikroTransferListModel
    {
        [DataMember]
        public long RegionManagerId { get; set; }
        [DataMember]
        public string ExpenseList { get; set; }
    }

    [RoutePrefix("api/Reconciliation/Expense")]
    public class ExpenseController : CRUDLApiController<Overtech.DataModels.Reconciliation.Expense, IExpenseService, Overtech.ViewModels.Reconciliation.Expense>
    {
        /*Section="Constructor"*/
        public ExpenseController(
            ILoggerFactory loggerFactory,
            IExpenseService expenseService)
            : base(loggerFactory, expenseService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [Route("OpenExpenses")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Reconciliation.Expense> OpenExpenses(long storeId, DateTime date)
        {
            return _dataService.OpenExpenses(storeId, date).Map<Overtech.DataModels.Reconciliation.Expense, Overtech.ViewModels.Reconciliation.Expense>();
        }

        [HttpGet]
        [Route("PaidExpenses")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Reconciliation.Expense> PaidExpenses(long storeId, DateTime date)
        {
            return _dataService.PaidExpenses(storeId, date).Map<Overtech.DataModels.Reconciliation.Expense, Overtech.ViewModels.Reconciliation.Expense>();
        }

        [HttpGet]
        [Route("ReadDate")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Reconciliation.Expense> ReadDate(DateTime startDate, DateTime endDate)
        {
            return _dataService.ReadDate(startDate, endDate).Map<Overtech.DataModels.Reconciliation.Expense, Overtech.ViewModels.Reconciliation.Expense>();
        }


        [HttpGet]
        [Route("ExpenseReport")]
        [OTControllerAction("List")]
        public DataSourceResult ExpenseReport(DateTime startDate, DateTime endDate, string storeList, string expenseTypeList, string managerList)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ExpenseReport(startDate, endDate, storeList, expenseTypeList, managerList);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ExpenseReportDetail")]
        [OTControllerAction("List")]
        public DataSourceResult ExpenseReportDetail(DateTime startDate, DateTime endDate, string storeList, string expenseTypeList, string managerList)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ExpenseReport(startDate, endDate, storeList, expenseTypeList, managerList);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("ExpenseReportChart")]
        [OTControllerAction("List")]
        public DataSourceResult ExpenseReportChart(string storeList, string expenseTypeList, string managerList)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ExpenseReportChart(storeList, expenseTypeList, managerList);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpGet]
        [Route("MikroTransferList")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Reconciliation.Expense> MikroTransferList(long regionManagerId)
        {
            return _dataService.MikroTransferList(regionManagerId).Map<Overtech.DataModels.Reconciliation.Expense, Overtech.ViewModels.Reconciliation.Expense>();
        }

        [HttpPost]
        [Route("MikroTransfer")]
        [OTControllerAction("Create")]
        public long MikroTransfer(MikroTransferListModel viewModel)
        {

            return _dataService.MikroTransfer(viewModel.RegionManagerId, viewModel.ExpenseList);

        }

        [HttpGet]
        [Route("ListExpenseLog")]
        [OTControllerAction("List")]
        public DataSourceResult ListExpenseLog(long expenseId)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.ListExpenseLog(expenseId);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}