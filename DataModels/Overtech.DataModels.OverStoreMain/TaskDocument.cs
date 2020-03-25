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
    [OTDataObject(Module = "OverStoreMain", ModuleShortName = "OSM", Table = "TASKDOCUMENT", HasAutoIdentity = false, DisplayName = "Task Document", LeftIdField = "OverStoreTask", RightIdField = "Document")]
    [DataContract]
    public class TaskDocument : DataModelObject
    {
        private long _overStoreTask;
        private long _document;
        private DateTime _createDate;
        private long _createUser;
        private long _createChannel;
        private long _createBranch;
        private long _createScreen;
        private long _overStoreTaskOverStoreTaskId;
        private string _documentName;

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

        /*Section="Field-Document"*/
        [OTDataField("DOCUMENT")]
        [DataMember]
        public long Document
        {
            get
            {
                return _document;
            }
            set
            {
                _document = value;
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
        [OTDataField("OVERSTORETASK.TASKID")]
        [ReadOnly(true)]
        [DataMember]
        public long OverStoreTaskOverStoreTaskId
        {
            get
            {
                return _overStoreTaskOverStoreTaskId;
            }
            set
            {
                _overStoreTaskOverStoreTaskId = value;
            }
        }

        /*Section="Field-RightParentName"*/
        [OTDataField("DOCUMENT.DOCUMENT_NM")]
        [ReadOnly(true)]
        [DataMember]
        public string DocumentName
        {
            get
            {
                return _documentName;
            }
            set
            {
                _documentName = value;
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

