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
    [OTDisplayName("Product Category")]
    [DataContract]
    public class ProductCategory : ViewModelObject
    {
        private long _categoryID;
        private string _category;
        private string _comment;

        /*Section="Field-CategoryID"*/
        [OTRequired("Category ID", null)]
        [OTDisplayName("Category ID")]
        [DataMember]
        public long CategoryID
        {
            get
            {
                return _categoryID;
            }
            set
            {
                _categoryID = value;
            }
        }

        /*Section="Field-Category"*/
        [OTRequired("Category", null)]
        [OTStringLength(100)]
        [OTDisplayName("Category")]
        [DataMember]
        public string Category
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
            return _categoryID;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}