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
    [OTDisplayName("Sales")]
    [DataContract]
    public class Sales : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Sales Id", null)]
        [OTDisplayName("Sales Id")]
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

        /*Section="Field-TransactionCode"*/
        [OTRequired("Transaction Code", null)]
        [OTDisplayName("Transaction Code")]
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

        /*Section="Field-CashierCode"*/
        [OTRequired("Cashier Code", null)]
        [OTStringLength(100)]
        [OTDisplayName("Cashier Code")]
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
        [UIHint("StoreCashRegisterList")]
        [OTRequired("Cash Register", null)]
        [OTDisplayName("Cash Register")]
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
        [OTRequired("Transaction Date", null)]
        [OTDisplayName("Transaction Date")]
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
        [OTRequired("Transaction Time", null)]
        [OTDisplayName("Transaction Time")]
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
        [OTRequired("VAT Amount", null)]
        [OTDisplayName("VAT Amount")]
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
        [OTRequired("Total", null)]
        [OTDisplayName("Total")]
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
        [OTRequired("Product Discount", null)]
        [OTDisplayName("Product Discount")]
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
        [OTRequired("Total Discount", null)]
        [OTDisplayName("Total Discount")]
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
        [OTRequired("Product Count", null)]
        [OTDisplayName("Product Count")]
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
        [OTRequired("Process Duration", null)]
        [OTDisplayName("Process Duration")]
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
        [OTRequired("Cancelled", null)]
        [OTDisplayName("Cancelled")]
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
        [UIHint("TransactionTypeList")]
        [OTRequired("Transaction Type", null)]
        [OTDisplayName("Transaction Type")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _salesId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public long InvoiceId { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}