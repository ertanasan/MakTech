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
namespace Overtech.DataModels.Price
{
    [OTDataObject(Module = "Price", ModuleShortName = "PRC", Table = "CURRENTPRICE", HasAutoIdentity = true, DisplayName = "Current Prices", IdField = "CurrentPricesId")]
    [DataContract]
    public class CurrentPrices : DataModelObject
    {
        private long _currentPricesId;
        private long _storeID;
        private string _productCodeName;
        private string _productName;
        private string _barcode;
        private int _productUnit;
        private decimal _salePrice;
        private decimal _saleVAT;
        private DateTime _versionTime;

        /*Section="Field-CurrentPricesId"*/
        [OTDataField("CURRENTPRICEID")]
        [DataMember]
        public long CurrentPricesId
        {
            get
            {
                return _currentPricesId;
            }
            set
            {
                _currentPricesId = value;
            }
        }

        /*Section="Field-StoreID"*/
        [OTDataField("STORE")]
        [DataMember]
        public long StoreID
        {
            get
            {
                return _storeID;
            }
            set
            {
                _storeID = value;
            }
        }

        /*Section="Field-ProductCodeName"*/
        [OTDataField("PRODUCTCODE_NM")]
        [DataMember]
        public string ProductCodeName
        {
            get
            {
                return _productCodeName;
            }
            set
            {
                _productCodeName = value;
            }
        }

        /*Section="Field-ProductName"*/
        [OTDataField("PRODUCT_NM")]
        [DataMember]
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
            }
        }

        /*Section="Field-Barcode"*/
        [OTDataField("BARCODE_TXT")]
        [DataMember]
        public string Barcode
        {
            get
            {
                return _barcode;
            }
            set
            {
                _barcode = value;
            }
        }

        /*Section="Field-ProductUnit"*/
        [OTDataField("PRODUCTUNIT_NO")]
        [DataMember]
        public int ProductUnit
        {
            get
            {
                return _productUnit;
            }
            set
            {
                _productUnit = value;
            }
        }

        /*Section="Field-SalePrice"*/
        [OTDataField("SALEPRICE_AMT")]
        [DataMember]
        public decimal SalePrice
        {
            get
            {
                return _salePrice;
            }
            set
            {
                _salePrice = value;
            }
        }

        /*Section="Field-SaleVAT"*/
        [OTDataField("SALEVAT_RT")]
        [DataMember]
        public decimal SaleVAT
        {
            get
            {
                return _saleVAT;
            }
            set
            {
                _saleVAT = value;
            }
        }

        /*Section="Field-VersionTime"*/
        [OTDataField("VERSION_TM")]
        [DataMember]
        public DateTime VersionTime
        {
            get
            {
                return _versionTime;
            }
            set
            {
                _versionTime = value;
            }
        }

        [OTDataField("PACKAGE")]
        [DataMember]
        public long PackageID  { get; set; }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _currentPricesId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("STORE_NM", IsExtended = true)]
        [DataMember]
        public string StoreName
        {
            get; set;
        }
        [OTDataField("UNIT_NM", IsExtended = true)]
        [DataMember]
        public string UnitName
        {
            get; set;
        }
        [OTDataField("GROUPCODE_NM", IsExtended = true)]
        [DataMember]
        public string GroupCodeName
        {
            get; set;
        }

        [OTDataField("PACKAGE_NM", IsExtended = true)]
        [DataMember]
        public string PackageName { get; set; }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

