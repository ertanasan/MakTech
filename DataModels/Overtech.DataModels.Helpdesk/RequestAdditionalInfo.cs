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
namespace Overtech.DataModels.Helpdesk
{
    [OTDataObject(Module = "Helpdesk", ModuleShortName = "HDK", Table = "REQADDITIONALINFO", HasAutoIdentity = true, DisplayName = "Request Additional Info", IdField = "RequestAdditionalInfoId", MasterField = "Request")]
    [DataContract]
    public class RequestAdditionalInfo : DataModelObject
    {
        private long _requestAdditionalInfoId;
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
        private long _request;
        private Nullable<decimal> _cost;
        private Nullable<DateTime> _warrantyDueDate;
        private Nullable<long> _folder;

        private IEnumerable<DocumentExtended> _documentList;

        /*Section="Field-RequestAdditionalInfoId"*/
        [OTDataField("REQADDITIONALINFOID")]
        [DataMember]
        public long RequestAdditionalInfoId
        {
            get
            {
                return _requestAdditionalInfoId;
            }
            set
            {
                _requestAdditionalInfoId = value;
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

        /*Section="Field-Request"*/
        [OTDataField("REQUEST")]
        [DataMember]
        public long Request
        {
            get
            {
                return _request;
            }
            set
            {
                _request = value;
            }
        }

        /*Section="Field-Cost"*/
        [OTDataField("COST_AMT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
            }
        }

        /*Section="Field-WarrantyDueDate"*/
        [OTDataField("WARRANTYDUE_DT", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> WarrantyDueDate
        {
            get
            {
                return _warrantyDueDate;
            }
            set
            {
                _warrantyDueDate = value;
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
        public IEnumerable<DocumentExtended> DocumentList
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
            _requestAdditionalInfoId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

