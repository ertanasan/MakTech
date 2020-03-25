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
    [OTDisplayName("Notification Status")]
    [DataContract]
    public class NotificationStatus : ViewModelObject
    {
        private long _notificationStatusId;
        private string _notificationStatusName;
        private string _description;

        /*Section="Field-NotificationStatusId"*/
        [OTRequired("Notification Status Id", null)]
        [OTDisplayName("Notification Status Id")]
        [DataMember]
        public long NotificationStatusId
        {
            get
            {
                return _notificationStatusId;
            }
            set
            {
                _notificationStatusId = value;
            }
        }

        /*Section="Field-NotificationStatusName"*/
        [OTRequired("Notification Status Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Notification Status Name")]
        [DataMember]
        public string NotificationStatusName
        {
            get
            {
                return _notificationStatusName;
            }
            set
            {
                _notificationStatusName = value;
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
            return _notificationStatusId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}