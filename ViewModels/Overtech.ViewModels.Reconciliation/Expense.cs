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
namespace Overtech.ViewModels.Reconciliation
{
    [OTDisplayName("Expense")]
    [DataContract]
    public class Expense : ViewModelObject
    {
        private long _expenseId;
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
        private long _expenseType;
        private Nullable<long> _store;
        private DateTime _expenseDate;
        private decimal _expenseAmount;
        private string _receiptNo;
        private bool _openFlag;
        private Nullable<DateTime> _payOffDate;
        private string _expenseDescription;
        private decimal _vatRate;
        private Nullable<int> _mikroTransactionCode;
        private Nullable<DateTime> _mikroTime;
        private Nullable<int> _statusCode;
        private string _statusText;
        private Nullable<long> _mikroUser;
        private bool _hasReceipt;
        private Nullable<long> _regionManager;

        /*Section="Field-ExpenseId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Expense Id", null)]
        [OTDisplayName("Expense Id")]
        [DataMember]
        public long ExpenseId
        {
            get
            {
                return _expenseId;
            }
            set
            {
                _expenseId = value;
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

        /*Section="Field-ExpenseType"*/
        [UIHint("ExpenseTypeList")]
        [OTRequired("Expense Type", null)]
        [OTDisplayName("Expense Type")]
        [DataMember]
        public long ExpenseType
        {
            get
            {
                return _expenseType;
            }
            set
            {
                _expenseType = value;
            }
        }

        /*Section="Field-Store"*/
        [UIHint("StoreList")]
        [OTDisplayName("Store")]
        [DataMember]
        public Nullable<long> Store
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

        /*Section="Field-ExpenseDate"*/
        [OTRequired("Expense Date", null)]
        [OTDisplayName("Expense Date")]
        [DataMember]
        public DateTime ExpenseDate
        {
            get
            {
                return _expenseDate;
            }
            set
            {
                _expenseDate = value;
            }
        }

        /*Section="Field-ExpenseAmount"*/
        [OTRequired("Expense Amount", null)]
        [OTDisplayName("Expense Amount")]
        [DataMember]
        public decimal ExpenseAmount
        {
            get
            {
                return _expenseAmount;
            }
            set
            {
                _expenseAmount = value;
            }
        }

        /*Section="Field-ReceiptNo"*/
        [OTDisplayName("ReceiptNo")]
        [DataMember]
        public string ReceiptNo
        {
            get
            {
                return _receiptNo;
            }
            set
            {
                _receiptNo = value;
            }
        }

        /*Section="Field-OpenFlag"*/
        [OTRequired("Open Flag", null)]
        [OTDisplayName("Open Flag")]
        [DataMember]
        public bool OpenFlag
        {
            get
            {
                return _openFlag;
            }
            set
            {
                _openFlag = value;
            }
        }

        /*Section="Field-PayOffDate"*/
        [OTDisplayName("PayOff Date")]
        [DataMember]
        public Nullable<DateTime> PayOffDate
        {
            get
            {
                return _payOffDate;
            }
            set
            {
                _payOffDate = value;
            }
        }

        /*Section="Field-ExpenseDescription"*/
        [OTStringLength(1000)]
        [OTDisplayName("Expense Description")]
        [DataMember]
        public string ExpenseDescription
        {
            get
            {
                return _expenseDescription;
            }
            set
            {
                _expenseDescription = value;
            }
        }

        /*Section="Field-VATRate"*/
        [OTRequired("VAT Rate", null)]
        [OTDisplayName("VAT Rate")]
        [DataMember]
        public decimal VATRate
        {
            get
            {
                return _vatRate;
            }
            set
            {
                _vatRate = value;
            }
        }

        /*Section="Field-MikroTransactionCode"*/
        [OTDisplayName("Mikro Transaction Code")]
        [DataMember]
        public Nullable<int> MikroTransactionCode
        {
            get
            {
                return _mikroTransactionCode;
            }
            set
            {
                _mikroTransactionCode = value;
            }
        }

        /*Section="Field-MikroTime"*/
        [OTDisplayName("Mikro Time")]
        [DataMember]
        public Nullable<DateTime> MikroTime
        {
            get
            {
                return _mikroTime;
            }
            set
            {
                _mikroTime = value;
            }
        }

        /*Section="Field-StatusCode"*/
        [OTDisplayName("Status Code")]
        [DataMember]
        public Nullable<int> StatusCode
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

        /*Section="Field-StatusText"*/
        [OTDisplayName("Status Text")]
        [DataMember]
        public string StatusText
        {
            get
            {
                return _statusText;
            }
            set
            {
                _statusText = value;
            }
        }

        /*Section="Field-MikroUser"*/
        [UIHint("UserList")]
        [OTDisplayName("Mikro User")]
        [DataMember]
        public Nullable<long> MikroUser
        {
            get
            {
                return _mikroUser;
            }
            set
            {
                _mikroUser = value;
            }
        }

        /*Section="Field-HasReceipt"*/
        [OTRequired("HasReceipt", null)]
        [OTDisplayName("HasReceipt")]
        [DataMember]
        public bool HasReceipt
        {
            get
            {
                return _hasReceipt;
            }
            set
            {
                _hasReceipt = value;
            }
        }

        /*Section="Field-RegionManager"*/
        [UIHint("RegionManagersList")]
        [OTDisplayName("Region Manager")]
        [DataMember]
        public Nullable<long> RegionManager
        {
            get
            {
                return _regionManager;
            }
            set
            {
                _regionManager = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _expenseId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public string StoreName { get; set; }
        [DataMember]
        public string CreateUserName { get; set; }
        [DataMember]
        public string UpdateUserName { get; set; }
        [DataMember]
        public string ExpenseTypeName { get; set; }
        [DataMember]
        public string ExpenseAccount { get; set; }
        [DataMember]
        public string RegionManagerAccount { get; set; }
        [DataMember]
        public string RegionManagerName { get; set; }
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}