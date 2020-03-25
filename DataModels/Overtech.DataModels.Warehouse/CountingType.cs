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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "COUNTINGTYPE", HasAutoIdentity = true, DisplayName = "Counting Type", IdField = "CountingTypeId")]
    [DataContract]
    public class CountingType : DataModelObject
    {
        private long _countingTypeId;
        private string _countingTypeName;

        /*Section="Field-CountingTypeId"*/
        [OTDataField("COUNTINGTYPEID")]
        [DataMember]
        public long CountingTypeId
        {
            get
            {
                return _countingTypeId;
            }
            set
            {
                _countingTypeId = value;
            }
        }

        /*Section="Field-CountingTypeName"*/
        [OTDataField("COUNTINGTYPE_NM")]
        [DataMember]
        public string CountingTypeName
        {
            get
            {
                return _countingTypeName;
            }
            set
            {
                _countingTypeName = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _countingTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

