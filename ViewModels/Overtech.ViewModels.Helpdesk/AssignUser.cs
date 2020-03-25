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
    [OTDisplayName("Assign User")]
    [DataContract]
    public class AssignUser : ViewModelObject
    {
        private long _assignUserId;
        private string _groupName;
        private long _responsibleUser;
        private bool _adminFlag;

        /*Section="Field-AssignUserId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Assign User Id", null)]
        [OTDisplayName("Assign User Id")]
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
        [OTRequired("Group Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Group Name")]
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
        [UIHint("UserList")]
        [OTRequired("Responsible User", null)]
        [OTDisplayName("Responsible User")]
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
        [OTRequired("Admin Flag", null)]
        [OTDisplayName("Admin Flag")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _assignUserId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string UserFullName { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}