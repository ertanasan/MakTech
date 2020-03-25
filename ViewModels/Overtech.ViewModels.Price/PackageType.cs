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
namespace Overtech.ViewModels.Price
{
    [OTDisplayName("Package Type")]
    [DataContract]
    public class PackageType : ViewModelObject
    {
        private long _packageTypeId;
        private string _packageTypeName;
        private string _comment;

        /*Section="Field-PackageTypeId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Package Type Id", null)]
        [OTDisplayName("Package Type Id")]
        [DataMember]
        public long PackageTypeId
        {
            get
            {
                return _packageTypeId;
            }
            set
            {
                _packageTypeId = value;
            }
        }

        /*Section="Field-PackageTypeName"*/
        [OTRequired("Package Type Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Package Type Name")]
        [DataMember]
        public string PackageTypeName
        {
            get
            {
                return _packageTypeName;
            }
            set
            {
                _packageTypeName = value;
            }
        }

        /*Section="Field-Comment"*/
        [OTStringLength(1000)]
        [OTDisplayName("Comment")]
        [DataMember]
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _packageTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}