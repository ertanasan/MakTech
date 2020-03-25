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
namespace Overtech.DataModels.Warehouse
{
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "RETURNREASON", HasAutoIdentity = true, DisplayName = "Return Reason", IdField = "ReturnReasonId")]
    [DataContract]
    public class ReturnReason : DataModelObject
    {
        private long _returnReasonId;
        private string _reasonName;
        private Nullable<long> _parent;

        /*Section="Field-ReturnReasonId"*/
        [OTDataField("RETURNREASONID")]
        [DataMember]
        public long ReturnReasonId
        {
            get
            {
                return _returnReasonId;
            }
            set
            {
                _returnReasonId = value;
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

        /*Section="Field-Parent"*/
        [OTDataField("PARENT", Nullable = true)]
        [DataMember]
        public Nullable<long> Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _returnReasonId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

