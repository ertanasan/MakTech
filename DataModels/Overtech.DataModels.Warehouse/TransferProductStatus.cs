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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "TRANSFERPRODUCTSTATUS", HasAutoIdentity = false, DisplayName = "Transfer Product Status", IdField = "TransferProductStatusId")]
    [DataContract]
    public class TransferProductStatus : DataModelObject
    {
        private long _transferProductStatusId;
        private string _productStatusName;

        /*Section="Field-TransferProductStatusId"*/
        [OTDataField("TRANSFERPRODUCTSTATUSID")]
        [DataMember]
        public long TransferProductStatusId
        {
            get
            {
                return _transferProductStatusId;
            }
            set
            {
                _transferProductStatusId = value;
            }
        }

        /*Section="Field-ProductStatusName"*/
        [OTDataField("PRODUCTSTATUS_NM")]
        [DataMember]
        public string ProductStatusName
        {
            get
            {
                return _productStatusName;
            }
            set
            {
                _productStatusName = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _transferProductStatusId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

