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
namespace Overtech.ViewModels.Store
{
    [OTDisplayName("City")]
    [DataContract]
    public class City : ViewModelObject
    {
        private long _cityId;
        private string _cityName;
        private string _plateCode;

        /*Section="Field-CityId"*/
        [ScaffoldColumn(false)]
        [OTRequired("City Id", null)]
        [OTDisplayName("City Id")]
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
        [OTRequired("City Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("City Name")]
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
        [OTDisplayName("Plate Code")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _cityId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}