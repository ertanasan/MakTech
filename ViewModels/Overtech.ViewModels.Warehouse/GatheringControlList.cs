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
    [OTDisplayName("GatheringControlList")]
    [DataContract]
    public class GatheringControlList : ViewModelObject
    {
        [DataMember]
        public long StoreOrderId { get; set; }

        [DataMember]
        public string StoreName { get; set; }

        [DataMember]
        public string OrderCodeName { get; set; }

        [DataMember]
        public DateTime OrderDate { get; set; }

        [DataMember]
        public DateTime ShipmentDate { get; set; }

        [DataMember]
        public int ProductCount { get; set; }

        [DataMember]
        public decimal OrderPriceAmount { get; set; }

        [DataMember]
        public int PalletCount { get; set; }

        [DataMember]
        public int TypeCount { get; set; }

        [DataMember]
        public int GatheredTypeCount { get; set; }

        [DataMember]
        public decimal GatheringPriceAmount { get; set; }

        [DataMember]
        public int GatheredProductCount { get; set; }

        [DataMember]
        public int ControlPalletCount { get; set; }

        [DataMember]
        public int ControlledPalletCount { get; set; }

        [DataMember]
        public decimal ControlPriceAmount { get; set; }

        [DataMember]
        public int ControlledProductCount { get; set; }

        [DataMember]
        public string StoreAddress { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public int GatheringStatus { get; set; }
        public override long GetId() { return 1; }
    }
}
