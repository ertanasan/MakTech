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
    [OTDataObject(Module = "Helpdesk", ModuleShortName = "HDK", Table = "REDIRECTIONGROUP", HasAutoIdentity = true, DisplayName = "Redirection Group", IdField = "RedirectionGroupId")]
    [DataContract]
    public class RedirectionGroup : DataModelObject
    {
        private long _redirectionGroupId;
        private string _groupName;
        private long _requestDefinition;

        /*Section="Field-RedirectionGroupId"*/
        [OTDataField("REDIRECTIONGROUPID")]
        [DataMember]
        public long RedirectionGroupId
        {
            get
            {
                return _redirectionGroupId;
            }
            set
            {
                _redirectionGroupId = value;
            }
        }

        /*Section="Field-GroupName"*/
        [OTDataField("GROUP_NM")]
        [DataMember]
        public string GroupName
        {
            get
            {
                return _groupName;
            }
            set
            {
                _groupName = value;
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _redirectionGroupId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

