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
namespace Overtech.DataModels.Store
{
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "SCALEBRAND", HasAutoIdentity = true, DisplayName = "Scale Brand", IdField = "ScaleBrandId")]
    [DataContract]
    public class ScaleBrand : DataModelObject
    {
        private long _scaleBrandId;
        private string _name;
        private string _description;

        /*Section="Field-ScaleBrandId"*/
        [OTDataField("SCALEBRANDID")]
        [DataMember]
        public long ScaleBrandId
        {
            get
            {
                return _scaleBrandId;
            }
            set
            {
                _scaleBrandId = value;
            }
        }

        /*Section="Field-Name"*/
        [OTDataField("BRAND_NM")]
        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /*Section="Field-Description"*/
        [OTDataField("COMMENT_DSC")]
        [DataMember]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _scaleBrandId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("PRICEFILEPATH_TXT", IsExtended = true)]
        [DataMember]
        public string PriceFilePath
        {
            get; set;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

