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
namespace Overtech.DataModels.Accounting
{
    [OTDataObject(Module = "Accounting", ModuleShortName = "ACC", Table = "BANKPOSTRAN", HasAutoIdentity = true, DisplayName = "Bank Pos Transactions", IdField = "BankPosTransactionsId")]
    [DataContract]
    public class BankPosTransactions : DataModelObject
    {
        private long _bankPosTransactionsId;
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
        private long _bank;
        private string _storeRef;
        private string _posRef;
        private DateTime _blockedDate;
        private Nullable<DateTime> _valueDate;
        private Nullable<int> _quantity;
        private decimal _creditAmount;
        private decimal _debitAmount;
        private decimal _commissionAmount;
        private Nullable<DateTime> _mikroTransferTime;
        private int _mikroStatusCode;
        private string _mikroTransactionCode;

        /*Section="Field-BankPosTransactionsId"*/
        [OTDataField("BANKPOSTRANID")]
        [DataMember]
        public long BankPosTransactionsId
        {
            get
            {
                return _bankPosTransactionsId;
            }
            set
            {
                _bankPosTransactionsId = value;
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

        /*Section="Field-Bank"*/
        [OTDataField("BANK")]
        [DataMember]
        public long Bank
        {
            get
            {
                return _bank;
            }
            set
            {
                _bank = value;
            }
        }

        /*Section="Field-StoreRef"*/
        [OTDataField("STOREREF_TXT")]
        [DataMember]
        public string StoreRef
        {
            get
            {
                return _storeRef;
            }
            set
            {
                _storeRef = value;
            }
        }

        /*Section="Field-PosRef"*/
        [OTDataField("POSREF_TXT")]
        [DataMember]
        public string PosRef
        {
            get
            {
                return _posRef;
            }
            set
            {
                _posRef = value;
            }
        }

        /*Section="Field-BlockedDate"*/
        [OTDataField("BLOCKED_DT")]
        [DataMember]
        public DateTime BlockedDate
        {
            get
            {
                return _blockedDate;
            }
            set
            {
                _blockedDate = value;
            }
        }

        /*Section="Field-ValueDate"*/
        [OTDataField("VALUE_DT", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> ValueDate
        {
            get
            {
                return _valueDate;
            }
            set
            {
                _valueDate = value;
            }
        }

        /*Section="Field-Quantity"*/
        [OTDataField("QUANTITY_QTY", Nullable = true)]
        [DataMember]
        public Nullable<int> Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }

        /*Section="Field-CreditAmount"*/
        [OTDataField("CREDIT_AMT")]
        [DataMember]
        public decimal CreditAmount
        {
            get
            {
                return _creditAmount;
            }
            set
            {
                _creditAmount = value;
            }
        }

        /*Section="Field-DebitAmount"*/
        [OTDataField("DEBIT_AMT")]
        [DataMember]
        public decimal DebitAmount
        {
            get
            {
                return _debitAmount;
            }
            set
            {
                _debitAmount = value;
            }
        }

        /*Section="Field-CommissionAmount"*/
        [OTDataField("COMMISSION_AMT")]
        [DataMember]
        public decimal CommissionAmount
        {
            get
            {
                return _commissionAmount;
            }
            set
            {
                _commissionAmount = value;
            }
        }

        /*Section="Field-MikroTransferTime"*/
        [OTDataField("MIKRO_TM", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> MikroTransferTime
        {
            get
            {
                return _mikroTransferTime;
            }
            set
            {
                _mikroTransferTime = value;
            }
        }

        /*Section="Field-MikroStatusCode"*/
        [OTDataField("MIKROSTATUS_CD")]
        [DataMember]
        public int MikroStatusCode
        {
            get
            {
                return _mikroStatusCode;
            }
            set
            {
                _mikroStatusCode = value;
            }
        }

        /*Section="Field-MikroTransactionCode"*/
        [OTDataField("MIKROTRANCODE_TXT")]
        [DataMember]
        public string MikroTransactionCode
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _bankPosTransactionsId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("STORE", IsExtended = true)]
        [DataMember]
        public int Store { get; set; }

        [OTDataField("STORE_NM", IsExtended = true)]
        [DataMember]
        public string StoreName { get; set; }

        [OTDataField("ROWNO", IsExtended = true)]
        [DataMember]
        public int RowNo { get; set; }

        [OTDataField("CARDZET_AMT", IsExtended = true)]
        [DataMember]
        public decimal ReconciliationCardAmount { get; set; }

        [OTDataField("CONTROL_CD", IsExtended = true)]
        [DataMember]
        public int ControlCode { get; set; }

        [OTDataField("STOREDIFF_AMT", IsExtended = true)]
        [DataMember]
        public decimal StoreDiffAmount { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

