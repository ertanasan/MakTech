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
namespace Overtech.ViewModels.Accounting
{
    [OTDisplayName("Firm Contact")]
    [DataContract]
    public class FirmContact : RelationViewModelObject
    {
        private long _firm;
        private long _contact;
        private DateTime _createDate;
        private long _createUser;
        private long _createChannel;
        private long _createBranch;
        private long _createScreen;
        private bool _isDefault;
        private bool _isActive;
        private bool _isPreferred;
        private string _firmName;
        private long _contactContactId;

        /*Section="Field-Firm"*/
        [UIHint("FirmList")]
        [OTRequired("Firm", null)]
        [OTDisplayName("Firm")]
        [DataMember]
        public long Firm
        {
            get
            {
                return _firm;
            }
            set
            {
                _firm = value;
            }
        }

        /*Section="Field-Contact"*/
        [UIHint("ContactList")]
        [OTRequired("Contact", null)]
        [OTDisplayName("Contact")]
        [DataMember]
        public long Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
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

        /*Section="Field-IsDefault"*/
        [OTRequired("Is Default", null)]
        [OTDisplayName("Is Default")]
        [DataMember]
        public bool IsDefault
        {
            get
            {
                return _isDefault;
            }
            set
            {
                _isDefault = value;
            }
        }

        /*Section="Field-IsActive"*/
        [OTRequired("Is Active", null)]
        [OTDisplayName("Is Active")]
        [DataMember]
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
            }
        }

        /*Section="Field-IsPreferred"*/
        [OTRequired("Is Preferred", null)]
        [OTDisplayName("Is Preferred")]
        [DataMember]
        public bool IsPreferred
        {
            get
            {
                return _isPreferred;
            }
            set
            {
                _isPreferred = value;
            }
        }
        #region Parent Name Fields
        /*Section="Field-LeftParentName"*/
        [OTDisplayName("Firm Name")]
        [DataMember]
        public string FirmName
        {
            get
            {
                return _firmName;
            }
            set
            {
                _firmName = value;
            }
        }

        /*Section="Field-RightParentName"*/
        [OTDisplayName("Contact ContactId")]
        [DataMember]
        public long ContactContactId
        {
            get
            {
                return _contactContactId;
            }
            set
            {
                _contactContactId = value;
            }
        }
        #endregion Parent Name Fields

        /*Section="Method-SetLeftId"*/
        public override void SetLeftId(long leftId)
        {
            _firm = leftId;
        }

        /*Section="Method-SetRightId"*/
        public override void SetRightId(long rightId)
        {
            _contact = rightId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [DataMember]
        public ViewModels.Contact.Contact ContactObject { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}