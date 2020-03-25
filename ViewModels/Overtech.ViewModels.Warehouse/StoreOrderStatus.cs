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
    [OTDisplayName("Store Order Status")]
    [DataContract]
    public class StoreOrderStatus : ViewModelObject
    {
        private long _storeOrderStatusId;
        private string _statusName;
        private string _comment;

        /*Section="Field-StoreOrderStatusId"*/
        [OTRequired("Store Order Status Id", null)]
        [OTDisplayName("Store Order Status Id")]
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
        [OTRequired("Status Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Status Name")]
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
        [OTStringLength(100)]
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
            return _storeOrderStatusId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}