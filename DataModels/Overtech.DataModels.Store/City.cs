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
namespace Overtech.DataModels.Store
{
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "CITY", HasAutoIdentity = true, DisplayName = "City", IdField = "CityId")]
    [DataContract]
    public class City : DataModelObject
    {
        private long _cityId;
        private string _cityName;
        private string _plateCode;

        /*Section="Field-CityId"*/
        [OTDataField("CITYID")]
        [DataMember]
        public long CityId
        {
            get
            {
                return _cityId;
            }
            set
            {
                _cityId = value;
            }
        }

        /*Section="Field-CityName"*/
        [OTDataField("CITY_NM")]
        [DataMember]
        public string CityName
        {
            get
            {
                return _cityName;
            }
            set
            {
                _cityName = value;
            }
        }

        /*Section="Field-PlateCode"*/
        [OTDataField("PLATECODE_TXT")]
        [DataMember]
        public string PlateCode
        {
            get
            {
                return _plateCode;
            }
            set
            {
                _plateCode = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _cityId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

