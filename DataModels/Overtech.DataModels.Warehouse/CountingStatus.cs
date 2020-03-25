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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "COUNTINGSTATUS", HasAutoIdentity = true, DisplayName = "Counting Status", IdField = "CountingStatusId")]
    [DataContract]
    public class CountingStatus : DataModelObject
    {
        private long _countingStatusId;
        private string _countingStatusName;

        /*Section="Field-CountingStatusId"*/
        [OTDataField("COUNTINGSTATUSID")]
        [DataMember]
        public long CountingStatusId
        {
            get
            {
                return _countingStatusId;
            }
            set
            {
                _countingStatusId = value;
            }
        }

        /*Section="Field-CountingStatusName"*/
        [OTDataField("COUNTINGSTATUS_NM")]
        [DataMember]
        public string CountingStatusName
        {
            get
            {
                return _countingStatusName;
            }
            set
            {
                _countingStatusName = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _countingStatusId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

