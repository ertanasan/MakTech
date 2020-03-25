using Overtech.Core.Data;
using Overtech.UI.Data.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Overtech.ViewModels.Warehouse
{
    public class WDashboardOrder : ViewModelObject
    {
        [DataMember]
        public WDWidgetData WidgetData { get; set; }

        [DataMember]
        public IList<WDGatheringDifference> GatheringDifferences { get; set; }


        [DataMember]
        public IList<OrderTrend> OrderTrend { get; set; }

        public override long GetId() { return 1; }
    }

    public class WDWidgetData : ViewModelObject
    {
        [DataMember]
        public decimal HeavyOrderAmount { get; set; }

        [DataMember]
        public decimal LightOrderAmount { get; set; }

        [DataMember]
        public decimal HeavyGatheredAmount { get; set; }

        [DataMember]
        public decimal LightGatheredAmount { get; set; }

        [DataMember]
        public decimal HeavyOrderPackage { get; set; }

        [DataMember]
        public decimal LightOrderPackage { get; set; }

        [DataMember]
        public decimal HeavyGatheredPackage { get; set; }

        [DataMember]
        public decimal LightGatheredPackage { get; set; }

        [DataMember]
        public int NonGatheredHeavyProduct { get; set; }

        [DataMember]
        public int HeavyProductCount { get; set; }

        [DataMember]
        public int NonGatheredLightProduct { get; set; }

        [DataMember]
        public int LightProductCount { get; set; }

        public override long GetId() { return 1; }
    }

    public class WDGatheringDifference : ViewModelObject
    {
        [DataMember]
        public string ProductCode { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public decimal CurrentStock { get; set; }

        [DataMember]
        public int NotGatheredStoreCount { get; set; }

        [DataMember]
        public int GatheredStoreCount { get; set; }

        [DataMember]
        public decimal NotGatheredStoreRate { get; set; }

        [DataMember]
        public decimal NotGatheredQuantity { get; set; }

        [DataMember]
        public decimal GatheredQuantity { get; set; }

        public override long GetId() { return 1; }
    }

    public class OrderTrend : ViewModelObject
    {
        [DataMember]
        public DateTime GatherDate { get; set; }

        [DataMember]
        public decimal ShippedQuantity { get; set; }

        [DataMember]
        public decimal OrderQuantity { get; set; }

        public override long GetId() { return 1; }
    }
}
