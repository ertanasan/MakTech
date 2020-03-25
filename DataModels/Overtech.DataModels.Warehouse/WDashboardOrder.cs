using Overtech.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Overtech.DataModels.Warehouse
{
    [OTDataObject]
    [DataContract]
    public class WDashboardOrder : DataModelObject
    {
        [DataMember]
        public WDWidgetData WidgetData { get; set; }

        [DataMember]
        public IList<WDGatheringDifference> GatheringDifferences { get; set; }

        [DataMember]
        public IList<OrderTrend> OrderTrend { get; set; }
        public override void SetId(long id) { }
    }

    [OTDataObject]
    [DataContract]
    public class WDWidgetData : DataModelObject
    {
        [OTDataField("HEAVYORDERPRICE_AMT")]
        [DataMember]
        public decimal HeavyOrderAmount { get; set; }

        [OTDataField("LIGHTORDERPRICE_AMT")]
        [DataMember]
        public decimal LightOrderAmount { get; set; }

        [OTDataField("HEAVYGATHEREDPRICE_AMT")]
        [DataMember]
        public decimal HeavyGatheredAmount { get; set; }

        [OTDataField("LIGHTGATHEREDPRICE_AMT")]
        [DataMember]
        public decimal LightGatheredAmount { get; set; }

        [OTDataField("HEAVYORDERPACKAGE_QTY")]
        [DataMember]
        public decimal HeavyOrderPackage { get; set; }

        [OTDataField("LIGHTORDERPACKAGE_QTY")]
        [DataMember]
        public decimal LightOrderPackage { get; set; }

        [OTDataField("HEAVYGATHEREDPACKAGE_QTY")]
        [DataMember]
        public decimal HeavyGatheredPackage { get; set; }

        [OTDataField("LIGHTGATHEREDPACKAGE_QTY")]
        [DataMember]
        public decimal LightGatheredPackage { get; set; }

        [OTDataField("NOTGATHEREDHEAVYPRODUCT_CNT")]
        [DataMember]
        public int NonGatheredHeavyProduct { get; set; }

        [OTDataField("HEAVYPRODUCT_CNT")]
        [DataMember]
        public int HeavyProductCount { get; set; }

        [OTDataField("NOTGATHEREDLIGHTPRODUCT_CNT")]
        [DataMember]
        public int NonGatheredLightProduct { get; set; }

        [OTDataField("LIGHTPRODUCT_CNT")]
        [DataMember]
        public int LightProductCount { get; set; }

        public override void SetId(long id) { }
    }

    [OTDataObject]
    [DataContract]
    public class WDGatheringDifference : DataModelObject
    {
        [OTDataField("PRODUCTCODE")]
        [DataMember]
        public string ProductCode { get; set; }

        [OTDataField("PRODUCTNAME")]
        [DataMember]
        public string ProductName { get; set; }

        [OTDataField("CURRENTSROCK")]
        [DataMember]
        public decimal CurrentStock { get; set; }

        [OTDataField("NOTGATHEREDSTORE_CNT")]
        [DataMember]
        public int NotGatheredStoreCount { get; set; }

        [OTDataField("GATHEREDSTORE_CNT")]
        [DataMember]
        public int GatheredStoreCount { get; set; }

        [OTDataField("NOTGATHEREDSTORE_RATE")]
        [DataMember]
        public decimal NotGatheredStoreRate { get; set; }

        [OTDataField("NOTGATHERED_QTY")]
        [DataMember]
        public decimal NotGatheredQuantity { get; set; }

        [OTDataField("GATHERED_QTY")]
        [DataMember]
        public decimal GatheredQuantity { get; set; }

        public override void SetId(long id) { }
    }

    [OTDataObject]
    [DataContract]
    public class OrderTrend : DataModelObject
    {
        [OTDataField("GATHER_DT")]
        [DataMember]
        public DateTime GatherDate { get; set; }

        [OTDataField("ORDER_QTY")]
        [DataMember]
        public decimal OrderQuantity { get; set; }

        [OTDataField("SHIPPED_QTY")]
        [DataMember]
        public decimal ShippedQuantity { get; set; }

        public override void SetId(long id) { }
    }
}
