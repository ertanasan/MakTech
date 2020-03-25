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
    public interface INotificationTypeService : ICRUDLServiceContract<Overtech.DataModels.Announcement.NotificationType>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

