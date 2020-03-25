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
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "STORE", HasAutoIdentity = false, DisplayName = "Store", IdField = "StoreId")]
    [DataContract]
    public class Store : DataModelObject
    {
        private long _storeId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private string _name;
        private long _organizationBranch;
        private string _ipAddress;
        private decimal _advance;
        private Nullable<DateTime> _openingDate;
        private Nullable<DateTime> _closingDate;
        private bool _activeFlag;
        private bool _productionFlag;
        private Nullable<long> _city;
        private Nullable<long> _town;
        private string _address;
        private Nullable<long> _regionManager;
        private bool _inConstruction;

        /*Section="Field-StoreId"*/
        [OTDataField("STOREID")]
        [DataMember]
        public long StoreId
        {
            get
            {
                return _storeId;
            }
            set
            {
                _storeId = value;
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
        [OTDataField("STORE_NM")]
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

        /*Section="Field-OrganizationBranch"*/
        [OTDataField("BRANCH")]
        [DataMember]
        public long OrganizationBranch
        {
            get
            {
                return _organizationBranch;
            }
            set
            {
                _organizationBranch = value;
            }
        }

        /*Section="Field-IpAddress"*/
        [OTDataField("IPADDRESS_TXT")]
        [DataMember]
        public string IpAddress
        {
            get
            {
                return _ipAddress;
            }
            set
            {
                _ipAddress = value;
            }
        }

        /*Section="Field-Advance"*/
        [OTDataField("ADVANCE_AMT")]
        [DataMember]
        public decimal Advance
        {
            get
            {
                return _advance;
            }
            set
            {
                _advance = value;
            }
        }

        /*Section="Field-OpeningDate"*/
        [OTDataField("OPENING_DT", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> OpeningDate
        {
            get
            {
                return _openingDate;
            }
            set
            {
                _openingDate = value;
            }
        }

        /*Section="Field-ClosingDate"*/
        [OTDataField("CLOSING_DT", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> ClosingDate
        {
            get
            {
                return _closingDate;
            }
            set
            {
                _closingDate = value;
            }
        }

        /*Section="Field-ActiveFlag"*/
        [OTDataField("ACTIVE_FL")]
        [DataMember]
        public bool ActiveFlag
        {
            get
            {
                return _activeFlag;
            }
            set
            {
                _activeFlag = value;
            }
        }

        /*Section="Field-ProductionFlag"*/
        [OTDataField("PRODUCTION_FL")]
        [DataMember]
        public bool ProductionFlag
        {
            get
            {
                return _productionFlag;
            }
            set
            {
                _productionFlag = value;
            }
        }

        /*Section="Field-City"*/
        [OTDataField("CITY", Nullable = true)]
        [DataMember]
        public Nullable<long> City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
            }
        }

        /*Section="Field-Town"*/
        [OTDataField("TOWN", Nullable = true)]
        [DataMember]
        public Nullable<long> Town
        {
            get
            {
                return _town;
            }
            set
            {
                _town = value;
            }
        }

        /*Section="Field-Address"*/
        [OTDataField("ADDRESS_TXT")]
        [DataMember]
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        /*Section="Field-RegionManager"*/
        [OTDataField("REGIONMANAGER", Nullable = true)]
        [DataMember]
        public Nullable<long> RegionManager
        {
            get
            {
                return _regionManager;
            }
            set
            {
                _regionManager = value;
            }
        }

        /*Section="Field-InConstruction"*/
        [OTDataField("INCONSTRUCTION_FL")]
        [DataMember]
        public bool InConstruction
        {
            get
            {
                return _inConstruction;
            }
            set
            {
                _inConstruction = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _storeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("CITY_NM", IsExtended = true)]
        [DataMember]
        public string CityName
        {
            get; set;
        }

        [OTDataField("TOWN_NM", IsExtended = true)]
        [DataMember]
        public string TownName
        {
            get; set;
        }

        [OTDataField("MANAGER_NM", IsExtended = true)]
        [DataMember]
        public string RegionManagerName
        {
            get; set;
        }

        [OTDataField("LASTORDERENTRY_TXT", IsExtended = true)]
        [DataMember]
        public string LastOrderEntry
        {
            get; set;
        }

        [OTDataField("USERBRANCHTYPE_NM", IsExtended = true)]
        [DataMember]
        public string UserBranchType
        {
            get; set;
        }

        [OTDataField("TERMINAL_CNT", IsExtended = true)]
        [DataMember]
        public int TerminalCount
        {
            get; set;
        }

        [OTDataField("DEPARTMENT_NM", IsExtended = true)]
        [DataMember]
        public string UserDepartment
        {
            get; set;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

