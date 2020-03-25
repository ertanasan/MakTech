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
namespace Overtech.DataModels.Price
{
    [OTDataObject(Module = "Price", ModuleShortName = "PRC", Table = "PROMOTIONTYPE", HasAutoIdentity = true, DisplayName = "Promotion Type", IdField = "PromotionTypeId")]
    [DataContract]
    public class PromotionType : DataModelObject
    {
        private long _promotionTypeId;
        private string _promotionName;
        private string _description;

        /*Section="Field-PromotionTypeId"*/
        [OTDataField("PROMOTIONTYPEID")]
        [DataMember]
        public long PromotionTypeId
        {
            get
            {
                return _promotionTypeId;
            }
            set
            {
                _promotionTypeId = value;
            }
        }

        /*Section="Field-PromotionName"*/
        [OTDataField("PROMOTIONTYPE_NM")]
        [DataMember]
        public string PromotionName
        {
            get
            {
                return _promotionName;
            }
            set
            {
                _promotionName = value;
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
            _promotionTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

