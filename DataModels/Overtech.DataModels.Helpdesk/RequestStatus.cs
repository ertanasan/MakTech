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
    [OTDataObject(Module = "Helpdesk", ModuleShortName = "HDK", Table = "REQUESTSTATUS", HasAutoIdentity = false, DisplayName = "Request Status", IdField = "RequestStatusId")]
    [DataContract]
    public class RequestStatus : DataModelObject
    {
        private long _requestStatusId;
        private string _statusName;

        /*Section="Field-RequestStatusId"*/
        [OTDataField("REQUESTSTATUSID")]
        [DataMember]
        public long RequestStatusId
        {
            get
            {
                return _requestStatusId;
            }
            set
            {
                _requestStatusId = value;
            }
        }

        /*Section="Field-StatusName"*/
        [OTDataField("STATUS_NM")]
        [DataMember]
        public string StatusName
        {
            get
            {
                return _statusName;
            }
            set
            {
                _statusName = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _requestStatusId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

