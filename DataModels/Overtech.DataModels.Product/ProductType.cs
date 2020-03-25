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
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "SUBGROUP", HasAutoIdentity = false, DisplayName = "Product Type", IdField = "SubgroupID")]
    [DataContract]
    public class ProductType : DataModelObject
    {
        private long _subgroupID;
        private string _subgroup;
        private long _category;
        private string _comment;

        /*Section="Field-SubgroupID"*/
        [OTDataField("SUBGROUPID")]
        [DataMember]
        public long SubgroupID
        {
            get
            {
                return _subgroupID;
            }
            set
            {
                _subgroupID = value;
            }
        }

        /*Section="Field-Subgroup"*/
        [OTDataField("SUBGROUP_NM")]
        [DataMember]
        public string Subgroup
        {
            get
            {
                return _subgroup;
            }
            set
            {
                _subgroup = value;
            }
        }

        /*Section="Field-Category"*/
        [OTDataField("CATEGORY")]
        [DataMember]
        public long Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
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
            _subgroupID = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

