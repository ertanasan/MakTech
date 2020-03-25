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
    [OTDisplayName("Card Distribution")]
    [DataContract]
    public class CardDistribution : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Card Distribution Id", null)]
        [OTDisplayName("Card Distribution Id")]
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

        /*Section="Field-CardGroupCode"*/
        [OTRequired("Card Group Code", null)]
        [OTDisplayName("Card Group Code")]
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
        [OTRequired("Card Zet Amount", null)]
        [OTDisplayName("Card Zet Amount")]
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
        [UIHint("ReconciliationList")]
        [OTRequired("Store Rec", null)]
        [OTDisplayName("Store Rec")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _cardDistributionId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public string CardGroupName
        {
            get; set;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}