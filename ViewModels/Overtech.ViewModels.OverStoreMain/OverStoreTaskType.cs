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
namespace Overtech.ViewModels.OverStoreMain
{
    [OTDisplayName("OverStoreTaskType")]
    [DataContract]
    public class OverStoreTaskType : ViewModelObject
    {
        private long _overStoreTaskTypeId;
        private string _taskType;

        /*Section="Field-OverStoreTaskTypeId"*/
        [OTRequired("OverStoreTaskType Id", null)]
        [OTDisplayName("OverStoreTaskType Id")]
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
        [OTRequired("Task Type", null)]
        [OTStringLength(100)]
        [OTDisplayName("Task Type")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _overStoreTaskTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}