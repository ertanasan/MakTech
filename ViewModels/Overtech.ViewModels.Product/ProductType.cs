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
namespace Overtech.ViewModels.Product
{
    [OTDisplayName("Product Type")]
    [DataContract]
    public class ProductType : ViewModelObject
    {
        private long _subgroupID;
        private string _subgroup;
        private long _category;
        private string _comment;

        /*Section="Field-SubgroupID"*/
        [OTRequired("Subgroup ID", null)]
        [OTDisplayName("Subgroup ID")]
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
        [OTRequired("Subgroup", null)]
        [OTStringLength(100)]
        [OTDisplayName("Subgroup")]
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
        [UIHint("ProductCategoryList")]
        [OTRequired("Category", null)]
        [OTDisplayName("Category")]
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
        [OTStringLength(1000)]
        [OTDisplayName("Comment")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _subgroupID;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}