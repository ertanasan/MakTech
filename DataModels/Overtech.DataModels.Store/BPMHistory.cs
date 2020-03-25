using Overtech.Core.Data;
using System;
using System.Runtime.Serialization;

namespace Overtech.DataModels.Store
{
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "BPMHistory", HasAutoIdentity = false, DisplayName = "BPMHistory", IdField = "BPMHistoryId")]
    [DataContract]
    public class BPMHistory : DataModelObject
    {
        [OTDataField("CREATE_DT", IsExtended = true)]
        [DataMember]
        public DateTime CreateDate { get; set; }

        [OTDataField("START_TM", IsExtended = true)]
        [DataMember]
        public DateTime StartTime { get; set; }

        [OTDataField("FINISH_TM", IsExtended = true)]
        [DataMember]
        public DateTime FinishTime { get; set; }

        [OTDataField("PERFORMER", IsExtended = true)]
        [DataMember]
        public int Performer { get; set; }

        [OTDataField("ACTIONSTATUS_CD", IsExtended = true)]
        [DataMember]
        public int ActionStatusCode { get; set; }

        [OTDataField("PROCESSSTATUS_CD", IsExtended = true)]
        [DataMember]
        public int ProcessStatusCode { get; set; }

        [OTDataField("CHOICE_TXT", IsExtended = true)]
        [DataMember]
        public string Choice { get; set; }

        [OTDataField("USERCOMMENT_DSC", IsExtended = true)]
        [DataMember]
        public string ActionComment { get; set; }

        [OTDataField("PROCESSDEFINITION_NM", IsExtended = true)]
        [DataMember]
        public string ProcessDefinitionName { get; set; }

        [OTDataField("ACTIVITY_NM", IsExtended = true)]
        [DataMember]
        public string ActivityName { get; set; }

        [OTDataField("ACTIVITYTYPE_NM", IsExtended = true)]
        [DataMember]
        public string ActivityTypeName { get; set; }

        [OTDataField("ACTIVITY_NO", IsExtended = true)]
        [DataMember]
        public int ActivityNo { get; set; }

        [OTDataField("ACTIVITYSTATUS_CD", IsExtended = true)]
        [DataMember]
        public string ActivityStatusCode { get; set; }

        [OTDataField("PERFORMER_NM", IsExtended = true)]
        [DataMember]
        public string PerformerName { get; set; }

        [OTDataField("TARGETSCOPE_NM", IsExtended = true)]
        [DataMember]
        public string TargetScopeName { get; set; }

        [OTDataField("TARGET_NM", IsExtended = true)]
        [DataMember]
        public string TargetName { get; set; }

        public override void SetId(long id) { }

    }
}


