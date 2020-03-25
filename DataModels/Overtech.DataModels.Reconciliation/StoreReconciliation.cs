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

    [OTDataObject(Module = "Reconciliation", ModuleShortName = "RCL")]
    [DataContract]
    public class StoreReconciliationIncome : DataModelObject
    {
        private string _cashRegister;
        private int _zetNo;
        private decimal _cashTotal;
        private decimal _cardTotal;
        private decimal _refundTotal;
        private decimal _saleTotal;
    
        [OTDataField("CashRegister")]
        [DataMember]
        public string CashRegister
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
        [OTDataField("ZetNo")]
        [DataMember]
        public int ZetNo
        {
            get
            {
                return _zetNo;
            }
            set
            {
                _zetNo = value;
            }
        }

        [OTDataField("CashTotal")]
        [DataMember]
        public decimal CashTotal
        {
            get
            {
                return _cashTotal;
            }
            set
            {
                _cashTotal = value;
            }
        }

        [OTDataField("CardTotal")]
        [DataMember]
        public decimal CardTotal
        {
            get
            {
                return _cardTotal;
            }
            set
            {
                _cardTotal = value;
            }
        }
        [OTDataField("RefundTotal")]
        [DataMember]
        public decimal RefundTotal
        {
            get
            {
                return _refundTotal;
            }
            set
            {
                _refundTotal = value;
            }
        }
        [OTDataField("SaleTotal")]
        [DataMember]
        public decimal SaleTotal
        {
            get
            {
                return _saleTotal;
            }
            set
            {
                _saleTotal = value;
            }
        }
        public override void SetId(long id)
        {
        }
    }

    [OTDataObject(Module = "Reconciliation", ModuleShortName = "RCL", Table = "RECONCILIATION", HasAutoIdentity = true, DisplayName = "Store Reconciliation", IdField = "StoreReconciliationId")]
    [DataContract]
    public class StoreReconciliation : DataModelObject
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
        private DateTime _transactionDate;
        private long _storeID;
        private decimal _previousDayAmount;
        private decimal _saleTotal;
        private decimal _cashTotal;
        private decimal _cardTotal;
        private decimal _toBank;
        private decimal _difference;
        private string _differenceExplanation;
        private decimal _completed;
        private decimal _eodAdvance;
        private DateTime _lastReconciliationDate;
        private decimal _assignedAdvance;
        private bool _reconciliated;
        private bool _approved;
        private string _storeName;
        private int _zetCount;
        private string _userFullName;
        private bool _missingReconciliation;

        [OTDataField("RECONCILIATIONID")]
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

        [OTDataField("STORE")]
        [DataMember]
        public long StoreID
        {
            get
            {
                return _storeID;
            }
            set
            {
                _storeID = value;
            }
        }

        [OTDataField("PREVIOUSDAYADVANCE_AMT")]
        [DataMember]
        public decimal PreviousDayAmount
        {
            get
            {
                return _previousDayAmount;
            }
            set
            {
                _previousDayAmount = value;
            }
        }

        [OTDataField("SALETOTAL_AMT")]
        [DataMember]
        public decimal SaleTotal
        {
            get
            {
                return _saleTotal;
            }
            set
            {
                _saleTotal = value;
            }
        }

        [OTDataField("CASHTOTAL_AMT")]
        [DataMember]
        public decimal CashTotal
        {
            get
            {
                return _cashTotal;
            }
            set
            {
                _cashTotal = value;
            }
        }

        [OTDataField("CARDTOTAL_AMT")]
        [DataMember]
        public decimal CardTotal
        {
            get
            {
                return _cardTotal;
            }
            set
            {
                _cardTotal = value;
            }
        }

        [OTDataField("TOBANK_AMT")]
        [DataMember]
        public decimal ToBank
        {
            get
            {
                return _toBank;
            }
            set
            {
                _toBank = value;
            }
        }

        [OTDataField("DIFFERENCE_AMT")]
        [DataMember]
        public decimal Difference
        {
            get
            {
                return _difference;
            }
            set
            {
                _difference = value;
            }
        }

        [OTDataField("DIFFERENCE_DSC")]
        [DataMember]
        public string DifferenceExplanation
        {
            get
            {
                return _differenceExplanation;
            }
            set
            {
                _differenceExplanation = value;
            }
        }

        [OTDataField("COMPLETED_AMT")]
        [DataMember]
        public decimal Completed
        {
            get
            {
                return _completed;
            }
            set
            {
                _completed = value;
            }
        }

        [OTDataField("EODADVANCE_AMT")]
        [DataMember]
        public decimal EodAdvance
        {
            get
            {
                return _eodAdvance;
            }
            set
            {
                _eodAdvance = value;
            }
        }

        [OTDataField("RECONCILIATED_FL")]
        [DataMember]
        public bool Reconciliated
        {
            get
            {
                return _reconciliated;
            }
            set
            {
                _reconciliated = value;
            }
        }

        [OTDataField("APPROVED_FL")]
        [DataMember]
        public bool Approved
        {
            get
            {
                return _approved;
            }
            set
            {
                _approved = value;
            }
        }

        #region customized


        [OTDataField("STORE_NM", IsExtended = true)]
        [DataMember]
        public string StoreName
        {
            get
            {
                return _storeName;
            }
            set
            {
                _storeName = value;
            }
        }

        public override void SetId(long id)
        {
            _storeReconciliationId = id;
        }

        [OTDataField("LASTRECONCILIATIONDATE", IsExtended = true)]
        [DataMember]
        public DateTime LastReconciliationDate
        {
            get
            {
                return _lastReconciliationDate;
            }
            set
            {
                _lastReconciliationDate = value;
            }
        }

        [OTDataField("ASSAIGNEDADVANCE", IsExtended = true)]
        [DataMember]
        public decimal AssaignedAdvance
        {
            get
            {
                return _assignedAdvance;
            }
            set
            {
                _assignedAdvance = value;
            }
        }

        [OTDataField("ZETCOUNT", IsExtended = true)]
        [DataMember]
        public int ZetCount
        {
            get
            {
                return _zetCount;
            }
            set
            {
                _zetCount = value;
            }
        }

        [OTDataField("USERFULL_NM", IsExtended = true)]
        [DataMember]
        public string UserFullName
        {
            get
            {
                return _userFullName;
            }
            set
            {
                _userFullName = value;
            }
        }
        [OTDataField("MISSINGRECONCILIATION", IsExtended = true)]
        [DataMember]
        public bool MissingReconciliation
        {
            get
            {
                return _missingReconciliation;
            }
            set
            {
                _missingReconciliation = value;
            }
        }
        #endregion customized
    }
}

