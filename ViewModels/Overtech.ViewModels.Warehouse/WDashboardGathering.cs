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
    public class WDashboardGathering : ViewModelObject
    {
        [DataMember]
        public WDGatherPerformanceSummary WidgetData { get; set; }

        [DataMember]
        public IEnumerable<WDGatheringTrend> GatheringTrend { get; set; }

        public override long GetId() { return 1; }
    }

    [OTDataObject]
    [DataContract]
    public class WDGatherPerformanceSummary : ViewModelObject
    {
        [DataMember]
        public decimal TodayQty { get; set; }

        [DataMember]
        public decimal TheDayLastWeekUntilNowQty { get; set; }

        [DataMember]
        public decimal YesterdayQty { get; set; }

        [DataMember]
        public decimal DailyAvgQty { get; set; }

        [DataMember]
        public decimal TodaySecondsPerKg { get; set; }

        [DataMember]
        public decimal AvgSecondsPerKg { get; set; }

        [DataMember]
        public int TodayErrorCnt { get; set; }

        [DataMember]
        public int AvgErrorCnt { get; set; }

        public override long GetId() { return 1; }
    }

    public class WDGatheringTrend : ViewModelObject
    {
        [DataMember]
        public int GatherUserId { get; set; }

        [DataMember]
        public string GatherUserName { get; set; }

        [DataMember]
        public DateTime GatherDate { get; set; }

        [DataMember]
        public decimal GatherQuantity { get; set; }

        [DataMember]
        public decimal ControlErrorCount { get; set; }

        [DataMember]
        public decimal ControlDiffPackage { get; set; }

        [DataMember]
        public decimal GatherPackage { get; set; }

        public override long GetId() { return 1; }
    }

}
