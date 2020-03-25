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
namespace Overtech.ViewModels.Warehouse
{
    [OTDisplayName("Return Reason")]
    [DataContract]
    public class ReturnReason : ViewModelObject
    {
        private long _returnReasonId;
        private string _reasonName;
        private Nullable<long> _parent;

        /*Section="Field-ReturnReasonId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Return Reason Id", null)]
        [OTDisplayName("Return Reason Id")]
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

        /*Section="Field-Parent"*/
        [UIHint("ReturnReasonList")]
        [OTDisplayName("Parent")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _returnReasonId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}