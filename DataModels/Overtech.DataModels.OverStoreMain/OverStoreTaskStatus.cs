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
namespace Overtech.DataModels.OverStoreMain
{
    [OTDataObject(Module = "OverStoreMain", ModuleShortName = "OSM", Table = "TASKSTATUS", HasAutoIdentity = false, DisplayName = "OverStoreTaskStatus", IdField = "OverStoreTaskStatusId")]
    [DataContract]
    public class OverStoreTaskStatus : DataModelObject
    {
        private long _overStoreTaskStatusId;
        private string _status;

        /*Section="Field-OverStoreTaskStatusId"*/
        [OTDataField("TASKSTATUSID")]
        [DataMember]
        public long OverStoreTaskStatusId
        {
            get
            {
                return _overStoreTaskStatusId;
            }
            set
            {
                _overStoreTaskStatusId = value;
            }
        }

        /*Section="Field-Status"*/
        [OTDataField("STATUS_NM")]
        [DataMember]
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _overStoreTaskStatusId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

