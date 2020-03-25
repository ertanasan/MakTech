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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "MATERIALORDER", HasAutoIdentity = true, DisplayName = "Material Order", IdField = "MaterialOrderId")]
    [DataContract]
    public class MaterialOrder : DataModelObject
    {
        private long _materialOrderId;
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
        private string _orderName;
        private DateTime _orderDate;
        private int _orderStatusCode;
        private long _store;
        private Nullable<long> _processInstanceNumber;
        private Nullable<int> _mikroStatusCode;
        private string _mikroReference;
        private Nullable<DateTime> _mikroTime;
        private Nullable<long> _mikroUser;
        private long _material;
        private Nullable<long> _materialInfo;
        private decimal _orderQuantity;
        private decimal _revisedQuantity;
        private decimal _shippedQuantity;
        private decimal _intakeQuantity;
        private string _note;

        /*Section="Field-MaterialOrderId"*/
        [OTDataField("MATERIALORDERID")]
        [DataMember]
        public long MaterialOrderId
        {
            get
            {
                return _materialOrderId;
            }
            set
            {
                _materialOrderId = value;
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

        /*Section="Field-OrderName"*/
        [OTDataField("ORDER_NM")]
        [DataMember]
        public string OrderName
        {
            get
            {
                return _orderName;
            }
            set
            {
                _orderName = value;
            }
        }

        /*Section="Field-OrderDate"*/
        [OTDataField("ORDER_DT")]
        [DataMember]
        public DateTime OrderDate
        {
            get
            {
                return _orderDate;
            }
            set
            {
                _orderDate = value;
            }
        }

        /*Section="Field-OrderStatusCode"*/
        [OTDataField("ORDERSTATUS_CD")]
        [DataMember]
        public int OrderStatusCode
        {
            get
            {
                return _orderStatusCode;
            }
            set
            {
                _orderStatusCode = value;
            }
        }

        /*Section="Field-Store"*/
        [OTDataField("STORE")]
        [DataMember]
        public long Store
        {
            get
            {
                return _store;
            }
            set
            {
                _store = value;
            }
        }

        /*Section="Field-ProcessInstanceNumber"*/
        [OTDataField("PROCESSINSTANCE_LNO", Nullable = true)]
        [DataMember]
        public Nullable<long> ProcessInstanceNumber
        {
            get
            {
                return _processInstanceNumber;
            }
            set
            {
                _processInstanceNumber = value;
            }
        }

        /*Section="Field-MikroStatusCode"*/
        [OTDataField("MIKROSTATUS_CD", Nullable = true)]
        [DataMember]
        public Nullable<int> MikroStatusCode
        {
            get
            {
                return _mikroStatusCode;
            }
            set
            {
                _mikroStatusCode = value;
            }
        }

        /*Section="Field-MikroReference"*/
        [OTDataField("MIKROREF_TXT")]
        [DataMember]
        public string MikroReference
        {
            get
            {
                return _mikroReference;
            }
            set
            {
                _mikroReference = value;
            }
        }

        /*Section="Field-MikroTime"*/
        [OTDataField("MIKRO_TM", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> MikroTime
        {
            get
            {
                return _mikroTime;
            }
            set
            {
                _mikroTime = value;
            }
        }

        /*Section="Field-MikroUser"*/
        [OTDataField("MIKROUSER", Nullable = true)]
        [DataMember]
        public Nullable<long> MikroUser
        {
            get
            {
                return _mikroUser;
            }
            set
            {
                _mikroUser = value;
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

        /*Section="Field-MaterialInfo"*/
        [OTDataField("MATERIALINFO", Nullable = true)]
        [DataMember]
        public Nullable<long> MaterialInfo
        {
            get
            {
                return _materialInfo;
            }
            set
            {
                _materialInfo = value;
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
            _materialOrderId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

