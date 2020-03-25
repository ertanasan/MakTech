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
    [OTDisplayName("Transfer Product")]
    [DataContract]
    public class TransferProduct : ViewModelObject
    {
        private long _transferProductId;
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
        private long _sourceStore;
        private long _destinationStore;
        private Nullable<long> _processInstance;
        private long _transferStatus;
        private string _waybillNo;
        private Nullable<long> _targetWarehouse;

        /*Section="Field-TransferProductId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Transfer Product Id", null)]
        [OTDisplayName("Transfer Product Id")]
        [DataMember]
        public long TransferProductId
        {
            get
            {
                return _transferProductId;
            }
            set
            {
                _transferProductId = value;
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

        /*Section="Field-SourceStore"*/
        [UIHint("StoreList")]
        [OTRequired("Source Store", null)]
        [OTDisplayName("Source Store")]
        [DataMember]
        public long SourceStore
        {
            get
            {
                return _sourceStore;
            }
            set
            {
                _sourceStore = value;
            }
        }

        /*Section="Field-DestinationStore"*/
        [UIHint("StoreList")]
        [OTRequired("Destination Store", null)]
        [OTDisplayName("Destination Store")]
        [DataMember]
        public long DestinationStore
        {
            get
            {
                return _destinationStore;
            }
            set
            {
                _destinationStore = value;
            }
        }

        /*Section="Field-ProcessInstance"*/
        [OTDisplayName("Process Instance")]
        [DataMember]
        public Nullable<long> ProcessInstance
        {
            get
            {
                return _processInstance;
            }
            set
            {
                _processInstance = value;
            }
        }

        /*Section="Field-TransferStatus"*/
        [UIHint("TransferProductStatusList")]
        [OTRequired("Transfer Status", null)]
        [OTDisplayName("Transfer Status")]
        [DataMember]
        public long TransferStatus
        {
            get
            {
                return _transferStatus;
            }
            set
            {
                _transferStatus = value;
            }
        }

        /*Section="Field-WaybillNo"*/
        [OTDisplayName("Waybill No")]
        [DataMember]
        public string WaybillNo
        {
            get
            {
                return _waybillNo;
            }
            set
            {
                _waybillNo = value;
            }
        }

        /*Section="Field-TargetWarehouse"*/
        [UIHint("ReturnDestinationList")]
        [OTDisplayName("Target Warehouse")]
        [DataMember]
        public Nullable<long> TargetWarehouse
        {
            get
            {
                return _targetWarehouse;
            }
            set
            {
                _targetWarehouse = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _transferProductId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [DataMember]
        public IEnumerable<TransferProductDetail> TransferDetails { get; set; }

        [DataMember]
        public string ProcessStatus { get; set; }

        [DataMember]
        public string PreviousComment { get; set; }

        [DataMember]
        public long action { get; set; }

        [DataMember]
        public string actionChoice { get; set; }

        [DataMember]
        public string actionComment { get; set; }

        [DataMember]
        public bool TransferToWarehouse { get; set; }
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}