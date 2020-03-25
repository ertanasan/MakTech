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
    [OTDisplayName("Product")]
    [DataContract]
    public class Product : ViewModelObject
    {
        /*Section="Constructor"*/
        public Product()
        {
            this.ImageReference = Guid.NewGuid().ToString();
        }

        public string ImageReference { get; set; }

        private long _productId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private string _code;
        private string _name;
        private Nullable<decimal> _purchaseVAT;
        private decimal _saleVAT;
        private Nullable<long> _subgroup;
        private Nullable<long> _superGroup1;
        private Nullable<long> _superGroup2;
        private Nullable<long> _superGroup3;
        private long _unit;
        private Nullable<long> _barcodeType;
        private Nullable<long> _seasonType;
        private string _oldCode;
        private bool _privateLabel;
        private bool _eTrade;
        private string _gtipCode;
        private byte[] _photo;
        private string _shortName;
        private bool _domestic;
        private Nullable<long> _country;
        private string _content;
        private Nullable<long> _warning;
        private Nullable<long> _storageCondition;
        private Nullable<int> _expiresIn;
        private Nullable<int> _shelfLife;
        private string _comment;
        private Nullable<long> _campaign;
        private Nullable<decimal> _weight;
        private Nullable<long> _weightUnit;
        private bool _active;
        private string _loadOrder;
        private Nullable<long> _parent;
        private Nullable<decimal> _initialPrice;

        /*Section="Field-ProductId"*/
        [OTRequired("Product Id", null)]
        [OTDisplayName("Product Id")]
        [DataMember]
        public long ProductId
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

        /*Section="Field-Code"*/
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

        /*Section="Field-Name"*/
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

        /*Section="Field-PurchaseVAT"*/
        [OTDisplayName("Purchase VAT")]
        [DataMember]
        public Nullable<decimal> PurchaseVAT
        {
            get
            {
                return _purchaseVAT;
            }
            set
            {
                _purchaseVAT = value;
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

        /*Section="Field-Subgroup"*/
        [UIHint("SubgroupList")]
        [OTDisplayName("Subgroup")]
        [DataMember]
        public Nullable<long> Subgroup
        {
            get
            {
                return _subgroup;
            }
            set
            {
                _subgroup = value;
            }
        }

        /*Section="Field-SuperGroup1"*/
        [UIHint("SuperGroup1List")]
        [OTDisplayName("Super Group 1")]
        [DataMember]
        public Nullable<long> SuperGroup1
        {
            get
            {
                return _superGroup1;
            }
            set
            {
                _superGroup1 = value;
            }
        }

        /*Section="Field-SuperGroup2"*/
        [UIHint("SuperGroup2List")]
        [OTDisplayName("Super Group 2")]
        [DataMember]
        public Nullable<long> SuperGroup2
        {
            get
            {
                return _superGroup2;
            }
            set
            {
                _superGroup2 = value;
            }
        }

        /*Section="Field-SuperGroup3"*/
        [UIHint("SuperGroup3List")]
        [OTDisplayName("Super Group 3")]
        [DataMember]
        public Nullable<long> SuperGroup3
        {
            get
            {
                return _superGroup3;
            }
            set
            {
                _superGroup3 = value;
            }
        }

        /*Section="Field-Unit"*/
        [UIHint("UnitList")]
        [OTRequired("Unit", null)]
        [OTDisplayName("Unit")]
        [DataMember]
        public long Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
            }
        }

        /*Section="Field-BarcodeType"*/
        [UIHint("BarcodeTypeIntList")]
        [OTDisplayName("Barcode Type")]
        [DataMember]
        public Nullable<long> BarcodeType
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

        /*Section="Field-SeasonType"*/
        [UIHint("SeasonTypeList")]
        [OTDisplayName("Season Type")]
        [DataMember]
        public Nullable<long> SeasonType
        {
            get
            {
                return _seasonType;
            }
            set
            {
                _seasonType = value;
            }
        }

        /*Section="Field-OldCode"*/
        [OTStringLength(100)]
        [OTDisplayName("Old Code")]
        [DataMember]
        public string OldCode
        {
            get
            {
                return _oldCode;
            }
            set
            {
                _oldCode = value;
            }
        }

        /*Section="Field-PrivateLabel"*/
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

        /*Section="Field-eTrade"*/
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

        /*Section="Field-GTIPCode"*/
        [OTDisplayName("GTIP Code")]
        [DataMember]
        public string GTIPCode
        {
            get
            {
                return _gtipCode;
            }
            set
            {
                _gtipCode = value;
            }
        }

        /*Section="Field-Photo"*/
        [OTDisplayName("Photo")]
        [DataMember]
        public byte[] Photo
        {
            get
            {
                return _photo;
            }
            set
            {
                _photo = value;
            }
        }

        /*Section="Field-ShortName"*/
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

        /*Section="Field-Domestic"*/
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

        /*Section="Field-Country"*/
        [UIHint("CountryList")]
        [OTDisplayName("Country")]
        [DataMember]
        public Nullable<long> Country
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

        /*Section="Field-Content"*/
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

        /*Section="Field-Warning"*/
        [UIHint("WarningList")]
        [OTDisplayName("Warning")]
        [DataMember]
        public Nullable<long> Warning
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

        /*Section="Field-StorageCondition"*/
        [UIHint("StorageConditionList")]
        [OTDisplayName("Storage Condition")]
        [DataMember]
        public Nullable<long> StorageCondition
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
        [OTDisplayName("Expires In")]
        [DataMember]
        public Nullable<int> ExpiresIn
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

        /*Section="Field-ShelfLife"*/
        [OTDisplayName("Shelf Life")]
        [DataMember]
        public Nullable<int> ShelfLife
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

        /*Section="Field-Comment"*/
        [OTStringLength(1000)]
        [OTDisplayName("Comment")]
        [DataMember]
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
            }
        }

        /*Section="Field-Campaign"*/
        [UIHint("ProductCampaignList")]
        [OTDisplayName("Campaign")]
        [DataMember]
        public Nullable<long> Campaign
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

        /*Section="Field-Weight"*/
        [OTDisplayName("Weight")]
        [DataMember]
        public Nullable<decimal> Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }

        /*Section="Field-WeightUnit"*/
        [UIHint("UnitList")]
        [OTDisplayName("Weight Unit")]
        [DataMember]
        public Nullable<long> WeightUnit
        {
            get
            {
                return _weightUnit;
            }
            set
            {
                _weightUnit = value;
            }
        }

        /*Section="Field-Active"*/
        [OTDisplayName("Active")]
        [DataMember]
        public bool Active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
        }

        /*Section="Field-LoadOrder"*/
        [OTDisplayName("Load Order")]
        [DataMember]
        public string LoadOrder
        {
            get
            {
                return _loadOrder;
            }
            set
            {
                _loadOrder = value;
            }
        }

        /*Section="Field-Parent"*/
        [UIHint("ProductList")]
        [OTDisplayName("Parent")]
        [DataMember]
        public Nullable<long> Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        /*Section="Field-InitialPrice"*/
        [OTDisplayName("Initial Price")]
        [DataMember]
        public Nullable<decimal> InitialPrice
        {
            get
            {
                return _initialPrice;
            }
            set
            {
                _initialPrice = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _productId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public string SearchString { get; set; }

        [DataMember]
        public decimal PackageQuantity { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}