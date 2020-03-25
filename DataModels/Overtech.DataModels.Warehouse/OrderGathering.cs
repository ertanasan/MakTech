using Overtech.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Overtech.DataModels.Warehouse
{
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "ORDERGATHERING", HasAutoIdentity = true, DisplayName = "OrderGathering", IdField = "ProductCodeName")]
    [DataContract]
    public class OrderGathering : DataModelObject
    {
        
        [OTDataField("PRODUCTCODE_NM")]
        [DataMember]
        public string ProductCodeName { get; set; }

        [OTDataField("PRODUCT_NM")]
        [DataMember]
        public string ProductName { get; set; }

        [OTDataField("ORDER_QTY")]
        [DataMember]
        public decimal OrderQuantity { get; set; }

        [OTDataField("PALLET_NO")]
        [DataMember]
        public int PalletNo { get; set; }

        [OTDataField("GATHERINGUSER_NM")]
        [DataMember]
        public string GatheringUserName { get; set; }

        [OTDataField("GATHERING_TM")]
        [DataMember]
        public DateTime GatheringTime { get; set; }

        [OTDataField("GATHERED_QTY")]
        [DataMember]
        public decimal GatheredQuantity { get; set; }

        [OTDataField("GATHERINGSTATUS")]
        [DataMember]
        public int GatheringStatus { get; set; }

        [OTDataField("CONTROLUSER_NM")]
        [DataMember]
        public string ControlUserName { get; set; }

        [OTDataField("CONTROL_TM")]
        [DataMember]
        public DateTime ControlTime { get; set; }

        [OTDataField("CONTROL_QTY")]
        [DataMember]
        public decimal ControlQuantity { get; set; }

        [OTDataField("GATHERINGPALLETSTATUS")]
        [DataMember]
        public int ControlStatus { get; set; }

        [OTDataField("PROCESSSTATUS")]
        [DataMember]
        public int ProcessStatus { get; set; }

        [OTDataField("UNITNAME", IsExtended =true)]
        [DataMember]
        public string UnitName { get; set; }

        [OTDataField("BARCODE_TXT", IsExtended = true)]
        [DataMember]
        public string Barcode { get; set; }

        [OTDataField("SHIPPED_QTY", IsExtended = true)]
        [DataMember]
        public int ShippedQuantity { get; set; }

        [OTDataField("STATUS", IsExtended = true)]
        [DataMember]
        public int STATUS { get; set; }

        public override void SetId(long id) { }
    }
}
