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
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "BARCODETYPEINT", HasAutoIdentity = false, DisplayName = "Barcode Type Int", IdField = "BarcodeTypeID")]
    [DataContract]
    public class BarcodeTypeInt : DataModelObject
    {
        private long _barcodeTypeID;
        private string _barcodeType;
        private string _comment;

        /*Section="Field-BarcodeTypeID"*/
        [OTDataField("BARCODETYPEINTID")]
        [DataMember]
        public long BarcodeTypeID
        {
            get
            {
                return _barcodeTypeID;
            }
            set
            {
                _barcodeTypeID = value;
            }
        }

        /*Section="Field-BarcodeType"*/
        [OTDataField("BARCODETYPE_NM")]
        [DataMember]
        public string BarcodeType
        {
            get
            {
                return _barcodeType;
            }
            set
            {
                _barcodeType = value;
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
            _barcodeTypeID = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

