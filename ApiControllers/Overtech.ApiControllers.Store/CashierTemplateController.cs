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
using Overtech.ServiceContracts.Store;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Store
{
    [RoutePrefix("api/Store/CashierTemplate")]
    public class CashierTemplateController : CRUDLApiController<Overtech.DataModels.Store.CashierTemplate, ICashierTemplateService, Overtech.ViewModels.Store.CashierTemplate>
    {
        /*Section="Constructor"*/
        public CashierTemplateController(
            ILoggerFactory loggerFactory,
            ICashierTemplateService cashierTemplateService)
            : base(loggerFactory, cashierTemplateService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}