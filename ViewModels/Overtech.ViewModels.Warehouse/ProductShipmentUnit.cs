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

    [OTDisplayName("Warehouse Product Unit")]
    [DataContract]
    public class WarehouseProductUnit : ViewModelObject
    {
        private long _productId;

        public override long GetId()
        {
            return _productId;
        }

        [DataMember]
        public long ProductId { get; set; }

        [DataMember]
        public string ProductCode { get; set; }

        [DataMember]
        public string ScaleCode { get; set; }

        [DataMember]
        public string Category { get; set; }

        [DataMember]
        public string SubGroup { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public decimal PackageQuantity { get; set; }

        [DataMember]
        public string PackageType { get; set; }

        [DataMember]
        public string Unit { get; set; }

        [DataMember]
        public string LoadLocation { get; set; }

        [DataMember]
        public string SearchString { get; set; }

        [DataMember]
        public decimal OnWayQuantity { get; set; }

        [DataMember]
        public decimal PriceAmount { get; set; }

    }

    [OTDisplayName("Product Shipment Unit")]
    [DataContract]
    public class ProductShipmentUnit : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Product Shipment Unit Id", null)]
        [OTDisplayName("Product Shipment Unit Id")]
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

        /*Section="Field-Product"*/
        [UIHint("ProductList")]
        [OTRequired("Product", null)]
        [OTDisplayName("Product")]
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
        [UIHint("ShipmentTypeList")]
        [OTRequired("Shipment Type", null)]
        [OTDisplayName("Shipment Type")]
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
        [OTRequired("Package Quantity", null)]
        [OTDisplayName("Package Quantity")]
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
        [UIHint("ShipmentPackageTypeList")]
        [OTRequired("Package Type", null)]
        [OTDisplayName("Package Type")]
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
        [OTDisplayName("Warehouse Location")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _productShipmentUnitId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}