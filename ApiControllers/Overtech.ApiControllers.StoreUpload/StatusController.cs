// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.StoreUpload;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.StoreUpload
{
    [RoutePrefix("api/StoreUpload/Status")]
    public class StatusController : CRUDLApiController<Overtech.DataModels.StoreUpload.Status, IStatusService, Overtech.ViewModels.StoreUpload.Status>
    {
        /*Section="Constructor"*/
        public StatusController(
            ILoggerFactory loggerFactory,
            IStatusService statusService)
            : base(loggerFactory, statusService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}