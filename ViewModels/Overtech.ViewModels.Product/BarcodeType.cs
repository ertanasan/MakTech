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
namespace Overtech.ViewModels.Product
{
    [OTDisplayName("Barcode Type")]
    [DataContract]
    public class BarcodeType : ViewModelObject
    {
        private long _barcodeTypeId;
        private string _barcodeTypeName;
        private string _comment;

        /*Section="Field-BarcodeTypeId"*/
        [OTRequired("Barcode Type Id", null)]
        [OTDisplayName("Barcode Type Id")]
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
        [OTRequired("Barcode Type Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Barcode Type Name")]
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
        [OTRequired("Comment", null)]
        [OTStringLength(1000)]
        [OTDisplayName("Comment")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _barcodeTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}