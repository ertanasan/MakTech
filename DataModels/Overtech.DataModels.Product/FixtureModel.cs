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
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "FIXTUREMODEL", HasAutoIdentity = true, DisplayName = "Fixture Model", IdField = "FixtureModelId", MasterField = "Brand")]
    [DataContract]
    public class FixtureModel : DataModelObject
    {
        private long _fixtureModelId;
        private long _brand;
        private string _modelName;

        /*Section="Field-FixtureModelId"*/
        [OTDataField("FIXTUREMODELID")]
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
        [OTDataField("BRAND")]
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
        [OTDataField("MODEL_NM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _fixtureModelId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

