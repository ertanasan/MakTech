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
namespace Overtech.ViewModels.Price
{
    [OTDisplayName("Price Label")]
    [DataContract]
    public class PriceVersion : ViewModelObject
    {
        private long _packageVersionId;
        private DateTime _versionDate;
        private string _priceVersionName;

        [ScaffoldColumn(false)]
        [OTDisplayName("PackageVersionID")]
        [ReadOnly(true)]
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

        [ScaffoldColumn(false)]
        [OTDisplayName("VersionDate")]
        [ReadOnly(true)]
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

        [ScaffoldColumn(false)]
        [OTDisplayName("VersionName")]
        [ReadOnly(true)]
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

        public override long GetId()
        {
            return _packageVersionId;
        }

        #region Customized
        #endregion Customized

    }


    [OTDisplayName("Product")]
    [DataContract]
    public class LabelPrice : ViewModelObject
    {
        /*Section="Constructor"*/
        public LabelPrice()
        {
            this.ImageReference = Guid.NewGuid().ToString();
        }

        public string ImageReference { get; set; }

        private long _productId;
        private string _code;
        private string _name;
        private decimal _saleVAT;
        private string _unitName;
        private long _barcodeType;
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
        private decimal _topPrice;
        private bool _print;
        private DateTime _priceChangeDate;
        private int _campaign;
        private decimal _unitPrice;
        private string _weightUnitName;


        [OTRequired("Product Id", null)]
        [OTDisplayName("Product Id")]
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

        [OTRequired("Code", null)]
        [OTStringLength(100)]
        [OTDisplayName("Code")]
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

        [OTRequired("Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Name")]
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

        [OTDisplayName("Sale VAT")]
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

        [UIHint("UnitList")]
        [OTRequired("UnitName", null)]
        [OTDisplayName("UnitName")]
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

        [UIHint("BarcodeTypeIntList")]
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

        [UIHint("Barcode")]
        [OTRequired("Barcode", null)]
        [OTDisplayName("Barcode")]
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

        [OTRequired("Private Label", null)]
        [OTDisplayName("Private Label")]
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

        [OTRequired("eTrade", null)]
        [OTDisplayName("eTrade")]
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
        
        [OTRequired("Short Name", null)]
        [OTStringLength(50)]
        [OTDisplayName("Short Name")]
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

        [OTRequired("Domestic", null)]
        [OTDisplayName("Domestic")]
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

        [UIHint("Country")]
        [OTRequired("Country", null)]
        [OTDisplayName("Country")]
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

        [OTRequired("Content", null)]
        [OTDisplayName("Content")]
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

        [UIHint("Warning")]
        [OTDisplayName("Warning")]
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

        [UIHint("StorageCondition")]
        [OTDisplayName("Storage Condition")]
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

        /*Section="Field-ExpiresIn"*/
        [OTRequired("Expires In", null)]
        [OTDisplayName("Expires In")]
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

        [OTRequired("Shelf Life", null)]
        [OTDisplayName("Shelf Life")]
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
        [OTDisplayName("Price")]
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

        [OTDisplayName("TopPrice")]
        [DataMember]
        public decimal TopPrice
        {
            get
            {
                return _topPrice;
            }
            set
            {
                _topPrice = value;
            }
        }

        [OTDisplayName("Print")]
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
        [OTDisplayName("Print")]
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

        [OTDisplayName("Campaign")]
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
        [OTDataField("UnitPrice")]
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
        [OTDisplayName("WeightUnitName")]
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

        public override long GetId()
        {
            return _productId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [DataMember]
        public long CurrentPriceId
        {
            get; set;
        }


        [DataMember]
        public int Package
        {
            get; set;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }

    #region Customized
    #endregion Customized

}


