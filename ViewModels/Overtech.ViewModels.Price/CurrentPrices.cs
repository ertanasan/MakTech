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
    [OTDisplayName("Current Prices")]
    [DataContract]
    public class CurrentPrices : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Current Prices Id", null)]
        [OTDisplayName("Current Prices Id")]
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
        [UIHint("StoreList")]
        [OTRequired("Store ID", null)]
        [OTDisplayName("Store ID")]
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
        [OTRequired("Product Code Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Product Code Name")]
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
        [OTRequired("Product Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Product Name")]
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
        [OTRequired("Barcode", null)]
        [OTDisplayName("Barcode")]
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
        [OTRequired("Product Unit", null)]
        [OTDisplayName("Product Unit")]
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
        [OTRequired("Sale Price", null)]
        [OTDisplayName("Sale Price")]
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
        [OTRequired("Sale VAT", null)]
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

        /*Section="Field-VersionTime"*/
        [OTRequired("Version Time", null)]
        [OTDisplayName("Version Time")]
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

        [OTDisplayName("Package ID")]
        [DataMember]
        public long PackageID { get; set; }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _currentPricesId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public string StoreName
        {
            get; set;
        }
        [DataMember]
        public string UnitName
        {
            get; set;
        }
        [DataMember]
        public string GroupCodeName
        {
            get; set;
        }

        [DataMember]
        public string PackageName { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}