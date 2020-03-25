using System;
using System.Runtime.Serialization;
using Overtech.Core.Data;
using Overtech.UI.Data.Annotations;

/*Section="ClassHeader"*/
namespace Overtech.ViewModels.Reconciliation
{
    [OTDisplayName("Reconciliation Log")]
    [DataContract]
    public class RecLog : ViewModelObject
    {
        long _id;

        [DataMember]
        public DateTime LogDate
        {
            get; set;
        }

        [DataMember]
        public string LogUserName
        {
            get; set;
        }

        [DataMember]
        public string StepText
        {
            get; set;
        }

        public override long GetId()
        {
            return _id;
        }
    }
}