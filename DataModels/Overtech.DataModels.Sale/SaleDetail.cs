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
    [OTDataObject(Module = "Sale", ModuleShortName = "SLS", Table = "SALEDETAIL", HasAutoIdentity = true, DisplayName = "Sale Detail", IdField = "SaleDetailId")]
    [DataContract]
    public class SaleDetail : DataModelObject
    {
        private long _saleDetailId;
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
        private long _saleID;
        private string _transactionID;
        private DateTime _transactionDate;
        private string _barcode;
        private long _productID;
        private string _productCode;
        private long _store;
        private decimal _price;
        private decimal _vatRate;
        private int _quantity;
        private long _unit;
        private bool _cancelFlag;
        private decimal _unitPrice;

        /*Section="Field-SaleDetailId"*/
        [OTDataField("SALEDETAILID")]
        [DataMember]
        public long SaleDetailId
        {
            get
            {
                return _saleDetailId;
            }
            set
            {
                _saleDetailId = value;
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

        /*Section="Field-SaleID"*/
        [OTDataField("SALE")]
        [DataMember]
        public long SaleID
        {
            get
            {
                return _saleID;
            }
            set
            {
                _saleID = value;
            }
        }

        /*Section="Field-TransactionID"*/
        [OTDataField("TRANSACTION_TXT")]
        [DataMember]
        public string TransactionID
        {
            get
            {
                return _transactionID;
            }
            set
            {
                _transactionID = value;
            }
        }

        /*Section="Field-TransactionDate"*/
        [OTDataField("TRANSACTION_DT")]
        [DataMember]
        public DateTime TransactionDate
        {
            get
            {
                return _transactionDate;
            }
            set
            {
                _transactionDate = value;
            }
        }

        /*Section="Field-Barcode"*/
        [OTDataField("BARCODE_TXT")]
        [DataMember]
        public string Barcode
        {
            get
            {
                return _barcode;
            }
            set
            {
                _barcode = value;
            }
        }

        /*Section="Field-ProductID"*/
        [OTDataField("PRODUCT")]
        [DataMember]
        public long ProductID
        {
            get
            {
                return _productID;
            }
            set
            {
                _productID = value;
            }
        }

        /*Section="Field-ProductCode"*/
        [OTDataField("PRODUCTCODE_NM")]
        [DataMember]
        public string ProductCode
        {
            get
            {
                return _productCode;
            }
            set
            {
                _productCode = value;
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

        /*Section="Field-Price"*/
        [OTDataField("PRICE")]
        [DataMember]
        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        /*Section="Field-VATRate"*/
        [OTDataField("VAT_RT")]
        [DataMember]
        public decimal VATRate
        {
            get
            {
                return _vatRate;
            }
            set
            {
                _vatRate = value;
            }
        }

        /*Section="Field-Quantity"*/
        [OTDataField("QUANTITY_QTY")]
        [DataMember]
        public int Quantity
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

        /*Section="Field-Unit"*/
        [OTDataField("UNIT")]
        [DataMember]
        public long Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
            }
        }

        /*Section="Field-CancelFlag"*/
        [OTDataField("CANCEL_FL")]
        [DataMember]
        public bool CancelFlag
        {
            get
            {
                return _cancelFlag;
            }
            set
            {
                _cancelFlag = value;
            }
        }

        /*Section="Field-UnitPrice"*/
        [OTDataField("UNITPRICE_AMT")]
        [DataMember]
        public decimal UnitPrice
        {
            get
            {
                return _unitPrice;
            }
            set
            {
                _unitPrice = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _saleDetailId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("PRODUCT_NM", IsExtended = true)]
        [DataMember]
        public string ProductName { get; set; }

        [OTDataField("KG_QTY", IsExtended = true)]
        [DataMember]
        public decimal KgQuantity { get; set; }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

