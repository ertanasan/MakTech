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
    [OTDisplayName("Supplier Type")]
    [DataContract]
    public class SupplierType : ViewModelObject
    {
        private long _supplierTypeId;
        private string _supplierTypeName;

        /*Section="Field-SupplierTypeId"*/
        [OTRequired("Supplier Type Id", null)]
        [OTDisplayName("Supplier Type Id")]
        [DataMember]
        public long SupplierTypeId
        {
            get
            {
                return _supplierTypeId;
            }
            set
            {
                _supplierTypeId = value;
            }
        }

        /*Section="Field-SupplierTypeName"*/
        [OTRequired("Supplier Type Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Supplier Type Name")]
        [DataMember]
        public string SupplierTypeName
        {
            get
            {
                return _supplierTypeName;
            }
            set
            {
                _supplierTypeName = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _supplierTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}