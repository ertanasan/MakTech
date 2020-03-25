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
namespace Overtech.DataModels.Price
{
    [OTDataObject(Module = "Price", ModuleShortName = "PRC", Table = "PRICECHANGE", HasAutoIdentity = true, DisplayName = "Price Change History", IdField = "PriceChangeHistoryId")]
    [DataContract]
    public class PriceChangeHistory : DataModelObject
    {
        private long _priceChangeHistoryId;
        private long _organization;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _store;
        private string _productCodeName;
        private string _productName;
        private string _operationCode;
        private Nullable<decimal> _oldPriceAmount;
        private Nullable<decimal> _newPriceAmount;
        private int _statusCode;

        /*Section="Field-PriceChangeHistoryId"*/
        [OTDataField("PRICECHANGEID")]
        [DataMember]
        public long PriceChangeHistoryId
        {
            get
            {
                return _priceChangeHistoryId;
            }
            set
            {
                _priceChangeHistoryId = value;
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

        /*Section="Field-ProductCodeName"*/
        [OTDataField("PRODUCTCODE_NM")]
        [DataMember]
        public string ProductCodeName
        {
            get
            {
                return _productCodeName;
            }
            set
            {
                _productCodeName = value;
            }
        }

        /*Section="Field-ProductName"*/
        [OTDataField("PRODUCTNAME_NM")]
        [DataMember]
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
            }
        }

        /*Section="Field-OperationCode"*/
        [OTDataField("OPERATION_TXT")]
        [DataMember]
        public string OperationCode
        {
            get
            {
                return _operationCode;
            }
            set
            {
                _operationCode = value;
            }
        }

        /*Section="Field-OldPriceAmount"*/
        [OTDataField("OLDPRICE_AMT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> OldPriceAmount
        {
            get
            {
                return _oldPriceAmount;
            }
            set
            {
                _oldPriceAmount = value;
            }
        }

        /*Section="Field-NewPriceAmount"*/
        [OTDataField("NEWPRICE_AMT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> NewPriceAmount
        {
            get
            {
                return _newPriceAmount;
            }
            set
            {
                _newPriceAmount = value;
            }
        }

        /*Section="Field-StatusCode"*/
        [OTDataField("STATUS_CD")]
        [DataMember]
        public int StatusCode
        {
            get
            {
                return _statusCode;
            }
            set
            {
                _statusCode = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _priceChangeHistoryId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

