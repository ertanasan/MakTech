// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Announcement;
using Overtech.ServiceContracts.Announcement;

/*Section="ClassHeader"*/
namespace Overtech.Services.Announcement
{
    [OTInspectorBehavior]
    public class NotificationStatusService : CRUDLDataService<Overtech.DataModels.Announcement.NotificationStatus>, INotificationStatusService
    {
        /*Section="Constructor-1"*/
        public NotificationStatusService()
        {
        }

        /*Section="Constructor-2"*/
        internal NotificationStatusService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Announcement.NotificationStatus Find(string notificationStatusName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmNotificationStatusName = dal.CreateParameter("NotificationStatusName", notificationStatusName);
                return dal.Read<Overtech.DataModels.Announcement.NotificationStatus>("ANN_SEL_FINDNOTIFICATIONSTATUS_SP", prmNotificationStatusName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}