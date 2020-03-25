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
    [OTDisplayName("Barcode Type Int")]
    [DataContract]
    public class BarcodeTypeInt : ViewModelObject
    {
        private long _barcodeTypeID;
        private string _barcodeType;
        private string _comment;

        /*Section="Field-BarcodeTypeID"*/
        [OTRequired("Barcode Type ID", null)]
        [OTDisplayName("Barcode Type ID")]
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
        [OTRequired("Barcode Type", null)]
        [OTStringLength(100)]
        [OTDisplayName("Barcode Type")]
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
            return _barcodeTypeID;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}