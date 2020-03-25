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
    [OTDisplayName("Package Promotion")]
    [DataContract]
    public class PackagePromotion : RelationViewModelObject
    {
        private long _package;
        private long _promotionType;
        private DateTime _createDate;
        private long _createUser;
        private long _createChannel;
        private long _createBranch;
        private long _createScreen;
        private string _packagePackageName;
        private string _promotionTypePromotionName;

        /*Section="Field-Package"*/
        [UIHint("PricePackageList")]
        [OTRequired("Package", null)]
        [OTDisplayName("Package")]
        [DataMember]
        public long Package
        {
            get
            {
                return _package;
            }
            set
            {
                _package = value;
            }
        }

        /*Section="Field-PromotionType"*/
        [UIHint("PromotionTypeList")]
        [OTRequired("Promotion Type", null)]
        [OTDisplayName("Promotion Type")]
        [DataMember]
        public long PromotionType
        {
            get
            {
                return _promotionType;
            }
            set
            {
                _promotionType = value;
            }
        }

        /*Section="Field-CreateDate"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Date")]
        [ReadOnly(true)]
        [DataMember]
        public DateTime CreateDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
            }
        }

        /*Section="Field-CreateUser"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create User")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateUser
        {
            get
            {
                return _createUser;
            }
            set
            {
                _createUser = value;
            }
        }

        /*Section="Field-CreateChannel"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Channel")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateChannel
        {
            get
            {
                return _createChannel;
            }
            set
            {
                _createChannel = value;
            }
        }

        /*Section="Field-CreateBranch"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Branch")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateBranch
        {
            get
            {
                return _createBranch;
            }
            set
            {
                _createBranch = value;
            }
        }

        /*Section="Field-CreateScreen"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Screen")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateScreen
        {
            get
            {
                return _createScreen;
            }
            set
            {
                _createScreen = value;
            }
        }
        #region Parent Name Fields
        /*Section="Field-LeftParentName"*/
        [OTDisplayName("Package PackageName")]
        [DataMember]
        public string PackagePackageName
        {
            get
            {
                return _packagePackageName;
            }
            set
            {
                _packagePackageName = value;
            }
        }

        /*Section="Field-RightParentName"*/
        [OTDisplayName("PromotionType PromotionName")]
        [DataMember]
        public string PromotionTypePromotionName
        {
            get
            {
                return _promotionTypePromotionName;
            }
            set
            {
                _promotionTypePromotionName = value;
            }
        }
        #endregion Parent Name Fields

        /*Section="Method-SetLeftId"*/
        public override void SetLeftId(long leftId)
        {
            _package = leftId;
        }

        /*Section="Method-SetRightId"*/
        public override void SetRightId(long rightId)
        {
            _promotionType = rightId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}