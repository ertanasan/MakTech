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
    [OTDisplayName("Shipment Unit")]
    [DataContract]
    public class ShipmentUnit : ViewModelObject
    {
        private long _shipmentUnitId;
        private string _unitName;
        private int _packageQuantity;
        private string _comment;

        /*Section="Field-ShipmentUnitId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Shipment Unit Id", null)]
        [OTDisplayName("Shipment Unit Id")]
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
        [OTRequired("Unit Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Unit Name")]
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
        [OTRequired("Package Quantity", null)]
        [OTDisplayName("Package Quantity")]
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
        [OTStringLength(200)]
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
            return _shipmentUnitId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}