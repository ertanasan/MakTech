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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "GATHERINGPALLET", HasAutoIdentity = true, DisplayName = "Gathering Pallet", IdField = "GatheringPalletId")]
    [DataContract]
    public class GatheringPallet : DataModelObject
    {
        private long _gatheringPalletId;
        private bool _deleted;
        private DateTime _createDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private Nullable<DateTime> _updateDate;
        private long _gathering;
        private long _organization;
        private int _palletNo;
        private Nullable<long> _controlUser;
        private Nullable<DateTime> _control;
        private Nullable<DateTime> _controlEndTime;
        private long _gatheringPalletStatus;

        /*Section="Field-GatheringPalletId"*/
        [OTDataField("GATHERINGPALLETID")]
        [DataMember]
        public long GatheringPalletId
        {
            get
            {
                return _gatheringPalletId;
            }
            set
            {
                _gatheringPalletId = value;
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

        /*Section="Field-Organization"*/
        [OTDataField("ORGANIZATION")]
        [ReadOnly(true)]
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

        /*Section="Field-ControlUser"*/
        [OTDataField("CONTROLUSER", Nullable = true)]
        [DataMember]
        public Nullable<long> ControlUser
        {
            get
            {
                return _controlUser;
            }
            set
            {
                _controlUser = value;
            }
        }

        /*Section="Field-Control"*/
        [OTDataField("CONTROLSTART_TM", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> Control
        {
            get
            {
                return _control;
            }
            set
            {
                _control = value;
            }
        }

        /*Section="Field-ControlEndTime"*/
        [OTDataField("CONTROLEND_TM", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> ControlEndTime
        {
            get
            {
                return _controlEndTime;
            }
            set
            {
                _controlEndTime = value;
            }
        }

        /*Section="Field-GatheringPalletStatus"*/
        [OTDataField("GATHERINGPALLETSTATUS")]
        [DataMember]
        public long GatheringPalletStatus
        {
            get
            {
                return _gatheringPalletStatus;
            }
            set
            {
                _gatheringPalletStatus = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _gatheringPalletId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("STORE_NM", IsExtended = true)]
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

        [OTDataField("GATHERINGTYPEID", IsExtended = true)]
        [DataMember]
        public int GatheringTypeId { get; set; }

        [OTDataField("CONTROLUSER_NM", IsExtended = true)]
        [DataMember]
        public string ControlUserName { get; set; }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

