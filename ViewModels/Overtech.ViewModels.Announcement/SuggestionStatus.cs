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
    [OTDisplayName("Suggestion Status")]
    [DataContract]
    public class SuggestionStatus : ViewModelObject
    {
        private long _suggestionStatusId;
        private string _statusName;

        /*Section="Field-SuggestionStatusId"*/
        [OTRequired("Suggestion Status Id", null)]
        [OTDisplayName("Suggestion Status Id")]
        [DataMember]
        public long SuggestionStatusId
        {
            get
            {
                return _suggestionStatusId;
            }
            set
            {
                _suggestionStatusId = value;
            }
        }

        /*Section="Field-StatusName"*/
        [OTRequired("Status Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Status Name")]
        [DataMember]
        public string StatusName
        {
            get
            {
                return _statusName;
            }
            set
            {
                _statusName = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _suggestionStatusId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}