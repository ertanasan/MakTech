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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "STOCKTAKINGSCHEDULE", HasAutoIdentity = true, DisplayName = "StockTaking Schedule", IdField = "StockTakingScheduleId")]
    [DataContract]
    public class StockTakingSchedule : DataModelObject
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
        [OTDataField("STOCKTAKINGSCHEDULEID")]
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

        /*Section="Field-ScheduleName"*/
        [OTDataField("SCHEDULE_NM")]
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

        /*Section="Field-CountingType"*/
        [OTDataField("COUNTINGTYPE")]
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
        [OTDataField("PLANNED_DT")]
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
        [OTDataField("ACTUAL_DT", Nullable = true)]
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
        [OTDataField("STATUS")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _stockTakingScheduleId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OTDataField("SCHEDULEFULL_NM", IsExtended = true)]
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

        [OTDataField("TAKINGUSER", IsExtended = true)]
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

