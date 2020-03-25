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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "GATHERINGTYPE", HasAutoIdentity = false, DisplayName = "Gathering Type", IdField = "GatheringTypeId")]
    [DataContract]
    public class GatheringType : DataModelObject
    {
        private long _gatheringTypeId;
        private string _gatheringTypeName;

        /*Section="Field-GatheringTypeId"*/
        [OTDataField("GATHERINGTYPEID")]
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
        [OTDataField("GATHERINGTYPE_NM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _gatheringTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

