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
namespace Overtech.DataModels.OverStoreMain
{
    [OTDataObject(Module = "OverStoreMain", ModuleShortName = "OSM", Table = "TASKHISTORY", HasAutoIdentity = true, DisplayName = "OverStoreTaskHistory", IdField = "OverStoreTaskHistoryId")]
    [DataContract]
    public class OverStoreTaskHistory : DataModelObject
    {
        private long _overStoreTaskHistoryId;
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
        private long _overStoreTask;
        private DateTime _historyTime;
        private long _status;
        private string _changeDetail;
        private int _responsibleType;
        private Nullable<long> _responsibleUser;
        private Nullable<long> _responsibleGroup;
        private Nullable<long> _responsibleBranch;
        private bool _forwardableFlag;

        /*Section="Field-OverStoreTaskHistoryId"*/
        [OTDataField("TASKHISTORYID")]
        [DataMember]
        public long OverStoreTaskHistoryId
        {
            get
            {
                return _overStoreTaskHistoryId;
            }
            set
            {
                _overStoreTaskHistoryId = value;
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

        /*Section="Field-OverStoreTask"*/
        [OTDataField("TASK")]
        [DataMember]
        public long OverStoreTask
        {
            get
            {
                return _overStoreTask;
            }
            set
            {
                _overStoreTask = value;
            }
        }

        /*Section="Field-HistoryTime"*/
        [OTDataField("HISTORY_TM")]
        [DataMember]
        public DateTime HistoryTime
        {
            get
            {
                return _historyTime;
            }
            set
            {
                _historyTime = value;
            }
        }

        /*Section="Field-Status"*/
        [OTDataField("STATUS")]
        [DataMember]
        public long Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        /*Section="Field-ChangeDetail"*/
        [OTDataField("CHANGEDETAIL_DSC")]
        [DataMember]
        public string ChangeDetail
        {
            get
            {
                return _changeDetail;
            }
            set
            {
                _changeDetail = value;
            }
        }

        /*Section="Field-ResponsibleType"*/
        [OTDataField("RESPONSIBLETYPE_CD")]
        [DataMember]
        public int ResponsibleType
        {
            get
            {
                return _responsibleType;
            }
            set
            {
                _responsibleType = value;
            }
        }

        /*Section="Field-ResponsibleUser"*/
        [OTDataField("RESPONSIBLEUSER", Nullable = true)]
        [DataMember]
        public Nullable<long> ResponsibleUser
        {
            get
            {
                return _responsibleUser;
            }
            set
            {
                _responsibleUser = value;
            }
        }

        /*Section="Field-ResponsibleGroup"*/
        [OTDataField("RESPONSIBLEGROUP", Nullable = true)]
        [DataMember]
        public Nullable<long> ResponsibleGroup
        {
            get
            {
                return _responsibleGroup;
            }
            set
            {
                _responsibleGroup = value;
            }
        }

        /*Section="Field-ResponsibleBranch"*/
        [OTDataField("RESPONSIBLEBRANCH", Nullable = true)]
        [DataMember]
        public Nullable<long> ResponsibleBranch
        {
            get
            {
                return _responsibleBranch;
            }
            set
            {
                _responsibleBranch = value;
            }
        }

        /*Section="Field-ForwardableFlag"*/
        [OTDataField("FORWARDABLE_FL")]
        [DataMember]
        public bool ForwardableFlag
        {
            get
            {
                return _forwardableFlag;
            }
            set
            {
                _forwardableFlag = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _overStoreTaskHistoryId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

