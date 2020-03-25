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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "STOREORDERDETAIL", HasAutoIdentity = true, DisplayName = "Store Order Detail", IdField = "StoreOrderDetailId")]
    [DataContract]
    public class StoreOrderDetail : DataModelObject
    {
        private long _storeOrderDetailId;
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
        private long _product;
        private decimal _orderQuantity;
        private Nullable<decimal> _revisedQuantity;
        private Nullable<decimal> _shippedQuantity;
        private decimal _orderUnitQuantity;
        private long _storeOrder;
        private Nullable<decimal> _intakeQuantity;
        private Nullable<decimal> _suggestionQuantity;

        /*Section="Field-StoreOrderDetailId"*/
        [OTDataField("STOREORDERDETAILID")]
        [DataMember]
        public long StoreOrderDetailId
        {
            get
            {
                return _storeOrderDetailId;
            }
            set
            {
                _storeOrderDetailId = value;
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

        /*Section="Field-Product"*/
        [OTDataField("PRODUCT")]
        [DataMember]
        public long Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
            }
        }

        /*Section="Field-OrderQuantity"*/
        [OTDataField("ORDER_QTY")]
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
        [OTDataField("REVISED_QTY", Nullable = true)]
        [DataMember]
        public Nullable<decimal> RevisedQuantity
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
        [OTDataField("SHIPPED_QTY", Nullable = true)]
        [DataMember]
        public Nullable<decimal> ShippedQuantity
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

        /*Section="Field-OrderUnitQuantity"*/
        [OTDataField("ORDERUNIT_QTY")]
        [DataMember]
        public decimal OrderUnitQuantity
        {
            get
            {
                return _orderUnitQuantity;
            }
            set
            {
                _orderUnitQuantity = value;
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

        /*Section="Field-IntakeQuantity"*/
        [OTDataField("INTAKE_QTY", Nullable = true)]
        [DataMember]
        public Nullable<decimal> IntakeQuantity
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

        /*Section="Field-SuggestionQuantity"*/
        [OTDataField("SUGGESTION_QTY", Nullable = true)]
        [DataMember]
        public Nullable<decimal> SuggestionQuantity
        {
            get
            {
                return _suggestionQuantity;
            }
            set
            {
                _suggestionQuantity = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _storeOrderDetailId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized

        [OTDataField("PRODUCTCODE_NM", IsExtended = true)]
        [DataMember]
        public string ProductCode
        {
            get; set;
        }

        [OTDataField("PRODUCT_NM", IsExtended = true)]
        [DataMember]
        public string ProductName
        {
            get; set;
        }

        [OTDataField("SUBGROUP_NM", IsExtended = true)]
        [DataMember]
        public string SubGroupName
        {
            get; set;
        }

        [OTDataField("CATEGORY_NM", IsExtended = true)]
        [DataMember]
        public string Category
        {
            get; set;
        }

        [OTDataField("SCALECODE_NM", IsExtended = true)]
        [DataMember]
        public string ScaleCode
        {
            get; set;
        }

        [OTDataField("PACKAGE_QTY", IsExtended = true)]
        [DataMember]
        public decimal PackageQuantity
        {
            get; set;
        }

        [OTDataField("PACKAGETYPE_NM", IsExtended = true)]
        [DataMember]
        public string PackageType
        {
            get; set;
        }

        [OTDataField("UNIT_NM", IsExtended = true)]
        [DataMember]
        public string Unit
        {
            get; set;
        }

        [OTDataField("LOADORDER_TXT", IsExtended = true)]
        [DataMember]
        public string LoadOrder
        {
            get; set;
        }

        [OTDataField("PRICE_AMT", IsExtended = true)]
        [DataMember]
        public decimal PriceAmount
        {
            get; set;
        }

        [OTDataField("ONWAY_QTY", IsExtended = true)]
        [DataMember]
        public decimal OnWayQuantity
        {
            get; set;
        }

        [OTDataField("WEIGHT_AMT", IsExtended = true)]
        [DataMember]
        public decimal WeightAmount
        {
            get; set;
        }

        [OTDataField("CLOSETOORDER_FL", IsExtended = true)]
        [DataMember]
        public bool ClosetoOrder
        {
            get; set;
        }

        [OTDataField("SALEAVG", IsExtended = true)]
        [DataMember]
        public decimal SaleAverage
        {
            get; set;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

