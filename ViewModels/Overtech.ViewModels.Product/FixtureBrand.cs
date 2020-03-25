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
    [OTDisplayName("Fixture Brand")]
    [DataContract]
    public class FixtureBrand : ViewModelObject
    {
        private long _fixtureBrandId;
        private long _fixture;
        private string _brandName;

        /*Section="Field-FixtureBrandId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Fixture Brand Id", null)]
        [OTDisplayName("Fixture Brand Id")]
        [DataMember]
        public long FixtureBrandId
        {
            get
            {
                return _fixtureBrandId;
            }
            set
            {
                _fixtureBrandId = value;
            }
        }

        /*Section="Field-Fixture"*/
        [UIHint("FixtureList")]
        [OTRequired("Fixture", null)]
        [OTDisplayName("Fixture")]
        [DataMember]
        public long Fixture
        {
            get
            {
                return _fixture;
            }
            set
            {
                _fixture = value;
            }
        }

        /*Section="Field-BrandName"*/
        [OTRequired("Brand Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Brand Name")]
        [DataMember]
        public string BrandName
        {
            get
            {
                return _brandName;
            }
            set
            {
                _brandName = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _fixtureBrandId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}