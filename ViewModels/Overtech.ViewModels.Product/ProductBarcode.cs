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
namespace Overtech.ViewModels.Product
{
    [OTDisplayName("Product Barcode")]
    [DataContract]
    public class ProductBarcode : ViewModelObject
    {
        private long _productBarcodeId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private long _product;
        private long _barcodeType;
        private string _barcodeText;

        /*Section="Field-ProductBarcodeId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Product Barcode Id", null)]
        [OTDisplayName("Product Barcode Id")]
        [DataMember]
        public long ProductBarcodeId
        {
            get
            {
                return _productBarcodeId;
            }
            set
            {
                _productBarcodeId = value;
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

        /*Section="Field-BarcodeType"*/
        [UIHint("BarcodeTypeList")]
        [OTRequired("Barcode Type", null)]
        [OTDisplayName("Barcode Type")]
        [DataMember]
        public long BarcodeType
        {
            get
            {
                return _barcodeType;
            }
            set
            {
                _barcodeType = value;
            }
        }

        /*Section="Field-BarcodeText"*/
        [OTRequired("Barcode Text", null)]
        [OTDisplayName("Barcode Text")]
        [DataMember]
        public string BarcodeText
        {
            get
            {
                return _barcodeText;
            }
            set
            {
                _barcodeText = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _productBarcodeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}