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

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Reconciliation
{
    [RoutePrefix("api/Reconciliation/ExpenseType")]
    public class ExpenseTypeController : CRUDLApiController<Overtech.DataModels.Reconciliation.ExpenseType, IExpenseTypeService, Overtech.ViewModels.Reconciliation.ExpenseType>
    {
        /*Section="Constructor"*/
        public ExpenseTypeController(
            ILoggerFactory loggerFactory,
            IExpenseTypeService expenseTypeService)
            : base(loggerFactory, expenseTypeService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}