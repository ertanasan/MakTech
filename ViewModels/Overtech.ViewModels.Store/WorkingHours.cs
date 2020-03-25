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
    [OTDisplayName("Working Hours")]
    [DataContract]
    public class WorkingHours : ViewModelObject
    {
        private long _workingHoursId;
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
        private string _storeCode;
        private string _storeName;
        private Nullable<DateTime> _openingTime;
        private Nullable<DateTime> _closingTime;
        private string _openUserName;
        private string _closeUserName;
        private Nullable<long> _store;
        private Nullable<long> _openUser;
        private Nullable<long> _closeUser;
        private string _note;

        /*Section="Field-WorkingHoursId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Working Hours Id", null)]
        [OTDisplayName("Working Hours Id")]
        [DataMember]
        public long WorkingHoursId
        {
            get
            {
                return _workingHoursId;
            }
            set
            {
                _workingHoursId = value;
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

        /*Section="Field-StoreCode"*/
        [OTDisplayName("Store Code")]
        [DataMember]
        public string StoreCode
        {
            get
            {
                return _storeCode;
            }
            set
            {
                _storeCode = value;
            }
        }

        /*Section="Field-StoreName"*/
        [OTStringLength(100)]
        [OTDisplayName("Store Name")]
        [DataMember]
        public string StoreName
        {
            get
            {
                return _storeName;
            }
            set
            {
                _storeName = value;
            }
        }

        /*Section="Field-OpeningTime"*/
        [OTDisplayName("Opening Time")]
        [DataMember]
        public Nullable<DateTime> OpeningTime
        {
            get
            {
                return _openingTime;
            }
            set
            {
                _openingTime = value;
            }
        }

        /*Section="Field-ClosingTime"*/
        [OTDisplayName("Closing Time")]
        [DataMember]
        public Nullable<DateTime> ClosingTime
        {
            get
            {
                return _closingTime;
            }
            set
            {
                _closingTime = value;
            }
        }

        /*Section="Field-OpenUserName"*/
        [OTStringLength(100)]
        [OTDisplayName("Open User Name")]
        [DataMember]
        public string OpenUserName
        {
            get
            {
                return _openUserName;
            }
            set
            {
                _openUserName = value;
            }
        }

        /*Section="Field-CloseUserName"*/
        [OTStringLength(100)]
        [OTDisplayName("Close User Name")]
        [DataMember]
        public string CloseUserName
        {
            get
            {
                return _closeUserName;
            }
            set
            {
                _closeUserName = value;
            }
        }

        /*Section="Field-Store"*/
        [UIHint("StoreList")]
        [OTDisplayName("Store")]
        [DataMember]
        public Nullable<long> Store
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

        /*Section="Field-OpenUser"*/
        [UIHint("UserList")]
        [OTDisplayName("Open User")]
        [DataMember]
        public Nullable<long> OpenUser
        {
            get
            {
                return _openUser;
            }
            set
            {
                _openUser = value;
            }
        }

        /*Section="Field-CloseUser"*/
        [UIHint("UserList")]
        [OTDisplayName("Close User")]
        [DataMember]
        public Nullable<long> CloseUser
        {
            get
            {
                return _closeUser;
            }
            set
            {
                _closeUser = value;
            }
        }

        /*Section="Field-Note"*/
        [OTStringLength(1000)]
        [OTDisplayName("Note")]
        [DataMember]
        public string Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _workingHoursId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}