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
    [OTDisplayName("Product Property")]
    [DataContract]
    public class ProductProperty : ViewModelObject
    {
        private long _productPropertyId;
        private long _propertyType;
        private long _product;
        private string _value;

        /*Section="Field-ProductPropertyId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Product Property Id", null)]
        [OTDisplayName("Product Property Id")]
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
        [UIHint("PropertyTypeList")]
        [OTRequired("Property Type", null)]
        [OTDisplayName("Property Type")]
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
        [UIHint("ProductList")]
        [OTRequired("Product", null)]
        [OTDisplayName("Product")]
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
        [OTRequired("Value", null)]
        [OTDisplayName("Value")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _productPropertyId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}