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
    [OTDataObject(Module = "Announcement", ModuleShortName = "ANN", Table = "NOTIFICATIONTYPE", HasAutoIdentity = false, DisplayName = "Notification Type", IdField = "NotificationTypeId")]
    [DataContract]
    public class NotificationType : DataModelObject
    {
        private long _notificationTypeId;
        private string _notificationTypeName;
        private string _description;

        /*Section="Field-NotificationTypeId"*/
        [OTDataField("NOTIFICATIONTYPEID")]
        [DataMember]
        public long NotificationTypeId
        {
            get
            {
                return _notificationTypeId;
            }
            set
            {
                _notificationTypeId = value;
            }
        }

        /*Section="Field-NotificationTypeName"*/
        [OTDataField("NOTIFICATIONTYPE_NM")]
        [DataMember]
        public string NotificationTypeName
        {
            get
            {
                return _notificationTypeName;
            }
            set
            {
                _notificationTypeName = value;
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
            _notificationTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

