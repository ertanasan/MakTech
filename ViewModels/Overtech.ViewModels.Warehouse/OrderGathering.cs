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
    public class OrderGathering : ViewModelObject
    {
        [DataMember]
        public string ProductCodeName { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public decimal OrderQuantity { get; set; }

        [DataMember]
        public int PalletNo { get; set; }

        [DataMember]
        public string GatheringUserName { get; set; }

        [DataMember]
        public DateTime GatheringTime { get; set; }

        [DataMember]
        public decimal GatheredQuantity { get; set; }

        [DataMember]
        public int GatheringStatus { get; set; }

        [DataMember]
        public string ControlUserName { get; set; }

        [DataMember]
        public DateTime ControlTime { get; set; }

        [DataMember]
        public decimal ControlQuantity { get; set; }

        [DataMember]
        public int ControlStatus { get; set; }

        [DataMember]
        public int ProcessStatus { get; set; }

        [DataMember]
        public string UnitName { get; set; }

        [DataMember]
        public string Barcode { get; set; }

        [DataMember]
        public int ShippedQuantity { get; set; }

        [DataMember]
        public int STATUS { get; set; }
        public override long GetId() { return 1; }
    }
}
