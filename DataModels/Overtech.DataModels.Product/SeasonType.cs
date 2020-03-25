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
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "SEASONTYPE", HasAutoIdentity = false, DisplayName = "Season Type", IdField = "SeasonTypeId")]
    [DataContract]
    public class SeasonType : DataModelObject
    {
        private long _seasonTypeId;
        private string _seasonTypeName;
        private string _comment;

        /*Section="Field-SeasonTypeId"*/
        [OTDataField("SEASONTYPEID")]
        [DataMember]
        public long SeasonTypeId
        {
            get
            {
                return _seasonTypeId;
            }
            set
            {
                _seasonTypeId = value;
            }
        }

        /*Section="Field-SeasonTypeName"*/
        [OTDataField("SEASONTYPE_NM")]
        [DataMember]
        public string SeasonTypeName
        {
            get
            {
                return _seasonTypeName;
            }
            set
            {
                _seasonTypeName = value;
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
            _seasonTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

