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
    [RoutePrefix("api/Accounting/FirmType")]
    public class FirmTypeController : CRUDLApiController<Overtech.DataModels.Accounting.FirmType, IFirmTypeService, Overtech.ViewModels.Accounting.FirmType>
    {
        /*Section="Constructor"*/
        public FirmTypeController(
            ILoggerFactory loggerFactory,
            IFirmTypeService firmTypeService)
            : base(loggerFactory, firmTypeService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}