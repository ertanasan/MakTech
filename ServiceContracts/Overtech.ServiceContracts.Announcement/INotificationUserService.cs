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
    public interface INotificationUserService : ICRUDRServiceContract<Overtech.DataModels.Announcement.NotificationUser>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        void AddNotificationUsers(NotificationUser notificationUser);

        [OperationContract]
        NotificationUser GetNotificationUser(long notificationId, long userId);

        [OperationContract]
        void TakeAction(DataModels.Announcement.NotificationUser dataObject, long actionId, string choice, string comment);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

