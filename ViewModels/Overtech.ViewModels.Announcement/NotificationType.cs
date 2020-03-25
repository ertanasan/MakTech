// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Overtech.Core.Data;
using Overtech.UI.Data.Annotations;

/*Section="ClassHeader"*/
namespace Overtech.ViewModels.Announcement
{
    [OTDisplayName("Notification Type")]
    [DataContract]
    public class NotificationType : ViewModelObject
    {
        private long _notificationTypeId;
        private string _notificationTypeName;
        private string _description;

        /*Section="Field-NotificationTypeId"*/
        [OTRequired("Notification Type Id", null)]
        [OTDisplayName("Notification Type Id")]
        [DataMember]
        public long NotificationTypeId
        {
            get
            {
                return _notificationTypeId;
            }
            set
            {
                _notificationTypeId = value;
            }
        }

        /*Section="Field-NotificationTypeName"*/
        [OTRequired("Notification Type Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Notification Type Name")]
        [DataMember]
        public string NotificationTypeName
        {
            get
            {
                return _notificationTypeName;
            }
            set
            {
                _notificationTypeName = value;
            }
        }

        /*Section="Field-Description"*/
        [OTStringLength(1000)]
        [OTDisplayName("Description")]
        [DataMember]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _notificationTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}