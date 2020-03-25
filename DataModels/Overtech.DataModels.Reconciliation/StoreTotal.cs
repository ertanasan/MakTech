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
    [OTDataObject(Module = "Reconciliation", ModuleShortName = "RCL", Table = "STORETOTAL", HasAutoIdentity = true, DisplayName = "Store Total", IdField = "StoreTotalID")]
    [DataContract]
    public class StoreTotal : DataModelObject
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
        [OTDataField("STORETOTALID")]
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

        /*Section="Field-Store"*/
        [OTDataField("STORE")]
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

        /*Section="Field-CreditCard1"*/
        [OTDataField("CREDITCARD1_AMT")]
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
        [OTDataField("CREDITCARD2_AMT")]
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
        [OTDataField("CREDITCARD3_AMT")]
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
        [OTDataField("CREDITCARD4_AMT")]
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
        [OTDataField("CREDITCARD5_AMT")]
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
        [OTDataField("CREDITCARD6_AMT")]
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
        [OTDataField("ADVANCE_AMT")]
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

        /*Section="Field-ToBank"*/
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

        /*Section="Field-NameSurname"*/
        [OTDataField("NAMESURNAME_NM")]
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
        [OTDataField("COMMENT_DSC")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _storeTotalID = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

