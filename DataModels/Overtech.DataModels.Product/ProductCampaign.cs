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
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "CAMPAIGN", HasAutoIdentity = false, DisplayName = "Product Campaign", IdField = "ProductCampaignId")]
    [DataContract]
    public class ProductCampaign : DataModelObject
    {
        private long _productCampaignId;
        private string _name;
        private string _imagePath;
        private bool _active;
        private string _comment;

        /*Section="Field-ProductCampaignId"*/
        [OTDataField("CAMPAIGNID")]
        [DataMember]
        public long ProductCampaignId
        {
            get
            {
                return _productCampaignId;
            }
            set
            {
                _productCampaignId = value;
            }
        }

        /*Section="Field-Name"*/
        [OTDataField("NAME_NM")]
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

        /*Section="Field-ImagePath"*/
        [OTDataField("IMAGEPATH_TXT")]
        [DataMember]
        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
            }
        }

        /*Section="Field-Active"*/
        [OTDataField("ACTIVE_FL")]
        [DataMember]
        public bool Active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
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
            _productCampaignId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

