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
namespace Overtech.ViewModels.Helpdesk
{
    [OTDisplayName("Request Attribute")]
    [DataContract]
    public class RequestAttribute : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Request Attribute Id", null)]
        [OTDisplayName("Request Attribute Id")]
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
        [OTRequired("Attribute Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Attribute Name")]
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
        [UIHint("RequestGroupList")]
        [OTDisplayName("Request Group")]
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
        [UIHint("RequestDefinitionList")]
        [OTDisplayName("Request Definition")]
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
        [UIHint("AttributeTypeList")]
        [OTRequired("Attribute Type", null)]
        [OTDisplayName("Attribute Type")]
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
        [OTDisplayName("Editable Flag")]
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
        [OTDisplayName("Required Flag")]
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
        [OTDisplayName("Display Order")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _requestAttributeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}