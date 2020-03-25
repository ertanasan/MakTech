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
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "PROPERTY", HasAutoIdentity = true, DisplayName = "Product Property", IdField = "ProductPropertyId")]
    [DataContract]
    public class ProductProperty : DataModelObject
    {
        private long _productPropertyId;
        private long _propertyType;
        private long _product;
        private string _value;

        /*Section="Field-ProductPropertyId"*/
        [OTDataField("PROPERTYID")]
        [DataMember]
        public long ProductPropertyId
        {
            get
            {
                return _productPropertyId;
            }
            set
            {
                _productPropertyId = value;
            }
        }

        /*Section="Field-PropertyType"*/
        [OTDataField("PROPERTYTYPE")]
        [DataMember]
        public long PropertyType
        {
            get
            {
                return _propertyType;
            }
            set
            {
                _propertyType = value;
            }
        }

        /*Section="Field-Product"*/
        [OTDataField("PRODUCT")]
        [DataMember]
        public long Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
            }
        }

        /*Section="Field-Value"*/
        [OTDataField("VALUE_TXT")]
        [DataMember]
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _productPropertyId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

