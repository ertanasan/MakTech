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
using Overtech.DataModels.Document;

/*Section="ClassHeader"*/
namespace Overtech.DataModels.Announcement
{
    [OTDataObject(Module = "Announcement", ModuleShortName = "ANN", Table = "NOTIFICATION", HasAutoIdentity = true, DisplayName = "Notification", IdField = "NotificationId")]
    [DataContract]
    public class Notification : DataModelObject
    {
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

        private IEnumerable<DataModels.Document.Document> _documentList;

        /*Section="Field-NotificationId"*/
        [OTDataField("NOTIFICATIONID")]
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
        [OTDataField("EVENT")]
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
        [OTDataField("ORGANIZATION")]
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
        [OTDataField("DELETED_FL")]
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

        /*Section="Field-UpdateDate"*/
        [OTDataField("UPDATE_DT", Nullable = true)]
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

        /*Section="Field-UpdateUser"*/
        [OTDataField("UPDATEUSER", Nullable = true)]
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

        /*Section="Field-NotificationText"*/
        [OTDataField("NOTIFICATION_TXT")]
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
        [OTDataField("NOTIFICATIONTYPE")]
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
        [OTDataField("NOTIFICATIONSTATUS")]
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
        [OTDataField("FOLDER", Nullable = true)]
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

        /*Section="Field-DocumentList"*/
        [ReadOnly(true)]
        [DataMember]
        public IEnumerable<DataModels.Document.Document> DocumentList
        {
            get
            {
                return _documentList;
            }
            set
            {
                _documentList = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _notificationId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OTDataField("USER_CNT", IsExtended = true)]
        [DataMember]
        public int UserCount
        {
            get; set;
        }

        [OTDataField("READ_CNT", IsExtended = true)]
        [DataMember]
        public int ReadCount
        {
            get; set;
        }
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

