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
using Overtech.ViewModels.Document;

/*Section="ClassHeader"*/
namespace Overtech.ViewModels.Finance
{
    [OTDisplayName("Contract Draft Version")]
    [DataContract]
    public class ContractDraftVersion : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Contract Draft Version Id", null)]
        [OTDisplayName("Contract Draft Version Id")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Organization")]
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

        /*Section="Field-DocumentId"*/
        [UIHint("DocumentList")]
        [OTRequired("Document Id", null)]
        [OTDisplayName("Document Id")]
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
        [OTStringLength(1000)]
        [OTDisplayName("Change Details")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _contractDraftVersionId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [DataMember]
        public DocumentHandle DraftDocument = new DocumentHandle();
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}