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
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "PRODUCT", HasAutoIdentity = false, DisplayName = "Product", IdField = "ProductId")]
    [DataContract]
    public class Product : DataModelObject
    {
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
        [OTDataField("PRODUCTID")]
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

        /*Section="Field-Code"*/
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

        /*Section="Field-Name"*/
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

        /*Section="Field-PurchaseVAT"*/
        [OTDataField("PURCHASEVAT_RT", Nullable = true)]
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

        /*Section="Field-Subgroup"*/
        [OTDataField("SUBGROUP", Nullable = true)]
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
        [OTDataField("SUPERGROUP1", Nullable = true)]
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
        [OTDataField("SUPERGROUP2", Nullable = true)]
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
        [OTDataField("SUPERGROUP3", Nullable = true)]
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
        [OTDataField("UNIT")]
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
        [OTDataField("BARCODETYPE", Nullable = true)]
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
        [OTDataField("SEASONTYPE", Nullable = true)]
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
        [OTDataField("OLDCODE_NM")]
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

        /*Section="Field-eTrade"*/
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

        /*Section="Field-GTIPCode"*/
        [OTDataField("GTIPCODE_TXT")]
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
        [OTDataField("PHOTO_IMG")]
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

        /*Section="Field-Domestic"*/
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

        /*Section="Field-Country"*/
        [OTDataField("COUNTRY", Nullable = true)]
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

        /*Section="Field-Warning"*/
        [OTDataField("WARNING", Nullable = true)]
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
        [OTDataField("STORAGECONDITION", Nullable = true)]
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
        [OTDataField("EXPIRESIN_CNT", Nullable = true)]
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
        [OTDataField("SHELFLIFE_CNT", Nullable = true)]
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
        [OTDataField("COMMENT_DSC")]
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
        [OTDataField("CAMPAIGN", Nullable = true)]
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
        [OTDataField("WEIGHT_AMT", Nullable = true)]
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
        [OTDataField("WEIGHTUNIT", Nullable = true)]
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
        [OTDataField("ACTIVE_FL")]
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
        [OTDataField("LOADORDER_TXT")]
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
        [OTDataField("PARENT", Nullable = true)]
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
        [OTDataField("INITIALPRICE_AMT", Nullable = true)]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _productId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("SEARCHSTRING", IsExtended = true)]
        [DataMember]
        public string SearchString { get; set; }

        [OTDataField("PACKAGE_QTY", IsExtended = true)]
        [DataMember]
        public decimal PackageQuantity { get; set; }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

