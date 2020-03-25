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
    [OTDisplayName("Fixture")]
    [DataContract]
    public class Fixture : ViewModelObject
    {
        private long _fixtureId;
        private string _fixtureName;

        /*Section="Field-FixtureId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Fixture Id", null)]
        [OTDisplayName("Fixture Id")]
        [DataMember]
        public long FixtureId
        {
            get
            {
                return _fixtureId;
            }
            set
            {
                _fixtureId = value;
            }
        }

        /*Section="Field-FixtureName"*/
        [OTRequired("Fixture Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Fixture Name")]
        [DataMember]
        public string FixtureName
        {
            get
            {
                return _fixtureName;
            }
            set
            {
                _fixtureName = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _fixtureId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}