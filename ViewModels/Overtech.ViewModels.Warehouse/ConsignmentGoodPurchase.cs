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
namespace Overtech.ViewModels.Warehouse
{
    [OTDisplayName("Consignment Good Purchase")]
    [DataContract]
    public class ConsignmentGoodPurchase : ViewModelObject
    {
        private long _consignmentGoodPurchaseId;
        private long _event;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private long _createChannel;
        private long _createBranch;
        private long _createScreen;
        private long _store;
        private long _product;
        private long _supplier;
        private decimal _quantity;

        /*Section="Field-ConsignmentGoodPurchaseId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Consignment Good Purchase Id", null)]
        [OTDisplayName("Consignment Good Purchase Id")]
        [DataMember]
        public long ConsignmentGoodPurchaseId
        {
            get
            {
                return _consignmentGoodPurchaseId;
            }
            set
            {
                _consignmentGoodPurchaseId = value;
            }
        }

        /*Section="Field-Event"*/
        [ScaffoldColumn(false)]
        [OTRequired("Event", null)]
        [OTDisplayName("Event")]
        [DataMember]
        public long Event
        {
            get
            {
                return _event;
            }
            set
            {
                _event = value;
            }
        }

        /*Section="Field-Organization"*/
        [ScaffoldColumn(false)]
        [OTRequired("Organization", null)]
        [OTDisplayName("Organization")]
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

        /*Section="Field-CreateChannel"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Channel")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateChannel
        {
            get
            {
                return _createChannel;
            }
            set
            {
                _createChannel = value;
            }
        }

        /*Section="Field-CreateBranch"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Branch")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateBranch
        {
            get
            {
                return _createBranch;
            }
            set
            {
                _createBranch = value;
            }
        }

        /*Section="Field-CreateScreen"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Screen")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateScreen
        {
            get
            {
                return _createScreen;
            }
            set
            {
                _createScreen = value;
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

        /*Section="Field-Supplier"*/
        [UIHint("SupplierList")]
        [OTRequired("Supplier", null)]
        [OTDisplayName("Supplier")]
        [DataMember]
        public long Supplier
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

        /*Section="Field-Quantity"*/
        [OTRequired("Quantity", null)]
        [OTDisplayName("Quantity")]
        [DataMember]
        public decimal Quantity
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
            return _consignmentGoodPurchaseId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [DataMember]
        public string UnitName
        {
            get; set;
        }

        [DataMember]
        public string TransactionType
        {
            get; set;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}