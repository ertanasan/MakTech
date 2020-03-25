using System;
using System.Runtime.Serialization;
using Overtech.Core.Data;
using Overtech.UI.Data.Annotations;

namespace Overtech.ViewModels.Reconciliation
{
    [OTDisplayName("ZControlLog")]
    [DataContract]
    public class ZControlLog : ViewModelObject
    {
        private long _zControlLogId;
        
        [DataMember]
        public long ZControlLogId { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public int CreateUser { get; set; }

        [DataMember]
        public int Store { get; set; }

        [DataMember]
        public DateTime ReconciliationDate { get; set; }
        
        [DataMember]
        public decimal ZetAmount { get; set; }

        public override long GetId()
        {
            return _zControlLogId;
        }
    }
}