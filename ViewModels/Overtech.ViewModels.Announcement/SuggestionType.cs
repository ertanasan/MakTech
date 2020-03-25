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
    [OTDisplayName("Suggestion Type")]
    [DataContract]
    public class SuggestionType : ViewModelObject
    {
        private long _suggestionTypeId;
        private string _suggestionTypeName;

        /*Section="Field-SuggestionTypeId"*/
        [OTRequired("Suggestion Type Id", null)]
        [OTDisplayName("Suggestion Type Id")]
        [DataMember]
        public long SuggestionTypeId
        {
            get
            {
                return _suggestionTypeId;
            }
            set
            {
                _suggestionTypeId = value;
            }
        }

        /*Section="Field-SuggestionTypeName"*/
        [OTRequired("Suggestion Type Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Suggestion Type Name")]
        [DataMember]
        public string SuggestionTypeName
        {
            get
            {
                return _suggestionTypeName;
            }
            set
            {
                _suggestionTypeName = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _suggestionTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}