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
    [OTDataObject(Module = "Helpdesk", ModuleShortName = "HDK", Table = "ATTRIBUTECHOICE", HasAutoIdentity = true, DisplayName = "Attribute Choice", IdField = "AttributeChoiceId", MasterField = "Attribute")]
    [DataContract]
    public class AttributeChoice : DataModelObject
    {
        private long _attributeChoiceId;
        private long _attribute;
        private string _choiceName;
        private Nullable<int> _displayOrder;
        private Nullable<int> _priorityPoint;

        /*Section="Field-AttributeChoiceId"*/
        [OTDataField("ATTRIBUTECHOICEID")]
        [DataMember]
        public long AttributeChoiceId
        {
            get
            {
                return _attributeChoiceId;
            }
            set
            {
                _attributeChoiceId = value;
            }
        }

        /*Section="Field-Attribute"*/
        [OTDataField("ATTRIBUTE")]
        [DataMember]
        public long Attribute
        {
            get
            {
                return _attribute;
            }
            set
            {
                _attribute = value;
            }
        }

        /*Section="Field-ChoiceName"*/
        [OTDataField("CHOICE_NM")]
        [DataMember]
        public string ChoiceName
        {
            get
            {
                return _choiceName;
            }
            set
            {
                _choiceName = value;
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

        /*Section="Field-PriorityPoint"*/
        [OTDataField("PRIORITYPOINT_NO", Nullable = true)]
        [DataMember]
        public Nullable<int> PriorityPoint
        {
            get
            {
                return _priorityPoint;
            }
            set
            {
                _priorityPoint = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _attributeChoiceId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

