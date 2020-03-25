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
namespace Overtech.DataModels.Finance
{
    [OTDataObject(Module = "Finance", ModuleShortName = "FIN", Table = "CONTRACTDRAFTVERSION", HasAutoIdentity = true, DisplayName = "Contract Draft Version", IdField = "ContractDraftVersionId")]
    [DataContract]
    public class ContractDraftVersion : DataModelObject
    {
        private long _contractDraftVersionId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private long _documentId;
        private string _changeDetails;

        /*Section="Field-ContractDraftVersionId"*/
        [OTDataField("CONTRACTDRAFTVERSIONID")]
        [DataMember]
        public long ContractDraftVersionId
        {
            get
            {
                return _contractDraftVersionId;
            }
            set
            {
                _contractDraftVersionId = value;
            }
        }

        /*Section="Field-Organization"*/
        [OTDataField("ORGANIZATION")]
        [ReadOnly(true)]
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

        /*Section="Field-DocumentId"*/
        [OTDataField("DRAFTDOCUMENT")]
        [DataMember]
        public long DocumentId
        {
            get
            {
                return _documentId;
            }
            set
            {
                _documentId = value;
            }
        }

        /*Section="Field-ChangeDetails"*/
        [OTDataField("CHANGEDETAIL_DSC")]
        [DataMember]
        public string ChangeDetails
        {
            get
            {
                return _changeDetails;
            }
            set
            {
                _changeDetails = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _contractDraftVersionId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

