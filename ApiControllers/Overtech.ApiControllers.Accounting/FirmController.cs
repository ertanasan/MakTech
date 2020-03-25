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
    [RoutePrefix("api/Accounting/Firm")]
    public class FirmController : CRUDLApiController<Overtech.DataModels.Accounting.Firm, IFirmService, Overtech.ViewModels.Accounting.Firm>
    {
        /*Section="Constructor"*/
        public FirmController(
            ILoggerFactory loggerFactory,
            IFirmService firmService)
            : base(loggerFactory, firmService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}