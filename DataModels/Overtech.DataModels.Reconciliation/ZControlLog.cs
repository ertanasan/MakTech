using System;
using System.Runtime.Serialization;
using Overtech.Core.Data;

namespace Overtech.DataModels.Reconciliation
{
    [OTDataObject(Module = "Reconciliation", ModuleShortName = "RCL", Table = "ZCONTROLLOG", HasAutoIdentity = true, DisplayName = "Z Control Log", IdField = "ZControlLogId")]
    [DataContract]
    public class ZControlLog : DataModelObject
    {
        long _zControlLogId;

        [OTDataField("ZCONTROLLOGID")]
        [DataMember]
        public long ZControlLogId { get; set; }

        [OTDataField("CREATE_DT")]
        [DataMember]
        public DateTime CreateDate { get; set; }

        [OTDataField("CREATEUSER")]
        [DataMember]
        public int CreateUser { get; set; }

        [OTDataField("STORE")]
        [DataMember]
        public int Store { get; set; }

        [OTDataField("RECONCILIATION_DT")]
        [DataMember]
        public DateTime ReconciliationDate { get; set; }

        [OTDataField("ZET_AMT")]
        [DataMember]
        public decimal ZetAmount { get; set; }

        public override void SetId(long id)
        {
            _zControlLogId = id;
        }
    }
}