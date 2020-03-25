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
    [OTDisplayName("Return Status")]
    [DataContract]
    public class ReturnStatus : ViewModelObject
    {
        private long _returnStatusId;
        private string _statusName;

        /*Section="Field-ReturnStatusId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Return Status Id", null)]
        [OTDisplayName("Return Status Id")]
        [DataMember]
        public long ReturnStatusId
        {
            get
            {
                return _returnStatusId;
            }
            set
            {
                _returnStatusId = value;
            }
        }

        /*Section="Field-StatusName"*/
        [OTRequired("Status Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Status Name")]
        [DataMember]
        public string StatusName
        {
            get
            {
                return _statusName;
            }
            set
            {
                _statusName = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _returnStatusId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}