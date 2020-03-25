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
    [OTDataObject(Module = "Price", ModuleShortName = "PRC", Table = "PACKAGE", HasAutoIdentity = true, DisplayName = "Price Package", IdField = "PackageId")]
    [DataContract]
    public class PricePackage : DataModelObject
    {
        private long _packageId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private string _packageName;
        private long _packageType;
        private string _comment;
        private Nullable<long> _image;

        /*Section="Field-PackageId"*/
        [OTDataField("PACKAGEID")]
        [DataMember]
        public long PackageId
        {
            get
            {
                return _packageId;
            }
            set
            {
                _packageId = value;
            }
        }

        /*Section="Field-Organization"*/
        [OTDataField("ORGANIZATION")]
        [ReadOnly(true)]
        [DataMember]
        public long Organization
        {
            get
            {
                return _organization;
            }
            set
            {
                _organization = value;
            }
        }

        /*Section="Field-Deleted"*/
        [OTDataField("DELETED_FL")]
        [ReadOnly(true)]
        [DataMember]
        public bool Deleted
        {
            get
            {
                return _deleted;
            }
            set
            {
                _deleted = value;
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

        /*Section="Field-UpdateDate"*/
        [OTDataField("UPDATE_DT", Nullable = true)]
        [ReadOnly(true)]
        [DataMember]
        public Nullable<DateTime> UpdateDate
        {
            get
            {
                return _updateDate;
            }
            set
            {
                _updateDate = value;
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

        /*Section="Field-UpdateUser"*/
        [OTDataField("UPDATEUSER", Nullable = true)]
        [ReadOnly(true)]
        [DataMember]
        public Nullable<long> UpdateUser
        {
            get
            {
                return _updateUser;
            }
            set
            {
                _updateUser = value;
            }
        }

        /*Section="Field-PackageName"*/
        [OTDataField("PACKAGE_NM")]
        [DataMember]
        public string PackageName
        {
            get
            {
                return _packageName;
            }
            set
            {
                _packageName = value;
            }
        }

        /*Section="Field-PackageType"*/
        [OTDataField("TYPE")]
        [DataMember]
        public long PackageType
        {
            get
            {
                return _packageType;
            }
            set
            {
                _packageType = value;
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

        /*Section="Field-Image"*/
        [OTDataField("IMAGE", Nullable = true)]
        [DataMember]
        public Nullable<long> Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _packageId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OTDataField("ALLSTORES_CN", IsExtended = true)]
        [DataMember]
        public int AllStores
        {
            get; set;
        }

        [OTDataField("ACTIVESTORES_CN", IsExtended = true)]
        [DataMember]
        public int ActiveStores
        {
            get; set;
        }
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

