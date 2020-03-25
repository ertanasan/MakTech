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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "MATERIALORDERDETAIL", HasAutoIdentity = true, DisplayName = "Material Order Detail", IdField = "MaterialOrderDetailId")]
    [DataContract]
    public class MaterialOrderDetail : DataModelObject
    {
        private long _materialOrderDetailId;
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
        private long _materialOrder;
        private long _material;
        private decimal _orderQuantity;
        private decimal _revisedQuantity;
        private decimal _shippedQuantity;
        private decimal _intakeQuantity;
        private string _note;

        /*Section="Field-MaterialOrderDetailId"*/
        [OTDataField("MATERIALORDERDETAILID")]
        [DataMember]
        public long MaterialOrderDetailId
        {
            get
            {
                return _materialOrderDetailId;
            }
            set
            {
                _materialOrderDetailId = value;
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

        /*Section="Field-MaterialOrder"*/
        [OTDataField("MATERIALORDER")]
        [DataMember]
        public long MaterialOrder
        {
            get
            {
                return _materialOrder;
            }
            set
            {
                _materialOrder = value;
            }
        }

        /*Section="Field-Material"*/
        [OTDataField("MATERIAL")]
        [DataMember]
        public long Material
        {
            get
            {
                return _material;
            }
            set
            {
                _material = value;
            }
        }

        /*Section="Field-OrderQuantity"*/
        [OTDataField("ORDER_AMT")]
        [DataMember]
        public decimal OrderQuantity
        {
            get
            {
                return _orderQuantity;
            }
            set
            {
                _orderQuantity = value;
            }
        }

        /*Section="Field-RevisedQuantity"*/
        [OTDataField("REVISED_AMT")]
        [DataMember]
        public decimal RevisedQuantity
        {
            get
            {
                return _revisedQuantity;
            }
            set
            {
                _revisedQuantity = value;
            }
        }

        /*Section="Field-ShippedQuantity"*/
        [OTDataField("SHIPPED_AMT")]
        [DataMember]
        public decimal ShippedQuantity
        {
            get
            {
                return _shippedQuantity;
            }
            set
            {
                _shippedQuantity = value;
            }
        }

        /*Section="Field-IntakeQuantity"*/
        [OTDataField("INTAKE_AMT")]
        [DataMember]
        public decimal IntakeQuantity
        {
            get
            {
                return _intakeQuantity;
            }
            set
            {
                _intakeQuantity = value;
            }
        }

        /*Section="Field-Note"*/
        [OTDataField("NOTE_TXT")]
        [DataMember]
        public string Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _materialOrderDetailId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

