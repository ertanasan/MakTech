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
    [OTDataObject(Module = "Price", ModuleShortName = "PRC", Table = "PRODUCT", HasAutoIdentity = true, DisplayName = "Product Price", IdField = "ProductPriceId")]
    [DataContract]
    public class ProductPrice : DataModelObject
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
        [OTDataField("PRODUCTID")]
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

        /*Section="Field-PriceAmount"*/
        [OTDataField("PRICE_AMT")]
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

        /*Section="Field-Package"*/
        [OTDataField("PACKAGE")]
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
        [OTDataField("TOPPRICE_AMT", Nullable = true)]
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
        [OTDataField("PRINTTOPPRICE_FL")]
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
        [OTDataField("PACKAGEVERSION")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _productPriceId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OTDataField("PRODUCT_NM", IsExtended =true)]
        [DataMember]
        public string ProductName
        {
            get; set;
        }
        [OTDataField("PRODUCTCODE_NM", IsExtended =true)]
        [DataMember]
        public string ProductCodeName
        {
            get; set;
        }
        [OTDataField("SALEVAT_RT", IsExtended = true)]
        [DataMember]
        public decimal SaleVATRate
        {
            get; set;
        }
        [OTDataField("UNIT", IsExtended = true)]
        [DataMember]
        public int Unit
        {
            get; set;
        }
        [OTDataField("PLU1", IsExtended = true)]
        [DataMember]
        public string Plu1
        {
            get; set;
        }
        [OTDataField("PLU2", IsExtended = true)]
        [DataMember]
        public string Plu2
        {
            get; set;
        }
        [OTDataField("PLU3", IsExtended = true)]
        [DataMember]
        public string Plu3
        {
            get; set;
        }
        [OTDataField("CATEGORY_NM", IsExtended = true)]
        [DataMember]
        public string ProductFamilyName
        {
            get; set;
        }
        [OTDataField("SUBGROUP_NM", IsExtended = true)]
        [DataMember]
        public string ProductTypeName
        {
            get; set;
        }
        [OTDataField("CURRENTPRICE_AMT", IsExtended = true)]
        [DataMember]
        public decimal CurrentPriceAmount
        {
            get; set;
        }
        [OTDataField("STORE", IsExtended = true)]
        [DataMember]
        public long StoreId
        {
            get; set;
        }
        [OTDataField("PRICEFILEPATH_TXT", IsExtended = true)]
        [DataMember]
        public string PriceFilePath
        {
            get; set;
        }
        [OTDataField("BRAND_NM", IsExtended = true)]
        [DataMember]
        public string BrandName
        {
            get; set;
        }
        [OTDataField("CURRENTPRICEVERSION", IsExtended = true)]
        [DataMember]
        public long CurrentPricePackageVersion
        {
            get; set;
        }
        [OTDataField("TOSHIBAID", IsExtended = true)]
        [DataMember]
        public string ToshibaId
        {
            get; set;
        }
        [OTDataField("PACKAGEPRODUCT", IsExtended = true)]
        [DataMember]
        public bool PackageProduct
        {
            get; set;
        }
        
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

