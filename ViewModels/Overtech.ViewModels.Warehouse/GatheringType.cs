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
    [OTDisplayName("Gathering Type")]
    [DataContract]
    public class GatheringType : ViewModelObject
    {
        private long _gatheringTypeId;
        private string _gatheringTypeName;

        /*Section="Field-GatheringTypeId"*/
        [OTRequired("Gathering Type Id", null)]
        [OTDisplayName("Gathering Type Id")]
        [DataMember]
        public long GatheringTypeId
        {
            get
            {
                return _gatheringTypeId;
            }
            set
            {
                _gatheringTypeId = value;
            }
        }

        /*Section="Field-GatheringTypeName"*/
        [OTRequired("Gathering Type Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Gathering Type Name")]
        [DataMember]
        public string GatheringTypeName
        {
            get
            {
                return _gatheringTypeName;
            }
            set
            {
                _gatheringTypeName = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _gatheringTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}