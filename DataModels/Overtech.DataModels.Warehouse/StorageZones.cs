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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "ZONE", HasAutoIdentity = true, DisplayName = "Storage Zones", IdField = "StorageZonesId")]
    [DataContract]
    public class StorageZones : DataModelObject
    {
        private long _storageZonesId;
        private string _location;
        private string _zoneName;

        /*Section="Field-StorageZonesId"*/
        [OTDataField("ZONEID")]
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
        [OTDataField("LOCATION_TXT")]
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
        [OTDataField("ZONE_NM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _storageZonesId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

