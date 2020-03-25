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
namespace Overtech.DataModels.StoreUpload
{
    [OTDataObject(Module = "StoreUpload", ModuleShortName = "SUP", Table = "STATUS", HasAutoIdentity = false, DisplayName = "Status", IdField = "StatusId")]
    [DataContract]
    public class Status : DataModelObject
    {
        private long _statusId;
        private string _name;
        private string _description;

        /*Section="Field-StatusId"*/
        [OTDataField("STATUSID")]
        [DataMember]
        public long StatusId
        {
            get
            {
                return _statusId;
            }
            set
            {
                _statusId = value;
            }
        }

        /*Section="Field-Name"*/
        [OTDataField("STATUS_NM")]
        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /*Section="Field-Description"*/
        [OTDataField("COMMENT_DSC")]
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
            _statusId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

