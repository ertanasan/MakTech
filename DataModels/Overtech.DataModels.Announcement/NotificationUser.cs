// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Overtech.Core.Data;

/*Section="ClassHeader"*/
namespace Overtech.DataModels.Announcement
{
    [OTDataObject(Module = "Announcement", ModuleShortName = "ANN", Table = "NOTIFICATIONUSER", HasAutoIdentity = false, DisplayName = "Notification User", LeftIdField = "Notification", RightIdField = "User")]
    [DataContract]
    public class NotificationUser : DataModelObject
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
        [OTDataField("NOTIFICATION")]
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
        [OTDataField("USER")]
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
        [OTDataField("CREATE_DT")]
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
        [OTDataField("CREATEUSER")]
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
        [OTDataField("CREATECHANNEL")]
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
        [OTDataField("CREATEBRANCH")]
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
        [OTDataField("CREATESCREEN")]
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
        [OTDataField("PROCESSINSTANCE_LNO", Nullable = true)]
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
        [OTDataField("NOTIFICATION.NOTIFICATIONID")]
        [ReadOnly(true)]
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
        [OTDataField("USER.USER_NM")]
        [ReadOnly(true)]
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

        [OTDataField("USER.USERFULL_NM")]
        [ReadOnly(true)]
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

            /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OTDataField("READ_FL", IsExtended = true)]
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

        [OTDataField("BRANCH_NM", IsExtended = true)]
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

        // [OTDataField("USERLIST_CNT", IsExtended = true)]
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

