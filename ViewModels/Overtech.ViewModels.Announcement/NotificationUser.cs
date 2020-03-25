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
    [OTDisplayName("Notification User")]
    [DataContract]
    public class NotificationUser : RelationViewModelObject
    {
        private long _notification;
        private long _user;
        private DateTime _createDate;
        private long _createUser;
        private long _createChannel;
        private long _createBranch;
        private long _createScreen;
        private Nullable<long> _processInstance;
        private long _notificationNotificationId;
        private string _userName;
        private string _userFullName;
        private bool _isRead;
        private string _branchName;

        /*Section="Field-Notification"*/
        [UIHint("NotificationList")]
        [OTRequired("Notification", null)]
        [OTDisplayName("Notification")]
        [DataMember]
        public long Notification
        {
            get
            {
                return _notification;
            }
            set
            {
                _notification = value;
            }
        }

        /*Section="Field-User"*/
        [UIHint("UserList")]
        [OTRequired("User", null)]
        [OTDisplayName("User")]
        [DataMember]
        public long User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
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

        /*Section="Field-ProcessInstance"*/
        [OTDisplayName("Process Instance")]
        [DataMember]
        public Nullable<long> ProcessInstance
        {
            get
            {
                return _processInstance;
            }
            set
            {
                _processInstance = value;
            }
        }
        #region Parent Name Fields
        /*Section="Field-LeftParentName"*/
        [OTDisplayName("Notification NotificationId")]
        [DataMember]
        public long NotificationNotificationId
        {
            get
            {
                return _notificationNotificationId;
            }
            set
            {
                _notificationNotificationId = value;
            }
        }

        /*Section="Field-RightParentName IsCustomized=true"*/
        [OTDisplayName("User Name")]
        [DataMember]
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }

        [OTDisplayName("User Full Name")]
        [DataMember]
        public string UserFullName
        {
            get
            {
                return _userFullName;
            }
            set
            {
                _userFullName = value;
            }
        }
        #endregion Parent Name Fields

        /*Section="Method-SetLeftId"*/
        public override void SetLeftId(long leftId)
        {
            _notification = leftId;
        }

        /*Section="Method-SetRightId"*/
        public override void SetRightId(long rightId)
        {
            _user = rightId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [DataMember]
        public bool IsRead
        {
            get
            {
                return _isRead;
            }
            set
            {
                _isRead = value;
            }
        }

        [DataMember]
        public string BranchName
        {
            get
            {
                return _branchName;
            }
            set
            {
                _branchName = value;
            }
        }

        [DataMember]
        public int[] UserList
        {
            get; set;
        }

        [DataMember]
        public long action { get; set; }

        [DataMember]
        public string actionChoice { get; set; }

        [DataMember]
        public string actionComment { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}