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
    [OTDisplayName("Store Order Detail")]
    [DataContract]
    public class StoreOrderDetail : ViewModelObject
    {
        private long _storeOrderDetailId;
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
        private long _product;
        private decimal _orderQuantity;
        private Nullable<decimal> _revisedQuantity;
        private Nullable<decimal> _shippedQuantity;
        private decimal _orderUnitQuantity;
        private long _storeOrder;
        private Nullable<decimal> _intakeQuantity;
        private Nullable<decimal> _suggestionQuantity;

        /*Section="Field-StoreOrderDetailId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Store Order Detail Id", null)]
        [OTDisplayName("Store Order Detail Id")]
        [DataMember]
        public long StoreOrderDetailId
        {
            get
            {
                return _storeOrderDetailId;
            }
            set
            {
                _storeOrderDetailId = value;
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

        /*Section="Field-OrderQuantity"*/
        [OTRequired("Order Quantity", null)]
        [OTDisplayName("Order Quantity")]
        [DataMember]
        public decimal OrderQuantity
        {
            get
            {
                return _orderQuantity;
            }
            set
            {
                _orderQuantity = value;
            }
        }

        /*Section="Field-RevisedQuantity"*/
        [OTDisplayName("Revised Quantity")]
        [DataMember]
        public Nullable<decimal> RevisedQuantity
        {
            get
            {
                return _revisedQuantity;
            }
            set
            {
                _revisedQuantity = value;
            }
        }

        /*Section="Field-ShippedQuantity"*/
        [OTDisplayName("Shipped Quantity")]
        [DataMember]
        public Nullable<decimal> ShippedQuantity
        {
            get
            {
                return _shippedQuantity;
            }
            set
            {
                _shippedQuantity = value;
            }
        }

        /*Section="Field-OrderUnitQuantity"*/
        [OTRequired("Order Unit Quantity", null)]
        [OTDisplayName("Order Unit Quantity")]
        [DataMember]
        public decimal OrderUnitQuantity
        {
            get
            {
                return _orderUnitQuantity;
            }
            set
            {
                _orderUnitQuantity = value;
            }
        }

        /*Section="Field-StoreOrder"*/
        [UIHint("StoreOrderList")]
        [OTRequired("Store Order", null)]
        [OTDisplayName("Store Order")]
        [DataMember]
        public long StoreOrder
        {
            get
            {
                return _storeOrder;
            }
            set
            {
                _storeOrder = value;
            }
        }

        /*Section="Field-IntakeQuantity"*/
        [OTDisplayName("Intake Quantity")]
        [DataMember]
        public Nullable<decimal> IntakeQuantity
        {
            get
            {
                return _intakeQuantity;
            }
            set
            {
                _intakeQuantity = value;
            }
        }

        /*Section="Field-SuggestionQuantity"*/
        [OTDisplayName("Suggestion Quantity")]
        [DataMember]
        public Nullable<decimal> SuggestionQuantity
        {
            get
            {
                return _suggestionQuantity;
            }
            set
            {
                _suggestionQuantity = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _storeOrderDetailId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public string ProductCode
        {
            get; set;
        }

        [DataMember]
        public string ProductName
        {
            get; set;
        }

        [DataMember]
        public string SubGroupName
        {
            get; set;
        }

        [DataMember]
        public string Category
        {
            get; set;
        }

        [DataMember]    
        public string ScaleCode
        {
            get; set;
        }

        [DataMember]
        public decimal PackageQuantity
        {
            get; set;
        }

        [DataMember]
        public string PackageType
        {
            get; set;
        }

        [DataMember]
        public string Unit
        {
            get; set;
        }

        [DataMember]
        public string LoadOrder
        {
            get; set;
        }

        [DataMember]
        public decimal PriceAmount
        {
            get; set;
        }

        [DataMember]
        public decimal OnWayQuantity
        {
            get; set;
        }

        [DataMember]
        public decimal WeightAmount
        {
            get; set;
        }

        [DataMember]
        public bool ClosetoOrder
        {
            get; set;
        }

        [DataMember]
        public decimal SaleAverage
        {
            get; set;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}