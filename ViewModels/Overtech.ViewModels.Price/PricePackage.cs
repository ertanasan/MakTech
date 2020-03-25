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
using Overtech.ViewModels.Document;

/*Section="ClassHeader"*/
namespace Overtech.ViewModels.Price
{
    [OTDisplayName("Price Package")]
    [DataContract]
    public class PricePackage : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Package Id", null)]
        [OTDisplayName("Package Id")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Organization")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Deleted")]
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

        /*Section="Field-UpdateDate"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Update Date")]
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

        /*Section="Field-UpdateUser"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Update User")]
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
        [OTRequired("Package Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Package Name")]
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
        [UIHint("PackageTypeList")]
        [OTRequired("Package Type", null)]
        [OTDisplayName("Package Type")]
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

        /*Section="Field-Image"*/
        [UIHint("DocumentList")]
        [OTDisplayName("Image")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _packageId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [DataMember]
        public int AllStores
        {
            get; set;
        }

        [DataMember]
        public int ActiveStores
        {
            get; set;
        }

        [DataMember]
        public DocumentHandle ImageDocument = new DocumentHandle();
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}