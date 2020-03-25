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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "CONSIGNMENTGOODPURCHASE", HasAutoIdentity = true, DisplayName = "Consignment Good Purchase", IdField = "ConsignmentGoodPurchaseId")]
    [DataContract]
    public class ConsignmentGoodPurchase : DataModelObject
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
        [OTDataField("CONSIGNMENTGOODPURCHASEID")]
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

        /*Section="Field-Product"*/
        [OTDataField("PRODUCT")]
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
        [OTDataField("SUPPLIER")]
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
        [OTDataField("QUANTITY_QTY")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _consignmentGoodPurchaseId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OTDataField("UNITNAME", IsExtended = true)]
        [DataMember]
        public string UnitName
        {
            get; set;
        }

        [OTDataField("TRANSACTIONTYPE", IsExtended = true)]
        [DataMember]
        public string TransactionType
        {
            get; set;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

