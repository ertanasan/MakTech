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
namespace Overtech.ViewModels.OverStoreMain
{
    [OTDisplayName("OverStoreTaskHistory")]
    [DataContract]
    public class OverStoreTaskHistory : ViewModelObject
    {
        private long _overStoreTaskHistoryId;
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
        private long _overStoreTask;
        private DateTime _historyTime;
        private long _status;
        private string _changeDetail;
        private int _responsibleType;
        private Nullable<long> _responsibleUser;
        private Nullable<long> _responsibleGroup;
        private Nullable<long> _responsibleBranch;
        private bool _forwardableFlag;

        /*Section="Field-OverStoreTaskHistoryId"*/
        [ScaffoldColumn(false)]
        [OTRequired("OverStoreTaskHistory Id", null)]
        [OTDisplayName("OverStoreTaskHistory Id")]
        [DataMember]
        public long OverStoreTaskHistoryId
        {
            get
            {
                return _overStoreTaskHistoryId;
            }
            set
            {
                _overStoreTaskHistoryId = value;
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

        /*Section="Field-OverStoreTask"*/
        [UIHint("OverStoreTaskList")]
        [OTRequired("OverStoreTask", null)]
        [OTDisplayName("OverStoreTask")]
        [DataMember]
        public long OverStoreTask
        {
            get
            {
                return _overStoreTask;
            }
            set
            {
                _overStoreTask = value;
            }
        }

        /*Section="Field-HistoryTime"*/
        [OTRequired("HistoryTime", null)]
        [OTDisplayName("HistoryTime")]
        [DataMember]
        public DateTime HistoryTime
        {
            get
            {
                return _historyTime;
            }
            set
            {
                _historyTime = value;
            }
        }

        /*Section="Field-Status"*/
        [UIHint("OverStoreTaskStatusList")]
        [OTRequired("Status", null)]
        [OTDisplayName("Status")]
        [DataMember]
        public long Status
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

        /*Section="Field-ChangeDetail"*/
        [OTStringLength(1000)]
        [OTDisplayName("Change Detail")]
        [DataMember]
        public string ChangeDetail
        {
            get
            {
                return _changeDetail;
            }
            set
            {
                _changeDetail = value;
            }
        }

        /*Section="Field-ResponsibleType"*/
        [OTRequired("Responsible Type", null)]
        [OTDisplayName("Responsible Type")]
        [DataMember]
        public int ResponsibleType
        {
            get
            {
                return _responsibleType;
            }
            set
            {
                _responsibleType = value;
            }
        }

        /*Section="Field-ResponsibleUser"*/
        [UIHint("UserList")]
        [OTDisplayName("Responsible User")]
        [DataMember]
        public Nullable<long> ResponsibleUser
        {
            get
            {
                return _responsibleUser;
            }
            set
            {
                _responsibleUser = value;
            }
        }

        /*Section="Field-ResponsibleGroup"*/
        [UIHint("GroupList")]
        [OTDisplayName("Responsible Group")]
        [DataMember]
        public Nullable<long> ResponsibleGroup
        {
            get
            {
                return _responsibleGroup;
            }
            set
            {
                _responsibleGroup = value;
            }
        }

        /*Section="Field-ResponsibleBranch"*/
        [UIHint("BranchList")]
        [OTDisplayName("Responsible Branch")]
        [DataMember]
        public Nullable<long> ResponsibleBranch
        {
            get
            {
                return _responsibleBranch;
            }
            set
            {
                _responsibleBranch = value;
            }
        }

        /*Section="Field-ForwardableFlag"*/
        [OTRequired("Forwardable Flag", null)]
        [OTDisplayName("Forwardable Flag")]
        [DataMember]
        public bool ForwardableFlag
        {
            get
            {
                return _forwardableFlag;
            }
            set
            {
                _forwardableFlag = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _overStoreTaskHistoryId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}