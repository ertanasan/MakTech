using Overtech.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Overtech.DataModels.Sale
{
    [OTDataObject(Module = "Sale", ModuleShortName = "SLS", Table = "REFUND", HasAutoIdentity = false, DisplayName = "Refund", IdField = "SaleDetailId")]
    [DataContract]
    public class Refund : DataModelObject
    {
        [OTDataField("SALEDETAILID")]
        [DataMember]
        public long SaleDetailId { get; set; }

        [OTDataField("TRANSACTION_DT")]
        [DataMember]
        public DateTime TransactionDate { get; set; }

        [OTDataField("TRANSACTION_TM")]
        [DataMember]
        public DateTime TransactionTime { get; set; }

        [OTDataField("TRANSACTION_TXT")]
        [DataMember]
        public string TransactionText { get; set; }

        [OTDataField("UNIT")]
        [DataMember]
        public int Unit { get; set; }

        [OTDataField("QUANTITY_QTY")]
        [DataMember]
        public decimal Quantity { get; set; }

        [OTDataField("PRICE")]
        [DataMember]
        public decimal Price { get; set; }

        [OTDataField("TRAN_DSC")]
        [DataMember]
        public string RefundDescription { get; set; }

        public override void SetId(long id) { }
    }
}
