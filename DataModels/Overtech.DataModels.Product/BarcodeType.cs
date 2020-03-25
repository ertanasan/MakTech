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
namespace Overtech.DataModels.Product
{
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "BARCODETYPE", HasAutoIdentity = false, DisplayName = "Barcode Type", IdField = "BarcodeTypeId")]
    [DataContract]
    public class BarcodeType : DataModelObject
    {
        private long _barcodeTypeId;
        private string _barcodeTypeName;
        private string _comment;

        /*Section="Field-BarcodeTypeId"*/
        [OTDataField("BARCODETYPEID")]
        [DataMember]
        public long BarcodeTypeId
        {
            get
            {
                return _barcodeTypeId;
            }
            set
            {
                _barcodeTypeId = value;
            }
        }

        /*Section="Field-BarcodeTypeName"*/
        [OTDataField("BARCODETYPE_NM")]
        [DataMember]
        public string BarcodeTypeName
        {
            get
            {
                return _barcodeTypeName;
            }
            set
            {
                _barcodeTypeName = value;
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
            _barcodeTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

