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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "PRODUCTIONCONTENT", HasAutoIdentity = true, DisplayName = "Production Content", IdField = "ProductionContentId")]
    [DataContract]
    public class ProductionContent : DataModelObject
    {
        private long _productionContentId;
        private long _production;
        private long _product;
        private decimal _shareRate;

        /*Section="Field-ProductionContentId"*/
        [OTDataField("PRODUCTIONCONTENTID")]
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
        [OTDataField("PRODUCTION")]
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
        [OTDataField("PRODUCT")]
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
        [OTDataField("SHARE_RT")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _productionContentId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized

        [OTDataField("PRODUCTCODE_NM", IsExtended = true)]
        [DataMember]
        public string ProductCode { get; set; }

        [OTDataField("PRODUCT_NM", IsExtended = true)]
        [DataMember]
        public string ProductName { get; set; }

        [OTDataField("MAINWAREHOUSESTOCK", IsExtended = true)]
        [DataMember]
        public decimal MainWarehouseStock { get; set; }

        [OTDataField("PRODUCTIONWAREHOUSESTOCK", IsExtended = true)]
        [DataMember]
        public decimal ProductionWarehouseStock { get; set; }

        [OTDataField("UNITWEIGHT", IsExtended = true)]
        [DataMember]
        public string UnitWeightStr { get; set; }

        [OTDataField("UNITCOST", IsExtended = true)]
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

