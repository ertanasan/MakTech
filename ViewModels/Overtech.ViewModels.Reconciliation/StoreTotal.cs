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
    [OTDisplayName("Store Total")]
    [DataContract]
    public class StoreTotal : ViewModelObject
    {
        private long _storeTotalID;
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
        private long _store;
        private decimal _cashTotal;
        private decimal _creditCard1;
        private decimal _creditCard2;
        private decimal _creditCard3;
        private decimal _creditCard4;
        private decimal _creditCard5;
        private decimal _creditCard6;
        private decimal _advance;
        private decimal _eodAdvance;
        private decimal _toBank;
        private string _nameSurname;
        private string _comment;
        private bool _reconciliated;

        /*Section="Field-StoreTotalID"*/
        [ScaffoldColumn(false)]
        [OTRequired("Store Total ID", null)]
        [OTDisplayName("Store Total ID")]
        [DataMember]
        public long StoreTotalID
        {
            get
            {
                return _storeTotalID;
            }
            set
            {
                _storeTotalID = value;
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

        /*Section="Field-CashTotal"*/
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

        /*Section="Field-CreditCard1"*/
        [OTRequired("Credit Card -1", null)]
        [OTDisplayName("Credit Card -1")]
        [DataMember]
        public decimal CreditCard1
        {
            get
            {
                return _creditCard1;
            }
            set
            {
                _creditCard1 = value;
            }
        }

        /*Section="Field-CreditCard2"*/
        [OTRequired("Credit Card -2", null)]
        [OTDisplayName("Credit Card -2")]
        [DataMember]
        public decimal CreditCard2
        {
            get
            {
                return _creditCard2;
            }
            set
            {
                _creditCard2 = value;
            }
        }

        /*Section="Field-CreditCard3"*/
        [OTRequired("Credit Card -3", null)]
        [OTDisplayName("Credit Card -3")]
        [DataMember]
        public decimal CreditCard3
        {
            get
            {
                return _creditCard3;
            }
            set
            {
                _creditCard3 = value;
            }
        }

        /*Section="Field-CreditCard4"*/
        [OTRequired("Credit Card 4", null)]
        [OTDisplayName("Credit Card 4")]
        [DataMember]
        public decimal CreditCard4
        {
            get
            {
                return _creditCard4;
            }
            set
            {
                _creditCard4 = value;
            }
        }

        /*Section="Field-CreditCard5"*/
        [OTRequired("Credit Card 5", null)]
        [OTDisplayName("Credit Card 5")]
        [DataMember]
        public decimal CreditCard5
        {
            get
            {
                return _creditCard5;
            }
            set
            {
                _creditCard5 = value;
            }
        }

        /*Section="Field-CreditCard6"*/
        [OTRequired("Credit Card 6", null)]
        [OTDisplayName("Credit Card 6")]
        [DataMember]
        public decimal CreditCard6
        {
            get
            {
                return _creditCard6;
            }
            set
            {
                _creditCard6 = value;
            }
        }

        /*Section="Field-Advance"*/
        [OTRequired("Advance", null)]
        [OTDisplayName("Advance")]
        [DataMember]
        public decimal Advance
        {
            get
            {
                return _advance;
            }
            set
            {
                _advance = value;
            }
        }

        /*Section="Field-EodAdvance"*/
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

        /*Section="Field-ToBank"*/
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

        /*Section="Field-NameSurname"*/
        [OTRequired("Name Surname", null)]
        [OTStringLength(100)]
        [OTDisplayName("Name Surname")]
        [DataMember]
        public string NameSurname
        {
            get
            {
                return _nameSurname;
            }
            set
            {
                _nameSurname = value;
            }
        }

        /*Section="Field-Comment"*/
        [OTStringLength(1000)]
        [OTDisplayName("Comment")]
        [DataMember]
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
            }
        }

        /*Section="Field-Reconciliated"*/
        [OTRequired("Reconciliated", null)]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _storeTotalID;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}