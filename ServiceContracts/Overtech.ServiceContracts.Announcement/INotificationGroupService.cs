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
    public interface INotificationGroupService : ICRUDLServiceContract<Overtech.DataModels.Announcement.NotificationGroup>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Announcement.NotificationGroup Find(string groupName);
        /*Section="Method-CreateNotificationGroupUser"*/
        [OperationContract]
        void CreateNotificationGroupUser(NotificationGroupUser notificationGroupUser);

        /*Section="Method-ReadNotificationGroupUser"*/
        [OperationContract]
        NotificationGroupUser ReadNotificationGroupUser(long notificationGroup, long user);

        /*Section="Method-DeleteNotificationGroupUser"*/
        [OperationContract]
        void DeleteNotificationGroupUser(long notificationGroup, long user);

        /*Section="Method-ListNotificationGroupUsers"*/
        [OperationContract]
        IEnumerable<NotificationGroupUser> ListNotificationGroupUsers(long notificationGroupId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

