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
    [OTDataObject(Module = "OverStoreMain", ModuleShortName = "OSM", Table = "TASKTYPE", HasAutoIdentity = false, DisplayName = "OverStoreTaskType", IdField = "OverStoreTaskTypeId")]
    [DataContract]
    public class OverStoreTaskType : DataModelObject
    {
        private long _overStoreTaskTypeId;
        private string _taskType;

        /*Section="Field-OverStoreTaskTypeId"*/
        [OTDataField("TASKTYPEID")]
        [DataMember]
        public long OverStoreTaskTypeId
        {
            get
            {
                return _overStoreTaskTypeId;
            }
            set
            {
                _overStoreTaskTypeId = value;
            }
        }

        /*Section="Field-TaskType"*/
        [OTDataField("TYPE_NM")]
        [DataMember]
        public string TaskType
        {
            get
            {
                return _taskType;
            }
            set
            {
                _taskType = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _overStoreTaskTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

