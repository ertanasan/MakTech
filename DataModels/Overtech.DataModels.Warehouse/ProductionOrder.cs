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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "PRODUCTIONORDER", HasAutoIdentity = true, DisplayName = "Production Order", IdField = "ProductionOrderId")]
    [DataContract]
    public class ProductionOrder : DataModelObject
    {
        private long _productionOrderId;
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
        private long _production;
        private int _quantity;
        private int _statusCode;
        private Nullable<long> _processInstance;
        private Nullable<int> _completedQuantity;

        /*Section="Field-ProductionOrderId"*/
        [OTDataField("PRODUCTIONORDERID")]
        [DataMember]
        public long ProductionOrderId
        {
            get
            {
                return _productionOrderId;
            }
            set
            {
                _productionOrderId = value;
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

        /*Section="Field-Production"*/
        [OTDataField("PRODUCTION")]
        [DataMember]
        public long Production
        {
            get
            {
                return _production;
            }
            set
            {
                _production = value;
            }
        }

        /*Section="Field-Quantity"*/
        [OTDataField("QUANTITY_QTY")]
        [DataMember]
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }

        /*Section="Field-StatusCode"*/
        [OTDataField("STATUS_CD")]
        [DataMember]
        public int StatusCode
        {
            get
            {
                return _statusCode;
            }
            set
            {
                _statusCode = value;
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

        /*Section="Field-CompletedQuantity"*/
        [OTDataField("COMPLETED_QTY", Nullable = true)]
        [DataMember]
        public Nullable<int> CompletedQuantity
        {
            get
            {
                return _completedQuantity;
            }
            set
            {
                _completedQuantity = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _productionOrderId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public long action { get; set; }

        [DataMember]
        public string actionChoice { get; set; }

        [DataMember]
        public string actionComment { get; set; }

        [DataMember]
        public IEnumerable<ProductionContent> contents { get; set; }

        [DataMember]
        public Nullable<decimal> PartialCompletion { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

