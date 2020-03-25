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
    [OTDisplayName("Notification")]
    [DataContract]
    public class Notification : ViewModelObject
    {
        /*Section="Constructor"*/
        public Notification()
        {
            this.FolderReference = Guid.NewGuid().ToString();
        }

        public string FolderReference { get; set; }

        private long _notificationId;
        private long _event;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private long _createChannel;
        private long _createBranch;
        private long _createScreen;
        private string _notificationText;
        private long _notificationType;
        private long _notificationStatus;
        private Nullable<long> _folder;

        /*Section="Field-NotificationId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Notification Id", null)]
        [OTDisplayName("Notification Id")]
        [DataMember]
        public long NotificationId
        {
            get
            {
                return _notificationId;
            }
            set
            {
                _notificationId = value;
            }
        }

        /*Section="Field-Event"*/
        [ScaffoldColumn(false)]
        [OTRequired("Event", null)]
        [OTDisplayName("Event")]
        [DataMember]
        public long Event
        {
            get
            {
                return _event;
            }
            set
            {
                _event = value;
            }
        }

        /*Section="Field-Organization"*/
        [ScaffoldColumn(false)]
        [OTRequired("Organization", null)]
        [OTDisplayName("Organization")]
        [DataMember]
        public long Organization
        {
            get
            {
                return _organization;
            }
            set
            {
                _organization = value;
            }
        }

        /*Section="Field-Deleted"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Deleted")]
        [ReadOnly(true)]
        [DataMember]
        public bool Deleted
        {
            get
            {
                return _deleted;
            }
            set
            {
                _deleted = value;
            }
        }

        /*Section="Field-CreateDate"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Date")]
        [ReadOnly(true)]
        [DataMember]
        public DateTime CreateDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
            }
        }

        /*Section="Field-UpdateDate"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Update Date")]
        [ReadOnly(true)]
        [DataMember]
        public Nullable<DateTime> UpdateDate
        {
            get
            {
                return _updateDate;
            }
            set
            {
                _updateDate = value;
            }
        }

        /*Section="Field-CreateUser"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create User")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateUser
        {
            get
            {
                return _createUser;
            }
            set
            {
                _createUser = value;
            }
        }

        /*Section="Field-UpdateUser"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Update User")]
        [ReadOnly(true)]
        [DataMember]
        public Nullable<long> UpdateUser
        {
            get
            {
                return _updateUser;
            }
            set
            {
                _updateUser = value;
            }
        }

        /*Section="Field-CreateChannel"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Channel")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateChannel
        {
            get
            {
                return _createChannel;
            }
            set
            {
                _createChannel = value;
            }
        }

        /*Section="Field-CreateBranch"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Branch")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateBranch
        {
            get
            {
                return _createBranch;
            }
            set
            {
                _createBranch = value;
            }
        }

        /*Section="Field-CreateScreen"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Screen")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateScreen
        {
            get
            {
                return _createScreen;
            }
            set
            {
                _createScreen = value;
            }
        }

        /*Section="Field-NotificationText"*/
        [OTRequired("Notification Text", null)]
        [OTDisplayName("Notification Text")]
        [DataMember]
        public string NotificationText
        {
            get
            {
                return _notificationText;
            }
            set
            {
                _notificationText = value;
            }
        }

        /*Section="Field-NotificationType"*/
        [UIHint("NotificationTypeList")]
        [OTRequired("Notification Type", null)]
        [OTDisplayName("Notification Type")]
        [DataMember]
        public long NotificationType
        {
            get
            {
                return _notificationType;
            }
            set
            {
                _notificationType = value;
            }
        }

        /*Section="Field-NotificationStatus"*/
        [UIHint("NotificationStatusList")]
        [OTRequired("Notification Status", null)]
        [OTDisplayName("Notification Status")]
        [DataMember]
        public long NotificationStatus
        {
            get
            {
                return _notificationStatus;
            }
            set
            {
                _notificationStatus = value;
            }
        }

        /*Section="Field-Folder"*/
        [UIHint("FolderList")]
        [OTDisplayName("Folder")]
        [DataMember]
        public Nullable<long> Folder
        {
            get
            {
                return _folder;
            }
            set
            {
                _folder = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _notificationId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [DataMember]
        public int UserCount
        {
            get; set;
        }

        [DataMember]
        public int ReadCount
        {
            get; set;
        }

        [DataMember]
        public ViewModels.Document.FolderHandle FolderHandle = new ViewModels.Document.FolderHandle();
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}