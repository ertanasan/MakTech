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
namespace Overtech.ViewModels.Store
{
    [OTDisplayName("Store Fixture")]
    [DataContract]
    public class StoreFixture : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Store Fixture Id", null)]
        [OTDisplayName("Store Fixture Id")]
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

        /*Section="Field-ProductFixture"*/
        [UIHint("FixtureList")]
        [OTRequired("Product Fixture", null)]
        [OTDisplayName("Product Fixture")]
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
        [OTDisplayName("Purchase Date")]
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
        [OTDisplayName("Serial No")]
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
        [OTDisplayName("End Of Guarantee Date")]
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
        [UIHint("SupplierList")]
        [OTDisplayName("Supplier")]
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
        [UIHint("StoreList")]
        [OTRequired("Store", null)]
        [OTDisplayName("Store")]
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
        [OTStringLength(100)]
        [OTDisplayName("Fixture Name")]
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
        [UIHint("FixtureBrandList")]
        [OTDisplayName("Brand")]
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
        [UIHint("FixtureModelList")]
        [OTDisplayName("Model")]
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
        [OTDisplayName("Quantity")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _storeFixtureId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}