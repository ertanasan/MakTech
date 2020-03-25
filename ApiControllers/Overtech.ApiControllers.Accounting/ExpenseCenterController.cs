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
    [RoutePrefix("api/Accounting/ExpenseCenter")]
    public class ExpenseCenterController : CRUDLApiController<Overtech.DataModels.Accounting.ExpenseCenter, IExpenseCenterService, Overtech.ViewModels.Accounting.ExpenseCenter>
    {
        /*Section="Constructor"*/
        public ExpenseCenterController(
            ILoggerFactory loggerFactory,
            IExpenseCenterService expenseCenterService)
            : base(loggerFactory, expenseCenterService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}