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
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "PRODUCTFAMILY", HasAutoIdentity = false, DisplayName = "Product Famiy", IdField = "ProductFamiyId")]
    [DataContract]
    public class ProductFamiy : DataModelObject
    {
        private long _productFamiyId;
        private string _name;
        private string _comment;

        /*Section="Field-ProductFamiyId"*/
        [OTDataField("PRODUCTFAMILYID")]
        [DataMember]
        public long ProductFamiyId
        {
            get
            {
                return _productFamiyId;
            }
            set
            {
                _productFamiyId = value;
            }
        }

        /*Section="Field-Name"*/
        [OTDataField("PRODUCTFAMILY_NM")]
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

        /*Section="Field-Comment"*/
        [OTDataField("COMMENT_DSC")]
        [DataMember]
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _productFamiyId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

