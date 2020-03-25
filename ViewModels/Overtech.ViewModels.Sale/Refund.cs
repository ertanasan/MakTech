using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Overtech.Core.Data;
using Overtech.UI.Data.Annotations;

namespace Overtech.ViewModels.Sale
{
    [OTDisplayName("Refund")]
    [DataContract]
    public class Refund : ViewModelObject
    {

        private long _saleDetailId;

        [DataMember]
        public long SaleDetailId { get { return _saleDetailId; } set { _saleDetailId = value; } }

        [DataMember]
        public DateTime TransactionDate { get; set; }

        [DataMember]
        public DateTime TransactionTime { get; set; }

        [DataMember]
        public string TransactionText { get; set; }

        [DataMember]
        public int Unit { get; set; }

        [DataMember]
        public decimal Quantity { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public string RefundDescription { get; set; }

        public override long GetId()
        {
            return _saleDetailId;
        }
    }
}
