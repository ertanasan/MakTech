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

namespace Overtech.DataModels.Price
{
    [OTDataObject(Module = "Price", ModuleShortName = "PRC", Table = "LABEL", HasAutoIdentity = true, DisplayName = "Price Label", IdField = "PriceLabelId")]
    [DataContract]
    public class PriceVersion : DataModelObject
    {
        private long _packageVersionId;
        private DateTime _versionDate;
        private string _priceVersionName;

        [OTDataField("PackageVersionID")]
        [DataMember]
        public long PackageVersionID
        {
            get
            {
                return _packageVersionId;
            }
            set
            {
                _packageVersionId = value;
            }
        }


        [OTDataField("VersionDate")]
        [DataMember]
        public DateTime VersionDate
        {
            get
            {
                return _versionDate;
            }
            set
            {
                _versionDate = value;
            }
        }

        [OTDataField("VersionName")]
        [DataMember]
        public string VersionName
        {
            get
            {
                return _priceVersionName;
            }
            set
            {
                _priceVersionName = value;
            }
        }

        public override void SetId(long id)
        {
        }

        #region Customized
        #endregion Customized
        
    }

    [OTDataObject(Module = "Price", ModuleShortName = "PRD", Table = "LABEL", HasAutoIdentity = false, DisplayName = "Prica Label", IdField = "PriceLabelId")]
    [DataContract]
    public class LabelPrice : DataModelObject
    {
        private long _productId;
        private string _code;
        private string _name;
        private decimal _saleVAT;
        private string _unitName;
        private string _barcodeType;
        private long _barcode;
        private bool _privateLabel;
        private bool _eTrade;
        private string _shortName;
        private bool _domestic;
        private string _country;
        private string _content;
        private string _warning;
        private string _storageCondition;
        private int _expiresIn;
        private int _shelfLife;
        private decimal _price;
        private decimal _topprice;
        private bool _print;
        private DateTime _priceChangeDate;
        private int _campaign;
        private decimal _unitPrice;
        private string _weightUnitName;


        [OTDataField("PRODUCTID")]
        [DataMember]
        public long ProductID
        {
            get
            {
                return _productId;
            }
            set
            {
                _productId = value;
            }
        }

        [OTDataField("CODE_NM")]
        [DataMember]
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        [OTDataField("NAME_NM")]
        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

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

        [OTDataField("UNIT_NM")]
        [DataMember]
        public string UnitName
        {
            get
            {
                return _unitName;
            }
            set
            {
                _unitName = value;
            }
        }

        [OTDataField("BARCODETYPE")]
        [DataMember]
        public string BarcodeType
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

        [OTDataField("BARCODE_TXT")]
        [DataMember]
        public long Barcode
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


        [OTDataField("PRIVATELABEL_FL")]
        [DataMember]
        public bool PrivateLabel
        {
            get
            {
                return _privateLabel;
            }
            set
            {
                _privateLabel = value;
            }
        }

        [OTDataField("ETRADE_FL")]
        [DataMember]
        public bool eTrade
        {
            get
            {
                return _eTrade;
            }
            set
            {
                _eTrade = value;
            }
        }

        [OTDataField("SHORTNAME_NM")]
        [DataMember]
        public string ShortName
        {
            get
            {
                return _shortName;
            }
            set
            {
                _shortName = value;
            }
        }

        [OTDataField("DOMESTIC_FL")]
        [DataMember]
        public bool Domestic
        {
            get
            {
                return _domestic;
            }
            set
            {
                _domestic = value;
            }
        }

        [OTDataField("COUNTRY_NM")]
        [DataMember]
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }

        [OTDataField("CONTENT_TXT")]
        [DataMember]
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }

        [OTDataField("WARNING_TXT")]
        [DataMember]
        public string Warning
        {
            get
            {
                return _warning;
            }
            set
            {
                _warning = value;
            }
        }

        [OTDataField("CONDITION_TXT")]
        [DataMember]
        public string StorageCondition
        {
            get
            {
                return _storageCondition;
            }
            set
            {
                _storageCondition = value;
            }
        }

        [OTDataField("EXPIRESIN_CNT")]
        [DataMember]
        public int ExpiresIn
        {
            get
            {
                return _expiresIn;
            }
            set
            {
                _expiresIn = value;
            }
        }

        [OTDataField("SHELFLIFE_CNT")]
        [DataMember]
        public int ShelfLife
        {
            get
            {
                return _shelfLife;
            }
            set
            {
                _shelfLife = value;
            }
        }

        [OTDataField("PRICE_AMT")]
        [DataMember]
        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        [OTDataField("TOPPRICE_AMT")]
        [DataMember]
        public decimal TopPrice
        {
            get
            {
                return _topprice;
            }
            set
            {
                _topprice = value;
            }
        }
        [OTDataField("PRINT_FL")]
        [DataMember]
        public bool Print
        {
            get
            {
                return _print;
            }
            set
            {
                _print = value;
            }
        }
        [OTDataField("PRICECHANGE_DT")]
        [DataMember]
        public DateTime PriceChangeDate
        {
            get
            {
                return _priceChangeDate;
            }
            set
            {
                _priceChangeDate = value;
            }
        }

        [OTDataField("CAMPAIGN")]
        [DataMember]
        public int Campaign
        {
            get
            {
                return _campaign;
            }
            set
            {
                _campaign = value;
            }
        }
        [OTDataField("UNITPRICE_AMT")]
        [DataMember]
        public decimal UnitPrice
        {
            get
            {
                return _unitPrice;
            }
            set
            {
                _unitPrice = value;
            }
        }
        [OTDataField("WEIGHTUNIT_NM")]
        [DataMember]
        public string WeightUnitName
        {
            get
            {
                return _weightUnitName;
            }
            set
            {
                _weightUnitName = value;
            }
        }
        public override void SetId(long id)
        {
            _productId = id;
        }

        #region Customized
        // Keep your custom code in this region.
        [OTDataField("CURRENTPRICEID", IsExtended = true)]
        [DataMember]
        public long CurrentPriceId
        {
            get; set;
        }

        [OTDataField("PACKAGE", IsExtended = true)]
        [DataMember]
        public int Package
        {
            get; set;
        }
        #endregion Customized
    }


}

