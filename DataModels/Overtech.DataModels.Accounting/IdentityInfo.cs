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
namespace Overtech.DataModels.Accounting
{
    [OTDataObject(Module = "Accounting", ModuleShortName = "ACC", Table = "IDENTITYINFO", HasAutoIdentity = true, DisplayName = "Identity Info", IdField = "IdentityInfoId")]
    [DataContract]
    public class IdentityInfo : DataModelObject
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
        [OTDataField("IDENTITYINFOID")]
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

        /*Section="Field-IdentityNo"*/
        [OTDataField("IDENTITYNO_TXT")]
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
        [OTDataField("IDENTITY_NM")]
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
        [OTDataField("TAXCENTERCODE_TXT")]
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
        [OTDataField("TAXCENTER_NM")]
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
        [OTDataField("ACTIVESTATUS_TXT")]
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
        [OTDataField("COMPANYTYPE_TXT")]
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
        [OTDataField("FATHER_NM")]
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
        [OTDataField("IDENTITYTYPE_TXT")]
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
        [OTDataField("PROFESSIONCODE_TXT")]
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
        [OTDataField("PROFESSION_DSC")]
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
        [OTDataField("ADDRESS_TXT")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _identityInfoId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("EMAIL_TXT", IsExtended = true)]
        [DataMember]
        public string Email { get; set; }
        [OTDataField("PHONENUMBER_TXT", IsExtended = true)]
        [DataMember]
        public string PhoneNumber { get; set; }
        [OTDataField("EINVOICEFLAG_NO", IsExtended = true)]
        [DataMember]
        public int EInvoiceFlag { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

