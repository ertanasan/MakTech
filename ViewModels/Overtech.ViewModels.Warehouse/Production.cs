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
    [OTDisplayName("Production")]
    [DataContract]
    public class Production : ViewModelObject
    {
        private long _productionId;
        private long _product;

        /*Section="Field-ProductionId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Production Id", null)]
        [OTDisplayName("Production Id")]
        [DataMember]
        public long ProductionId
        {
            get
            {
                return _productionId;
            }
            set
            {
                _productionId = value;
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _productionId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public string ProductName { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}