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
    [OTDataObject(Module = "Helpdesk", ModuleShortName = "HDK", Table = "PROCESSDEF", HasAutoIdentity = true, DisplayName = "Process Definition", IdField = "ProcessDefinitionId")]
    [DataContract]
    public class HelpdeskProcess : DataModelObject
    {
        private long _processDefinitionId;
        private string _processDefinitionName;
        private int _processNo;

        /*Section="Field-ProcessDefinitionId"*/
        [OTDataField("PROCESSDEFID")]
        [DataMember]
        public long ProcessDefinitionId
        {
            get
            {
                return _processDefinitionId;
            }
            set
            {
                _processDefinitionId = value;
            }
        }

        /*Section="Field-ProcessDefinitionName"*/
        [OTDataField("PROCESSDEF_NM")]
        [DataMember]
        public string ProcessDefinitionName
        {
            get
            {
                return _processDefinitionName;
            }
            set
            {
                _processDefinitionName = value;
            }
        }

        /*Section="Field-ProcessNo"*/
        [OTDataField("PROCESS_NO")]
        [DataMember]
        public int ProcessNo
        {
            get
            {
                return _processNo;
            }
            set
            {
                _processNo = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _processDefinitionId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

