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
    [OTDisplayName("Shipment Package Type")]
    [DataContract]
    public class ShipmentPackageType : ViewModelObject
    {
        private long _shipmentPackageTypeId;
        private string _packageTypeName;

        /*Section="Field-ShipmentPackageTypeId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Shipment Package Type Id", null)]
        [OTDisplayName("Shipment Package Type Id")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _shipmentPackageTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}