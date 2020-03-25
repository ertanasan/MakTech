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
    [OTDisplayName("Intake Status")]
    [DataContract]
    public class IntakeStatus : ViewModelObject
    {
        private long _intakeStatusId;
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
        private long _storeOrderDetail;
        private long _intakeStatusType;
        private string _description;
        private bool _isTransferred;
        private Nullable<DateTime> _mikroTransferTime;
        private decimal _quantityDifference;

        /*Section="Field-IntakeStatusId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Intake Status Id", null)]
        [OTDisplayName("Intake Status Id")]
        [DataMember]
        public long IntakeStatusId
        {
            get
            {
                return _intakeStatusId;
            }
            set
            {
                _intakeStatusId = value;
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

        /*Section="Field-StoreOrderDetail"*/
        [UIHint("StoreOrderDetailList")]
        [OTRequired("Store Order Detail", null)]
        [OTDisplayName("Store Order Detail")]
        [DataMember]
        public long StoreOrderDetail
        {
            get
            {
                return _storeOrderDetail;
            }
            set
            {
                _storeOrderDetail = value;
            }
        }

        /*Section="Field-IntakeStatusType"*/
        [UIHint("IntakeStatusTypeList")]
        [OTRequired("Intake Status Type", null)]
        [OTDisplayName("Intake Status Type")]
        [DataMember]
        public long IntakeStatusType
        {
            get
            {
                return _intakeStatusType;
            }
            set
            {
                _intakeStatusType = value;
            }
        }

        /*Section="Field-Description"*/
        [OTStringLength(1000)]
        [OTDisplayName("Description")]
        [DataMember]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /*Section="Field-IsTransferred"*/
        [OTRequired("Is Transferred", null)]
        [OTDisplayName("Is Transferred")]
        [DataMember]
        public bool IsTransferred
        {
            get
            {
                return _isTransferred;
            }
            set
            {
                _isTransferred = value;
            }
        }

        /*Section="Field-MikroTransferTime"*/
        [OTDisplayName("Mikro Transfer Time")]
        [DataMember]
        public Nullable<DateTime> MikroTransferTime
        {
            get
            {
                return _mikroTransferTime;
            }
            set
            {
                _mikroTransferTime = value;
            }
        }

        /*Section="Field-QuantityDifference"*/
        [OTRequired("Quantity Difference", null)]
        [OTDisplayName("Quantity Difference")]
        [DataMember]
        public decimal QuantityDifference
        {
            get
            {
                return _quantityDifference;
            }
            set
            {
                _quantityDifference = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _intakeStatusId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [DataMember]
        public string DifferenceType
        {
            get; set;
        }

        [DataMember]
        public string StoreName
        {
            get; set;
        }

        [DataMember]
        public string ProductName
        {
            get; set;
        }

        [DataMember]
        public string UnitName
        {
            get; set;
        }

        [DataMember]
        public DateTime OrderDate
        {
            get; set;
        }

        [DataMember]
        public DateTime MikroShipmentDate
        {
            get; set;
        }

        [DataMember]
        public DateTime IntakeDate
        {
            get; set;
        }

        [DataMember]
        public decimal ShippedQuantity
        {
            get; set;
        }

        [DataMember]
        public decimal IntakeQuantity
        {
            get; set;
        }

        [DataMember]
        public long StoreOrder
        {
            get; set;
        }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}