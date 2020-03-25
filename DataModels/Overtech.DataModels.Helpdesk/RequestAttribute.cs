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
    [OTDataObject(Module = "Helpdesk", ModuleShortName = "HDK", Table = "ATTRIBUTE", HasAutoIdentity = true, DisplayName = "Request Attribute", IdField = "RequestAttributeId")]
    [DataContract]
    public class RequestAttribute : DataModelObject
    {
        private long _requestAttributeId;
        private string _attributeName;
        private Nullable<long> _requestGroup;
        private Nullable<long> _requestDefinition;
        private long _attributeType;
        private bool _editableFlag;
        private bool _requiredFlag;
        private Nullable<int> _displayOrder;

        /*Section="Field-RequestAttributeId"*/
        [OTDataField("ATTRIBUTEID")]
        [DataMember]
        public long RequestAttributeId
        {
            get
            {
                return _requestAttributeId;
            }
            set
            {
                _requestAttributeId = value;
            }
        }

        /*Section="Field-AttributeName"*/
        [OTDataField("ATTRIBUTE_NM")]
        [DataMember]
        public string AttributeName
        {
            get
            {
                return _attributeName;
            }
            set
            {
                _attributeName = value;
            }
        }

        /*Section="Field-RequestGroup"*/
        [OTDataField("REQUESTGROUP", Nullable = true)]
        [DataMember]
        public Nullable<long> RequestGroup
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

        /*Section="Field-RequestDefinition"*/
        [OTDataField("REQUESTDEFINITION", Nullable = true)]
        [DataMember]
        public Nullable<long> RequestDefinition
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

        /*Section="Field-AttributeType"*/
        [OTDataField("ATTRIBUTETYPE")]
        [DataMember]
        public long AttributeType
        {
            get
            {
                return _attributeType;
            }
            set
            {
                _attributeType = value;
            }
        }

        /*Section="Field-EditableFlag"*/
        [OTDataField("EDITABLE_FL")]
        [DataMember]
        public bool EditableFlag
        {
            get
            {
                return _editableFlag;
            }
            set
            {
                _editableFlag = value;
            }
        }

        /*Section="Field-RequiredFlag"*/
        [OTDataField("REQUIRED_FL")]
        [DataMember]
        public bool RequiredFlag
        {
            get
            {
                return _requiredFlag;
            }
            set
            {
                _requiredFlag = value;
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _requestAttributeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

