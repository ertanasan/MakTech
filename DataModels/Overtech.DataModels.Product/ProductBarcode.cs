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
namespace Overtech.DataModels.Product
{
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "BARCODE", HasAutoIdentity = true, DisplayName = "Product Barcode", IdField = "ProductBarcodeId")]
    [DataContract]
    public class ProductBarcode : DataModelObject
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
        [OTDataField("BARCODEID")]
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

        /*Section="Field-BarcodeType"*/
        [OTDataField("BARCODETYPE")]
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
        [OTDataField("BARCODE_TXT")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _productBarcodeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

