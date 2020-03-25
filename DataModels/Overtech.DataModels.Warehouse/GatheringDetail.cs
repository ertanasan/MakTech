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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "GATHERINGDETAIL", HasAutoIdentity = true, DisplayName = "Gathering Detail", IdField = "GatheringDetailId")]
    [DataContract]
    public class GatheringDetail : DataModelObject
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
        [OTDataField("GATHERINGDETAILID")]
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

        /*Section="Field-StoreOrderDetail"*/
        [OTDataField("STOREORDERDETAIL")]
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
        [OTDataField("GATHERING_TM", Nullable = true)]
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
        [OTDataField("GATHERING")]
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
        [OTDataField("GATHERED_QTY", Nullable = true)]
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
        [OTDataField("PALLET_NO")]
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
        [OTDataField("CONTROL_QTY", Nullable = true)]
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
        [OTDataField("CONTROL_TM", Nullable = true)]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _gatheringDetailId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OTDataField("PRODUCTNAME", IsExtended = true)]
        [DataMember]
        public string ProductName { get; set; }

        [OTDataField("PRODUCTCODE", IsExtended = true)]
        [DataMember]
        public string ProductCode { get; set; }

        [OTDataField("ORDER_QTY", IsExtended = true)]
        [DataMember]
        public decimal OrderQuantity { get; set; }

        [OTDataField("ORDERUNIT_QTY", IsExtended = true)]
        [DataMember]
        public decimal PackageUnit { get; set; }

        [OTDataField("UNIT_NM", IsExtended = true)]
        [DataMember]
        public string UnitName { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

