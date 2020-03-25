using Overtech.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Overtech.DataModels.Warehouse
{
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "WAREHOUSEDASHBOARD", HasAutoIdentity = true, DisplayName = "WarehouseDashboard", IdField = "GatheringId")]
    [DataContract]
    public class ControlDBList : DataModelObject
    {
        [OTDataField("GATHERINGTYPE")]
        [DataMember]
        public int GatheringType { get; set; }

        [OTDataField("CONTROLUSER")]
        [DataMember]
        public int ControlUser { get; set; }

        [OTDataField("USERFULL_NM")]
        [DataMember]
        public string ControlUserName { get; set; }

        [OTDataField("CONTROLPALLET_CNT")]
        [DataMember]
        public int ControlPalletCount { get; set; }

        [OTDataField("CONTROLLEDPALLET_CNT")]
        [DataMember]
        public int ControlledPalletCount { get; set; }

        public override void SetId(long id) { }
    }

    [DataContract]
    public class GatheringDBList : DataModelObject
    {
        [OTDataField("GATHERINGTYPE")]
        [DataMember]
        public int GatheringType { get; set; }

        [OTDataField("USERFULL_NM")]
        [DataMember]
        public string GatheringUserName { get; set; }

        [OTDataField("GATHEREDWEIGHT")]
        [DataMember]
        public decimal GatheredWeight { get; set; }

        [OTDataField("GATHEREDPALLET_CNT")]
        [DataMember]
        public int GatheredPalletCount { get; set; }

        [OTDataField("ORDER_CNT")]
        [DataMember]
        public int OrderCount { get; set; }

        [OTDataField("GATHEREDPACKAGE_QTY")]
        [DataMember]
        public decimal GatheredPackage { get; set; }

        public override void SetId(long id) { }
    }

    [DataContract]
    public class OrderDBList : DataModelObject
    {
        [OTDataField("STOREORDERID")]
        [DataMember]
        public long StoreOrderId { get; set; }

        [OTDataField("STATUS")]
        [DataMember]
        public int Status { get; set; }

        [OTDataField("STORE")]
        [DataMember]
        public int Store { get; set; }

        [OTDataField("ORDER_DT")]
        [DataMember]
        public DateTime OrderDate { get; set; }

        [OTDataField("SHIPMENT_DT")]
        [DataMember]
        public DateTime ShipmentDate { get; set; }

        [OTDataField("OLDORDER_FL")]
        [DataMember]
        public Boolean OldOrderFlag { get; set; }

        [OTDataField("ORDERWEIGHT")]
        [DataMember]
        public decimal OrderWeight { get; set; }

        [OTDataField("HEAVYORDERWEIGHT")]
        [DataMember]
        public decimal HeavyOrderWeight { get; set; }

        [OTDataField("LIGHTORDERWEIGHT")]
        [DataMember]
        public decimal LightOrderWeight { get; set; }

        [OTDataField("HEAVYGATHEREDWEIGHT")]
        [DataMember]
        public decimal HeavyGatheredWeight { get; set; }

        [OTDataField("LIGHTGATHEREDWEIGHT")]
        [DataMember]
        public decimal LightGatheredWeight { get; set; }

        [OTDataField("WAITINGHEAVYORDER_CNT")]
        [DataMember]
        public int WaitingHeavyOrderCount { get; set; }

        [OTDataField("WAITINGLIGHTORDER_CNT")]
        [DataMember]
        public int WaitingLightOrderCount { get; set; }

        [OTDataField("WAITINGHEAVYCONTROLPALLET_CNT")]
        [DataMember]
        public int WaitingHeavyControlPalletCount { get; set; }

        [OTDataField("WAITINGLIGHTCONTROLPALLET_CNT")]
        [DataMember]
        public int WaitingLightControlPalletCount { get; set; }

        [OTDataField("ORDERPRICE")]
        [DataMember]
        public decimal OrderPrice { get; set; }

        public override void SetId(long id) { }
    }
    
    [DataContract]
    public class WHDashboard : DataModelObject
    {

        [DataMember]
        public IList<OrderDBList> OrderList { get; set; }

        [DataMember]
        public IList<GatheringDBList> GatheringList { get; set; }

        [DataMember]
        public IList<ControlDBList> ControlList { get; set; }
        public override void SetId(long id) { }
    }

}
