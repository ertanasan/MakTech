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
    [OTDisplayName("Counting Status")]
    [DataContract]
    public class CountingStatus : ViewModelObject
    {
        private long _countingStatusId;
        private string _countingStatusName;

        /*Section="Field-CountingStatusId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Counting Status Id", null)]
        [OTDisplayName("Counting Status Id")]
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
        [OTRequired("Counting Status Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Counting Status Name")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _countingStatusId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}