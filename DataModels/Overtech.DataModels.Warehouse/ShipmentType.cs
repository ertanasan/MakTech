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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "SHIPMENTTYPE", HasAutoIdentity = false, DisplayName = "Shipment Type", IdField = "ShipmentTypeId")]
    [DataContract]
    public class ShipmentType : DataModelObject
    {
        private long _shipmentTypeId;
        private string _shipmentTypeName;

        /*Section="Field-ShipmentTypeId"*/
        [OTDataField("SHIPMENTTYPEID")]
        [DataMember]
        public long ShipmentTypeId
        {
            get
            {
                return _shipmentTypeId;
            }
            set
            {
                _shipmentTypeId = value;
            }
        }

        /*Section="Field-ShipmentTypeName"*/
        [OTDataField("SHIPMENTTYPE_NM")]
        [DataMember]
        public string ShipmentTypeName
        {
            get
            {
                return _shipmentTypeName;
            }
            set
            {
                _shipmentTypeName = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _shipmentTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

