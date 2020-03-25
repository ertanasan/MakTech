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
    [OTDataObject(Module = "Announcement", ModuleShortName = "ANN", Table = "SUGGESTIONSTATUS", HasAutoIdentity = false, DisplayName = "Suggestion Status", IdField = "SuggestionStatusId")]
    [DataContract]
    public class SuggestionStatus : DataModelObject
    {
        private long _suggestionStatusId;
        private string _statusName;

        /*Section="Field-SuggestionStatusId"*/
        [OTDataField("SUGGESTIONSTATUSID")]
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
        [OTDataField("STATUS_NM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _suggestionStatusId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

