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
namespace Overtech.DataModels.Store
{
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "WORKINGHOURS", HasAutoIdentity = true, DisplayName = "Working Hours", IdField = "WorkingHoursId")]
    [DataContract]
    public class WorkingHours : DataModelObject
    {
        private long _workingHoursId;
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
        private string _storeCode;
        private string _storeName;
        private Nullable<DateTime> _openingTime;
        private Nullable<DateTime> _closingTime;
        private string _openUserName;
        private string _closeUserName;
        private Nullable<long> _store;
        private Nullable<long> _openUser;
        private Nullable<long> _closeUser;
        private string _note;

        /*Section="Field-WorkingHoursId"*/
        [OTDataField("WORKINGHOURSID")]
        [DataMember]
        public long WorkingHoursId
        {
            get
            {
                return _workingHoursId;
            }
            set
            {
                _workingHoursId = value;
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

        /*Section="Field-StoreCode"*/
        [OTDataField("STORECODE_TXT")]
        [DataMember]
        public string StoreCode
        {
            get
            {
                return _storeCode;
            }
            set
            {
                _storeCode = value;
            }
        }

        /*Section="Field-StoreName"*/
        [OTDataField("STORE_NM")]
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

        /*Section="Field-OpeningTime"*/
        [OTDataField("OPENING_TM", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> OpeningTime
        {
            get
            {
                return _openingTime;
            }
            set
            {
                _openingTime = value;
            }
        }

        /*Section="Field-ClosingTime"*/
        [OTDataField("CLOSING_TM", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> ClosingTime
        {
            get
            {
                return _closingTime;
            }
            set
            {
                _closingTime = value;
            }
        }

        /*Section="Field-OpenUserName"*/
        [OTDataField("OPENGUSER_NM")]
        [DataMember]
        public string OpenUserName
        {
            get
            {
                return _openUserName;
            }
            set
            {
                _openUserName = value;
            }
        }

        /*Section="Field-CloseUserName"*/
        [OTDataField("CLOSEUSER_NM")]
        [DataMember]
        public string CloseUserName
        {
            get
            {
                return _closeUserName;
            }
            set
            {
                _closeUserName = value;
            }
        }

        /*Section="Field-Store"*/
        [OTDataField("STORE", Nullable = true)]
        [DataMember]
        public Nullable<long> Store
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

        /*Section="Field-OpenUser"*/
        [OTDataField("OPENUSER", Nullable = true)]
        [DataMember]
        public Nullable<long> OpenUser
        {
            get
            {
                return _openUser;
            }
            set
            {
                _openUser = value;
            }
        }

        /*Section="Field-CloseUser"*/
        [OTDataField("CLOSEUSER", Nullable = true)]
        [DataMember]
        public Nullable<long> CloseUser
        {
            get
            {
                return _closeUser;
            }
            set
            {
                _closeUser = value;
            }
        }

        /*Section="Field-Note"*/
        [OTDataField("NOTE_DSC")]
        [DataMember]
        public string Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _workingHoursId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

