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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "STOCKTAKING", HasAutoIdentity = true, DisplayName = "Stock Taking", IdField = "StockTakingId")]
    [DataContract]
    public class StockTaking : DataModelObject
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
        [OTDataField("STOCKTAKINGID")]
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

        /*Section="Field-CountingDate"*/
        [OTDataField("COUNTING_DT")]
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

        /*Section="Field-CountingValue"*/
        [OTDataField("COUNTINGVALUE_AMT", Nullable = true)]
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
        [OTDataField("ZONE")]
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
        [OTDataField("STOCKTAKINGSCHEDULE")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _stockTakingId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("PRODUCTCODE_NM", IsExtended = true)]
        [DataMember]
        public string ProductCode
        {
            get; set;
        }

        [OTDataField("SCALECODE_NM", IsExtended = true)]
        [DataMember]
        public string ScaleCode
        {
            get; set;
        }

        [OTDataField("PRODUCT_NM", IsExtended = true)]
        [DataMember]
        public string ProductName
        {
            get; set;
        }

        [OTDataField("CATEGORY_NM", IsExtended = true)]
        [DataMember]
        public string Category
        {
            get; set;
        }

        [OTDataField("UNIT_NM", IsExtended = true)]
        [DataMember]
        public string Unit
        {
            get; set;
        }

        [OTDataField("INITIALCOUNTINGVALUE_AMT", IsExtended = true)]
        [DataMember]
        public decimal InitialCountingValue
        {
            get; set;
        }

        [OTDataField("UNITPRICE_AMT", IsExtended = true)]
        [DataMember]
        public decimal UnitPrice
        {
            get; set;
        }

        [OTDataField("CURRENTSTOCK", IsExtended = true)]
        [DataMember]
        public decimal CurrentStock
        {
            get; set;
        }

        [OTDataField("STOCKRED", IsExtended = true)]
        [DataMember]
        public Boolean StockRed
        {
            get; set;
        }

        [OTDataField("MAINWH", IsExtended = true)]
        [DataMember]
        public decimal MainWarehouseStock
        {
            get; set;
        }

        [OTDataField("PRODUCTIONWH", IsExtended = true)]
        [DataMember]
        public decimal ProductionWarehouseStock
        {
            get; set;
        }

        [OTDataField("REFUNDWH", IsExtended = true)]
        [DataMember]
        public decimal RefundWarehouseStock
        {
            get; set;
        }

        [OTDataField("GATHERED", IsExtended = true)]
        [DataMember]
        public decimal GatheredStock
        {
            get; set;
        }


        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

