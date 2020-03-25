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
    [OTDisplayName("Material Order")]
    [DataContract]
    public class MaterialOrder : ViewModelObject
    {
        private long _materialOrderId;
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
        private string _orderName;
        private DateTime _orderDate;
        private int _orderStatusCode;
        private long _store;
        private Nullable<long> _processInstanceNumber;
        private Nullable<int> _mikroStatusCode;
        private string _mikroReference;
        private Nullable<DateTime> _mikroTime;
        private Nullable<long> _mikroUser;
        private long _material;
        private Nullable<long> _materialInfo;
        private decimal _orderQuantity;
        private decimal _revisedQuantity;
        private decimal _shippedQuantity;
        private decimal _intakeQuantity;
        private string _note;

        /*Section="Field-MaterialOrderId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Material Order Id", null)]
        [OTDisplayName("Material Order Id")]
        [DataMember]
        public long MaterialOrderId
        {
            get
            {
                return _materialOrderId;
            }
            set
            {
                _materialOrderId = value;
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

        /*Section="Field-OrderName"*/
        [OTRequired("Order Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Order Name")]
        [DataMember]
        public string OrderName
        {
            get
            {
                return _orderName;
            }
            set
            {
                _orderName = value;
            }
        }

        /*Section="Field-OrderDate"*/
        [OTRequired("Order Date", null)]
        [OTDisplayName("Order Date")]
        [DataMember]
        public DateTime OrderDate
        {
            get
            {
                return _orderDate;
            }
            set
            {
                _orderDate = value;
            }
        }

        /*Section="Field-OrderStatusCode"*/
        [OTRequired("Order Status Code", null)]
        [OTDisplayName("Order Status Code")]
        [DataMember]
        public int OrderStatusCode
        {
            get
            {
                return _orderStatusCode;
            }
            set
            {
                _orderStatusCode = value;
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

        /*Section="Field-ProcessInstanceNumber"*/
        [OTDisplayName("Process Instance Number")]
        [DataMember]
        public Nullable<long> ProcessInstanceNumber
        {
            get
            {
                return _processInstanceNumber;
            }
            set
            {
                _processInstanceNumber = value;
            }
        }

        /*Section="Field-MikroStatusCode"*/
        [OTDisplayName("Mikro Status Code")]
        [DataMember]
        public Nullable<int> MikroStatusCode
        {
            get
            {
                return _mikroStatusCode;
            }
            set
            {
                _mikroStatusCode = value;
            }
        }

        /*Section="Field-MikroReference"*/
        [OTDisplayName("Mikro Reference")]
        [DataMember]
        public string MikroReference
        {
            get
            {
                return _mikroReference;
            }
            set
            {
                _mikroReference = value;
            }
        }

        /*Section="Field-MikroTime"*/
        [OTDisplayName("Mikro Time")]
        [DataMember]
        public Nullable<DateTime> MikroTime
        {
            get
            {
                return _mikroTime;
            }
            set
            {
                _mikroTime = value;
            }
        }

        /*Section="Field-MikroUser"*/
        [UIHint("UserList")]
        [OTDisplayName("Mikro User")]
        [DataMember]
        public Nullable<long> MikroUser
        {
            get
            {
                return _mikroUser;
            }
            set
            {
                _mikroUser = value;
            }
        }

        /*Section="Field-Material"*/
        [UIHint("MaterialList")]
        [OTRequired("Material", null)]
        [OTDisplayName("Material")]
        [DataMember]
        public long Material
        {
            get
            {
                return _material;
            }
            set
            {
                _material = value;
            }
        }

        /*Section="Field-MaterialInfo"*/
        [UIHint("MaterialInfoList")]
        [OTDisplayName("MaterialInfo")]
        [DataMember]
        public Nullable<long> MaterialInfo
        {
            get
            {
                return _materialInfo;
            }
            set
            {
                _materialInfo = value;
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
        [OTRequired("Revised Quantity", null)]
        [OTDisplayName("Revised Quantity")]
        [DataMember]
        public decimal RevisedQuantity
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
        [OTRequired("Shipped Quantity", null)]
        [OTDisplayName("Shipped Quantity")]
        [DataMember]
        public decimal ShippedQuantity
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

        /*Section="Field-IntakeQuantity"*/
        [OTRequired("Intake Quantity", null)]
        [OTDisplayName("Intake Quantity")]
        [DataMember]
        public decimal IntakeQuantity
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

        /*Section="Field-Note"*/
        [OTRequired("Note", null)]
        [OTDisplayName("Note")]
        [DataMember]
        public string Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _materialOrderId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}