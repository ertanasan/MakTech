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
namespace Overtech.ViewModels.Contact
{
    [OTDisplayName("Town")]
    [DataContract]
    public class Town : ViewModelObject
    {
        private long _townId;
        private long _city;
        private string _townName;

        /*Section="Field-TownId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Town Id", null)]
        [OTDisplayName("Town Id")]
        [DataMember]
        public long TownId
        {
            get
            {
                return _townId;
            }
            set
            {
                _townId = value;
            }
        }

        /*Section="Field-City"*/
        [UIHint("CityList")]
        [OTRequired("City", null)]
        [OTDisplayName("City")]
        [DataMember]
        public long City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
            }
        }

        /*Section="Field-TownName"*/
        [OTRequired("Town Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Town Name")]
        [DataMember]
        public string TownName
        {
            get
            {
                return _townName;
            }
            set
            {
                _townName = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _townId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}