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
    [OTDisplayName("Material Order Detail")]
    [DataContract]
    public class MaterialOrderDetail : ViewModelObject
    {
        private long _materialOrderDetailId;
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
        private long _materialOrder;
        private long _material;
        private decimal _orderQuantity;
        private decimal _revisedQuantity;
        private decimal _shippedQuantity;
        private decimal _intakeQuantity;
        private string _note;

        /*Section="Field-MaterialOrderDetailId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Material Order Detail Id", null)]
        [OTDisplayName("Material Order Detail Id")]
        [DataMember]
        public long MaterialOrderDetailId
        {
            get
            {
                return _materialOrderDetailId;
            }
            set
            {
                _materialOrderDetailId = value;
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

        /*Section="Field-MaterialOrder"*/
        [UIHint("MaterialOrderList")]
        [OTRequired("Material Order", null)]
        [OTDisplayName("Material Order")]
        [DataMember]
        public long MaterialOrder
        {
            get
            {
                return _materialOrder;
            }
            set
            {
                _materialOrder = value;
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
            return _materialOrderDetailId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}