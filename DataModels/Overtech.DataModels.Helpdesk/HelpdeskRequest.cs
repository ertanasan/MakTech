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
namespace Overtech.DataModels.Helpdesk
{

    public enum RequestStatusList
    {
        Giris                                     = 1,
        Revize                                    = 3,
        RevizeTamam                               = 5,
        Momende                                   = 7,
        CozumOnaylandi                            = 11,
        ServiseAlindi                             = 22,
        DepoyaIletildi                            = 31,
        SatinAlmayaIletildi                       = 32,
        Yonlendirildi                             = 33,
        DisTedarikciyeIletildi                    = 34,
        MagazayaGonderildi                        = 41,
        Depodastokyok                             = 42,
        AskiyaAlindi                              = 44,
        Cozuldu                                   = 55,
        Cozulmemis                                = 66,
        HurdayaAlindi                             = 77,
        YenisiGonderildi                          = 88,
        Iptal                                     = 99
    }

    [OTDataObject(Module = "Helpdesk", ModuleShortName = "HDK", Table = "REQUESTBPM", HasAutoIdentity = true, DisplayName = "RequestBPM", IdField = "ActionId")]
    [DataContract]
    public class RequestBPM : DataModelObject
    {
        [OTDataField("ACTIONID")]
        [DataMember]
        public long ActionId { get; set; }

        [OTDataField("SCREEN_REF")]
        [DataMember]
        public string ScreenReference { get; set; }
        public override void SetId(long id) { }
    }

    [OTDataObject(Module = "Helpdesk", ModuleShortName = "HDK", Table = "REQUEST", HasAutoIdentity = true, DisplayName = "Helpdesk Request", IdField = "HelpdeskRequestId")]
    [DataContract]
    public class HelpdeskRequest : DataModelObject
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
        private long _store;
        private Nullable<long> _redirectionGroup;
        private string _contactPhoneNumber;
        private Nullable<long> _responsibleUser;

        /*Section="Field-HelpdeskRequestId"*/
        [OTDataField("REQUESTID")]
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

        /*Section="Field-RequestDefinition"*/
        [OTDataField("REQUESTDEFINITION")]
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
        [OTDataField("REQUEST_DSC")]
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
        [OTDataField("STATUS_CD")]
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
        [OTDataField("PROCESSINSTANCE_LNO", Nullable = true)]
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

        /*Section="Field-RedirectionGroup"*/
        [OTDataField("REDIRECTIONGROUP", Nullable = true)]
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
        [OTDataField("PHONENUMBER_TXT")]
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
        [OTDataField("RESPONSIBLEUSER", Nullable = true)]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _helpdeskRequestId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public IEnumerable<RequestDetail> RequestDetailList { get; set; }

        [OTDataField("PROCESS", IsExtended = true)]
        [DataMember]
        public int Process
        {
            get; set;
        }

        [OTDataField("PROCESS_NM", IsExtended = true)]
        [DataMember]
        public string ProcessName
        {
            get; set;
        }

        [OTDataField("REQUESTGROUP", IsExtended = true)]
        [DataMember]
        public int RequestGroup
        {
            get; set;
        }

        [OTDataField("STORE_NM", IsExtended = true)]
        [DataMember]
        public string StoreName
        {
            get; set;
        }

        [OTDataField("PROCESSINSTANCESTATUS_CD", IsExtended = true)]
        [DataMember]
        public int ProcessInstanceStatusCode
        {
            get; set;
        }

        [OTDataField("ACTIVITY_NM", IsExtended = true)]
        [DataMember]
        public string ActivityName
        {
            get; set;
        }

        [OTDataField("USERTASK_FL", IsExtended = true)]
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

