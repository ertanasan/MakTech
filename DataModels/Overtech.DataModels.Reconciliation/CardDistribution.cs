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
    [OTDataObject(Module = "Reconciliation", ModuleShortName = "RCL", Table = "CARDDIST", HasAutoIdentity = true, DisplayName = "Card Distribution", IdField = "CardDistributionId")]
    [DataContract]
    public class CardDistribution : DataModelObject
    {
        private long _cardDistributionId;
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
        private int _cardGroupCode;
        private decimal _cardZetAmount;
        private long _storeRec;

        /*Section="Field-CardDistributionId"*/
        [OTDataField("CARDDISTID")]
        [DataMember]
        public long CardDistributionId
        {
            get
            {
                return _cardDistributionId;
            }
            set
            {
                _cardDistributionId = value;
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

        /*Section="Field-CardGroupCode"*/
        [OTDataField("CARDGROUP_CD")]
        [DataMember]
        public int CardGroupCode
        {
            get
            {
                return _cardGroupCode;
            }
            set
            {
                _cardGroupCode = value;
            }
        }

        /*Section="Field-CardZetAmount"*/
        [OTDataField("CARDZET_AMT")]
        [DataMember]
        public decimal CardZetAmount
        {
            get
            {
                return _cardZetAmount;
            }
            set
            {
                _cardZetAmount = value;
            }
        }

        /*Section="Field-StoreRec"*/
        [OTDataField("STOREREC")]
        [DataMember]
        public long StoreRec
        {
            get
            {
                return _storeRec;
            }
            set
            {
                _storeRec = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _cardDistributionId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("CARDGROUP_NM", IsExtended = true)]
        [DataMember]
        public string CardGroupName
        {
            get; set;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

