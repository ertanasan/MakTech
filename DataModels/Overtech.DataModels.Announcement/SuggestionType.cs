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
    [OTDataObject(Module = "Announcement", ModuleShortName = "ANN", Table = "SUGGESTIONTYPE", HasAutoIdentity = false, DisplayName = "Suggestion Type", IdField = "SuggestionTypeId")]
    [DataContract]
    public class SuggestionType : DataModelObject
    {
        private long _suggestionTypeId;
        private string _suggestionTypeName;

        /*Section="Field-SuggestionTypeId"*/
        [OTDataField("SUGGESTIONTYPEID")]
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
        [OTDataField("SUGGESTIONTYPE_NM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _suggestionTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

