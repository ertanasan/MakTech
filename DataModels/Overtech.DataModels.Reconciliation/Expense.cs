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
namespace Overtech.DataModels.Reconciliation
{
    [OTDataObject(Module = "Reconciliation", ModuleShortName = "RCL", Table = "EXPENSE", HasAutoIdentity = true, DisplayName = "Expense", IdField = "ExpenseId")]
    [DataContract]
    public class Expense : DataModelObject
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
        [OTDataField("EXPENSEID")]
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

        /*Section="Field-ExpenseType"*/
        [OTDataField("EXPENSETYPE")]
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
        [OTDataField("STORE", Nullable = true)]
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
        [OTDataField("EXPENSE_DT")]
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
        [OTDataField("EXPENSE_AMT")]
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
        [OTDataField("RECEIPTNO_TXT")]
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
        [OTDataField("OPEN_FL")]
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
        [OTDataField("PAYOFF_DT", Nullable = true)]
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
        [OTDataField("EXPENSE_DSC")]
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
        [OTDataField("VAT_RT")]
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
        [OTDataField("MIKRO_CD", Nullable = true)]
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
        [OTDataField("MIKRO_TM", Nullable = true)]
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
        [OTDataField("STATUS_CD", Nullable = true)]
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
        [OTDataField("STATUS_TXT")]
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
        [OTDataField("MIKROUSER", Nullable = true)]
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
        [OTDataField("HASRECEIPT_FL")]
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
        [OTDataField("REGIONMANAGER", Nullable = true)]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _expenseId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("STORE_NM", IsExtended = true)]
        [DataMember]
        public string StoreName { get; set; }

        [OTDataField("CREATEUSER_NM", IsExtended = true)]
        [DataMember]
        public string CreateUserName { get; set; }

        [OTDataField("UPDATEUSER_NM", IsExtended = true)]
        [DataMember]
        public string UpdateUserName { get; set; }

        [OTDataField("EXPENSETYPE_NM", IsExtended = true)]
        [DataMember]
        public string ExpenseTypeName { get; set; }

        [OTDataField("ACCOUNTCODE_TXT", IsExtended = true)]
        [DataMember]
        public string ExpenseAccount { get; set; }

        [OTDataField("RMACCOUNT_TXT", IsExtended = true)]
        [DataMember]
        public string RegionManagerAccount { get; set; }

        [OTDataField("REGIONMANAGER_NM", IsExtended = true)]
        [DataMember]
        public string RegionManagerName { get; set; }

        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

