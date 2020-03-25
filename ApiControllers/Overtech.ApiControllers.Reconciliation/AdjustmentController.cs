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

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Reconciliation
{
    [RoutePrefix("api/Reconciliation/Adjustment")]
    public class AdjustmentController : CRUDLApiController<Overtech.DataModels.Reconciliation.Adjustment, IAdjustmentService, Overtech.ViewModels.Reconciliation.Adjustment>
    {
        /*Section="Constructor"*/
        public AdjustmentController(
            ILoggerFactory loggerFactory,
            IAdjustmentService adjustmentService)
            : base(loggerFactory, adjustmentService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [Route("Adjustment")]
        [OTControllerAction("Read")]
        public decimal OpenExpenses(long storeId, DateTime date)
        {
            return _dataService.Adjustment(storeId, date);
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}