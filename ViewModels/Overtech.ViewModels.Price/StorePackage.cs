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
namespace Overtech.ViewModels.Price
{
    [OTDisplayName("Store Package")]
    [DataContract]
    public class StorePackage : ViewModelObject
    {
        private long _storePackageId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private long _store;
        private long _package;
        private int _priorityNumber;
        private Nullable<bool> _isCurrentFlag;
        private Nullable<long> _currentVersion;
        private DateTime _startTime;
        private DateTime _endTime;

        /*Section="Field-StorePackageId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Store Package Id", null)]
        [OTDisplayName("Store Package Id")]
        [DataMember]
        public long StorePackageId
        {
            get
            {
                return _storePackageId;
            }
            set
            {
                _storePackageId = value;
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

        /*Section="Field-Package"*/
        [UIHint("PricePackageList")]
        [OTRequired("Package", null)]
        [OTDisplayName("Package")]
        [DataMember]
        public long Package
        {
            get
            {
                return _package;
            }
            set
            {
                _package = value;
            }
        }

        /*Section="Field-PriorityNumber"*/
        [OTRequired("Priority Number", null)]
        [OTDisplayName("Priority Number")]
        [DataMember]
        public int PriorityNumber
        {
            get
            {
                return _priorityNumber;
            }
            set
            {
                _priorityNumber = value;
            }
        }

        /*Section="Field-IsCurrentFlag"*/
        [OTDisplayName("Is Current Flag")]
        [DataMember]
        public Nullable<bool> IsCurrentFlag
        {
            get
            {
                return _isCurrentFlag;
            }
            set
            {
                _isCurrentFlag = value;
            }
        }

        /*Section="Field-CurrentVersion"*/
        [UIHint("PackageVersionList")]
        [OTDisplayName("Current Version")]
        [DataMember]
        public Nullable<long> CurrentVersion
        {
            get
            {
                return _currentVersion;
            }
            set
            {
                _currentVersion = value;
            }
        }

        /*Section="Field-StartTime"*/
        [OTRequired("Start Time", null)]
        [OTDisplayName("Start Time")]
        [DataMember]
        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        /*Section="Field-EndTime"*/
        [OTRequired("End Time", null)]
        [OTDisplayName("End Time")]
        [DataMember]
        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _storePackageId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public int[] StoreList
        {
            get; set;
        }

        [DataMember]
        public Boolean AllStores
        {
            get; set;
        }

        [DataMember]
        public string PackageName
        {
            get; set;
        }
        [DataMember]
        public string StoreName
        {
            get; set;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}