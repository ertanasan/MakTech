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
namespace Overtech.ViewModels.Sale
{
    [OTDisplayName("Sale Customer")]
    [DataContract]
    public class SaleCustomer : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Sale Customer Id", null)]
        [OTDisplayName("Sale Customer Id")]
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

        /*Section="Field-CustomerName"*/
        [OTRequired("Customer Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Customer Name")]
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

        /*Section="Field-TaxCenterName"*/
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

        /*Section="Field-TaxIdentityNo"*/
        [OTRequired("Tax Identity No", null)]
        [OTDisplayName("Tax Identity No")]
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

        /*Section="Field-FiscalSerial"*/
        [OTDisplayName("Fiscal Serial")]
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
        [OTDisplayName("EInvoice Zet Number")]
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
        [OTDisplayName("EInvoice Receipt Number")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _saleCustomerId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}