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
    [OTDisplayName("Storage Zones")]
    [DataContract]
    public class StorageZones : ViewModelObject
    {
        private long _storageZonesId;
        private string _location;
        private string _zoneName;

        /*Section="Field-StorageZonesId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Storage Zones Id", null)]
        [OTDisplayName("Storage Zones Id")]
        [DataMember]
        public long StorageZonesId
        {
            get
            {
                return _storageZonesId;
            }
            set
            {
                _storageZonesId = value;
            }
        }

        /*Section="Field-Location"*/
        [OTRequired("Location", null)]
        [OTDisplayName("Location")]
        [DataMember]
        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }

        /*Section="Field-ZoneName"*/
        [OTRequired("Zone Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Zone Name")]
        [DataMember]
        public string ZoneName
        {
            get
            {
                return _zoneName;
            }
            set
            {
                _zoneName = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _storageZonesId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}