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
using Overtech.DataModels.Document;//Custom

/*Section="ClassHeader"*/
namespace Overtech.DataModels.StoreUpload
{
    [OTDataObject(Module = "StoreUpload", ModuleShortName = "SUP", Table = "DATAUPLOAD", HasAutoIdentity = true, DisplayName = "Data Upload", IdField = "DataUploadId")]
    [DataContract]
    public class DataUpload : DataModelObject
    {
        private long _dataUploadId;
        private long _organization;
        private long _event;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private long _createChannel;
        private long _createBranch;
        private long _createScreen;
        private long _uploadType;
        private long _status;
        private long _document;
        private DateTime _uploadDate;
        private Nullable<DateTime> _processDate;
        private string _sourceRef;

        /*Section="Field-DataUploadId"*/
        [OTDataField("DATAUPLOADID")]
        [DataMember]
        public long DataUploadId
        {
            get
            {
                return _dataUploadId;
            }
            set
            {
                _dataUploadId = value;
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

        /*Section="Field-UploadType"*/
        [OTDataField("TYPE")]
        [DataMember]
        public long UploadType
        {
            get
            {
                return _uploadType;
            }
            set
            {
                _uploadType = value;
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

        /*Section="Field-UploadDate"*/
        [OTDataField("UPLOAD_DT")]
        [DataMember]
        public DateTime UploadDate
        {
            get
            {
                return _uploadDate;
            }
            set
            {
                _uploadDate = value;
            }
        }

        /*Section="Field-ProcessDate"*/
        [OTDataField("PROCESS_DT", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> ProcessDate
        {
            get
            {
                return _processDate;
            }
            set
            {
                _processDate = value;
            }
        }

        /*Section="Field-SourceRef"*/
        [OTDataField("SOURCE_REF")]
        [DataMember]
        public string SourceRef
        {
            get
            {
                return _sourceRef;
            }
            set
            {
                _sourceRef = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _dataUploadId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.

        [DataMember]
        public byte[] CompressedData { get; set; }
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

