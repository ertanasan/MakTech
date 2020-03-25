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
    [OTDisplayName("OverStoreTaskStatus")]
    [DataContract]
    public class OverStoreTaskStatus : ViewModelObject
    {
        private long _overStoreTaskStatusId;
        private string _status;

        /*Section="Field-OverStoreTaskStatusId"*/
        [OTRequired("OverStoreTaskStatus Id", null)]
        [OTDisplayName("OverStoreTaskStatus Id")]
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
        [OTRequired("Status", null)]
        [OTStringLength(100)]
        [OTDisplayName("Status")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _overStoreTaskStatusId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}