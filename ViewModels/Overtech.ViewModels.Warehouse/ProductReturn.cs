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
namespace Overtech.ViewModels.Warehouse
{
    [OTDisplayName("Product Return")]
    [DataContract]
    public class ProductReturn : ViewModelObject
    {
        private long _productReturnId;
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
        private DateTime _returnDate;
        private Nullable<DateTime> _waybillDate;
        private long _product;
        private string _supplier;
        private Nullable<DateTime> _manufacturingDate;
        private Nullable<DateTime> _expireDate;
        private decimal _returnQuantity;
        private long _packageType;
        private string _returnReasonText;
        private Nullable<long> _returnDestination;
        private int _statusCode;
        private Nullable<long> _processInstance;
        private long _store;
        private Nullable<decimal> _intakeAmount;
        private bool _isCustomerReturn;
        private bool _reusableFlag;
        private Nullable<long> _saleDetailId;
        private string _waybillText;

        /*Section="Field-ProductReturnId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Product Return Id", null)]
        [OTDisplayName("Product Return Id")]
        [DataMember]
        public long ProductReturnId
        {
            get
            {
                return _productReturnId;
            }
            set
            {
                _productReturnId = value;
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

        /*Section="Field-ReturnDate"*/
        [OTRequired("Return Date", null)]
        [OTDisplayName("Return Date")]
        [DataMember]
        public DateTime ReturnDate
        {
            get
            {
                return _returnDate;
            }
            set
            {
                _returnDate = value;
            }
        }

        /*Section="Field-WaybillDate"*/
        [OTDisplayName("Waybill Date")]
        [DataMember]
        public Nullable<DateTime> WaybillDate
        {
            get
            {
                return _waybillDate;
            }
            set
            {
                _waybillDate = value;
            }
        }

        /*Section="Field-WaybillText"*/
        [OTDisplayName("Waybill Text")]
        [DataMember]
        public string WaybillText
        {
            get
            {
                return _waybillText;
            }
            set
            {
                _waybillText = value;
            }
        }

        /*Section="Field-Product"*/
        [UIHint("ProductList")]
        [OTRequired("Product", null)]
        [OTDisplayName("Product")]
        [DataMember]
        public long Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
            }
        }

        /*Section="Field-Supplier"*/
        [OTDisplayName("Supplier")]
        [DataMember]
        public string Supplier
        {
            get
            {
                return _supplier;
            }
            set
            {
                _supplier = value;
            }
        }

        /*Section="Field-ManufacturingDate"*/
        [OTDisplayName("Manufacturing Date")]
        [DataMember]
        public Nullable<DateTime> ManufacturingDate
        {
            get
            {
                return _manufacturingDate;
            }
            set
            {
                _manufacturingDate = value;
            }
        }

        /*Section="Field-ExpireDate"*/
        [OTDisplayName("Expire Date")]
        [DataMember]
        public Nullable<DateTime> ExpireDate
        {
            get
            {
                return _expireDate;
            }
            set
            {
                _expireDate = value;
            }
        }

        /*Section="Field-ReturnQuantity"*/
        [OTRequired("Return Quantity", null)]
        [OTDisplayName("Return Quantity")]
        [DataMember]
        public decimal ReturnQuantity
        {
            get
            {
                return _returnQuantity;
            }
            set
            {
                _returnQuantity = value;
            }
        }

        /*Section="Field-PackageType"*/
        [UIHint("ShipmentPackageTypeList")]
        [OTRequired("Package Type", null)]
        [OTDisplayName("Package Type")]
        [DataMember]
        public long PackageType
        {
            get
            {
                return _packageType;
            }
            set
            {
                _packageType = value;
            }
        }

        /*Section="Field-ReturnReasonText"*/
        [OTDisplayName("Return Reason Text")]
        [DataMember]
        public string ReturnReasonText
        {
            get
            {
                return _returnReasonText;
            }
            set
            {
                _returnReasonText = value;
            }
        }

        /*Section="Field-ReturnDestination"*/
        [UIHint("ReturnDestinationList")]
        [OTDisplayName("Return Destination")]
        [DataMember]
        public Nullable<long> ReturnDestination
        {
            get
            {
                return _returnDestination;
            }
            set
            {
                _returnDestination = value;
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

        /*Section="Field-Store"*/
        [UIHint("StoreList")]
        [OTRequired("Store", null)]
        [OTDisplayName("Store")]
        [DataMember]
        public long Store
        {
            get
            {
                return _store;
            }
            set
            {
                _store = value;
            }
        }

        /*Section="Field-IntakeAmount"*/
        [OTDisplayName("Intake Amount")]
        [DataMember]
        public Nullable<decimal> IntakeAmount
        {
            get
            {
                return _intakeAmount;
            }
            set
            {
                _intakeAmount = value;
            }
        }

        /*Section="Field-IsCustomerReturn"*/
        [OTDisplayName("IsCustomerReturn")]
        [DataMember]
        public bool IsCustomerReturn
        {
            get
            {
                return _isCustomerReturn;
            }
            set
            {
                _isCustomerReturn = value;
            }
        }

        /*Section="Field-ReusableFlag"*/
        [OTDisplayName("Reusable Flag")]
        [DataMember]
        public bool ReusableFlag
        {
            get
            {
                return _reusableFlag;
            }
            set
            {
                _reusableFlag = value;
            }
        }

        /*Section="Field-SaleDetailId"*/
        [UIHint("SaleDetailList")]
        [OTDisplayName("Sale Detail Id")]
        [DataMember]
        public Nullable<long> SaleDetailId
        {
            get
            {
                return _saleDetailId;
            }
            set
            {
                _saleDetailId = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _productReturnId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public IEnumerable<ProductReturnReason> ReturnReason { get; set; }

        [DataMember]
        public string ReturnReasons { get; set; }

        [DataMember]
        public string StatusText { get; set; }

        [DataMember]
        public long action { get; set; }

        [DataMember]
        public string actionChoice { get; set; }

        [DataMember]
        public string actionComment { get; set; }
    }

    public class ProductReturnHistory : ViewModelObject
    {
        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public DateTime StartTime { get; set; }

        [DataMember]
        public DateTime FinishTime { get; set; }

        [DataMember]
        public int Performer { get; set; }

        [DataMember]
        public int ActionStatusCode { get; set; }

        [DataMember]
        public int ProcessStatusCode { get; set; }

        [DataMember]
        public string Choice { get; set; }

        [DataMember]
        public string ActionComment { get; set; }

        public override long GetId() { return 0;  }

        #endregion Customized
        /*Section="ClassFooter"*/
    }
}