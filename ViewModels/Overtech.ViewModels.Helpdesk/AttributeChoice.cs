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
    [OTDisplayName("Attribute Choice")]
    [DataContract]
    public class AttributeChoice : ViewModelObject
    {
        private long _attributeChoiceId;
        private long _attribute;
        private string _choiceName;
        private Nullable<int> _displayOrder;
        private Nullable<int> _priorityPoint;

        /*Section="Field-AttributeChoiceId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Attribute Choice Id", null)]
        [OTDisplayName("Attribute Choice Id")]
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
        [UIHint("RequestAttributeList")]
        [OTRequired("Attribute", null)]
        [OTDisplayName("Attribute")]
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
        [OTRequired("Choice Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Choice Name")]
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

        /*Section="Field-PriorityPoint"*/
        [OTDisplayName("Priority Point")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _attributeChoiceId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}