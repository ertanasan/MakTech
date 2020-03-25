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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "SHIPMENTUNIT", HasAutoIdentity = true, DisplayName = "Shipment Unit", IdField = "ShipmentUnitId")]
    [DataContract]
    public class ShipmentUnit : DataModelObject
    {
        private long _shipmentUnitId;
        private string _unitName;
        private int _packageQuantity;
        private string _comment;

        /*Section="Field-ShipmentUnitId"*/
        [OTDataField("SHIPMENTUNITID")]
        [DataMember]
        public long ShipmentUnitId
        {
            get
            {
                return _shipmentUnitId;
            }
            set
            {
                _shipmentUnitId = value;
            }
        }

        /*Section="Field-UnitName"*/
        [OTDataField("UNIT_NM")]
        [DataMember]
        public string UnitName
        {
            get
            {
                return _unitName;
            }
            set
            {
                _unitName = value;
            }
        }

        /*Section="Field-PackageQuantity"*/
        [OTDataField("PACKAGE_QTY")]
        [DataMember]
        public int PackageQuantity
        {
            get
            {
                return _packageQuantity;
            }
            set
            {
                _packageQuantity = value;
            }
        }

        /*Section="Field-Comment"*/
        [OTDataField("COMMENT_DSC")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _shipmentUnitId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

