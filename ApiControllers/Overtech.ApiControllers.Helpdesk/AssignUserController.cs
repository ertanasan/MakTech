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
    [RoutePrefix("api/Helpdesk/AssignUser")]
    public class AssignUserController : CRUDLApiController<Overtech.DataModels.Helpdesk.AssignUser, IAssignUserService, Overtech.ViewModels.Helpdesk.AssignUser>
    {
        /*Section="Constructor"*/
        public AssignUserController(
            ILoggerFactory loggerFactory,
            IAssignUserService assignUserService)
            : base(loggerFactory, assignUserService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}