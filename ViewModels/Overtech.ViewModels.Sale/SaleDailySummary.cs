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
    [OTDisplayName("Sale Daily Summary")]
    [DataContract]
    public class SaleDailySummary : ViewModelObject
    {
        private long _saleDailySummaryId;
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
        private long _storeID;
        private DateTime _transactionDate;
        private Nullable<int> _zetNo;
        private Nullable<int> _receiptCount;
        private Nullable<decimal> _receiptTotal;
        private Nullable<int> _refundCount;
        private Nullable<decimal> _refundAmount;
        private Nullable<decimal> _cashAmount;
        private Nullable<decimal> _cardAmount;
        private long _cashRegister;
        private Nullable<decimal> _slpTotal;
        private int _slpCount;

        /*Section="Field-SaleDailySummaryId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Sale Daily Summary Id", null)]
        [OTDisplayName("Sale Daily Summary Id")]
        [DataMember]
        public long SaleDailySummaryId
        {
            get
            {
                return _saleDailySummaryId;
            }
            set
            {
                _saleDailySummaryId = value;
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

        /*Section="Field-StoreID"*/
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

        /*Section="Field-ZetNo"*/
        [OTDisplayName("Zet No")]
        [DataMember]
        public Nullable<int> ZetNo
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

        /*Section="Field-ReceiptCount"*/
        [OTDisplayName("Receipt Count")]
        [DataMember]
        public Nullable<int> ReceiptCount
        {
            get
            {
                return _receiptCount;
            }
            set
            {
                _receiptCount = value;
            }
        }

        /*Section="Field-ReceiptTotal"*/
        [OTDisplayName("Receipt Total")]
        [DataMember]
        public Nullable<decimal> ReceiptTotal
        {
            get
            {
                return _receiptTotal;
            }
            set
            {
                _receiptTotal = value;
            }
        }

        /*Section="Field-RefundCount"*/
        [OTDisplayName("Refund Count")]
        [DataMember]
        public Nullable<int> RefundCount
        {
            get
            {
                return _refundCount;
            }
            set
            {
                _refundCount = value;
            }
        }

        /*Section="Field-RefundAmount"*/
        [OTDisplayName("Refund Amount")]
        [DataMember]
        public Nullable<decimal> RefundAmount
        {
            get
            {
                return _refundAmount;
            }
            set
            {
                _refundAmount = value;
            }
        }

        /*Section="Field-CashAmount"*/
        [OTDisplayName("Cash Amount")]
        [DataMember]
        public Nullable<decimal> CashAmount
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
        [OTDisplayName("Card Amount")]
        [DataMember]
        public Nullable<decimal> CardAmount
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

        /*Section="Field-SlpTotal"*/
        [OTDisplayName("SlpTotal")]
        [DataMember]
        public Nullable<decimal> SlpTotal
        {
            get
            {
                return _slpTotal;
            }
            set
            {
                _slpTotal = value;
            }
        }

        /*Section="Field-SlpCount"*/
        [OTRequired("SlpCount", null)]
        [OTDisplayName("SlpCount")]
        [DataMember]
        public int SlpCount
        {
            get
            {
                return _slpCount;
            }
            set
            {
                _slpCount = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _saleDailySummaryId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}