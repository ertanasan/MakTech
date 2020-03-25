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
    [OTDataObject(Module = "Sale", ModuleShortName = "SLS", Table = "SALEZET", HasAutoIdentity = true, DisplayName = "Sale Daily Summary", IdField = "SaleDailySummaryId")]
    [DataContract]
    public class SaleDailySummary : DataModelObject
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
        [OTDataField("SALEZETID")]
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

        /*Section="Field-StoreID"*/
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

        /*Section="Field-ZetNo"*/
        [OTDataField("ZET_NO", Nullable = true)]
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
        [OTDataField("RECEIPT_CNT", Nullable = true)]
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
        [OTDataField("RECEIPTTOTAL_AMT", Nullable = true)]
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
        [OTDataField("REFUND_CNT", Nullable = true)]
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
        [OTDataField("REFUND_AMT", Nullable = true)]
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
        [OTDataField("CASH_AMT", Nullable = true)]
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
        [OTDataField("CARD_AMT", Nullable = true)]
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

        /*Section="Field-SlpTotal"*/
        [OTDataField("SLPTOTAL_AMT", Nullable = true)]
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
        [OTDataField("SLP_CNT")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _saleDailySummaryId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

