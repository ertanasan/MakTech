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
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "COUNTRY", HasAutoIdentity = false, DisplayName = "Country", IdField = "CountryId")]
    [DataContract]
    public class Country : DataModelObject
    {
        private long _countryId;
        private string _countryName;
        private string _comment;

        /*Section="Field-CountryId"*/
        [OTDataField("COUNTRYID")]
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
        [OTDataField("COUNTRY_NM")]
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
        [OTDataField("COMMENT_DSC")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _countryId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

