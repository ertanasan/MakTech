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
    [RoutePrefix("api/Announcement/NotificationStatus")]
    public class NotificationStatusController : CRUDLApiController<Overtech.DataModels.Announcement.NotificationStatus, INotificationStatusService, Overtech.ViewModels.Announcement.NotificationStatus>
    {
        /*Section="Constructor"*/
        public NotificationStatusController(
            ILoggerFactory loggerFactory,
            INotificationStatusService notificationStatusService)
            : base(loggerFactory, notificationStatusService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}