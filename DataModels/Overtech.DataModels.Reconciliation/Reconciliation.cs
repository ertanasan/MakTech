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
using Overtech.DataModels.Sale;

/*Section="ClassHeader"*/
namespace Overtech.DataModels.Reconciliation
{
    [OTDataObject(Module = "Reconciliation", ModuleShortName = "RCL", Table = "STORE", HasAutoIdentity = true, DisplayName = "Reconciliation", IdField = "StoreReconciliationId")]
    [DataContract]
    public class Reconciliation : DataModelObject
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
        [OTDataField("STORERECID")]
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

        /*Section="Field-ReconciliationDate"*/
        [OTDataField("RECONCILIATION_DT")]
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
        [OTDataField("ZET_AMT")]
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
        [OTDataField("DEFINEDADVANCE_AMT")]
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
        [OTDataField("EXPENSE_AMT", Nullable = true)]
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
        [OTDataField("CASH_AMT")]
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
        [OTDataField("CARD_AMT")]
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
        [OTDataField("RECOVERED_AMT", Nullable = true)]
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
        [OTDataField("ADJUSTMENT_AMT", Nullable = true)]
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
        [OTDataField("NETOFF_AMT")]
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
        [OTDataField("BANK_AMT")]
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
        [OTDataField("CURRENTADVANCE_AMT")]
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
        [OTDataField("EXPENSERETURN_AMT", Nullable = true)]
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
        [OTDataField("DIFFREASONCODES_TXT")]
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
        [OTDataField("DIFFREASON_TXT")]
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
        [OTDataField("LASTSTEP_NO", Nullable = true)]
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
        [OTDataField("COMPLETE_FL")]
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
        [OTDataField("ADJUSTMENT_DSC")]
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
        [OTDataField("DEFICITCYCLE_CNT", Nullable = true)]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _storeReconciliationId = id;
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

        [OTDataField("CASHDEFICIT", IsExtended = true)]
        [DataMember]
        public decimal CashDeficit
        {
            get; set;
        }

        [OTDataField("CASHSURPLUS", IsExtended = true)]
        [DataMember]
        public decimal CashSurplus
        {
            get; set;
        }

        [OTDataField("CUMULATIVEDIFF", IsExtended = true)]
        [DataMember]
        public decimal CumulativeDiff
        {
            get; set;
        }

        [OTDataField("LASTRECONCILIATION_DT", IsExtended = true)]
        [DataMember]
        public DateTime LastReconciliationDate
        {
            get; set;
        }

        [OTDataField("STORE_NM", IsExtended = true)]
        [DataMember]
        public string StoreName { get; set; }

        [OTDataField("USER_NM", IsExtended = true)]
        [DataMember]
        public string UserName { get; set; }

        [OTDataField("REGION_NM", IsExtended = true)]
        [DataMember]
        public string RegionName { get; set; }

        [OTDataField("REGIONMANAGER_NM", IsExtended = true)]
        [DataMember]
        public string RegionManagerName { get; set; }

        [OTDataField("TOTALOPENEXPENSE_AMT", IsExtended = true)]
        [DataMember]
        public decimal TotalOpenExpense { get; set; }

        [OTDataField("NEXTDATE", IsExtended = true)]
        [DataMember]
        public DateTime NextDate { get; set; }

        [OTDataField("INVOICETOTAL", IsExtended = true)]
        [DataMember]
        public decimal InvoiceTotal { get; set; }

    }
    #endregion Customized

    /*Section="ClassFooter"*/
}

