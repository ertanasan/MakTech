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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "PACKAGETYPE", HasAutoIdentity = true, DisplayName = "Shipment Package Type", IdField = "ShipmentPackageTypeId")]
    [DataContract]
    public class ShipmentPackageType : DataModelObject
    {
        private long _shipmentPackageTypeId;
        private string _packageTypeName;

        /*Section="Field-ShipmentPackageTypeId"*/
        [OTDataField("PACKAGETYPEID")]
        [DataMember]
        public long ShipmentPackageTypeId
        {
            get
            {
                return _shipmentPackageTypeId;
            }
            set
            {
                _shipmentPackageTypeId = value;
            }
        }

        /*Section="Field-PackageTypeName"*/
        [OTDataField("PACKAGETYPE_NM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _shipmentPackageTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

