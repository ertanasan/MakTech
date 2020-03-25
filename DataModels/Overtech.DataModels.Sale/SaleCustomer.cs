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
namespace Overtech.DataModels.Sale
{
    [OTDataObject(Module = "Sale", ModuleShortName = "SLS", Table = "SALECUSTOMER", HasAutoIdentity = true, DisplayName = "Sale Customer", IdField = "SaleCustomerId", MasterField = "Sale")]
    [DataContract]
    public class SaleCustomer : DataModelObject
    {
        private long _saleCustomerId;
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
        private long _sale;
        private bool _eInvoiceFlag;
        private string _customerName;
        private string _address;
        private string _taxCenterName;
        private string _taxIdentityNo;
        private string _email;
        private string _phoneNumber;
        private string _fiscalSerial;
        private Nullable<int> _eInvoiceZetNumber;
        private Nullable<int> _eInvoiceReceiptNumber;

        /*Section="Field-SaleCustomerId"*/
        [OTDataField("SALECUSTOMERID")]
        [DataMember]
        public long SaleCustomerId
        {
            get
            {
                return _saleCustomerId;
            }
            set
            {
                _saleCustomerId = value;
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

        /*Section="Field-Sale"*/
        [OTDataField("SALE")]
        [DataMember]
        public long Sale
        {
            get
            {
                return _sale;
            }
            set
            {
                _sale = value;
            }
        }

        /*Section="Field-EInvoiceFlag"*/
        [OTDataField("EINVOICE_FL")]
        [DataMember]
        public bool EInvoiceFlag
        {
            get
            {
                return _eInvoiceFlag;
            }
            set
            {
                _eInvoiceFlag = value;
            }
        }

        /*Section="Field-CustomerName"*/
        [OTDataField("CUSTOMER_NM")]
        [DataMember]
        public string CustomerName
        {
            get
            {
                return _customerName;
            }
            set
            {
                _customerName = value;
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

        /*Section="Field-TaxIdentityNo"*/
        [OTDataField("IDENTITYNO_TXT")]
        [DataMember]
        public string TaxIdentityNo
        {
            get
            {
                return _taxIdentityNo;
            }
            set
            {
                _taxIdentityNo = value;
            }
        }

        /*Section="Field-Email"*/
        [OTDataField("EMAIL_TXT")]
        [DataMember]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        /*Section="Field-PhoneNumber"*/
        [OTDataField("PHONENUMBER_TXT")]
        [DataMember]
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
            }
        }

        /*Section="Field-FiscalSerial"*/
        [OTDataField("FISCALSERIAL_TXT")]
        [DataMember]
        public string FiscalSerial
        {
            get
            {
                return _fiscalSerial;
            }
            set
            {
                _fiscalSerial = value;
            }
        }

        /*Section="Field-EInvoiceZetNumber"*/
        [OTDataField("EINVOICEZET_NO", Nullable = true)]
        [DataMember]
        public Nullable<int> EInvoiceZetNumber
        {
            get
            {
                return _eInvoiceZetNumber;
            }
            set
            {
                _eInvoiceZetNumber = value;
            }
        }

        /*Section="Field-EInvoiceReceiptNumber"*/
        [OTDataField("EINVOICERECEIPT_NO", Nullable = true)]
        [DataMember]
        public Nullable<int> EInvoiceReceiptNumber
        {
            get
            {
                return _eInvoiceReceiptNumber;
            }
            set
            {
                _eInvoiceReceiptNumber = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _saleCustomerId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

