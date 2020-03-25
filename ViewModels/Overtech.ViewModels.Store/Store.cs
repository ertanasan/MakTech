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
    [OTDisplayName("Store")]
    [DataContract]
    public class Store : ViewModelObject
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
        [OTRequired("Store Id", null)]
        [OTDisplayName("Store Id")]
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

        /*Section="Field-OrganizationBranch"*/
        [UIHint("BranchList")]
        [OTRequired("Organization Branch", null)]
        [OTDisplayName("Organization Branch")]
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
        [OTRequired("Ip Address", null)]
        [OTDisplayName("Ip Address")]
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
        [OTRequired("Advance", null)]
        [OTDisplayName("Advance")]
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
        [OTDisplayName("Opening Date")]
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
        [OTDisplayName("Closing Date")]
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
        [OTDisplayName("Active Flag")]
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
        [OTDisplayName("Production Flag")]
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
        [UIHint("CityList")]
        [OTDisplayName("City")]
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
        [UIHint("TownList")]
        [OTDisplayName("Town")]
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
        [OTDisplayName("Address")]
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
        [UIHint("RegionManagersList")]
        [OTDisplayName("Region Manager")]
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
        [OTDisplayName("InConstruction")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _storeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public string CityName
        {
            get; set;
        }

        [DataMember]
        public string TownName
        {
            get; set;
        }

        [DataMember]
        public string RegionManagerName
        {
            get; set;
        }

        [DataMember]
        public string LastOrderEntry
        {
            get; set;
        }

        [DataMember]
        public string UserBranchType
        {
            get; set;
        }

        [DataMember]
        public int TerminalCount
        {
            get; set;
        }

        [DataMember]
        public string UserDepartment
        {
            get; set;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}