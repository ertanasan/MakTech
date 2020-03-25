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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "STOREORDERSTATUS", HasAutoIdentity = false, DisplayName = "Store Order Status", IdField = "StoreOrderStatusId")]
    [DataContract]
    public class StoreOrderStatus : DataModelObject
    {
        private long _storeOrderStatusId;
        private string _statusName;
        private string _comment;

        /*Section="Field-StoreOrderStatusId"*/
        [OTDataField("STOREORDERSTATUSID")]
        [DataMember]
        public long StoreOrderStatusId
        {
            get
            {
                return _storeOrderStatusId;
            }
            set
            {
                _storeOrderStatusId = value;
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

        /*Section="Field-Comment"*/
        [OTDataField("COMMENT_DSC")]
        [DataMember]
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _storeOrderStatusId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

