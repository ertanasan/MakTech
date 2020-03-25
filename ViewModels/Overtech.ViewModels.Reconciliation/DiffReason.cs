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
namespace Overtech.ViewModels.Reconciliation
{
    [OTDisplayName("Diff Reason")]
    [DataContract]
    public class DiffReason : ViewModelObject
    {
        private long _diffReasonId;
        private string _reasonName;
        private bool _shortFlag;

        /*Section="Field-DiffReasonId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Diff Reason Id", null)]
        [OTDisplayName("Diff Reason Id")]
        [DataMember]
        public long DiffReasonId
        {
            get
            {
                return _diffReasonId;
            }
            set
            {
                _diffReasonId = value;
            }
        }

        /*Section="Field-ReasonName"*/
        [OTRequired("Reason Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Reason Name")]
        [DataMember]
        public string ReasonName
        {
            get
            {
                return _reasonName;
            }
            set
            {
                _reasonName = value;
            }
        }

        /*Section="Field-ShortFlag"*/
        [OTDisplayName("Short Flag")]
        [DataMember]
        public bool ShortFlag
        {
            get
            {
                return _shortFlag;
            }
            set
            {
                _shortFlag = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _diffReasonId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}