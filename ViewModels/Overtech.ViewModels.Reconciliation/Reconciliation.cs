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
using Overtech.ViewModels.Sale;

/*Section="ClassHeader"*/
namespace Overtech.ViewModels.Reconciliation
{
    [OTDisplayName("Reconciliation")]
    [DataContract]
    public class Reconciliation : ViewModelObject
    {
        private long _storeReconciliationId;
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
        private Nullable<long> _store;
        private DateTime _reconciliationDate;
        private decimal _zetAmount;
        private decimal _definedAdvance;
        private Nullable<decimal> _expenseAmount;
        private decimal _cashAmount;
        private decimal _cardAmount;
        private Nullable<decimal> _recoveredAmount;
        private Nullable<decimal> _adjustmentAmount;
        private decimal _netoffAmount;
        private decimal _bankAmount;
        private decimal _currentAdvance;
        private Nullable<decimal> _expenseReturn;
        private string _diffReasonCodes;
        private string _diffReason;
        private Nullable<int> _lastStepNo;
        private bool _completeFlag;
        private string _adjustmentReason;
        private Nullable<int> _deficitCycleCount;

        /*Section="Field-StoreReconciliationId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Store Reconciliation Id", null)]
        [OTDisplayName("Store Reconciliation Id")]
        [DataMember]
        public long StoreReconciliationId
        {
            get
            {
                return _storeReconciliationId;
            }
            set
            {
                _storeReconciliationId = value;
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

        /*Section="Field-ReconciliationDate"*/
        [OTRequired("Reconciliation Date", null)]
        [OTDisplayName("Reconciliation Date")]
        [DataMember]
        public DateTime ReconciliationDate
        {
            get
            {
                return _reconciliationDate;
            }
            set
            {
                _reconciliationDate = value;
            }
        }

        /*Section="Field-ZetAmount"*/
        [OTRequired("Zet Amount", null)]
        [OTDisplayName("Zet Amount")]
        [DataMember]
        public decimal ZetAmount
        {
            get
            {
                return _zetAmount;
            }
            set
            {
                _zetAmount = value;
            }
        }

        /*Section="Field-DefinedAdvance"*/
        [OTRequired("Defined Advance", null)]
        [OTDisplayName("Defined Advance")]
        [DataMember]
        public decimal DefinedAdvance
        {
            get
            {
                return _definedAdvance;
            }
            set
            {
                _definedAdvance = value;
            }
        }

        /*Section="Field-ExpenseAmount"*/
        [OTDisplayName("Expense Amount")]
        [DataMember]
        public Nullable<decimal> ExpenseAmount
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

        /*Section="Field-CashAmount"*/
        [OTRequired("Cash Amount", null)]
        [OTDisplayName("Cash Amount")]
        [DataMember]
        public decimal CashAmount
        {
            get
            {
                return _cashAmount;
            }
            set
            {
                _cashAmount = value;
            }
        }

        /*Section="Field-CardAmount"*/
        [OTRequired("Card Amount", null)]
        [OTDisplayName("Card Amount")]
        [DataMember]
        public decimal CardAmount
        {
            get
            {
                return _cardAmount;
            }
            set
            {
                _cardAmount = value;
            }
        }

        /*Section="Field-RecoveredAmount"*/
        [OTDisplayName("Recovered Amount")]
        [DataMember]
        public Nullable<decimal> RecoveredAmount
        {
            get
            {
                return _recoveredAmount;
            }
            set
            {
                _recoveredAmount = value;
            }
        }

        /*Section="Field-AdjustmentAmount"*/
        [OTDisplayName("Adjustment Amount")]
        [DataMember]
        public Nullable<decimal> AdjustmentAmount
        {
            get
            {
                return _adjustmentAmount;
            }
            set
            {
                _adjustmentAmount = value;
            }
        }

        /*Section="Field-NetoffAmount"*/
        [OTRequired("Netoff Amount", null)]
        [OTDisplayName("Netoff Amount")]
        [DataMember]
        public decimal NetoffAmount
        {
            get
            {
                return _netoffAmount;
            }
            set
            {
                _netoffAmount = value;
            }
        }

        /*Section="Field-BankAmount"*/
        [OTRequired("Bank Amount", null)]
        [OTDisplayName("Bank Amount")]
        [DataMember]
        public decimal BankAmount
        {
            get
            {
                return _bankAmount;
            }
            set
            {
                _bankAmount = value;
            }
        }

        /*Section="Field-CurrentAdvance"*/
        [OTRequired("Current Advance", null)]
        [OTDisplayName("Current Advance")]
        [DataMember]
        public decimal CurrentAdvance
        {
            get
            {
                return _currentAdvance;
            }
            set
            {
                _currentAdvance = value;
            }
        }

        /*Section="Field-ExpenseReturn"*/
        [OTDisplayName("Expense Return")]
        [DataMember]
        public Nullable<decimal> ExpenseReturn
        {
            get
            {
                return _expenseReturn;
            }
            set
            {
                _expenseReturn = value;
            }
        }

        /*Section="Field-DiffReasonCodes"*/
        [OTDisplayName("Diff Reason Codes")]
        [DataMember]
        public string DiffReasonCodes
        {
            get
            {
                return _diffReasonCodes;
            }
            set
            {
                _diffReasonCodes = value;
            }
        }

        /*Section="Field-DiffReason"*/
        [OTDisplayName("Diff Reason")]
        [DataMember]
        public string DiffReason
        {
            get
            {
                return _diffReason;
            }
            set
            {
                _diffReason = value;
            }
        }

        /*Section="Field-LastStepNo"*/
        [OTDisplayName("Last Step No")]
        [DataMember]
        public Nullable<int> LastStepNo
        {
            get
            {
                return _lastStepNo;
            }
            set
            {
                _lastStepNo = value;
            }
        }

        /*Section="Field-CompleteFlag"*/
        [OTDisplayName("Complete Flag")]
        [DataMember]
        public bool CompleteFlag
        {
            get
            {
                return _completeFlag;
            }
            set
            {
                _completeFlag = value;
            }
        }

        /*Section="Field-AdjustmentReason"*/
        [OTStringLength(300)]
        [OTDisplayName("Adjustment Reason")]
        [DataMember]
        public string AdjustmentReason
        {
            get
            {
                return _adjustmentReason;
            }
            set
            {
                _adjustmentReason = value;
            }
        }

        /*Section="Field-DeficitCycleCount"*/
        [OTDisplayName("Deficit Cycle Count")]
        [DataMember]
        public Nullable<int> DeficitCycleCount
        {
            get
            {
                return _deficitCycleCount;
            }
            set
            {
                _deficitCycleCount = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _storeReconciliationId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public IEnumerable<CashDistribution> CashDist { get; set; }

        [DataMember]
        public IEnumerable<CardDistribution> CardDist { get; set; }

        [DataMember]
        public IEnumerable<RecLog> RecLog { get; set; }

        [DataMember]
        public IEnumerable<CancelReason> CancelReasons { get; set; }

        [DataMember]
        public decimal CashDeficit { get; set; }

        [DataMember]
        public decimal CashSurplus { get; set; }

        [DataMember]
        public decimal CumulativeDiff { get; set; }

        [DataMember]
        public DateTime LastReconciliationDate { get; set; }

        [DataMember]
        public string StoreName { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string RegionName { get; set; }

        [DataMember]
        public string RegionManagerName { get; set; }

        [DataMember]
        public decimal TotalOpenExpense { get; set; }

        [DataMember]
        public DateTime NextDate { get; set; }

        [DataMember]
        public decimal InvoiceTotal { get; set; }
        #endregion Customized
        /*Section="ClassFooter"*/
    }
}