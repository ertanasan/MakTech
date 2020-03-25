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
namespace Overtech.ViewModels.Warehouse
{
    [OTDisplayName("Gathering Detail")]
    [DataContract]
    public class GatheringDetail : ViewModelObject
    {
        private long _gatheringDetailId;
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
        private long _storeOrderDetail;
        private Nullable<DateTime> _gatheringTime;
        private long _gathering;
        private Nullable<decimal> _gatheredQuantity;
        private int _palletNo;
        private Nullable<decimal> _controlQuantity;
        private Nullable<DateTime> _controlTime;

        /*Section="Field-GatheringDetailId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Gathering Detail Id", null)]
        [OTDisplayName("Gathering Detail Id")]
        [DataMember]
        public long GatheringDetailId
        {
            get
            {
                return _gatheringDetailId;
            }
            set
            {
                _gatheringDetailId = value;
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

        /*Section="Field-StoreOrderDetail"*/
        [UIHint("StoreOrderDetailList")]
        [OTRequired("Store Order Detail", null)]
        [OTDisplayName("Store Order Detail")]
        [DataMember]
        public long StoreOrderDetail
        {
            get
            {
                return _storeOrderDetail;
            }
            set
            {
                _storeOrderDetail = value;
            }
        }

        /*Section="Field-GatheringTime"*/
        [OTDisplayName("Gathering Time")]
        [DataMember]
        public Nullable<DateTime> GatheringTime
        {
            get
            {
                return _gatheringTime;
            }
            set
            {
                _gatheringTime = value;
            }
        }

        /*Section="Field-Gathering"*/
        [UIHint("GatheringList")]
        [OTRequired("Gathering", null)]
        [OTDisplayName("Gathering")]
        [DataMember]
        public long Gathering
        {
            get
            {
                return _gathering;
            }
            set
            {
                _gathering = value;
            }
        }

        /*Section="Field-GatheredQuantity"*/
        [OTDisplayName("Gathered Quantity")]
        [DataMember]
        public Nullable<decimal> GatheredQuantity
        {
            get
            {
                return _gatheredQuantity;
            }
            set
            {
                _gatheredQuantity = value;
            }
        }

        /*Section="Field-PalletNo"*/
        [OTRequired("Pallet No", null)]
        [OTDisplayName("Pallet No")]
        [DefaultValue(1)]
        [DataMember]
        public int PalletNo
        {
            get
            {
                return _palletNo;
            }
            set
            {
                _palletNo = value;
            }
        }

        /*Section="Field-ControlQuantity"*/
        [OTDisplayName("Control Quantity")]
        [DataMember]
        public Nullable<decimal> ControlQuantity
        {
            get
            {
                return _controlQuantity;
            }
            set
            {
                _controlQuantity = value;
            }
        }

        /*Section="Field-ControlTime"*/
        [OTDisplayName("Control Time")]
        [DataMember]
        public Nullable<DateTime> ControlTime
        {
            get
            {
                return _controlTime;
            }
            set
            {
                _controlTime = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _gatheringDetailId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public string ProductCode { get; set; }

        [DataMember]
        public decimal OrderQuantity { get; set; }

        [DataMember]
        public decimal PackageUnit { get; set; }

        [DataMember]
        public string UnitName { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}