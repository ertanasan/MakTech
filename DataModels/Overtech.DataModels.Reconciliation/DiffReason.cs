// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Overtech.Core.Data;

/*Section="ClassHeader"*/
namespace Overtech.DataModels.Reconciliation
{
    [OTDataObject(Module = "Reconciliation", ModuleShortName = "RCL", Table = "DIFFREASON", HasAutoIdentity = true, DisplayName = "Diff Reason", IdField = "DiffReasonId")]
    [DataContract]
    public class DiffReason : DataModelObject
    {
        private long _diffReasonId;
        private string _reasonName;
        private bool _shortFlag;

        /*Section="Field-DiffReasonId"*/
        [OTDataField("DIFFREASONID")]
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
        [OTDataField("REASON_NM")]
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
        [OTDataField("SHORT_FL")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _diffReasonId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

