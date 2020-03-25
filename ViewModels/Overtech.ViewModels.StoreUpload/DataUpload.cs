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
namespace Overtech.ViewModels.StoreUpload
{
    [OTDisplayName("Data Upload")]
    [DataContract]
    public class DataUpload : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Data Upload Id", null)]
        [OTDisplayName("Data Upload Id")]
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
        [ScaffoldColumn(false)]
        [OTRequired("Organization", null)]
        [OTDisplayName("Organization")]
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
        [ScaffoldColumn(false)]
        [OTRequired("Event", null)]
        [OTDisplayName("Event")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Deleted")]
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

        /*Section="Field-UpdateDate"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Update Date")]
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

        /*Section="Field-UpdateUser"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Update User")]
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

        /*Section="Field-UploadType"*/
        [UIHint("UploadTypeList")]
        [OTRequired("Upload Type", null)]
        [OTDisplayName("Upload Type")]
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
        [UIHint("StatusList")]
        [OTRequired("Status", null)]
        [OTDisplayName("Status")]
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
        [UIHint("DocumentList")]
        [OTRequired("Document", null)]
        [OTDisplayName("Document")]
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
        [OTRequired("Upload Date", null)]
        [OTDisplayName("Upload Date")]
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
        [OTDisplayName("Process Date")]
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
        [OTRequired("Source Ref", null)]
        [OTStringLength(100)]
        [OTDisplayName("Source Ref")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _dataUploadId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}