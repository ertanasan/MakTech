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

    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "WAREHOUSEPRODUCTUNIT", HasAutoIdentity = true, DisplayName = "Warehouse Product Unit", IdField = "ProductId")]
    [DataContract]
    public class WarehouseProductUnit : DataModelObject
    {
        private long _productId;

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _productId = id;
        }

        [OTDataField("PRODUCTID")]
        [DataMember]
        public long ProductId { get; set; }

        [OTDataField("CODE_NM")]
        [DataMember]
        public string ProductCode { get; set; }

        [OTDataField("SCALECODE_NM")]
        [DataMember]
        public string ScaleCode { get; set; }

        [OTDataField("CATEGORY_NM")]
        [DataMember]
        public string Category { get; set; }

        [OTDataField("SUBGROUP_NM")]
        [DataMember]
        public string SubGroup { get; set; }

        [OTDataField("NAME_NM")]
        [DataMember]
        public string ProductName { get; set; }

        [OTDataField("PACKAGE_QTY")]
        [DataMember]
        public decimal PackageQuantity { get; set; }

        [OTDataField("PACKAGETYPE_NM")]
        [DataMember]
        public string PackageType { get; set; }

        [OTDataField("UNIT_NM")]
        [DataMember]
        public string Unit{ get; set; }

        [OTDataField("LOCATION_TXT")]
        [DataMember]
        public string LoadLocation { get; set; }

        [OTDataField("SEARCHSTRING")]
        [DataMember]
        public string SearchString { get; set; }

        [OTDataField("ONWAY_QTY")]
        [DataMember]
        public decimal OnWayQuantity { get; set; }

        [OTDataField("PRICE_AMT")]
        [DataMember]
        public decimal PriceAmount { get; set; }
    }

    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "PRODUCTSHIPMENTUNIT", HasAutoIdentity = true, DisplayName = "Product Shipment Unit", IdField = "ProductShipmentUnitId")]
    [DataContract]
    public class ProductShipmentUnit : DataModelObject
    {
        private long _productShipmentUnitId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private long _product;
        private long _shipmentType;
        private decimal _packageQuantity;
        private long _packageType;
        private string _warehouseLocation;

        /*Section="Field-ProductShipmentUnitId"*/
        [OTDataField("PRODUCTSHIPMENTUNITID")]
        [DataMember]
        public long ProductShipmentUnitId
        {
            get
            {
                return _productShipmentUnitId;
            }
            set
            {
                _productShipmentUnitId = value;
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

        /*Section="Field-ShipmentType"*/
        [OTDataField("SHIPMENTTYPE")]
        [DataMember]
        public long ShipmentType
        {
            get
            {
                return _shipmentType;
            }
            set
            {
                _shipmentType = value;
            }
        }

        /*Section="Field-PackageQuantity"*/
        [OTDataField("PACKAGE_QTY")]
        [DataMember]
        public decimal PackageQuantity
        {
            get
            {
                return _packageQuantity;
            }
            set
            {
                _packageQuantity = value;
            }
        }

        /*Section="Field-PackageType"*/
        [OTDataField("PACKAGETYPE")]
        [DataMember]
        public long PackageType
        {
            get
            {
                return _packageType;
            }
            set
            {
                _packageType = value;
            }
        }

        /*Section="Field-WarehouseLocation"*/
        [OTDataField("LOCATION_TXT")]
        [DataMember]
        public string WarehouseLocation
        {
            get
            {
                return _warehouseLocation;
            }
            set
            {
                _warehouseLocation = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _productShipmentUnitId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

