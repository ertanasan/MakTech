using System.Data;
using System.Runtime.Serialization;

using Overtech.Core.Data;

namespace Overtech.DataModels.Price
{
    [DataContract]
    public class PackagePerformance: DataModelObject
    {
        public override void SetId(long id)
        {
        }

        [OTDataField("PackageId", IsExtended = true)]
        [DataMember]
        public long PackageId
        {
            get; set;
        }

        [OTDataField("SaleChangePercentage", IsExtended = true)]
        [DataMember]
        public float SaleChangePercentage
        {
            get; set;
        }

        [OTDataField("PriceChangePercentage", IsExtended = true)]
        [DataMember]
        public float PriceChangePercentage
        {
            get; set;
        }

        [OTDataField("ProductCount", IsExtended = true)]
        [DataMember]
        public int ProductCount
        {
            get; set;
        }

        [OTDataField("PerformanceDetailsGrid", IsExtended = true)]
        [DataMember]
        public DataTable PerformanceDetailsGrid
        {
            get; set;
        }
    }
}