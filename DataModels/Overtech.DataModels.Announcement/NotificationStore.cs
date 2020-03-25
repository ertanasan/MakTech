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
    [OTDataObject(Module = "Announcement", ModuleShortName = "ANN", Table = "NOTIFICATIONSTORE", HasAutoIdentity = false, DisplayName = "Notification Store", LeftIdField = "Notification", RightIdField = "Store")]
    [DataContract]
    public class NotificationStore : DataModelObject
    {
        private long _notification;
        private long _store;
        private DateTime _createDate;
        private long _createUser;
        private long _createChannel;
        private long _createBranch;
        private long _createScreen;
        private Nullable<long> _processInstance;
        private long _notificationNotificationId;
        private string _storeName;

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

        /*Section="Field-Store"*/
        [OTDataField("STORE")]
        [DataMember]
        public long Store
        {
            get
            {
                return _store;
            }
            set
            {
                _store = value;
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

        /*Section="Field-RightParentName"*/
        [OTDataField("STORE.STORE_NM")]
        [ReadOnly(true)]
        [DataMember]
        public string StoreName
        {
            get
            {
                return _storeName;
            }
            set
            {
                _storeName = value;
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
        [OTDataField("STORELST_TXT", IsExtended = true)]
        [DataMember]
        public int[] StoreList
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

