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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "INTAKESTATUS", HasAutoIdentity = true, DisplayName = "Intake Status", IdField = "IntakeStatusId")]
    [DataContract]
    public class IntakeStatus : DataModelObject
    {
        private long _intakeStatusId;
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
        private long _intakeStatusType;
        private string _description;
        private bool _isTransferred;
        private Nullable<DateTime> _mikroTransferTime;
        private decimal _quantityDifference;

        /*Section="Field-IntakeStatusId"*/
        [OTDataField("INTAKESTATUSID")]
        [DataMember]
        public long IntakeStatusId
        {
            get
            {
                return _intakeStatusId;
            }
            set
            {
                _intakeStatusId = value;
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

        /*Section="Field-IntakeStatusType"*/
        [OTDataField("INTAKESTATUSTYPE")]
        [DataMember]
        public long IntakeStatusType
        {
            get
            {
                return _intakeStatusType;
            }
            set
            {
                _intakeStatusType = value;
            }
        }

        /*Section="Field-Description"*/
        [OTDataField("DESCRIPTION_DSC")]
        [DataMember]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /*Section="Field-IsTransferred"*/
        [OTDataField("MIKROTRANSFER_FL")]
        [DataMember]
        public bool IsTransferred
        {
            get
            {
                return _isTransferred;
            }
            set
            {
                _isTransferred = value;
            }
        }

        /*Section="Field-MikroTransferTime"*/
        [OTDataField("MIKROTRANSFER_TM", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> MikroTransferTime
        {
            get
            {
                return _mikroTransferTime;
            }
            set
            {
                _mikroTransferTime = value;
            }
        }

        /*Section="Field-QuantityDifference"*/
        [OTDataField("QUANTITYDIF_QTY")]
        [DataMember]
        public decimal QuantityDifference
        {
            get
            {
                return _quantityDifference;
            }
            set
            {
                _quantityDifference = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _intakeStatusId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OTDataField("DIFFTYPE_TXT", IsExtended = true)]
        [DataMember]
        public string DifferenceType
        {
            get; set;
        }
        
        [OTDataField("STORE_NM", IsExtended = true)]
        [DataMember]
        public string StoreName
        {
            get; set;
        }

        [OTDataField("PRODUCT_NM", IsExtended = true)]
        [DataMember]
        public string ProductName
        {
            get; set;
        }

        [OTDataField("UNIT_NM", IsExtended = true)]
        [DataMember]
        public string UnitName
        {
            get; set;
        }

        [OTDataField("ORDER_DT", IsExtended = true)]
        [DataMember]
        public DateTime OrderDate
        {
            get; set;
        }

        [OTDataField("MIKROSHIPMENT_DT", IsExtended = true)]
        [DataMember]
        public DateTime MikroShipmentDate
        {
            get; set;
        }

        [OTDataField("INTAKE_DT", IsExtended = true)]
        [DataMember]
        public DateTime IntakeDate
        {
            get; set;
        }

        [OTDataField("SHIPPED_QTY", IsExtended = true)]
        [DataMember]
        public decimal ShippedQuantity
        {
            get; set;
        }

        [OTDataField("INTAKE_QTY", IsExtended = true)]
        [DataMember]
        public decimal IntakeQuantity
        {
            get; set;
        }

        [OTDataField("STOREORDER", IsExtended = true)]
        [DataMember]
        public long StoreOrder
        {
            get; set;
        }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

