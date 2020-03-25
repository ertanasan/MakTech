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
    [OTDataObject(Module = "Finance", ModuleShortName = "FIN", Table = "LANDLORD", HasAutoIdentity = true, DisplayName = "Landlord", IdField = "LandlordId")]
    [DataContract]
    public class Landlord : DataModelObject
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
        [OTDataField("LANDLORDID")]
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

        /*Section="Field-LandlordName"*/
        [OTDataField("LANDLOARD_NM")]
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
        [OTDataField("LANDLORDTYPE_CD")]
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
        [OTDataField("LANDLORD_ADR")]
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
        [OTDataField("CONTACT_TXT")]
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
        [OTDataField("NATIONALID_TXT")]
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
        [OTDataField("TAXPAYERID_TXT")]
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
        [OTDataField("TAXOFFICE_TXT")]
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
        [OTDataField("LEGALREPRESENTATIVE", Nullable = true)]
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
        [OTDataField("ACCOUNTINGCODE_TXT")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _landlordId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
    }

    [OTDataObject]
    [DataContract]
    public class LandlordMikro : DataModelObject
    {
        [OTDataField("LANDLORDGUID")]
        [DataMember]
        public string LandLordGuId { get; set; }

        [OTDataField("CODE_TXT")]
        [DataMember]
        public string Code { get; set; }

        [OTDataField("CODE2_TXT")]
        [DataMember]
        public string Code2 { get; set; }

        [OTDataField("NAME1_TXT")]
        [DataMember]
        public string Name1 { get; set; }

        [OTDataField("NAME2_TXT")]
        [DataMember]
        public string Name2 { get; set; }

        [OTDataField("CURRENCY_TXT")]
        [DataMember]
        public string Currency { get; set; }

        [OTDataField("LANDLORDTYPE_CD")]
        [DataMember]
        public int LandlordType { get; set; }

        [OTDataField("LANDLORD_ADR")]
        [DataMember]
        public string LandlordAddress { get; set; }

        [OTDataField("CONTACT_TXT")]
        [DataMember]
        public string ContactInfo { get; set; }

        [OTDataField("NATIONALID_TXT")]
        [DataMember]
        public string NationalId { get; set; }

        [OTDataField("TAXPAYERID_TXT")]
        [DataMember]
        public string TaxpayerId { get; set; }

        [OTDataField("TAXOFFICE_TXT")]
        [DataMember]
        public string TaxOffice { get; set; }

        [OTDataField("IBAN1_TXT")]
        [DataMember]
        public string Iban { get; set; }

        /*Section="Method-SetId"*/
        public override void SetId(long id) { }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

