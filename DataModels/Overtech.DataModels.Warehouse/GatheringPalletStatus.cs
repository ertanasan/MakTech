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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "GATHERINGPALLETSTATUS", HasAutoIdentity = false, DisplayName = "Gathering Pallet Status", IdField = "StatusId")]
    [DataContract]
    public class GatheringPalletStatus : DataModelObject
    {
        private long _statusId;
        private string _name;

        /*Section="Field-StatusId"*/
        [OTDataField("GATHERINGPALLETSTATUSID")]
        [DataMember]
        public long StatusId
        {
            get
            {
                return _statusId;
            }
            set
            {
                _statusId = value;
            }
        }

        /*Section="Field-Name"*/
        [OTDataField("STATUS_NM")]
        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _statusId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

