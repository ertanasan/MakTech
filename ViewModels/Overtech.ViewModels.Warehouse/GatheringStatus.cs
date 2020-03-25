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
    [OTDisplayName("Gathering Status")]
    [DataContract]
    public class GatheringStatus : ViewModelObject
    {
        private long _gatheringStatusId;
        private string _statusName;

        /*Section="Field-GatheringStatusId"*/
        [OTRequired("Gathering Status Id", null)]
        [OTDisplayName("Gathering Status Id")]
        [DataMember]
        public long GatheringStatusId
        {
            get
            {
                return _gatheringStatusId;
            }
            set
            {
                _gatheringStatusId = value;
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
            return _gatheringStatusId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}