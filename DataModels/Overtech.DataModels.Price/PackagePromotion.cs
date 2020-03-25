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
    [OTDataObject(Module = "Price", ModuleShortName = "PRC", Table = "PACKAGEPROMOTION", HasAutoIdentity = false, DisplayName = "Package Promotion", LeftIdField = "Package", RightIdField = "PromotionType")]
    [DataContract]
    public class PackagePromotion : DataModelObject
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
        [OTDataField("PACKAGE")]
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
        [OTDataField("PROMOTIONTYPE")]
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
        [OTDataField("CREATE_DT")]
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
        [OTDataField("CREATEUSER")]
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
        [OTDataField("CREATECHANNEL")]
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
        [OTDataField("CREATEBRANCH")]
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
        [OTDataField("CREATESCREEN")]
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
        [OTDataField("PACKAGE.PACKAGE_NM")]
        [ReadOnly(true)]
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
        [OTDataField("PROMOTIONTYPE.PROMOTIONTYPE_NM")]
        [ReadOnly(true)]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

