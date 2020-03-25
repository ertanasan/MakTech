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
    [OTDataObject(Module = "Helpdesk", ModuleShortName = "HDK", Table = "ATTRIBUTETYPE", HasAutoIdentity = true, DisplayName = "Attribute Type", IdField = "AttributeTypeId")]
    [DataContract]
    public class AttributeType : DataModelObject
    {
        private long _attributeTypeId;
        private string _attributeTypeName;

        /*Section="Field-AttributeTypeId"*/
        [OTDataField("ATTRIBUTETYPEID")]
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
        [OTDataField("ATTRIBUTETYPE_NM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _attributeTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

