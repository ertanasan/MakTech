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
    [OTDisplayName("Sale Detail")]
    [DataContract]
    public class SaleDetail : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Sale Detail Id", null)]
        [OTDisplayName("Sale Detail Id")]
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

        /*Section="Field-SaleID"*/
        [UIHint("SalesList")]
        [OTRequired("Sale ID", null)]
        [OTDisplayName("Sale ID")]
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
        [OTRequired("Transaction ID", null)]
        [OTDisplayName("Transaction ID")]
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
        [OTRequired("Transaction Date", null)]
        [OTDisplayName("Transaction Date")]
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
        [OTRequired("Barcode", null)]
        [OTDisplayName("Barcode")]
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
        [UIHint("ProductList")]
        [OTRequired("Product ID", null)]
        [OTDisplayName("Product ID")]
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
        [OTRequired("Product Code", null)]
        [OTStringLength(100)]
        [OTDisplayName("Product Code")]
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

        /*Section="Field-Price"*/
        [OTRequired("Price", null)]
        [OTDisplayName("Price")]
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
        [OTRequired("VAT Rate", null)]
        [OTDisplayName("VAT Rate")]
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
        [OTRequired("Quantity", null)]
        [OTDisplayName("Quantity")]
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
        [UIHint("UnitList")]
        [OTRequired("Unit", null)]
        [OTDisplayName("Unit")]
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
        [OTRequired("Cancel Flag", null)]
        [OTDisplayName("Cancel Flag")]
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
        [OTRequired("Unit Price", null)]
        [OTDisplayName("Unit Price")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _saleDetailId;
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