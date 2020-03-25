using System;
using System.Runtime.Serialization;
using Overtech.Core.Data;

namespace Overtech.DataModels.Reconciliation
{
    [OTDataObject(Module = "Reconciliation", ModuleShortName = "RCL", Table = "RECLOG", HasAutoIdentity = true, DisplayName = "Rec Log", IdField = "Id")]
    [DataContract]
    public class RecLog : DataModelObject
    {
        long _id;

        [OTDataField("LOG_DT")]
        [DataMember]
        public DateTime LogDate
        {
            get; set;
        }

        /*Section="Field-Event"*/
        [OTDataField("LOGUSER_NM")]
        [DataMember]
        public string LogUserName
        {
            get; set;
        }

        /*Section="Field-Organization"*/
        [OTDataField("STEP_TXT")]
        [DataMember]
        public string StepText
        {
            get; set;
        }

        public override void SetId(long id)
        {
            _id = id;
        }
    }
}