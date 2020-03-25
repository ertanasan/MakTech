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
namespace Overtech.DataModels.Accounting
{
    [OTDataObject(Module = "Accounting", ModuleShortName = "ACC", Table = "FIRMCONTACT", HasAutoIdentity = false, DisplayName = "Firm Contact", LeftIdField = "Firm", RightIdField = "Contact")]
    [DataContract]
    public class FirmContact : DataModelObject
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
        [OTDataField("FIRM")]
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
        [OTDataField("CONTACT")]
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

        /*Section="Field-IsDefault"*/
        [OTDataField("ISDEFAULT_FL")]
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
        [OTDataField("ISACTIVE_FL")]
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
        [OTDataField("ISPREFERRED_FL")]
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
        [OTDataField("FIRM.FIRM_NM")]
        [ReadOnly(true)]
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
        [OTDataField("CONTACT.CONTACTID")]
        [ReadOnly(true)]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [DataMember]
        public DataModels.Contact.Contact ContactObject { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

