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
    [OTDisplayName("Subgroup")]
    [DataContract]
    public class Subgroup : ViewModelObject
    {
        private long _subgroupID;
        private string _subgroupName;
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

        /*Section="Field-SubgroupName"*/
        [OTRequired("Subgroup Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Subgroup Name")]
        [DataMember]
        public string SubgroupName
        {
            get
            {
                return _subgroupName;
            }
            set
            {
                _subgroupName = value;
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