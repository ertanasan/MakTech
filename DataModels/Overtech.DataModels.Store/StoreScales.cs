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
namespace Overtech.DataModels.Store
{
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "SCALE", HasAutoIdentity = true, DisplayName = "Store Scales", IdField = "StoreScalesId")]
    [DataContract]
    public class StoreScales : DataModelObject
    {
        private long _storeScalesId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private string _name;
        private long _store;
        private long _scaleModel;
        private string _priceFilePath;
        private Nullable<long> _currentPriceVersion;
        private Nullable<DateTime> _currentPriceLoadTime;
        private Nullable<long> _privatePriceVersion;
        private Nullable<DateTime> _privatePriceLoadTime;
        private bool _createPriceFileFlag;
        private string _ipAdress;
        private bool _status;
        private string _statusText;
        private string _serialNumber;

        /*Section="Field-StoreScalesId"*/
        [OTDataField("SCALEID")]
        [DataMember]
        public long StoreScalesId
        {
            get
            {
                return _storeScalesId;
            }
            set
            {
                _storeScalesId = value;
            }
        }

        /*Section="Field-Organization"*/
        [OTDataField("ORGANIZATION")]
        [ReadOnly(true)]
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

        /*Section="Field-Name"*/
        [OTDataField("SCALE_NM")]
        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
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

        /*Section="Field-ScaleModel"*/
        [OTDataField("SCALEMODEL")]
        [DataMember]
        public long ScaleModel
        {
            get
            {
                return _scaleModel;
            }
            set
            {
                _scaleModel = value;
            }
        }

        /*Section="Field-PriceFilePath"*/
        [OTDataField("PRICEFILEPATH_TXT")]
        [DataMember]
        public string PriceFilePath
        {
            get
            {
                return _priceFilePath;
            }
            set
            {
                _priceFilePath = value;
            }
        }

        /*Section="Field-CurrentPriceVersion"*/
        [OTDataField("CURRENTPRICEVERSION", Nullable = true)]
        [DataMember]
        public Nullable<long> CurrentPriceVersion
        {
            get
            {
                return _currentPriceVersion;
            }
            set
            {
                _currentPriceVersion = value;
            }
        }

        /*Section="Field-CurrentPriceLoadTime"*/
        [OTDataField("CURRENTPRICELOAD_TM", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> CurrentPriceLoadTime
        {
            get
            {
                return _currentPriceLoadTime;
            }
            set
            {
                _currentPriceLoadTime = value;
            }
        }

        /*Section="Field-PrivatePriceVersion"*/
        [OTDataField("PRIVATEPRICEVERSION", Nullable = true)]
        [DataMember]
        public Nullable<long> PrivatePriceVersion
        {
            get
            {
                return _privatePriceVersion;
            }
            set
            {
                _privatePriceVersion = value;
            }
        }

        /*Section="Field-PrivatePriceLoadTime"*/
        [OTDataField("PRIVATEPRICELOAD_TM", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> PrivatePriceLoadTime
        {
            get
            {
                return _privatePriceLoadTime;
            }
            set
            {
                _privatePriceLoadTime = value;
            }
        }

        /*Section="Field-CreatePriceFileFlag"*/
        [OTDataField("CREATEPRICEFILE_FL")]
        [DataMember]
        public bool CreatePriceFileFlag
        {
            get
            {
                return _createPriceFileFlag;
            }
            set
            {
                _createPriceFileFlag = value;
            }
        }

        /*Section="Field-IpAdress"*/
        [OTDataField("IPADDRESS_TXT")]
        [DataMember]
        public string IpAdress
        {
            get
            {
                return _ipAdress;
            }
            set
            {
                _ipAdress = value;
            }
        }

        /*Section="Field-Status"*/
        [OTDataField("STATUS_FL")]
        [DataMember]
        public bool Status
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

        /*Section="Field-StatusText"*/
        [OTDataField("STATUS_TXT")]
        [DataMember]
        public string StatusText
        {
            get
            {
                return _statusText;
            }
            set
            {
                _statusText = value;
            }
        }

        /*Section="Field-StatusText"*/
        [OTDataField("SERIAL_TXT")]
        [DataMember]
        public string SerialNumber
        {
            get
            {
                return _serialNumber;
            }
            set
            {
                _serialNumber = value;
            }
        }

        /*Section="Field-StatusText"*/
        [OTDataField("SEALVALID_DT")]
        [DataMember]
        public DateTime SealValidDate
        {
            get; set;
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _storeScalesId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("MODEL_NM", IsExtended = true)]
        [DataMember]
        public string ModelName
        {
            get; set;
        }
        [OTDataField("SCALEBRANDID", IsExtended = true)]
        [DataMember]
        public string ScaleBrandId
        {
            get; set;
        }
        [OTDataField("BRAND_NM", IsExtended = true)]
        [DataMember]
        public string BrandName
        {
            get; set;
        }
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

