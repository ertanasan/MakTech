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
    [OTDisplayName("Product Campaign")]
    [DataContract]
    public class ProductCampaign : ViewModelObject
    {
        private long _productCampaignId;
        private string _name;
        private string _imagePath;
        private bool _active;
        private string _comment;

        /*Section="Field-ProductCampaignId"*/
        [OTRequired("Product Campaign Id", null)]
        [OTDisplayName("Product Campaign Id")]
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
        [OTRequired("Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Name")]
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
        [OTDisplayName("Image Path")]
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
        [OTRequired("Active", null)]
        [OTDisplayName("Active")]
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
        [OTStringLength(1000)]
        [OTDisplayName("Comment")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _productCampaignId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}