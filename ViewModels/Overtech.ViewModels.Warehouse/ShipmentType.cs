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
    [OTDisplayName("Shipment Type")]
    [DataContract]
    public class ShipmentType : ViewModelObject
    {
        private long _shipmentTypeId;
        private string _shipmentTypeName;

        /*Section="Field-ShipmentTypeId"*/
        [OTRequired("Shipment Type Id", null)]
        [OTDisplayName("Shipment Type Id")]
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
        [OTRequired("Shipment Type Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Shipment Type Name")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _shipmentTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}