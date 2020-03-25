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
namespace Overtech.ViewModels.Price
{
    [OTDisplayName("Promotion Type")]
    [DataContract]
    public class PromotionType : ViewModelObject
    {
        private long _promotionTypeId;
        private string _promotionName;
        private string _description;

        /*Section="Field-PromotionTypeId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Promotion Type Id", null)]
        [OTDisplayName("Promotion Type Id")]
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
        [OTRequired("Promotion Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Promotion Name")]
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
        [OTStringLength(1000)]
        [OTDisplayName("Description")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _promotionTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}