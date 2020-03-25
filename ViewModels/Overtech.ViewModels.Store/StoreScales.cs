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
namespace Overtech.ViewModels.Store
{
    [OTDisplayName("Store Scales")]
    [DataContract]
    public class StoreScales : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Store Scales Id", null)]
        [OTDisplayName("Store Scales Id")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Organization")]
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

        /*Section="Field-Name"*/
        [OTRequired("Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Name")]
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

        /*Section="Field-ScaleModel"*/
        [UIHint("ScaleModelList")]
        [OTRequired("Scale Model", null)]
        [OTDisplayName("Scale Model")]
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
        [OTDisplayName("Price File Path")]
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
        [UIHint("PackageVersionList")]
        [OTDisplayName("Current Price Version")]
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
        [OTDisplayName("Current Price Load Time")]
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
        [UIHint("PackageVersionList")]
        [OTDisplayName("Private Price Version")]
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
        [OTDisplayName("Private Price Load Time")]
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
        [OTDisplayName("Create Price File Flag")]
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
        [OTDisplayName("IpAdress")]
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
        [OTDisplayName("Status")]
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
        [OTDisplayName("Status Text")]
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
        [OTDisplayName("Serial Number")]
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
        [OTDisplayName("Seal Valid Date")]
        [DataMember]
        public DateTime SealValidDate
        {
            get; set;
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _storeScalesId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public string ModelName
        {
            get; set;
        }
        [DataMember]
        public string ScaleBrandId
        {
            get; set;
        }
        [DataMember]
        public string BrandName
        {
            get; set;
        }
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}