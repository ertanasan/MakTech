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
    [OTDataObject(Module = "Accounting", ModuleShortName = "ACC", Table = "BANKSTATEMENT", HasAutoIdentity = true, DisplayName = "Bank Statement", IdField = "BankStatementId")]
    [DataContract]
    public class BankStatement : DataModelObject
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
        [OTDataField("BANKSTATEMENTID")]
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

        /*Section="Field-Date"*/
        [OTDataField("DATE_DT")]
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
        [OTDataField("DESCRIPTION_DSC")]
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
        [OTDataField("TRANSACTION_AMT")]
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
        [OTDataField("BALANCE_AMT")]
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
        [OTDataField("CHANNEL_DSC")]
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
        [OTDataField("INFO1_DSC")]
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
        [OTDataField("INFO2_DSC")]
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
        [OTDataField("INFO3_DSC")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _bankStatementId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

