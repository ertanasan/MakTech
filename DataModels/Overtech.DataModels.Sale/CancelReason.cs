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
namespace Overtech.DataModels.Sale
{
    [OTDataObject(Module = "Sale", ModuleShortName = "SLS", Table = "CANCELREASON", HasAutoIdentity = true, DisplayName = "Cancel Reason", IdField = "CancelReasonId")]
    [DataContract]
    public class CancelReason : DataModelObject
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
        [OTDataField("CANCELREASONID")]
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
        [OTDataField("EVENT")]
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
        [OTDataField("ORGANIZATION")]
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

        /*Section="Field-CreateChannel"*/
        [OTDataField("CREATECHANNEL")]
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
        [OTDataField("CREATEBRANCH")]
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
        [OTDataField("CREATESCREEN")]
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
        [OTDataField("STOREREC")]
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
        [OTDataField("SALEDETAIL")]
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
        [OTDataField("REASON_TXT")]
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
        [OTDataField("CASHIER_NM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _cancelReasonId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("SALETRANSACTION_TM", IsExtended = true)]
        [DataMember]
        public DateTime SaleTransactionTime { get; set; }

        [OTDataField("SALECASHREGISTER", IsExtended = true)]
        [DataMember]
        public int SaleCashRegister { get; set; }

        [OTDataField("PRODUCTCODE_NM", IsExtended = true)]
        [DataMember]
        public string ProductCodeName { get; set; }

        [OTDataField("PRODUCT_NM", IsExtended = true)]
        [DataMember]
        public string ProductName { get; set; }

        [OTDataField("PRICE", IsExtended = true)]
        [DataMember]
        public decimal Price { get; set; }

        [OTDataField("STORE", IsExtended = true)]
        [DataMember]
        public int Store { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

