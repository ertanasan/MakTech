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
    [OTDataObject(Module = "Reconciliation", ModuleShortName = "RCL", Table = "CASHDIST", HasAutoIdentity = true, DisplayName = "Cash Distribution", IdField = "CashDistributionId")]
    [DataContract]
    public class CashDistribution : DataModelObject
    {
        private long _cashDistributionId;
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
        private long _storeReconciliation;
        private long _banknote;
        private int _quantity;
        private int _groupCode;

        /*Section="Field-CashDistributionId"*/
        [OTDataField("CASHDISTID")]
        [DataMember]
        public long CashDistributionId
        {
            get
            {
                return _cashDistributionId;
            }
            set
            {
                _cashDistributionId = value;
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

        /*Section="Field-StoreReconciliation"*/
        [OTDataField("STOREREC")]
        [DataMember]
        public long StoreReconciliation
        {
            get
            {
                return _storeReconciliation;
            }
            set
            {
                _storeReconciliation = value;
            }
        }

        /*Section="Field-Banknote"*/
        [OTDataField("BANKNOTE")]
        [DataMember]
        public long Banknote
        {
            get
            {
                return _banknote;
            }
            set
            {
                _banknote = value;
            }
        }

        /*Section="Field-Quantity"*/
        [OTDataField("QUANTITY_QTY")]
        [DataMember]
        public int Quantity
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

        /*Section="Field-GroupCode"*/
        [OTDataField("GROUP_CD")]
        [DataMember]
        public int GroupCode
        {
            get
            {
                return _groupCode;
            }
            set
            {
                _groupCode = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _cashDistributionId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("BANKNOTE_AMT", IsExtended = true)]
        [DataMember]
        public decimal BanknoteAmount
        {
            get; set;
        }

        [OTDataField("COIN_FL", IsExtended = true)]
        [DataMember]
        public bool CoinFlag
        {
            get; set;
        }

        [OTDataField("AMOUNT_AMT", IsExtended = true)]
        [DataMember]
        public decimal Amount
        {
            get; set;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

