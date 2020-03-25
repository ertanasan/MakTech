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
    [OTDataObject(Module = "Helpdesk", ModuleShortName = "HDK", Table = "REQUESTDEF", HasAutoIdentity = true, DisplayName = "Request Definition", IdField = "RequestDefinitionId", MasterField = "RequestGroup")]
    [DataContract]
    public class RequestDefinition : DataModelObject
    {
        private long _requestDefinitionId;
        private string _requestDefinitionName;
        private long _requestGroup;
        private long _process;
        private string _microCode;
        private Nullable<int> _displayOrder;
        private bool _activeFlag;

        /*Section="Field-RequestDefinitionId"*/
        [OTDataField("REQUESTDEFID")]
        [DataMember]
        public long RequestDefinitionId
        {
            get
            {
                return _requestDefinitionId;
            }
            set
            {
                _requestDefinitionId = value;
            }
        }

        /*Section="Field-RequestDefinitionName"*/
        [OTDataField("REQUESTDEF_NM")]
        [DataMember]
        public string RequestDefinitionName
        {
            get
            {
                return _requestDefinitionName;
            }
            set
            {
                _requestDefinitionName = value;
            }
        }

        /*Section="Field-RequestGroup"*/
        [OTDataField("REQUESTGROUP")]
        [DataMember]
        public long RequestGroup
        {
            get
            {
                return _requestGroup;
            }
            set
            {
                _requestGroup = value;
            }
        }

        /*Section="Field-Process"*/
        [OTDataField("PROCESS")]
        [DataMember]
        public long Process
        {
            get
            {
                return _process;
            }
            set
            {
                _process = value;
            }
        }

        /*Section="Field-MicroCode"*/
        [OTDataField("MICROCODE_TXT")]
        [DataMember]
        public string MicroCode
        {
            get
            {
                return _microCode;
            }
            set
            {
                _microCode = value;
            }
        }

        /*Section="Field-DisplayOrder"*/
        [OTDataField("DISPLAYORDER_NO", Nullable = true)]
        [DataMember]
        public Nullable<int> DisplayOrder
        {
            get
            {
                return _displayOrder;
            }
            set
            {
                _displayOrder = value;
            }
        }

        /*Section="Field-ActiveFlag"*/
        [OTDataField("ACTIVE_FL")]
        [DataMember]
        public bool ActiveFlag
        {
            get
            {
                return _activeFlag;
            }
            set
            {
                _activeFlag = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _requestDefinitionId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

