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
namespace Overtech.DataModels.Warehouse
{
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "PRODUCTRETURN", HasAutoIdentity = true, DisplayName = "Product Return", IdField = "ProductReturnId")]
    [DataContract]
    public class ProductReturn : DataModelObject
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
        [OTDataField("PRODUCTRETURNID")]
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

        /*Section="Field-ReturnDate"*/
        [OTDataField("RETURN_DT")]
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
        [OTDataField("WAYBILL_DT", Nullable = true)]
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
        [OTDataField("WAYBILL_TXT")]
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
        [OTDataField("PRODUCT")]
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
        [OTDataField("SUPPLIER_TXT")]
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
        [OTDataField("MANUFACTURING_DT", Nullable = true)]
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
        [OTDataField("EXPIRE_DT", Nullable = true)]
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
        [OTDataField("RETURNQUANTITY_AMT")]
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
        [OTDataField("PACKAGETYPE")]
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
        [OTDataField("RETURNREASON_TXT")]
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
        [OTDataField("RETURNDESTINATION", Nullable = true)]
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

        /*Section="Field-Store"*/
        [OTDataField("STORE")]
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
        [OTDataField("INTAKE_AMT", Nullable = true)]
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
        [OTDataField("CUSTOMERRETURN_FL")]
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
        [OTDataField("REUSABLE_FL")]
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
        [OTDataField("SALEDETAIL", Nullable = true)]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _productReturnId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public IEnumerable<ProductReturnReason> ReturnReason { get; set; }

        [DataMember]
        public string ReturnReasons { get; set; }

        [OTDataField("STATUS_TXT", IsExtended = true)]
        [DataMember]
        public string StatusText { get; set; }

        [DataMember]
        public long action { get; set; }

        [DataMember]
        public string actionChoice { get; set; }

        [DataMember]
        public string actionComment { get; set; }

    }

    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS")]
    public class ProductReturnHistory : DataModelObject
    {
        [OTDataField("CREATE_DT", IsExtended = true)]
        [DataMember]
        public DateTime CreateDate { get; set; }

        [OTDataField("START_TM", IsExtended = true)]
        [DataMember]
        public DateTime StartTime { get; set; }

        [OTDataField("FINISH_TM", IsExtended = true)]
        [DataMember]
        public DateTime FinishTime { get; set; }

        [OTDataField("PERFORMER", IsExtended = true)]
        [DataMember]
        public int Performer { get; set; }

        [OTDataField("ACTIONSTATUS_CD", IsExtended = true)]
        [DataMember]
        public int ActionStatusCode { get; set; }

        [OTDataField("PROCESSSTATUS_CD", IsExtended = true)]
        [DataMember]
        public int ProcessStatusCode { get; set; }

        [OTDataField("CHOICE_TXT", IsExtended = true)]
        [DataMember]
        public string Choice { get; set; }

        [OTDataField("USERCOMMENT_DSC", IsExtended = true)]
        [DataMember]
        public string ActionComment { get; set; }

        public override void SetId(long id) { }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

