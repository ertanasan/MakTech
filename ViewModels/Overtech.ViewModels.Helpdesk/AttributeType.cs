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
    [OTDisplayName("Attribute Type")]
    [DataContract]
    public class AttributeType : ViewModelObject
    {
        private long _attributeTypeId;
        private string _attributeTypeName;

        /*Section="Field-AttributeTypeId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Attribute Type Id", null)]
        [OTDisplayName("Attribute Type Id")]
        [DataMember]
        public long AttributeTypeId
        {
            get
            {
                return _attributeTypeId;
            }
            set
            {
                _attributeTypeId = value;
            }
        }

        /*Section="Field-AttributeTypeName"*/
        [OTRequired("Attribute Type Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Attribute Type Name")]
        [DataMember]
        public string AttributeTypeName
        {
            get
            {
                return _attributeTypeName;
            }
            set
            {
                _attributeTypeName = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _attributeTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}