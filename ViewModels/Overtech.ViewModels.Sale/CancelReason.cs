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
namespace Overtech.ViewModels.Sale
{
    [OTDisplayName("Cancel Reason")]
    [DataContract]
    public class CancelReason : ViewModelObject
    {
        private long _cancelReasonId;
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
        private long _storeReconciliation;
        private long _saleDetail;
        private string _reasonText;
        private string _cashierName;

        /*Section="Field-CancelReasonId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Cancel Reason Id", null)]
        [OTDisplayName("Cancel Reason Id")]
        [DataMember]
        public long CancelReasonId
        {
            get
            {
                return _cancelReasonId;
            }
            set
            {
                _cancelReasonId = value;
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

        /*Section="Field-StoreReconciliation"*/
        [UIHint("ReconciliationList")]
        [OTRequired("Store Reconciliation", null)]
        [OTDisplayName("Store Reconciliation")]
        [DataMember]
        public long StoreReconciliation
        {
            get
            {
                return _storeReconciliation;
            }
            set
            {
                _storeReconciliation = value;
            }
        }

        /*Section="Field-SaleDetail"*/
        [UIHint("SaleDetailList")]
        [OTRequired("Sale Detail", null)]
        [OTDisplayName("Sale Detail")]
        [DataMember]
        public long SaleDetail
        {
            get
            {
                return _saleDetail;
            }
            set
            {
                _saleDetail = value;
            }
        }

        /*Section="Field-ReasonText"*/
        [OTRequired("Reason Text", null)]
        [OTDisplayName("Reason Text")]
        [DataMember]
        public string ReasonText
        {
            get
            {
                return _reasonText;
            }
            set
            {
                _reasonText = value;
            }
        }

        /*Section="Field-CashierName"*/
        [OTRequired("Cashier Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Cashier Name")]
        [DataMember]
        public string CashierName
        {
            get
            {
                return _cashierName;
            }
            set
            {
                _cashierName = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _cancelReasonId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public DateTime SaleTransactionTime { get; set; }

        [DataMember]
        public int SaleCashRegister { get; set; }

        [DataMember]
        public string ProductCodeName { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public int Store { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}