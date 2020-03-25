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
    [OTDisplayName("Fixture Model")]
    [DataContract]
    public class FixtureModel : ViewModelObject
    {
        private long _fixtureModelId;
        private long _brand;
        private string _modelName;

        /*Section="Field-FixtureModelId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Fixture Model Id", null)]
        [OTDisplayName("Fixture Model Id")]
        [DataMember]
        public long FixtureModelId
        {
            get
            {
                return _fixtureModelId;
            }
            set
            {
                _fixtureModelId = value;
            }
        }

        /*Section="Field-Brand"*/
        [UIHint("FixtureBrandList")]
        [OTRequired("Brand", null)]
        [OTDisplayName("Brand")]
        [DataMember]
        public long Brand
        {
            get
            {
                return _brand;
            }
            set
            {
                _brand = value;
            }
        }

        /*Section="Field-ModelName"*/
        [OTRequired("Model Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Model Name")]
        [DataMember]
        public string ModelName
        {
            get
            {
                return _modelName;
            }
            set
            {
                _modelName = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _fixtureModelId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}