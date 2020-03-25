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
namespace Overtech.DataModels.Product
{
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "FIXTURE", HasAutoIdentity = true, DisplayName = "Fixture", IdField = "FixtureId")]
    [DataContract]
    public class Fixture : DataModelObject
    {
        private long _fixtureId;
        private string _fixtureName;

        /*Section="Field-FixtureId"*/
        [OTDataField("FIXTUREID")]
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
        [OTDataField("FIXTURE_NM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _fixtureId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

