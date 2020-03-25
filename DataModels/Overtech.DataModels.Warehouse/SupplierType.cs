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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "SUPPLIERTYPE", HasAutoIdentity = false, DisplayName = "Supplier Type", IdField = "SupplierTypeId")]
    [DataContract]
    public class SupplierType : DataModelObject
    {
        private long _supplierTypeId;
        private string _supplierTypeName;

        /*Section="Field-SupplierTypeId"*/
        [OTDataField("SUPPLIERTYPEID")]
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
        [OTDataField("SUPPLIERTYPE_NM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _supplierTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

