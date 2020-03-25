// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Announcement;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Announcement
{
    [ServiceContract]
    public interface INotificationService : ICRUDLServiceContract<Overtech.DataModels.Announcement.Notification>
    {
        /*Section="Method-ListNotificationUsers"*/
        [OperationContract]
        IEnumerable<NotificationUser> ListNotificationUsers(long notificationId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        void PublishNotification(DataModels.Announcement.Notification notification);

        [OperationContract]
        IEnumerable<DataModels.Announcement.Notification> GetUserNotifications(string isSystemNotificationsIncluded);

        [OperationContract]
        void CreateLogForDownload(long documentId);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

