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
namespace Overtech.DataModels.Warehouse
{
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "MATERIALCATEGORY", HasAutoIdentity = true, DisplayName = "Material Category", IdField = "MaterialCategoryId")]
    [DataContract]
    public class MaterialCategory : DataModelObject
    {
        private long _materialCategoryId;
        private string _categoryName;

        /*Section="Field-MaterialCategoryId"*/
        [OTDataField("MATERIALCATEGORYID")]
        [DataMember]
        public long MaterialCategoryId
        {
            get
            {
                return _materialCategoryId;
            }
            set
            {
                _materialCategoryId = value;
            }
        }

        /*Section="Field-CategoryName"*/
        [OTDataField("CATEGORY_NM")]
        [DataMember]
        public string CategoryName
        {
            get
            {
                return _categoryName;
            }
            set
            {
                _categoryName = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _materialCategoryId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

