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
namespace Overtech.ViewModels.Accounting
{
    [OTDisplayName("Bank Pos Transactions")]
    [DataContract]
    public class BankPosTransactions : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Bank Pos Transactions Id", null)]
        [OTDisplayName("Bank Pos Transactions Id")]
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

        /*Section="Field-Bank"*/
        [UIHint("BankList")]
        [OTRequired("Bank", null)]
        [OTDisplayName("Bank")]
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
        [OTDisplayName("StoreRef")]
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
        [OTDisplayName("PosRef")]
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
        [OTRequired("Blocked Date", null)]
        [OTDisplayName("Blocked Date")]
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
        [OTDisplayName("Value Date")]
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
        [OTDisplayName("Quantity")]
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
        [OTRequired("Credit Amount", null)]
        [OTDisplayName("Credit Amount")]
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
        [OTRequired("Debit Amount", null)]
        [OTDisplayName("Debit Amount")]
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
        [OTRequired("Commission Amount", null)]
        [OTDisplayName("Commission Amount")]
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
        [OTDisplayName("Mikro Transfer Time")]
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
        [OTRequired("Mikro Status Code", null)]
        [OTDisplayName("Mikro Status Code")]
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
        [OTDisplayName("Mikro Transaction Code")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _bankPosTransactionsId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public int Store { get; set; }

        [DataMember]
        public string StoreName { get; set; }

        [DataMember]
        public int RowNo { get; set; }

        [DataMember]
        public decimal ReconciliationCardAmount { get; set; }

        [DataMember]
        public int ControlCode { get; set; }

        [DataMember]
        public decimal StoreDiffAmount { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}