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
namespace Overtech.DataModels.Warehouse
{
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "STOREORDER", HasAutoIdentity = true, DisplayName = "Store Order", IdField = "StoreOrderId")]
    [DataContract]
    public class StoreOrder : DataModelObject
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
        [OTDataField("STOREORDERID")]
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

        /*Section="Field-OrderCode"*/
        [OTDataField("ORDERCODE_NM")]
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
        [OTDataField("STATUS")]
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
        [OTDataField("ORDER_DT")]
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
        [OTDataField("SHIPMENT_DT")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _storeOrderId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("APPROVEENABLED_FL", IsExtended = true)]
        [DataMember]
        public bool ApproveEnabled { get; set; }

        [OTDataField("EDITDETAILSENABLED_FL", IsExtended = true)]
        [DataMember]
        public bool EditDetailsEnabled { get; set; }

        [OTDataField("PRINTENABLED_FL", IsExtended = true)]
        [DataMember]
        public bool PrintEnabled { get; set; }

        [OTDataField("SHIPMENTENABLED_FL", IsExtended = true)]
        [DataMember]
        public bool ShipmentEnabled { get; set; }

        [OTDataField("STORE_NM", IsExtended = true)]
        [DataMember]
        public string StoreName { get; set; }

        [OTDataField("FIRSTENTRYUSER", IsExtended = true)]
        [DataMember]
        public string FirstEntryUser { get; set; }

        [OTDataField("FIRSTENTRYTIME", IsExtended = true)]
        [DataMember]
        public DateTime FirstEntryTime { get; set; }

        [OTDataField("LASTAPPROVEUSER", IsExtended = true)]
        [DataMember]
        public string LastApproveUser { get; set; }

        [OTDataField("LASTAPPROVETIME", IsExtended = true)]
        [DataMember]
        public DateTime LastApproveTime { get; set; }

        [OTDataField("CONTROLUSER", IsExtended = true)]
        [DataMember]
        public string Controller { get; set; }

        [OTDataField("CONTROLTIME", IsExtended = true)]
        [DataMember]
        public DateTime ControlTime { get; set; }

        [OTDataField("DISPATCHUSER", IsExtended = true)]
        [DataMember]
        public string DispatchUser { get; set; }

        [OTDataField("DISPATCHTIME", IsExtended = true)]
        [DataMember]
        public DateTime DispatchTime { get; set; }

        [OTDataField("AUTHLEVEL_CD", IsExtended = true)]
        [DataMember]
        public int AuthorizationLevel { get; set; }

        [OTDataField("ORDERVALUE_AMT", IsExtended = true)]
        [DataMember]
        public decimal OrderValue { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

