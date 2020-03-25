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
namespace Overtech.DataModels.Announcement
{
    [OTDataObject(Module = "Announcement", ModuleShortName = "ANN", Table = "SUGGESTION", HasAutoIdentity = true, DisplayName = "Suggestion", IdField = "SuggestionId")]
    [DataContract]
    public class Suggestion : DataModelObject
    {
        private long _suggestionId;
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
        private string _suggestionText;
        private Nullable<long> _processInstance;
        private long _status;
        private Nullable<long> _type;
        private Nullable<decimal> _innovativenessRating;
        private Nullable<decimal> _feasibilityRating;
        private Nullable<decimal> _addedValueRating;

        /*Section="Field-SuggestionId"*/
        [OTDataField("SUGGESTIONID")]
        [DataMember]
        public long SuggestionId
        {
            get
            {
                return _suggestionId;
            }
            set
            {
                _suggestionId = value;
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

        /*Section="Field-SuggestionText"*/
        [OTDataField("SUGGESTION_TXT")]
        [DataMember]
        public string SuggestionText
        {
            get
            {
                return _suggestionText;
            }
            set
            {
                _suggestionText = value;
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

        /*Section="Field-Status"*/
        [OTDataField("STATUS")]
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

        /*Section="Field-Type"*/
        [OTDataField("TYPE", Nullable = true)]
        [DataMember]
        public Nullable<long> Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        /*Section="Field-InnovativenessRating"*/
        [OTDataField("INNOVATIVENESS_RT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> InnovativenessRating
        {
            get
            {
                return _innovativenessRating;
            }
            set
            {
                _innovativenessRating = value;
            }
        }

        /*Section="Field-FeasibilityRating"*/
        [OTDataField("FEASIBILITY_RT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> FeasibilityRating
        {
            get
            {
                return _feasibilityRating;
            }
            set
            {
                _feasibilityRating = value;
            }
        }

        /*Section="Field-AddedValueRating"*/
        [OTDataField("ADDEDVALUE_RT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> AddedValueRating
        {
            get
            {
                return _addedValueRating;
            }
            set
            {
                _addedValueRating = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _suggestionId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OTDataField("BRANCH_NM", IsExtended = true)]
        [DataMember]
        public string BranchName
        {
            get; set;
        }

        [DataMember]
        public long action { get; set; }

        [DataMember]
        public string actionChoice { get; set; }

        [DataMember]
        public string actionComment { get; set; }

        [OTDataField("PREVIOUSACTIONCOMMENT_DSC", IsExtended = true)]   
        [DataMember]
        public string PreviousActionComment { get; set; }

    }

    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS")]
    public class SuggestionHistory : DataModelObject
    {
        [OTDataField("CREATE_DT", IsExtended = true)]
        [DataMember]
        public DateTime CreateDate { get; set; }

        [OTDataField("START_TM", IsExtended = true)]
        [DataMember]
        public DateTime StartTime { get; set; }

        [OTDataField("FINISH_TM", IsExtended = true)]
        [DataMember]
        public DateTime FinishTime { get; set; }

        [OTDataField("PERFORMER", IsExtended = true)]
        [DataMember]
        public int Performer { get; set; }

        [OTDataField("ACTIONSTATUS_CD", IsExtended = true)]
        [DataMember]
        public int ActionStatusCode { get; set; }

        [OTDataField("PROCESSSTATUS_CD", IsExtended = true)]
        [DataMember]
        public int ProcessStatusCode { get; set; }

        [OTDataField("CHOICE_TXT", IsExtended = true)]
        [DataMember]
        public string Choice { get; set; }

        [OTDataField("USERCOMMENT_DSC", IsExtended = true)]
        [DataMember]
        public string ActionComment { get; set; }

        public override void SetId(long id) { }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

