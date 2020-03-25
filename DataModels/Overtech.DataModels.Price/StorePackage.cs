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
    [OTDataObject(Module = "Price", ModuleShortName = "PRC", Table = "STOREPACKAGE", HasAutoIdentity = true, DisplayName = "Store Package", IdField = "StorePackageId")]
    [DataContract]
    public class StorePackage : DataModelObject
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
        [OTDataField("STOREPACKAGEID")]
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

        /*Section="Field-Package"*/
        [OTDataField("PACKAGE")]
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
        [OTDataField("PRIORITY_NO")]
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
        [OTDataField("ISCURRENT_FL")]
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
        [OTDataField("CURRENTVERSION")]
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
        [OTDataField("START_TM")]
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
        [OTDataField("END_TM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _storePackageId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("STORELST_TXT", IsExtended = true)]
        [DataMember]
        public int[] StoreList
        {
            get; set;
        }

        [OTDataField("ALLSTORES_FL", IsExtended = true)]
        [DataMember]
        public Boolean AllStores
        {
            get; set;
        }

        [OTDataField("PACKAGE_NM", IsExtended = true)]
        [DataMember]
        public string PackageName
        {
            get; set;
        }

        [OTDataField("STORE_NM", IsExtended = true)]
        [DataMember]
        public string StoreName
        {
            get; set;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

