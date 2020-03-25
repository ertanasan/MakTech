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
    [OTDisplayName("Sale Invoice")]
    [DataContract]
    public class SaleInvoice : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Sale Invoice Id", null)]
        [OTDisplayName("Sale Invoice Id")]
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

        /*Section="Field-EInvoiceFlag"*/
        [OTRequired("EInvoice Flag", null)]
        [OTDisplayName("EInvoice Flag")]
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
        [OTRequired("Customer Id Number", null)]
        [OTDisplayName("Customer Id Number")]
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
        [OTRequired("Title", null)]
        [OTStringLength(1000)]
        [OTDisplayName("Title")]
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
        [OTRequired("Email", null)]
        [OTDisplayName("Email")]
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
        [UIHint("SalesList")]
        [OTRequired("Sale", null)]
        [OTDisplayName("Sale")]
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
        [UIHint("EInvoiceClientList")]
        [OTDisplayName("EInvoice Client")]
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

        /*Section="Field-StatusCode"*/
        [OTRequired("Status Code", null)]
        [OTDisplayName("Status Code")]
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
        [OTRequired("Mikro Flag", null)]
        [OTDisplayName("Mikro Flag")]
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
        [OTDisplayName("Mikro Transfer Time")]
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
        [OTDisplayName("Process Instance")]
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
        [OTDisplayName("Phone Number")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _saleInvoiceId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public DateTime SaleDate { get; set; }

        [DataMember]
        public string SaleRef { get; set; }

        [DataMember]
        public decimal SaleAmount { get; set; }

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