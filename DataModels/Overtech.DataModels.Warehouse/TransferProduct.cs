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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "TRANSFERPRODUCT", HasAutoIdentity = true, DisplayName = "Transfer Product", IdField = "TransferProductId")]
    [DataContract]
    public class TransferProduct : DataModelObject
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
        [OTDataField("TRANSFERPRODUCTID")]
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

        /*Section="Field-SourceStore"*/
        [OTDataField("SOURCESTORE")]
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
        [OTDataField("DESTINATIONSTORE")]
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
        [OTDataField("PROCESSINSTANCE_LNO", Nullable = true)]
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
        [OTDataField("TRANSFERSTATUS")]
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
        [OTDataField("WAYBILL_TXT")]
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
        [OTDataField("RETURNDESTINATION", Nullable = true)]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _transferProductId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [DataMember]
        public IEnumerable<TransferProductDetail> TransferDetails { get; set; }

        [OTDataField("PREVIOUSCOMMENT_DSC", IsExtended=true)]
        [DataMember]
        public string PreviousComment { get; set; }

        [OTDataField("PROCESSSTATUS_DSC", IsExtended = true)]
        [DataMember]
        public string ProcessStatus { get; set; }

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

