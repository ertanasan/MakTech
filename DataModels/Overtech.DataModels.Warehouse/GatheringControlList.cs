using Overtech.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Overtech.DataModels.Warehouse
{
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "GATHERINGCONTROLLIST", HasAutoIdentity = true, DisplayName = "GatheringControlList", IdField = "StoreOrderId")]
    [DataContract]
    public class GatheringControlList : DataModelObject
    {

        [OTDataField("STOREORDERID")]
        [DataMember]
        public long StoreOrderId { get; set; }

        [OTDataField("STORE_NM")]
        [DataMember]
        public string StoreName { get; set; }

        [OTDataField("ORDERCODE_NM")]
        [DataMember]
        public string OrderCodeName { get; set; }

        [OTDataField("ORDER_DT")]
        [DataMember]
        public DateTime OrderDate { get; set; }

        [OTDataField("SHIPMENT_DT")]
        [DataMember]
        public DateTime ShipmentDate { get; set; }

        [OTDataField("PRODUCT_CNT")]
        [DataMember]
        public int ProductCount { get; set; }

        [OTDataField("ORDERPRICE_AMT")]
        [DataMember]
        public decimal OrderPriceAmount { get; set; }

        [OTDataField("PALLET_CNT")]
        [DataMember]
        public int PalletCount { get; set; }

        [OTDataField("TYPE_CNT")]
        [DataMember]
        public int TypeCount { get; set; }

        [OTDataField("GATHEREDTYPE_CNT")]
        [DataMember]
        public int GatheredTypeCount { get; set; }

        [OTDataField("GATHERINGPRICE_AMT")]
        [DataMember]
        public decimal GatheringPriceAmount { get; set; }

        [OTDataField("GATHEREDPRODUCT_CNT")]
        [DataMember]
        public int GatheredProductCount { get; set; }

        [OTDataField("CONTROLPALLET_CNT")]
        [DataMember]
        public int ControlPalletCount { get; set; }

        [OTDataField("CONTROLLEDPALLET_CNT")]
        [DataMember]
        public int ControlledPalletCount { get; set; }

        [OTDataField("CONTROLPRICE_AMT")]
        [DataMember]
        public decimal ControlPriceAmount { get; set; }

        [OTDataField("CONTROLLEDPRODUCT_CNT")]
        [DataMember]
        public int ControlledProductCount { get; set; }

        [OTDataField("ADDRESS_TXT")]
        [DataMember]
        public string StoreAddress { get; set; }

        [OTDataField("STATUS")]
        [DataMember]
        public int Status { get; set; }

        [OTDataField("GATHERINGSTATUS_CD")]
        [DataMember]
        public int GatheringStatus { get; set; }

        public override void SetId(long id) { }
    }
}
