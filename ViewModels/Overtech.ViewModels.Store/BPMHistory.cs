// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Overtech.Core.Data;
using Overtech.UI.Data.Annotations;

/*Section="ClassHeader"*/
namespace Overtech.ViewModels.Store
{
    [OTDisplayName("BPMHistory")]
    [DataContract]
    public class BPMHistory : ViewModelObject
    {
        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public DateTime StartTime { get; set; }

        [DataMember]
        public DateTime FinishTime { get; set; }

        [DataMember]
        public int Performer { get; set; }

        [DataMember]
        public int ActionStatusCode { get; set; }

        [DataMember]
        public int ProcessStatusCode { get; set; }

        [DataMember]
        public string Choice { get; set; }

        [DataMember]
        public string ActionComment { get; set; }

        [DataMember]
        public string ProcessDefinitionName { get; set; }

        [DataMember]
        public string ActivityName { get; set; }

        [DataMember]
        public string ActivityTypeName { get; set; }

        [DataMember]
        public int ActivityNo { get; set; }

        [DataMember]
        public string ActivityStatusCode { get; set; }

        [DataMember]
        public string PerformerName { get; set; }

        [DataMember]
        public string TargetScopeName { get; set; }

        [DataMember]
        public string TargetName { get; set; }

        public override long GetId() { return 0; }
    }

}