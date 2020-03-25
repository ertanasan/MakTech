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
    [OTDisplayName("Bank Statement")]
    [DataContract]
    public class BankStatement : ViewModelObject
    {
        private long _bankStatementId;
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
        private DateTime _date;
        private string _description;
        private decimal _transactionAmount;
        private decimal _balance;
        private string _channel;
        private string _info1;
        private string _info2;
        private string _info3;

        /*Section="Field-BankStatementId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Bank Statement Id", null)]
        [OTDisplayName("Bank Statement Id")]
        [DataMember]
        public long BankStatementId
        {
            get
            {
                return _bankStatementId;
            }
            set
            {
                _bankStatementId = value;
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

        /*Section="Field-Date"*/
        [OTRequired("Date", null)]
        [OTDisplayName("Date")]
        [DataMember]
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        /*Section="Field-Description"*/
        [OTRequired("Description", null)]
        [OTStringLength(1000)]
        [OTDisplayName("Description")]
        [DataMember]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /*Section="Field-TransactionAmount"*/
        [OTRequired("Transaction Amount", null)]
        [OTDisplayName("Transaction Amount")]
        [DataMember]
        public decimal TransactionAmount
        {
            get
            {
                return _transactionAmount;
            }
            set
            {
                _transactionAmount = value;
            }
        }

        /*Section="Field-Balance"*/
        [OTRequired("Balance", null)]
        [OTDisplayName("Balance")]
        [DataMember]
        public decimal Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        }

        /*Section="Field-Channel"*/
        [OTRequired("Channel", null)]
        [OTStringLength(100)]
        [OTDisplayName("Channel")]
        [DataMember]
        public string Channel
        {
            get
            {
                return _channel;
            }
            set
            {
                _channel = value;
            }
        }

        /*Section="Field-Info1"*/
        [OTStringLength(100)]
        [OTDisplayName("Info 1")]
        [DataMember]
        public string Info1
        {
            get
            {
                return _info1;
            }
            set
            {
                _info1 = value;
            }
        }

        /*Section="Field-Info2"*/
        [OTStringLength(100)]
        [OTDisplayName("Info 2")]
        [DataMember]
        public string Info2
        {
            get
            {
                return _info2;
            }
            set
            {
                _info2 = value;
            }
        }

        /*Section="Field-Info3"*/
        [OTStringLength(100)]
        [OTDisplayName("Info 3")]
        [DataMember]
        public string Info3
        {
            get
            {
                return _info3;
            }
            set
            {
                _info3 = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _bankStatementId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}