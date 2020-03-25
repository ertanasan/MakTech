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
namespace Overtech.ViewModels.Helpdesk
{
    [OTDisplayName("RequestBPM")]
    [DataContract]
    public class RequestBPM : ViewModelObject
    {
        [DataMember]
        public long ActionId { get; set; }

        [DataMember]
        public string ScreenReference { get; set; }

        public override long GetId() { return 1; }
    }

    [OTDisplayName("Helpdesk Request")]
    [DataContract]
    public class HelpdeskRequest : ViewModelObject
    {
        private long _helpdeskRequestId;
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
        private long _requestDefinition;
        private string _requestDescription;
        private int _statusCode;
        private Nullable<long> _processInstance;
        private Nullable<long> _store;
        private Nullable<long> _redirectionGroup;
        private string _contactPhoneNumber;
        private Nullable<long> _responsibleUser;

        /*Section="Field-HelpdeskRequestId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Helpdesk Request Id", null)]
        [OTDisplayName("Helpdesk Request Id")]
        [DataMember]
        public long HelpdeskRequestId
        {
            get
            {
                return _helpdeskRequestId;
            }
            set
            {
                _helpdeskRequestId = value;
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

        /*Section="Field-RequestDefinition"*/
        [UIHint("RequestDefinitionList")]
        [OTRequired("Request Definition", null)]
        [OTDisplayName("Request Definition")]
        [DataMember]
        public long RequestDefinition
        {
            get
            {
                return _requestDefinition;
            }
            set
            {
                _requestDefinition = value;
            }
        }

        /*Section="Field-RequestDescription"*/
        [OTStringLength(1000)]
        [OTDisplayName("Request Description")]
        [DataMember]
        public string RequestDescription
        {
            get
            {
                return _requestDescription;
            }
            set
            {
                _requestDescription = value;
            }
        }

        /*Section="Field-StatusCode"*/
        [OTRequired("Status Code", null)]
        [OTDisplayName("Status Code")]
        [DataMember]
        public int StatusCode
        {
            get
            {
                return _statusCode;
            }
            set
            {
                _statusCode = value;
            }
        }

        /*Section="Field-ProcessInstance"*/
        [OTDisplayName("Process Instance")]
        [DataMember]
        public Nullable<long> ProcessInstance
        {
            get
            {
                return _processInstance;
            }
            set
            {
                _processInstance = value;
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

        /*Section="Field-RedirectionGroup"*/
        [UIHint("RedirectionGroupList")]
        [OTDisplayName("Redirection Group")]
        [DataMember]
        public Nullable<long> RedirectionGroup
        {
            get
            {
                return _redirectionGroup;
            }
            set
            {
                _redirectionGroup = value;
            }
        }

        /*Section="Field-ContactPhoneNumber"*/
        [OTDisplayName("Contact Phone Number")]
        [DataMember]
        public string ContactPhoneNumber
        {
            get
            {
                return _contactPhoneNumber;
            }
            set
            {
                _contactPhoneNumber = value;
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _helpdeskRequestId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public IEnumerable<RequestDetail> RequestDetailList { get; set; }

        [DataMember]
        public int Process
        {
            get; set;
        }
        [DataMember]
        public string ProcessName
        {
            get; set;
        }
        [DataMember]
        public int RequestGroup
        {
            get; set;
        }

        [DataMember]
        public string StoreName
        {
            get; set;
        }

        [DataMember]
        public int ProcessInstanceStatusCode
        {
            get; set;
        }

        [DataMember]
        public string ActivityName
        {
            get; set;
        }

        [DataMember]
        public Boolean UserTask
        {
            get; set;
        }

        [DataMember]
        public long action { get; set; }

        [DataMember]
        public string actionChoice { get; set; }

        [DataMember]
        public string actionComment { get; set; }
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}