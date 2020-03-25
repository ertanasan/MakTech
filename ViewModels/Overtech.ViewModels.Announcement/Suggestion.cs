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
namespace Overtech.ViewModels.Announcement
{
    [OTDisplayName("Suggestion")]
    [DataContract]
    public class Suggestion : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Suggestion Id", null)]
        [OTDisplayName("Suggestion Id")]
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

        /*Section="Field-SuggestionText"*/
        [OTRequired("Suggestion Text", null)]
        [OTDisplayName("Suggestion Text")]
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

        /*Section="Field-Status"*/
        [UIHint("SuggestionStatusList")]
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

        /*Section="Field-Type"*/
        [UIHint("SuggestionTypeList")]
        [OTDisplayName("Type")]
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
        [OTDisplayName("Innovativeness Rating")]
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
        [OTDisplayName("Feasibility Rating")]
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
        [OTDisplayName("Added Value Rating")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _suggestionId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
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

        [DataMember]
        public string PreviousActionComment { get; set; }
    }

    public class SuggestionHistory : ViewModelObject
    {
        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public DateTime StartTime { get; set; }

        [DataMember]
        public DateTime FinishTime { get; set; }

        [DataMember]
        public int Performer { get; set; }

        [DataMember]
        public int ActionStatusCode { get; set; }

        [DataMember]
        public int ProcessStatusCode { get; set; }

        [DataMember]
        public string Choice { get; set; }

        [DataMember]
        public string ActionComment { get; set; }

        public override long GetId() { return 0; }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}