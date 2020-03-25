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
    [OTDisplayName("Product Price")]
    [DataContract]
    public class ProductPrice : ViewModelObject
    {
        private long _productPriceId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private decimal _priceAmount;
        private long _product;
        private long _package;
        private Nullable<decimal> _topPriceAmount;
        private bool _printTopPriceFlag;
        private long _packageVersion;

        /*Section="Field-ProductPriceId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Product Price Id", null)]
        [OTDisplayName("Product Price Id")]
        [DataMember]
        public long ProductPriceId
        {
            get
            {
                return _productPriceId;
            }
            set
            {
                _productPriceId = value;
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

        /*Section="Field-PriceAmount"*/
        [OTRequired("Price Amount", null)]
        [OTDisplayName("Price Amount")]
        [DataMember]
        public decimal PriceAmount
        {
            get
            {
                return _priceAmount;
            }
            set
            {
                _priceAmount = value;
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

        /*Section="Field-Package"*/
        [UIHint("PricePackageList")]
        [OTRequired("Package", null)]
        [OTDisplayName("Package")]
        [DataMember]
        public long Package
        {
            get
            {
                return _package;
            }
            set
            {
                _package = value;
            }
        }

        /*Section="Field-TopPriceAmount"*/
        [OTDisplayName("Top Price Amount")]
        [DataMember]
        public Nullable<decimal> TopPriceAmount
        {
            get
            {
                return _topPriceAmount;
            }
            set
            {
                _topPriceAmount = value;
            }
        }

        /*Section="Field-PrintTopPriceFlag"*/
        [OTDisplayName("Print Top Price Flag")]
        [DataMember]
        public bool PrintTopPriceFlag
        {
            get
            {
                return _printTopPriceFlag;
            }
            set
            {
                _printTopPriceFlag = value;
            }
        }

        /*Section="Field-PackageVersion"*/
        [UIHint("PackageVersionList")]
        [OTRequired("Package Version", null)]
        [OTDisplayName("Package Version")]
        [DataMember]
        public long PackageVersion
        {
            get
            {
                return _packageVersion;
            }
            set
            {
                _packageVersion = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _productPriceId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [DataMember]
        public string ProductName
        {
            get; set;
        }
        [DataMember]
        public string ProductCodeName
        {
            get; set;
        }
        [DataMember]
        public decimal SaleVATRate
        {
            get; set;
        }
        [DataMember]
        public int Unit
        {
            get; set;
        }
        [DataMember]
        public string Plu1
        {
            get; set;
        }
        [DataMember]
        public string Plu2
        {
            get; set;
        }
        [DataMember]
        public string Plu3
        {
            get; set;
        }
        [DataMember]
        public string ProductFamilyName
        {
            get; set;
        }
        [DataMember]
        public string ProductTypeName
        {
            get; set;
        }
        [DataMember]
        public decimal CurrentPriceAmount
        {
            get; set;
        }
        [DataMember]
        public long StoreId
        {
            get; set;
        }
        [DataMember]
        public string PriceFilePath
        {
            get; set;
        }
        [DataMember]
        public string BrandName
        {
            get; set;
        }
        [DataMember]
        public long CurrentPricePackageVersion
        {
            get; set;
        }
        [DataMember]
        public string ToshibaId
        {
            get; set;
        }
        [DataMember]
        public bool PackageProduct
        {
            get; set;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}