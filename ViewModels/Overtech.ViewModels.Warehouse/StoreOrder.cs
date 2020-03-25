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
    [OTDisplayName("Store Order")]
    [DataContract]
    public class StoreOrder : ViewModelObject
    {
        private long _storeOrderId;
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
        private string _orderCode;
        private long _status;
        private DateTime _orderDate;
        private DateTime _shipmentDate;

        /*Section="Field-StoreOrderId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Store Order Id", null)]
        [OTDisplayName("Store Order Id")]
        [DataMember]
        public long StoreOrderId
        {
            get
            {
                return _storeOrderId;
            }
            set
            {
                _storeOrderId = value;
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

        /*Section="Field-OrderCode"*/
        [OTRequired("Order Code", null)]
        [OTStringLength(100)]
        [OTDisplayName("Order Code")]
        [DataMember]
        public string OrderCode
        {
            get
            {
                return _orderCode;
            }
            set
            {
                _orderCode = value;
            }
        }

        /*Section="Field-Status"*/
        [UIHint("StoreOrderStatusList")]
        [OTRequired("Status", null)]
        [OTDisplayName("Status")]
        [DataMember]
        public long Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
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

        /*Section="Field-ShipmentDate"*/
        [OTRequired("Shipment Date", null)]
        [OTDisplayName("Shipment Date")]
        [DataMember]
        public DateTime ShipmentDate
        {
            get
            {
                return _shipmentDate;
            }
            set
            {
                _shipmentDate = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _storeOrderId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public bool ApproveEnabled { get; set; }

        [DataMember]
        public bool EditDetailsEnabled { get; set; }

        [DataMember]
        public bool PrintEnabled { get; set; }

        [DataMember]
        public bool ShipmentEnabled { get; set; }

        [DataMember]
        public string StoreName { get; set; }

        [DataMember]
        public string FirstEntryUser { get; set; }

        [DataMember]
        public DateTime FirstEntryTime { get; set; }

        [DataMember]
        public string LastApproveUser { get; set; }

        [DataMember]
        public DateTime LastApproveTime { get; set; }

        [DataMember]
        public string Controller { get; set; }

        [DataMember]
        public DateTime ControlTime { get; set; }

        [DataMember]
        public string DispatchUser { get; set; }

        [DataMember]
        public DateTime DispatchTime { get; set; }

        [DataMember]
        public int AuthorizationLevel { get; set; }

        [DataMember]
        public decimal OrderValue { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}