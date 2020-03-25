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
    [OTDisplayName("StockTaking Schedule")]
    [DataContract]
    public class StockTakingSchedule : ViewModelObject
    {
        private long _stockTakingScheduleId;
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
        private string _scheduleName;
        private long _store;
        private long _countingType;
        private DateTime _plannedDate;
        private Nullable<DateTime> _actualDate;
        private long _countingStatus;
        private string _scheduleFullName;
        private string _takingUser;

        /*Section="Field-StockTakingScheduleId"*/
        [ScaffoldColumn(false)]
        [OTRequired("StockTaking Schedule Id", null)]
        [OTDisplayName("StockTaking Schedule Id")]
        [DataMember]
        public long StockTakingScheduleId
        {
            get
            {
                return _stockTakingScheduleId;
            }
            set
            {
                _stockTakingScheduleId = value;
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

        /*Section="Field-ScheduleName"*/
        [OTRequired("Schedule Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Schedule Name")]
        [DataMember]
        public string ScheduleName
        {
            get
            {
                return _scheduleName;
            }
            set
            {
                _scheduleName = value;
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

        /*Section="Field-CountingType"*/
        [UIHint("CountingTypeList")]
        [OTRequired("Counting Type", null)]
        [OTDisplayName("Counting Type")]
        [DataMember]
        public long CountingType
        {
            get
            {
                return _countingType;
            }
            set
            {
                _countingType = value;
            }
        }

        /*Section="Field-PlannedDate"*/
        [OTRequired("Planned Date", null)]
        [OTDisplayName("Planned Date")]
        [DataMember]
        public DateTime PlannedDate
        {
            get
            {
                return _plannedDate;
            }
            set
            {
                _plannedDate = value;
            }
        }

        /*Section="Field-ActualDate"*/
        [OTDisplayName("Actual Date")]
        [DataMember]
        public Nullable<DateTime> ActualDate
        {
            get
            {
                return _actualDate;
            }
            set
            {
                _actualDate = value;
            }
        }

        /*Section="Field-CountingStatus"*/
        [UIHint("CountingStatusList")]
        [OTRequired("Counting Status", null)]
        [OTDisplayName("Counting Status")]
        [DataMember]
        public long CountingStatus
        {
            get
            {
                return _countingStatus;
            }
            set
            {
                _countingStatus = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _stockTakingScheduleId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OTStringLength(100)]
        [OTDisplayName("Schedule Full Name")]
        [DataMember]
        public string ScheduleFullName
        {
            get
            {
                return _scheduleFullName;
            }
            set
            {
                _scheduleFullName = value;
            }
        }

        [OTStringLength(100)]
        [OTDisplayName("Taking User")]
        [DataMember]
        public string TakingUser
        {
            get
            {
                return _takingUser;
            }
            set
            {
                _takingUser = value;
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}