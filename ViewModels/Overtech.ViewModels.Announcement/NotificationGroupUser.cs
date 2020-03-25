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
    [OTDisplayName("Notification Group User")]
    [DataContract]
    public class NotificationGroupUser : RelationViewModelObject
    {
        private long _notificationGroup;
        private long _user;
        private DateTime _createDate;
        private long _createUser;
        private long _createChannel;
        private long _createBranch;
        private long _createScreen;
        private string _notificationGroupGroupName;
        private string _userName;

        /*Section="Field-NotificationGroup"*/
        [UIHint("NotificationGroupList")]
        [OTRequired("Notification Group", null)]
        [OTDisplayName("Notification Group")]
        [DataMember]
        public long NotificationGroup
        {
            get
            {
                return _notificationGroup;
            }
            set
            {
                _notificationGroup = value;
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
        #region Parent Name Fields
        /*Section="Field-LeftParentName"*/
        [OTDisplayName("NotificationGroup GroupName")]
        [DataMember]
        public string NotificationGroupGroupName
        {
            get
            {
                return _notificationGroupGroupName;
            }
            set
            {
                _notificationGroupGroupName = value;
            }
        }

        /*Section="Field-RightParentName"*/
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
        #endregion Parent Name Fields

        /*Section="Method-SetLeftId"*/
        public override void SetLeftId(long leftId)
        {
            _notificationGroup = leftId;
        }

        /*Section="Method-SetRightId"*/
        public override void SetRightId(long rightId)
        {
            _user = rightId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}