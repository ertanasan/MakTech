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
    [OTDataObject(Module = "Announcement", ModuleShortName = "ANN", Table = "NOTIFICATIONGROUPUSER", HasAutoIdentity = false, DisplayName = "Notification Group User", LeftIdField = "NotificationGroup", RightIdField = "User")]
    [DataContract]
    public class NotificationGroupUser : DataModelObject
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
        [OTDataField("NOTIFICATIONGROUP")]
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

        #region Parent Name Fields
        /*Section="Field-LeftParentName"*/
        [OTDataField("NOTIFICATIONGROUP.GROUP_NM")]
        [ReadOnly(true)]
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
        #endregion Parent Name Fields

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

