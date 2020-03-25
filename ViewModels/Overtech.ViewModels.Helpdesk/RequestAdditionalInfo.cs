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
namespace Overtech.ViewModels.Helpdesk
{
    [OTDisplayName("Request Additional Info")]
    [DataContract]
    public class RequestAdditionalInfo : ViewModelObject
    {
        /*Section="Constructor"*/
        public RequestAdditionalInfo()
        {
            this.FolderReference = Guid.NewGuid().ToString();
        }

        public string FolderReference { get; set; }

        private long _requestAdditionalInfoId;
        private long _event;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private long _createChannel;
        private long _createBranch;
        private long _createScreen;
        private long _request;
        private Nullable<decimal> _cost;
        private Nullable<DateTime> _warrantyDueDate;
        private Nullable<long> _folder;

        /*Section="Field-RequestAdditionalInfoId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Request Additional Info Id", null)]
        [OTDisplayName("Request Additional Info Id")]
        [DataMember]
        public long RequestAdditionalInfoId
        {
            get
            {
                return _requestAdditionalInfoId;
            }
            set
            {
                _requestAdditionalInfoId = value;
            }
        }

        /*Section="Field-Event"*/
        [ScaffoldColumn(false)]
        [OTRequired("Event", null)]
        [OTDisplayName("Event")]
        [DataMember]
        public long Event
        {
            get
            {
                return _event;
            }
            set
            {
                _event = value;
            }
        }

        /*Section="Field-Organization"*/
        [ScaffoldColumn(false)]
        [OTRequired("Organization", null)]
        [OTDisplayName("Organization")]
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

        /*Section="Field-Request"*/
        [UIHint("HelpdeskRequestList")]
        [OTRequired("Request", null)]
        [OTDisplayName("Request")]
        [DataMember]
        public long Request
        {
            get
            {
                return _request;
            }
            set
            {
                _request = value;
            }
        }

        /*Section="Field-Cost"*/
        [OTDisplayName("Cost")]
        [DataMember]
        public Nullable<decimal> Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
            }
        }

        /*Section="Field-WarrantyDueDate"*/
        [OTDisplayName("Warranty Due Date")]
        [DataMember]
        public Nullable<DateTime> WarrantyDueDate
        {
            get
            {
                return _warrantyDueDate;
            }
            set
            {
                _warrantyDueDate = value;
            }
        }

        /*Section="Field-Folder"*/
        [UIHint("FolderList")]
        [OTDisplayName("Folder")]
        [DataMember]
        public Nullable<long> Folder
        {
            get
            {
                return _folder;
            }
            set
            {
                _folder = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _requestAdditionalInfoId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}