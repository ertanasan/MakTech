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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "GATHERINGSTATUS", HasAutoIdentity = false, DisplayName = "Gathering Status", IdField = "GatheringStatusId")]
    [DataContract]
    public class GatheringStatus : DataModelObject
    {
        private long _gatheringStatusId;
        private string _statusName;

        /*Section="Field-GatheringStatusId"*/
        [OTDataField("GATHERINGSTATUSID")]
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
        [OTDataField("GATHERINGSTATUS_NM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _gatheringStatusId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

