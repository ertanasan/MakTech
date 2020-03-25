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
namespace Overtech.ViewModels.Warehouse
{
    [OTDisplayName("Transfer Product Status")]
    [DataContract]
    public class TransferProductStatus : ViewModelObject
    {
        private long _transferProductStatusId;
        private string _productStatusName;

        /*Section="Field-TransferProductStatusId"*/
        [OTRequired("Transfer Product Status Id", null)]
        [OTDisplayName("Transfer Product Status Id")]
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
        [OTRequired("Product Status Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Product Status Name")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _transferProductStatusId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}