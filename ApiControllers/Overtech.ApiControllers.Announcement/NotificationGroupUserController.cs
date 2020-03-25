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
using Overtech.ServiceContracts.Announcement;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Announcement
{
    [RoutePrefix("api/Announcement/NotificationGroupUser")]
    public class NotificationGroupUserController : OTRelationApiController<Overtech.DataModels.Announcement.NotificationGroupUser, INotificationGroupUserService, Overtech.ViewModels.Announcement.NotificationGroupUser>
    {
        /*Section="Constructor"*/
        public NotificationGroupUserController(
            ILoggerFactory loggerFactory,
            INotificationGroupUserService notificationGroupUserService)
            : base(loggerFactory, notificationGroupUserService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [HttpGet]
        [Route("ListAllGroupUsers")]
        [OTControllerAction("List")]
        public IEnumerable<ViewModels.Announcement.NotificationGroupUser> ListAllGroupUsers()
        {
            return _dataService.ListAllGroupUsers().Map<DataModels.Announcement.NotificationGroupUser, ViewModels.Announcement.NotificationGroupUser>();
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}