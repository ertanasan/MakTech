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
    [OTDisplayName("WarehouseDashboard")]
    public class ControlDBList : ViewModelObject
    {
        [DataMember]
        public int GatheringType { get; set; }

        [DataMember]
        public int ControlUser { get; set; }

        [DataMember]
        public string ControlUserName { get; set; }

        [DataMember]
        public int ControlPalletCount { get; set; }

        [DataMember]
        public int ControlledPalletCount { get; set; }

        public override long GetId() { return 1; }
    }

    [DataContract]
    public class GatheringDBList : ViewModelObject
    {
        [DataMember]
        public int GatheringType { get; set; }

        [DataMember]
        public string GatheringUserName { get; set; }

        [DataMember]
        public decimal GatheredWeight { get; set; }

        [DataMember]
        public int GatheredPalletCount { get; set; }

        [DataMember]
        public int OrderCount { get; set; }

        [DataMember]
        public decimal GatheredPackage { get; set; }

        public override long GetId() { return 1; }

    }

    [DataContract]
    public class OrderDBList : ViewModelObject
    {
        [DataMember]
        public long StoreOrderId { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public int Store { get; set; }

        [DataMember]
        public DateTime OrderDate { get; set; }

        [DataMember]
        public DateTime ShipmentDate { get; set; }

        [DataMember]
        public Boolean OldOrderFlag { get; set; }

        [DataMember]
        public decimal OrderWeight { get; set; }

        [DataMember]
        public decimal HeavyOrderWeight { get; set; }

        [DataMember]
        public decimal LightOrderWeight { get; set; }

        [DataMember]
        public decimal HeavyGatheredWeight { get; set; }

        [DataMember]
        public decimal LightGatheredWeight { get; set; }

        [DataMember]
        public int WaitingHeavyOrderCount { get; set; }

        [DataMember]
        public int WaitingLightOrderCount { get; set; }

        [DataMember]
        public int WaitingHeavyControlPalletCount { get; set; }

        [DataMember]
        public int WaitingLightControlPalletCount { get; set; }

        [DataMember]
        public decimal OrderPrice { get; set; }
        public override long GetId() { return 1; }

    }

    [DataContract]
    public class WHDashboard : ViewModelObject
    {

        [DataMember]
        public IList<OrderDBList> OrderList { get; set; }

        [DataMember]
        public IList<GatheringDBList> GatheringList { get; set; }

        [DataMember]
        public IList<ControlDBList> ControlList { get; set; }
        public override long GetId() { return 1; }

    }

}
