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
namespace Overtech.DataModels.Warehouse
{
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "RETURNSTATUS", HasAutoIdentity = true, DisplayName = "Return Status", IdField = "ReturnStatusId")]
    [DataContract]
    public class ReturnStatus : DataModelObject
    {
        private long _returnStatusId;
        private string _statusName;

        /*Section="Field-ReturnStatusId"*/
        [OTDataField("RETURNSTATUSID")]
        [DataMember]
        public long ReturnStatusId
        {
            get
            {
                return _returnStatusId;
            }
            set
            {
                _returnStatusId = value;
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
            _returnStatusId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

