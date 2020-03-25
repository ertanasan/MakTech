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
using Overtech.ServiceContracts.Helpdesk;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Helpdesk
{
    [RoutePrefix("api/Helpdesk/RequestStatus")]
    public class RequestStatusController : CRUDLApiController<Overtech.DataModels.Helpdesk.RequestStatus, IRequestStatusService, Overtech.ViewModels.Helpdesk.RequestStatus>
    {
        /*Section="Constructor"*/
        public RequestStatusController(
            ILoggerFactory loggerFactory,
            IRequestStatusService requestStatusService)
            : base(loggerFactory, requestStatusService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}