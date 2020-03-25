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
namespace Overtech.DataModels.Helpdesk
{
    [OTDataObject(Module = "Helpdesk", ModuleShortName = "HDK", Table = "ASSIGNUSER", HasAutoIdentity = true, DisplayName = "Assign User", IdField = "AssignUserId")]
    [DataContract]
    public class AssignUser : DataModelObject
    {
        private long _assignUserId;
        private string _groupName;
        private long _responsibleUser;
        private bool _adminFlag;

        /*Section="Field-AssignUserId"*/
        [OTDataField("ASSIGNUSERID")]
        [DataMember]
        public long AssignUserId
        {
            get
            {
                return _assignUserId;
            }
            set
            {
                _assignUserId = value;
            }
        }

        /*Section="Field-GroupName"*/
        [OTDataField("GROUP_NM")]
        [DataMember]
        public string GroupName
        {
            get
            {
                return _groupName;
            }
            set
            {
                _groupName = value;
            }
        }

        /*Section="Field-ResponsibleUser"*/
        [OTDataField("RESPONSIBLEUSER")]
        [DataMember]
        public long ResponsibleUser
        {
            get
            {
                return _responsibleUser;
            }
            set
            {
                _responsibleUser = value;
            }
        }

        /*Section="Field-AdminFlag"*/
        [OTDataField("ADMIN_FL")]
        [DataMember]
        public bool AdminFlag
        {
            get
            {
                return _adminFlag;
            }
            set
            {
                _adminFlag = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _assignUserId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("USER_NM", IsExtended = true)]
        [DataMember]
        public string UserName { get; set; }

        [OTDataField("USERFULL_NM", IsExtended = true)]
        [DataMember]
        public string UserFullName { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

