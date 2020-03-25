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
    [OTDisplayName("Cash Distribution")]
    [DataContract]
    public class CashDistribution : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Cash Distribution Id", null)]
        [OTDisplayName("Cash Distribution Id")]
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

        /*Section="Field-StoreReconciliation"*/
        [UIHint("ReconciliationList")]
        [OTRequired("Store Reconciliation", null)]
        [OTDisplayName("Store Reconciliation")]
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
        [UIHint("BanknoteList")]
        [OTRequired("Banknote", null)]
        [OTDisplayName("Banknote")]
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
        [OTRequired("Quantity", null)]
        [OTDisplayName("Quantity")]
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
        [OTRequired("Group Code", null)]
        [OTDisplayName("Group Code")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _cashDistributionId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public decimal BanknoteAmount
        {
            get; set;
        }

        [DataMember]
        public bool CoinFlag
        {
            get; set;
        }

        [DataMember]
        public decimal Amount
        {
            get; set;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}