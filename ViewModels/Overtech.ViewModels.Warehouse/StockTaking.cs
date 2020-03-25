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
    [OTDisplayName("Stock Taking")]
    [DataContract]
    public class StockTaking : ViewModelObject
    {
        private long _stockTakingId;
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
        private DateTime _countingDate;
        private long _product;
        private Nullable<decimal> _countingValue;
        private long _zone;
        private long _stockTakingSchedule;

        /*Section="Field-StockTakingId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Stock Taking Id", null)]
        [OTDisplayName("Stock Taking Id")]
        [DataMember]
        public long StockTakingId
        {
            get
            {
                return _stockTakingId;
            }
            set
            {
                _stockTakingId = value;
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

        /*Section="Field-CountingDate"*/
        [OTRequired("Counting Date", null)]
        [OTDisplayName("Counting Date")]
        [DataMember]
        public DateTime CountingDate
        {
            get
            {
                return _countingDate;
            }
            set
            {
                _countingDate = value;
            }
        }

        /*Section="Field-Product"*/
        [UIHint("ProductList")]
        [OTRequired("Product", null)]
        [OTDisplayName("Product")]
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

        /*Section="Field-CountingValue"*/
        [OTDisplayName("Counting Value")]
        [DataMember]
        public Nullable<decimal> CountingValue
        {
            get
            {
                return _countingValue;
            }
            set
            {
                _countingValue = value;
            }
        }

        /*Section="Field-Zone"*/
        [UIHint("StorageZonesList")]
        [OTRequired("Zone", null)]
        [OTDisplayName("Zone")]
        [DataMember]
        public long Zone
        {
            get
            {
                return _zone;
            }
            set
            {
                _zone = value;
            }
        }

        /*Section="Field-StockTakingSchedule"*/
        [UIHint("StockTakingScheduleList")]
        [OTRequired("Stock Taking Schedule", null)]
        [OTDisplayName("Stock Taking Schedule")]
        [DataMember]
        public long StockTakingSchedule
        {
            get
            {
                return _stockTakingSchedule;
            }
            set
            {
                _stockTakingSchedule = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _stockTakingId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public string ProductCode
        {
            get; set;
        }

        [DataMember]
        public string ScaleCode
        {
            get; set;
        }

        [DataMember]
        public string ProductName
        {
            get; set;
        }

        [DataMember]
        public string Category
        {
            get; set;
        }

        [DataMember]
        public string Unit
        {
            get; set;
        }

        [DataMember]
        public decimal InitialCountingValue
        {
            get; set;
        }

        [DataMember]
        public decimal UnitPrice
        {
            get; set;
        }

        [DataMember]
        public decimal CurrentStock
        {
            get; set;
        }

        [DataMember]
        public Boolean StockRed
        {
            get; set;
        }

        [DataMember]
        public decimal MainWarehouseStock
        {
            get; set;
        }

        [DataMember]
        public decimal ProductionWarehouseStock
        {
            get; set;
        }

        [DataMember]
        public decimal RefundWarehouseStock
        {
            get; set;
        }

        [DataMember]
        public decimal GatheredStock
        {
            get; set;
        }


        #endregion Customized

        /*Section="ClassFooter"*/
    }
}