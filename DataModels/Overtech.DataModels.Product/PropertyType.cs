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
namespace Overtech.DataModels.Product
{
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "PROPERTYTYPE", HasAutoIdentity = false, DisplayName = "Property Type", IdField = "PropertyTypeId")]
    [DataContract]
    public class PropertyType : DataModelObject
    {
        private long _propertyTypeId;
        private string _name;
        private string _description;

        /*Section="Field-PropertyTypeId"*/
        [OTDataField("PROPERTYTYPEID")]
        [DataMember]
        public long PropertyTypeId
        {
            get
            {
                return _propertyTypeId;
            }
            set
            {
                _propertyTypeId = value;
            }
        }

        /*Section="Field-Name"*/
        [OTDataField("PROPERTYTYPE_NM")]
        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /*Section="Field-Description"*/
        [OTDataField("COMMENT_DSC")]
        [DataMember]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _propertyTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

