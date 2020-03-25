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
    [OTDataObject(Module = "OverStoreMain", ModuleShortName = "OSM", Table = "TASK", HasAutoIdentity = true, DisplayName = "OverStoreTask", IdField = "OverStoreTaskId")]
    [DataContract]
    public class OverStoreTask : DataModelObject
    {
        private long _overStoreTaskId;
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
        private long _status;
        private long _type;
        private string _content;
        private Nullable<DateTime> _deadline;
        private int _responsibleType;
        private Nullable<long> _responsibleUser;
        private Nullable<long> _responsibleGroup;
        private Nullable<long> _responsibleBranch;
        private Nullable<long> _processInstance;
        private bool _forwardableFlag;
        private Nullable<long> _folder;

        private IEnumerable<Overtech.DataModels.Document.Document> _documentList = new List<Overtech.DataModels.Document.Document>();

        /*Section="Field-OverStoreTaskId"*/
        [OTDataField("TASKID")]
        [DataMember]
        public long OverStoreTaskId
        {
            get
            {
                return _overStoreTaskId;
            }
            set
            {
                _overStoreTaskId = value;
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

        /*Section="Field-Type"*/
        [OTDataField("TYPE")]
        [DataMember]
        public long Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        /*Section="Field-Content"*/
        [OTDataField("CONTENT_TXT")]
        [DataMember]
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }

        /*Section="Field-Deadline"*/
        [OTDataField("DEADLINE_TM", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> Deadline
        {
            get
            {
                return _deadline;
            }
            set
            {
                _deadline = value;
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
            _overStoreTaskId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [DataMember]
        public long action { get; set; }

        [DataMember]
        public string actionChoice { get; set; }

        [DataMember]
        public string actionComment { get; set; }

        [OTDataField("PREVIOUSACTIONCOMMENT_DSC", IsExtended = true)]
        [DataMember]
        public string PreviousActionComment { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

