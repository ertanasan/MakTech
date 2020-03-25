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
    [OTDisplayName("Product Stock Group")]
    [DataContract]
    public class ProductStockGroup : ViewModelObject
    {
        private long _product;
        private long _stockGroup;
        private long _stockGroupId;

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

        /*Section="Field-StockGroup"*/
        [UIHint("StockGroupNameList")]
        [OTRequired("Stock Group", null)]
        [OTDisplayName("Stock Group")]
        [DataMember]
        public long StockGroup
        {
            get
            {
                return _stockGroup;
            }
            set
            {
                _stockGroup = value;
            }
        }

        /*Section="Field-StockGroupId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Stock Group Id", null)]
        [OTDisplayName("Stock Group Id")]
        [DataMember]
        public long StockGroupId
        {
            get
            {
                return _stockGroupId;
            }
            set
            {
                _stockGroupId = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _stockGroupId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}