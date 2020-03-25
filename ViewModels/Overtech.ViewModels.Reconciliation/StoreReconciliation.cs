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

    [OTDataObject(Module = "Reconciliation", ModuleShortName = "RCL")]
    [DataContract]
    public class StoreReconciliationIncome : ViewModelObject
    {
        private string _cashRegister;
        private int _zetNo;
        private decimal _cashTotal;
        private decimal _cardTotal;
        private decimal _refundTotal;
        private decimal _saleTotal;

        [ScaffoldColumn(false)]
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
        [ScaffoldColumn(false)]
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

        [ScaffoldColumn(false)]
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

        [ScaffoldColumn(false)]
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
        [ScaffoldColumn(false)]
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
        [ScaffoldColumn(false)]
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
        public override long GetId()
        {
            return 0;
        }
    }

    [OTDisplayName("Store Reconciliation")]
    [DataContract]
    public class StoreReconciliation : ViewModelObject
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
        private int _zetCount;
        private string _userFullName;
        private bool _missingReconciliation;
        private string _storeName;

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

        [UIHint("StoreList")]
        [OTRequired("Store ID", null)]
        [OTDisplayName("Store ID")]
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

        [OTRequired("Previous Day Amount", null)]
        [OTDisplayName("Previous Day Amount")]
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

        [OTRequired("Sale Total", null)]
        [OTDisplayName("Sale Total")]
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

        [OTRequired("Cash Total", null)]
        [OTDisplayName("Cash Total")]
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

        [OTRequired("Card Total", null)]
        [OTDisplayName("Card Total")]
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

        [OTRequired("To Bank", null)]
        [OTDisplayName("To Bank")]
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

        [OTRequired("Difference", null)]
        [OTDisplayName("Difference")]
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

        [OTStringLength(1000)]
        [OTDisplayName("Difference Explanation")]
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

        [OTRequired("Completed", null)]
        [OTDisplayName("Completed")]
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

        [OTRequired("Eod Advance", null)]
        [OTDisplayName("Eod Advance")]
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

        [OTDisplayName("Reconciliated")]
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

        [OTDisplayName("Approved")]
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


        #region Customized
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

        [OTDisplayName("Zet Count")]
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
        #endregion Customized


        public override long GetId()
        {
            return _storeReconciliationId;
        }
        

    }
}