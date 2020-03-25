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
namespace Overtech.ViewModels.Finance
{
    [OTDisplayName("Landlord")]
    [DataContract]
    public class Landlord : ViewModelObject
    {
        private long _landlordId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private string _landlordName;
        private int _landlordType;
        private string _landlordAddress;
        private string _contactInfo;
        private string _nationalId;
        private string _taxpayerId;
        private string _taxOffice;
        private Nullable<long> _legalRepresentative;
        private string _accountingCode;

        /*Section="Field-LandlordId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Landlord Id", null)]
        [OTDisplayName("Landlord Id")]
        [DataMember]
        public long LandlordId
        {
            get
            {
                return _landlordId;
            }
            set
            {
                _landlordId = value;
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

        /*Section="Field-LandlordName"*/
        [OTRequired("Landlord Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Landlord Name")]
        [DataMember]
        public string LandlordName
        {
            get
            {
                return _landlordName;
            }
            set
            {
                _landlordName = value;
            }
        }

        /*Section="Field-LandlordType"*/
        [OTRequired("Landlord Type", null)]
        [OTDisplayName("Landlord Type")]
        [DefaultValue(1)]
        [DataMember]
        public int LandlordType
        {
            get
            {
                return _landlordType;
            }
            set
            {
                _landlordType = value;
            }
        }

        /*Section="Field-LandlordAddress"*/
        [OTDisplayName("Landlord Address")]
        [DataMember]
        public string LandlordAddress
        {
            get
            {
                return _landlordAddress;
            }
            set
            {
                _landlordAddress = value;
            }
        }

        /*Section="Field-ContactInfo"*/
        [OTDisplayName("Contact Info")]
        [DataMember]
        public string ContactInfo
        {
            get
            {
                return _contactInfo;
            }
            set
            {
                _contactInfo = value;
            }
        }

        /*Section="Field-NationalId"*/
        [OTDisplayName("National Id")]
        [DataMember]
        public string NationalId
        {
            get
            {
                return _nationalId;
            }
            set
            {
                _nationalId = value;
            }
        }

        /*Section="Field-TaxpayerId"*/
        [OTDisplayName("Taxpayer Id")]
        [DataMember]
        public string TaxpayerId
        {
            get
            {
                return _taxpayerId;
            }
            set
            {
                _taxpayerId = value;
            }
        }

        /*Section="Field-TaxOffice"*/
        [OTDisplayName("Tax Office")]
        [DataMember]
        public string TaxOffice
        {
            get
            {
                return _taxOffice;
            }
            set
            {
                _taxOffice = value;
            }
        }

        /*Section="Field-LegalRepresentative"*/
        [UIHint("LandlordList")]
        [OTDisplayName("Legal Representative")]
        [DataMember]
        public Nullable<long> LegalRepresentative
        {
            get
            {
                return _legalRepresentative;
            }
            set
            {
                _legalRepresentative = value;
            }
        }

        /*Section="Field-AccountingCode"*/
        [OTDisplayName("Accounting Code")]
        [DataMember]
        public string AccountingCode
        {
            get
            {
                return _accountingCode;
            }
            set
            {
                _accountingCode = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _landlordId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
    }

    [DataContract]
    public class LandlordMikro : ViewModelObject
    {
        [DataMember] public string LandLordGuId { get; set; }
        [DataMember] public string Code { get; set; }
        [DataMember] public string Code2 { get; set; }
        [DataMember] public string Name1 { get; set; }
        [DataMember] public string Name2 { get; set; }
        [DataMember] public string Currency { get; set; }
        [DataMember] public int LandlordType { get; set; }
        [DataMember] public string LandlordAddress { get; set; }
        [DataMember] public string ContactInfo { get; set; }
        [DataMember] public string NationalId { get; set; }
        [DataMember] public string TaxpayerId { get; set; }
        [DataMember] public string TaxOffice { get; set; }
        [DataMember] public string Iban { get; set; }

        /*Section="Method-SetId"*/
        public override long GetId() { return 0; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}