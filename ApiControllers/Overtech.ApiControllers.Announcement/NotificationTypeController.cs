﻿// Created by OverGenerator
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
    [RoutePrefix("api/Announcement/NotificationType")]
    public class NotificationTypeController : CRUDLApiController<Overtech.DataModels.Announcement.NotificationType, INotificationTypeService, Overtech.ViewModels.Announcement.NotificationType>
    {
        /*Section="Constructor"*/
        public NotificationTypeController(
            ILoggerFactory loggerFactory,
            INotificationTypeService notificationTypeService)
            : base(loggerFactory, notificationTypeService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}