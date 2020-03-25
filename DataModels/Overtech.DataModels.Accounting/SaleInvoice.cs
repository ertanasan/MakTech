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
    [OTDataObject(Module = "Accounting", ModuleShortName = "ACC", Table = "INVOICE", HasAutoIdentity = true, DisplayName = "Sale Invoice", IdField = "SaleInvoiceId")]
    [DataContract]
    public class SaleInvoice : DataModelObject
    {
        private long _saleInvoiceId;
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
        private bool _eInvoiceFlag;
        private long _customerIdNumber;
        private string _title;
        private string _email;
        private long _sale;
        private Nullable<long> _eInvoiceClient;
        private string _address;
        private int _statusCode;
        private bool _mikroFlag;
        private Nullable<DateTime> _mikroTransferTime;
        private Nullable<long> _processInstance;
        private string _phoneNumber;

        /*Section="Field-SaleInvoiceId"*/
        [OTDataField("INVOICEID")]
        [DataMember]
        public long SaleInvoiceId
        {
            get
            {
                return _saleInvoiceId;
            }
            set
            {
                _saleInvoiceId = value;
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

        /*Section="Field-CustomerIdNumber"*/
        [OTDataField("CUSTOMERID_LNO")]
        [DataMember]
        public long CustomerIdNumber
        {
            get
            {
                return _customerIdNumber;
            }
            set
            {
                _customerIdNumber = value;
            }
        }

        /*Section="Field-Title"*/
        [OTDataField("TITLE_DSC")]
        [DataMember]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
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

        /*Section="Field-EInvoiceClient"*/
        [OTDataField("EINVOICECLIENT", Nullable = true)]
        [DataMember]
        public Nullable<long> EInvoiceClient
        {
            get
            {
                return _eInvoiceClient;
            }
            set
            {
                _eInvoiceClient = value;
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

        /*Section="Field-StatusCode"*/
        [OTDataField("STATUS_CD")]
        [DataMember]
        public int StatusCode
        {
            get
            {
                return _statusCode;
            }
            set
            {
                _statusCode = value;
            }
        }

        /*Section="Field-MikroFlag"*/
        [OTDataField("MIKRO_FL")]
        [DataMember]
        public bool MikroFlag
        {
            get
            {
                return _mikroFlag;
            }
            set
            {
                _mikroFlag = value;
            }
        }

        /*Section="Field-MikroTransferTime"*/
        [OTDataField("MIKRO_TM", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> MikroTransferTime
        {
            get
            {
                return _mikroTransferTime;
            }
            set
            {
                _mikroTransferTime = value;
            }
        }

        /*Section="Field-ProcessInstance"*/
        [OTDataField("PROCESSINSTANCE_LNO", Nullable = true)]
        [DataMember]
        public Nullable<long> ProcessInstance
        {
            get
            {
                return _processInstance;
            }
            set
            {
                _processInstance = value;
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _saleInvoiceId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("TRANSACTION_DT", IsExtended = true)]
        [DataMember]
        public DateTime SaleDate { get; set; }

        [OTDataField("TRANSACTION_TXT", IsExtended = true)]
        [DataMember]
        public string SaleRef { get; set; }

        [OTDataField("TOTAL_AMT", IsExtended = true)]
        [DataMember]
        public decimal SaleAmount { get; set; }

        [OTDataField("STORE", IsExtended = true)]
        [DataMember]
        public int SaleStore { get; set; }

        [DataMember]
        public long action { get; set; }

        [DataMember]
        public string actionChoice { get; set; }

        [DataMember]
        public string actionComment { get; set; }
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

