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
    public interface INotificationStoreService : ICRUDRServiceContract<Overtech.DataModels.Announcement.NotificationStore>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        void AddNotificationStores(NotificationStore notificationStore);

        [OperationContract]
        NotificationStore GetNotificationStore(long notificationId, long storeId);

        [OperationContract]
        void TakeAction(DataModels.Announcement.NotificationStore dataObject, long actionId, string choice, string comment);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

