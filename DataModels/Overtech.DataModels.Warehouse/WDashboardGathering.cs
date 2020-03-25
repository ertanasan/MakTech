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
    public class WDashboardGathering : DataModelObject
    {
        [DataMember]
        public WDGatherPerformanceSummary WidgetData { get; set; }

        [DataMember]
        public IEnumerable<WDGatheringTrend> GatheringTrend { get; set; }

        public override void SetId(long id) { }
    }

    [OTDataObject]
    [DataContract]
    public class WDGatherPerformanceSummary : DataModelObject
    {
        [OTDataField("TODAY_QTY")]
        [DataMember]
        public decimal TodayQty { get; set; }

        [OTDataField("THEDAYLASTWEEKUNTILNOW_QTY")]
        [DataMember]
        public decimal TheDayLastWeekUntilNowQty { get; set; }

        [OTDataField("YESTERDAY_QTY")]
        [DataMember]
        public decimal YesterdayQty { get; set; }

        [OTDataField("DAILYAVG_QTY")]
        [DataMember]
        public decimal DailyAvgQty { get; set; }

        [OTDataField("TODAYSECONDSPERKG")]
        [DataMember]
        public decimal TodaySecondsPerKg { get; set; }

        [OTDataField("AVGSECONDSPERKG")]
        [DataMember]
        public decimal AvgSecondsPerKg { get; set; }

        [OTDataField("TODAYERROR_CNT")]
        [DataMember]
        public int TodayErrorCnt { get; set; }

        [OTDataField("DAILYAVGERROR_CNT")]
        [DataMember]
        public int AvgErrorCnt { get; set; }

        public override void SetId(long id) { }
    }

    [OTDataObject]
    [DataContract]
    public class WDGatheringTrend : DataModelObject
    {
        [OTDataField("GATHERUSERID")]
        [DataMember]
        public int GatherUserId { get; set; }

        [OTDataField("GATHERUSER_NM")]
        [DataMember]
        public string GatherUserName { get; set; }

        [OTDataField("GATHER_DT")]
        [DataMember]
        public DateTime GatherDate { get; set; }

        [OTDataField("GATHER_QTY")]
        [DataMember]
        public decimal GatherQuantity { get; set; }

        [OTDataField("CONTROLERR_CNT")]
        [DataMember]
        public decimal ControlErrorCount { get; set; }

        [OTDataField("CONTROLDIFF_CNT")]
        [DataMember]
        public decimal ControlDiffPackage { get; set; }

        [OTDataField("GATHERPACKAGE_QTY")]
        [DataMember]
        public decimal GatherPackage { get; set; }

        public override void SetId(long id) { }
    }

}
