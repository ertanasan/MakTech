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
namespace Overtech.ViewModels.Helpdesk
{
    [OTDisplayName("Request Status")]
    [DataContract]
    public class RequestStatus : ViewModelObject
    {
        private long _requestStatusId;
        private string _statusName;

        /*Section="Field-RequestStatusId"*/
        [OTRequired("Request Status Id", null)]
        [OTDisplayName("Request Status Id")]
        [DataMember]
        public long RequestStatusId
        {
            get
            {
                return _requestStatusId;
            }
            set
            {
                _requestStatusId = value;
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
            return _requestStatusId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}