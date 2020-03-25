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
    [RoutePrefix("api/Helpdesk/RedirectionGroup")]
    public class RedirectionGroupController : CRUDLApiController<Overtech.DataModels.Helpdesk.RedirectionGroup, IRedirectionGroupService, Overtech.ViewModels.Helpdesk.RedirectionGroup>
    {
        /*Section="Constructor"*/
        public RedirectionGroupController(
            ILoggerFactory loggerFactory,
            IRedirectionGroupService redirectionGroupService)
            : base(loggerFactory, redirectionGroupService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}