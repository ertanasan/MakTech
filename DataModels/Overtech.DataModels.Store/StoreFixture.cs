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
namespace Overtech.DataModels.Store
{
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "FIXTURE", HasAutoIdentity = true, DisplayName = "Store Fixture", IdField = "StoreFixtureId", MasterField = "Store")]
    [DataContract]
    public class StoreFixture : DataModelObject
    {
        private long _storeFixtureId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private long _productFixture;
        private Nullable<DateTime> _purchaseDate;
        private string _serialNo;
        private Nullable<DateTime> _endOfGuaranteeDate;
        private Nullable<long> _supplier;
        private long _store;
        private string _fixtureName;
        private Nullable<long> _brand;
        private Nullable<long> _model;
        private Nullable<int> _quantity;

        /*Section="Field-StoreFixtureId"*/
        [OTDataField("FIXTUREID")]
        [DataMember]
        public long StoreFixtureId
        {
            get
            {
                return _storeFixtureId;
            }
            set
            {
                _storeFixtureId = value;
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

        /*Section="Field-ProductFixture"*/
        [OTDataField("FIXTURE")]
        [DataMember]
        public long ProductFixture
        {
            get
            {
                return _productFixture;
            }
            set
            {
                _productFixture = value;
            }
        }

        /*Section="Field-PurchaseDate"*/
        [OTDataField("PURCHASE_DT", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> PurchaseDate
        {
            get
            {
                return _purchaseDate;
            }
            set
            {
                _purchaseDate = value;
            }
        }

        /*Section="Field-SerialNo"*/
        [OTDataField("SERIALNO_TXT")]
        [DataMember]
        public string SerialNo
        {
            get
            {
                return _serialNo;
            }
            set
            {
                _serialNo = value;
            }
        }

        /*Section="Field-EndOfGuaranteeDate"*/
        [OTDataField("ENDOFGUARANTEE_DT", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> EndOfGuaranteeDate
        {
            get
            {
                return _endOfGuaranteeDate;
            }
            set
            {
                _endOfGuaranteeDate = value;
            }
        }

        /*Section="Field-Supplier"*/
        [OTDataField("SUPPLIER", Nullable = true)]
        [DataMember]
        public Nullable<long> Supplier
        {
            get
            {
                return _supplier;
            }
            set
            {
                _supplier = value;
            }
        }

        /*Section="Field-Store"*/
        [OTDataField("STORE")]
        [DataMember]
        public long Store
        {
            get
            {
                return _store;
            }
            set
            {
                _store = value;
            }
        }

        /*Section="Field-FixtureName"*/
        [OTDataField("STOREFIXTURE_NM")]
        [DataMember]
        public string FixtureName
        {
            get
            {
                return _fixtureName;
            }
            set
            {
                _fixtureName = value;
            }
        }

        /*Section="Field-Brand"*/
        [OTDataField("BRAND", Nullable = true)]
        [DataMember]
        public Nullable<long> Brand
        {
            get
            {
                return _brand;
            }
            set
            {
                _brand = value;
            }
        }

        /*Section="Field-Model"*/
        [OTDataField("MODEL", Nullable = true)]
        [DataMember]
        public Nullable<long> Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
            }
        }

        /*Section="Field-Quantity"*/
        [OTDataField("QUANTITY_QTY", Nullable = true)]
        [DataMember]
        public Nullable<int> Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _storeFixtureId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

