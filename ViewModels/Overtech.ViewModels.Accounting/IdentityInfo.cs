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
namespace Overtech.ViewModels.Accounting
{
    [OTDisplayName("Identity Info")]
    [DataContract]
    public class IdentityInfo : ViewModelObject
    {
        private long _identityInfoId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private string _identityNo;
        private string _identityName;
        private string _taxCenterCode;
        private string _taxCenterName;
        private string _activeStatus;
        private string _companyType;
        private string _fatherName;
        private string _identityType;
        private string _professionCode;
        private string _profession;
        private string _address;

        /*Section="Field-IdentityInfoId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Identity Info Id", null)]
        [OTDisplayName("Identity Info Id")]
        [DataMember]
        public long IdentityInfoId
        {
            get
            {
                return _identityInfoId;
            }
            set
            {
                _identityInfoId = value;
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

        /*Section="Field-IdentityNo"*/
        [OTRequired("Identity No", null)]
        [OTDisplayName("Identity No")]
        [DataMember]
        public string IdentityNo
        {
            get
            {
                return _identityNo;
            }
            set
            {
                _identityNo = value;
            }
        }

        /*Section="Field-IdentityName"*/
        [OTRequired("Identity Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Identity Name")]
        [DataMember]
        public string IdentityName
        {
            get
            {
                return _identityName;
            }
            set
            {
                _identityName = value;
            }
        }

        /*Section="Field-TaxCenterCode"*/
        [OTRequired("Tax Center Code", null)]
        [OTDisplayName("Tax Center Code")]
        [DataMember]
        public string TaxCenterCode
        {
            get
            {
                return _taxCenterCode;
            }
            set
            {
                _taxCenterCode = value;
            }
        }

        /*Section="Field-TaxCenterName"*/
        [OTRequired("Tax Center Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Tax Center Name")]
        [DataMember]
        public string TaxCenterName
        {
            get
            {
                return _taxCenterName;
            }
            set
            {
                _taxCenterName = value;
            }
        }

        /*Section="Field-ActiveStatus"*/
        [OTDisplayName("Active Status")]
        [DataMember]
        public string ActiveStatus
        {
            get
            {
                return _activeStatus;
            }
            set
            {
                _activeStatus = value;
            }
        }

        /*Section="Field-CompanyType"*/
        [OTDisplayName("Company Type")]
        [DataMember]
        public string CompanyType
        {
            get
            {
                return _companyType;
            }
            set
            {
                _companyType = value;
            }
        }

        /*Section="Field-FatherName"*/
        [OTStringLength(30)]
        [OTDisplayName("Father Name")]
        [DataMember]
        public string FatherName
        {
            get
            {
                return _fatherName;
            }
            set
            {
                _fatherName = value;
            }
        }

        /*Section="Field-IdentityType"*/
        [OTDisplayName("Identity Type")]
        [DataMember]
        public string IdentityType
        {
            get
            {
                return _identityType;
            }
            set
            {
                _identityType = value;
            }
        }

        /*Section="Field-ProfessionCode"*/
        [OTDisplayName("Profession Code")]
        [DataMember]
        public string ProfessionCode
        {
            get
            {
                return _professionCode;
            }
            set
            {
                _professionCode = value;
            }
        }

        /*Section="Field-Profession"*/
        [OTStringLength(1000)]
        [OTDisplayName("Profession")]
        [DataMember]
        public string Profession
        {
            get
            {
                return _profession;
            }
            set
            {
                _profession = value;
            }
        }

        /*Section="Field-Address"*/
        [OTDisplayName("Address")]
        [DataMember]
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _identityInfoId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public int EInvoiceFlag { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}