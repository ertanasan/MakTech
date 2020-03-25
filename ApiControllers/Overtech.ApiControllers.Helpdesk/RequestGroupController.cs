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
    [RoutePrefix("api/Helpdesk/RequestGroup")]
    public class RequestGroupController : CRUDLApiController<Overtech.DataModels.Helpdesk.RequestGroup, IRequestGroupService, Overtech.ViewModels.Helpdesk.RequestGroup>
    {
        /*Section="Constructor"*/
        public RequestGroupController(
            ILoggerFactory loggerFactory,
            IRequestGroupService requestGroupService)
            : base(loggerFactory, requestGroupService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}