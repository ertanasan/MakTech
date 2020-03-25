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
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "FIXTUREBRAND", HasAutoIdentity = true, DisplayName = "Fixture Brand", IdField = "FixtureBrandId", MasterField = "Fixture")]
    [DataContract]
    public class FixtureBrand : DataModelObject
    {
        private long _fixtureBrandId;
        private long _fixture;
        private string _brandName;

        /*Section="Field-FixtureBrandId"*/
        [OTDataField("FIXTUREBRANDID")]
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
        [OTDataField("FIXTURE")]
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
        [OTDataField("BRAND_NM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _fixtureBrandId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

