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
namespace Overtech.DataModels.Announcement
{
    [OTDataObject(Module = "Announcement", ModuleShortName = "ANN", Table = "NOTIFICATIONSTATUS", HasAutoIdentity = false, DisplayName = "Notification Status", IdField = "NotificationStatusId")]
    [DataContract]
    public class NotificationStatus : DataModelObject
    {
        private long _notificationStatusId;
        private string _notificationStatusName;
        private string _description;

        /*Section="Field-NotificationStatusId"*/
        [OTDataField("NOTIFICATIONSTATUSID")]
        [DataMember]
        public long NotificationStatusId
        {
            get
            {
                return _notificationStatusId;
            }
            set
            {
                _notificationStatusId = value;
            }
        }

        /*Section="Field-NotificationStatusName"*/
        [OTDataField("NOTIFICATIONSTATUS_NM")]
        [DataMember]
        public string NotificationStatusName
        {
            get
            {
                return _notificationStatusName;
            }
            set
            {
                _notificationStatusName = value;
            }
        }

        /*Section="Field-Description"*/
        [OTDataField("DESCRIPTION_DSC")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _notificationStatusId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

