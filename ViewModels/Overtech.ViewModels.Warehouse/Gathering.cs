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
    [OTDisplayName("Gathering")]
    [DataContract]
    public class Gathering : ViewModelObject
    {
        private long _gatheringId;
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
        private long _storeOrder;
        private Nullable<long> _gatheringUser;
        private Nullable<DateTime> _gatheringStartTime;
        private Nullable<DateTime> _gatheringEndTime;
        private long _gatheringStatus;
        private long _gatheringType;
        private Nullable<int> _priority;

        /*Section="Field-GatheringId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Gathering Id", null)]
        [OTDisplayName("Gathering Id")]
        [DataMember]
        public long GatheringId
        {
            get
            {
                return _gatheringId;
            }
            set
            {
                _gatheringId = value;
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

        /*Section="Field-StoreOrder"*/
        [UIHint("StoreOrderList")]
        [OTRequired("Store Order", null)]
        [OTDisplayName("Store Order")]
        [DataMember]
        public long StoreOrder
        {
            get
            {
                return _storeOrder;
            }
            set
            {
                _storeOrder = value;
            }
        }

        /*Section="Field-GatheringUser"*/
        [UIHint("UserList")]
        [OTDisplayName("Gathering User")]
        [DataMember]
        public Nullable<long> GatheringUser
        {
            get
            {
                return _gatheringUser;
            }
            set
            {
                _gatheringUser = value;
            }
        }

        /*Section="Field-GatheringStartTime"*/
        [OTDisplayName("Gathering Start Time")]
        [DataMember]
        public Nullable<DateTime> GatheringStartTime
        {
            get
            {
                return _gatheringStartTime;
            }
            set
            {
                _gatheringStartTime = value;
            }
        }

        /*Section="Field-GatheringEndTime"*/
        [OTDisplayName("Gathering End Time")]
        [DataMember]
        public Nullable<DateTime> GatheringEndTime
        {
            get
            {
                return _gatheringEndTime;
            }
            set
            {
                _gatheringEndTime = value;
            }
        }

        /*Section="Field-GatheringStatus"*/
        [UIHint("GatheringStatusList")]
        [OTRequired("Gathering Status", null)]
        [OTDisplayName("Gathering Status")]
        [DefaultValue(1)]
        [DataMember]
        public long GatheringStatus
        {
            get
            {
                return _gatheringStatus;
            }
            set
            {
                _gatheringStatus = value;
            }
        }

        /*Section="Field-GatheringType"*/
        [UIHint("GatheringTypeList")]
        [OTRequired("Gathering Type", null)]
        [OTDisplayName("Gathering Type")]
        [DataMember]
        public long GatheringType
        {
            get
            {
                return _gatheringType;
            }
            set
            {
                _gatheringType = value;
            }
        }

        /*Section="Field-Priority"*/
        [OTDisplayName("Priority")]
        [DataMember]
        public Nullable<int> Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _gatheringId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [DataMember]
        public string StoreName { get; set; }

        [DataMember]
        public DateTime OrderDate { get; set; }

        [DataMember]
        public DateTime ShipmentDate { get; set; }

        [DataMember]
        public string StoreOrderName { get; set; }

        [DataMember]
        public string GatheringTypeName { get; set; }

        [DataMember]
        public string GatheringUserName { get; set; }

        [DataMember]
        public decimal OrderTotalKg { get; set; }

        [DataMember]
        public int ProductCount { get; set; }

        [DataMember]
        public decimal PackageCount { get; set; }

    }

    public class GatheringStats : ViewModelObject
    {
        [DataMember]
        public int WaitingLightCount
        {
            get; set;
        }

        [DataMember]
        public int WaitingHeavyCount
        {
            get; set;
        }

        [DataMember]
        public int ProcessingLightCount
        {
            get; set;
        }

        [DataMember]
        public int ProcessingHeavyCount
        {
            get; set;
        }

        [DataMember]
        public int OnHoldLightCount
        {
            get; set;
        }

        [DataMember]
        public int OnHoldHeavyCount
        {
            get; set;
        }

        [DataMember]
        public int WaitingForControlLightCount
        {
            get; set;
        }

        [DataMember]
        public int WaitingForControlHeavyCount
        {
            get; set;
        }

        [DataMember]
        public int ControllingLightCount
        {
            get; set;
        }

        [DataMember]
        public int ControllingHeavyCount
        {
            get; set;
        }

        [DataMember]
        public int OnHoldControlLightCount
        {
            get; set;
        }

        [DataMember]
        public int OnHoldControlHeavyCount
        {
            get; set;
        }

        public override long GetId()
        {
            throw new NotImplementedException();
        }
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}