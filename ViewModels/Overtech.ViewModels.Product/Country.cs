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
namespace Overtech.ViewModels.Product
{
    [OTDisplayName("Country")]
    [DataContract]
    public class Country : ViewModelObject
    {
        private long _countryId;
        private string _countryName;
        private string _comment;

        /*Section="Field-CountryId"*/
        [OTRequired("Country Id", null)]
        [OTDisplayName("Country Id")]
        [DataMember]
        public long CountryId
        {
            get
            {
                return _countryId;
            }
            set
            {
                _countryId = value;
            }
        }

        /*Section="Field-CountryName"*/
        [OTRequired("CountryName", null)]
        [OTStringLength(100)]
        [OTDisplayName("CountryName")]
        [DataMember]
        public string CountryName
        {
            get
            {
                return _countryName;
            }
            set
            {
                _countryName = value;
            }
        }

        /*Section="Field-Comment"*/
        [OTStringLength(1000)]
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
            return _countryId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}