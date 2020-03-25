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
    [OTDisplayName("Sale Payment")]
    [DataContract]
    public class SalePayment : ViewModelObject
    {
        private long _salePaymentId;
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
        private long _saleID;
        private string _transactionID;
        private DateTime _transactionDate;
        private long _store;
        private string _paymentType;
        private decimal _paidAmount;
        private decimal _refundAmount;
        private Nullable<long> _posBankType;
        private Nullable<long> _posTrxType;
        private string _creditCardNo;
        private bool _isDebitCard;
        private decimal _creditCardAmount;

        /*Section="Field-SalePaymentId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Sale Payment Id", null)]
        [OTDisplayName("Sale Payment Id")]
        [DataMember]
        public long SalePaymentId
        {
            get
            {
                return _salePaymentId;
            }
            set
            {
                _salePaymentId = value;
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

        /*Section="Field-SaleID"*/
        [UIHint("SalesList")]
        [OTRequired("Sale ID", null)]
        [OTDisplayName("Sale ID")]
        [DataMember]
        public long SaleID
        {
            get
            {
                return _saleID;
            }
            set
            {
                _saleID = value;
            }
        }

        /*Section="Field-TransactionID"*/
        [OTRequired("Transaction ID", null)]
        [OTDisplayName("Transaction ID")]
        [DataMember]
        public string TransactionID
        {
            get
            {
                return _transactionID;
            }
            set
            {
                _transactionID = value;
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

        /*Section="Field-Store"*/
        [UIHint("StoreList")]
        [OTRequired("Store", null)]
        [OTDisplayName("Store")]
        [DataMember]
        public long Store
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

        /*Section="Field-PaymentType"*/
        [OTRequired("Payment Type", null)]
        [OTDisplayName("Payment Type")]
        [DataMember]
        public string PaymentType
        {
            get
            {
                return _paymentType;
            }
            set
            {
                _paymentType = value;
            }
        }

        /*Section="Field-PaidAmount"*/
        [OTRequired("Paid Amount", null)]
        [OTDisplayName("Paid Amount")]
        [DataMember]
        public decimal PaidAmount
        {
            get
            {
                return _paidAmount;
            }
            set
            {
                _paidAmount = value;
            }
        }

        /*Section="Field-RefundAmount"*/
        [OTRequired("Refund Amount", null)]
        [OTDisplayName("Refund Amount")]
        [DataMember]
        public decimal RefundAmount
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

        /*Section="Field-PosBankType"*/
        [OTDisplayName("Pos Bank Type")]
        [DataMember]
        public Nullable<long> PosBankType
        {
            get
            {
                return _posBankType;
            }
            set
            {
                _posBankType = value;
            }
        }

        /*Section="Field-PosTrxType"*/
        [OTDisplayName("Pos Trx Type")]
        [DataMember]
        public Nullable<long> PosTrxType
        {
            get
            {
                return _posTrxType;
            }
            set
            {
                _posTrxType = value;
            }
        }

        /*Section="Field-CreditCardNo"*/
        [OTDisplayName("CreditCardNo")]
        [DataMember]
        public string CreditCardNo
        {
            get
            {
                return _creditCardNo;
            }
            set
            {
                _creditCardNo = value;
            }
        }

        /*Section="Field-IsDebitCard"*/
        [OTDisplayName("Is Debit Card")]
        [DataMember]
        public bool IsDebitCard
        {
            get
            {
                return _isDebitCard;
            }
            set
            {
                _isDebitCard = value;
            }
        }

        /*Section="Field-CreditCardAmount"*/
        [OTRequired("Credit Card Amount", null)]
        [OTDisplayName("Credit Card Amount")]
        [DataMember]
        public decimal CreditCardAmount
        {
            get
            {
                return _creditCardAmount;
            }
            set
            {
                _creditCardAmount = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _salePaymentId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}