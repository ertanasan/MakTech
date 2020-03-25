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
    [OTDataObject(Module = "Sale", ModuleShortName = "SLS", Table = "SALE", HasAutoIdentity = true, DisplayName = "Sales", IdField = "SalesId")]
    [DataContract]
    public class Sales : DataModelObject
    {
        private long _salesId;
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
        private string _transactionCode;
        private long _store;
        private string _cashierCode;
        private long _cashRegister;
        private DateTime _transactionDate;
        private DateTime _transactionTime;
        private decimal _vatAmount;
        private decimal _total;
        private decimal _productDiscount;
        private decimal _totalDiscount;
        private int _productCount;
        private int _processDuration;
        private bool _cancelled;
        private long _transactionType;

        /*Section="Field-SalesId"*/
        [OTDataField("SALEID")]
        [DataMember]
        public long SalesId
        {
            get
            {
                return _salesId;
            }
            set
            {
                _salesId = value;
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

        /*Section="Field-TransactionCode"*/
        [OTDataField("TRANSACTION_TXT")]
        [DataMember]
        public string TransactionCode
        {
            get
            {
                return _transactionCode;
            }
            set
            {
                _transactionCode = value;
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

        /*Section="Field-CashierCode"*/
        [OTDataField("CASHIER_NM")]
        [DataMember]
        public string CashierCode
        {
            get
            {
                return _cashierCode;
            }
            set
            {
                _cashierCode = value;
            }
        }

        /*Section="Field-CashRegister"*/
        [OTDataField("CASHREGISTER")]
        [DataMember]
        public long CashRegister
        {
            get
            {
                return _cashRegister;
            }
            set
            {
                _cashRegister = value;
            }
        }

        /*Section="Field-TransactionDate"*/
        [OTDataField("TRANSACTION_DT")]
        [DataMember]
        public DateTime TransactionDate
        {
            get
            {
                return _transactionDate;
            }
            set
            {
                _transactionDate = value;
            }
        }

        /*Section="Field-TransactionTime"*/
        [OTDataField("TRANSACTION_TM")]
        [DataMember]
        public DateTime TransactionTime
        {
            get
            {
                return _transactionTime;
            }
            set
            {
                _transactionTime = value;
            }
        }

        /*Section="Field-VATAmount"*/
        [OTDataField("TOTALVAT_AMT")]
        [DataMember]
        public decimal VATAmount
        {
            get
            {
                return _vatAmount;
            }
            set
            {
                _vatAmount = value;
            }
        }

        /*Section="Field-Total"*/
        [OTDataField("TOTAL_AMT")]
        [DataMember]
        public decimal Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
            }
        }

        /*Section="Field-ProductDiscount"*/
        [OTDataField("PRODUCTDISCOUNT_AMT")]
        [DataMember]
        public decimal ProductDiscount
        {
            get
            {
                return _productDiscount;
            }
            set
            {
                _productDiscount = value;
            }
        }

        /*Section="Field-TotalDiscount"*/
        [OTDataField("SALEDISCOUNT_AMT")]
        [DataMember]
        public decimal TotalDiscount
        {
            get
            {
                return _totalDiscount;
            }
            set
            {
                _totalDiscount = value;
            }
        }

        /*Section="Field-ProductCount"*/
        [OTDataField("PRODUCT_CNT")]
        [DataMember]
        public int ProductCount
        {
            get
            {
                return _productCount;
            }
            set
            {
                _productCount = value;
            }
        }

        /*Section="Field-ProcessDuration"*/
        [OTDataField("DURATION_CNT")]
        [DataMember]
        public int ProcessDuration
        {
            get
            {
                return _processDuration;
            }
            set
            {
                _processDuration = value;
            }
        }

        /*Section="Field-Cancelled"*/
        [OTDataField("CANCELLED_FL")]
        [DataMember]
        public bool Cancelled
        {
            get
            {
                return _cancelled;
            }
            set
            {
                _cancelled = value;
            }
        }

        /*Section="Field-TransactionType"*/
        [OTDataField("TRANSACTIONTYPE")]
        [DataMember]
        public long TransactionType
        {
            get
            {
                return _transactionType;
            }
            set
            {
                _transactionType = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _salesId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("INVOICEID", IsExtended = true)]
        [DataMember]
        public long InvoiceId { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

