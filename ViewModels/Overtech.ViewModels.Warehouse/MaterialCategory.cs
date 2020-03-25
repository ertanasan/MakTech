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
namespace Overtech.ViewModels.Warehouse
{
    [OTDisplayName("Material Category")]
    [DataContract]
    public class MaterialCategory : ViewModelObject
    {
        private long _materialCategoryId;
        private string _categoryName;

        /*Section="Field-MaterialCategoryId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Material Category Id", null)]
        [OTDisplayName("Material Category Id")]
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
        [OTRequired("Category Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Category Name")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _materialCategoryId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}