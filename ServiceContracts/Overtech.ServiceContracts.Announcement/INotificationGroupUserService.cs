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
    public interface INotificationGroupUserService : ICRUDRServiceContract<Overtech.DataModels.Announcement.NotificationGroupUser>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        IEnumerable<DataModels.Announcement.NotificationGroupUser> ListAllGroupUsers();
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

