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
    [OTDisplayName("Gathering Pallet")]
    [DataContract]
    public class GatheringPallet : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Gathering Pallet Id", null)]
        [OTDisplayName("Gathering Pallet Id")]
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

        /*Section="Field-Organization"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Organization")]
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
        [OTRequired("Pallet No", null)]
        [OTDisplayName("Pallet No")]
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
        [UIHint("UserList")]
        [ScaffoldColumn(false)]
        [OTDisplayName("Control User")]
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
        [OTDisplayName("Control ")]
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
        [OTDisplayName("Control End Time")]
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
        [UIHint("GatheringPalletStatusList")]
        [OTRequired("Gathering Pallet Status", null)]
        [OTDisplayName("Gathering Pallet Status")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _gatheringPalletId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
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
        public int GatheringTypeId { get; set; }

        [DataMember]
        public string ControlUserName { get; set; }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}