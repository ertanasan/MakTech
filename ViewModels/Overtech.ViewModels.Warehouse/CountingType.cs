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
    [OTDisplayName("Counting Type")]
    [DataContract]
    public class CountingType : ViewModelObject
    {
        private long _countingTypeId;
        private string _countingTypeName;

        /*Section="Field-CountingTypeId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Counting Type Id", null)]
        [OTDisplayName("Counting Type Id")]
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
        [OTRequired("Counting Type Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Counting Type Name")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _countingTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}