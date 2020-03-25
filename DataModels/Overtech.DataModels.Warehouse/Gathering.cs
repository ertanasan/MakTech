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
namespace Overtech.DataModels.Warehouse
{
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "GATHERING", HasAutoIdentity = true, DisplayName = "Gathering", IdField = "GatheringId")]
    [DataContract]
    public class Gathering : DataModelObject
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
        [OTDataField("GATHERINGID")]
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

        /*Section="Field-StoreOrder"*/
        [OTDataField("STOREORDER")]
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
        [OTDataField("GATHERINGUSER", Nullable = true)]
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
        [OTDataField("GATHERINGSTART_TM", Nullable = true)]
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
        [OTDataField("GATHERINGEND_TM", Nullable = true)]
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
        [OTDataField("GATHERINGSTATUS")]
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
        [OTDataField("GATHERINGTYPE")]
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
        [OTDataField("PRIORITY_NO", Nullable = true)]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _gatheringId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OTDataField("STORENAME", IsExtended = true)]
        [DataMember]
        public string StoreName { get; set; }

        [OTDataField("ORDER_DT", IsExtended = true)]
        [DataMember]
        public DateTime OrderDate { get; set; }

        [OTDataField("SHIPMENT_DT", IsExtended = true)]
        [DataMember]
        public DateTime ShipmentDate { get; set; }

        [OTDataField("ORDERCODE_NM", IsExtended = true)]
        [DataMember]
        public string StoreOrderName { get; set; }

        [OTDataField("GATHERINGTYPE_NM", IsExtended = true)]
        [DataMember]
        public string GatheringTypeName { get; set; }

        [OTDataField("GATHERINGUSER_NM", IsExtended = true)]
        [DataMember]
        public string GatheringUserName { get; set; }

        [OTDataField("ORDERTOTALKG", IsExtended = true)]
        [DataMember]
        public decimal OrderTotalKg { get; set; }

        [OTDataField("PRODUCTCOUNT", IsExtended = true)]
        [DataMember]
        public int ProductCount { get; set; }

        [OTDataField("PACKAGECOUNT", IsExtended = true)]
        [DataMember]
        public decimal PackageCount { get; set; }

    }

    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", DisplayName = "GatheringStats")]
    public class GatheringStats: DataModelObject
    {
        [OTDataField("WAITINGLIGHT_CNT")]
        [DataMember]
        public int WaitingLightCount
        {
            get; set;
        }

        [OTDataField("WAITINGHEAVY_CNT")]
        [DataMember]
        public int WaitingHeavyCount
        {
            get; set;
        }

        [OTDataField("PROCESSINGLIGHT_CNT")]
        [DataMember]
        public int ProcessingLightCount
        {
            get; set;
        }

        [OTDataField("PROCESSINGHEAVY_CNT")]
        [DataMember]
        public int ProcessingHeavyCount
        {
            get; set;
        }

        [OTDataField("ONHOLDLIGHT_CNT")]
        [DataMember]
        public int OnHoldLightCount
        {
            get; set;
        }

        [OTDataField("ONHOLDHEAVY_CNT")]
        [DataMember]
        public int OnHoldHeavyCount
        {
            get; set;
        }

        [OTDataField("WAITINGFORCONTROLIGHT_CNT")]
        [DataMember]
        public int WaitingForControlLightCount
        {
            get; set;
        }

        [OTDataField("WAITINGFORCONTROLHEAVY_CNT")]
        [DataMember]
        public int WaitingForControlHeavyCount
        {
            get; set;
        }

        [OTDataField("CONTROLLINGLIGHT_CNT")]
        [DataMember]
        public int ControllingLightCount
        {
            get; set;
        }

        [OTDataField("CONTROLLINGHEAVY_CNT")]
        [DataMember]
        public int ControllingHeavyCount
        {
            get; set;
        }

        [OTDataField("ONHOLDCONTROLLIGHT_CNT")]
        [DataMember]
        public int OnHoldControlLightCount
        {
            get; set;
        }

        [OTDataField("ONHOLDCONTROLHEAVY_CNT")]
        [DataMember]
        public int OnHoldControlHeavyCount
        {
            get; set;
        }

        public override void SetId(long id)
        {
            throw new NotImplementedException();
        }
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

