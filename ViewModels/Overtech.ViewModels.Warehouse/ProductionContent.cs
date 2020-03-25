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
    [OTDisplayName("Production Content")]
    [DataContract]
    public class ProductionContent : ViewModelObject
    {
        private long _productionContentId;
        private long _production;
        private long _product;
        private decimal _shareRate;

        /*Section="Field-ProductionContentId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Production Content Id", null)]
        [OTDisplayName("Production Content Id")]
        [DataMember]
        public long ProductionContentId
        {
            get
            {
                return _productionContentId;
            }
            set
            {
                _productionContentId = value;
            }
        }

        /*Section="Field-Production"*/
        [UIHint("ProductionList")]
        [OTRequired("Production", null)]
        [OTDisplayName("Production")]
        [DataMember]
        public long Production
        {
            get
            {
                return _production;
            }
            set
            {
                _production = value;
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

        /*Section="Field-ShareRate"*/
        [OTRequired("Share Rate", null)]
        [OTDisplayName("Share Rate")]
        [DataMember]
        public decimal ShareRate
        {
            get
            {
                return _shareRate;
            }
            set
            {
                _shareRate = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _productionContentId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public string ProductCode { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public decimal MainWarehouseStock { get; set; }

        [DataMember]
        public decimal ProductionWarehouseStock { get; set; }

        [DataMember]
        public string UnitWeightStr { get; set; }

        [DataMember]
        public decimal UnitCost { get; set; }

        [DataMember]
        public IEnumerable<decimal> UnitWeightList { get; set; }

        [DataMember]
        public decimal UnitWeight { get; set; }

        [DataMember]
        public int RequiredPackage { get; set; }

        [DataMember]
        public decimal AllocatedPackage { get; set; }

        [DataMember]
        public decimal AllocatedQuantity { get; set; }

        [DataMember]
        public decimal Remnant { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}