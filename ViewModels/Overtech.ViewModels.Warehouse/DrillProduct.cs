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
    [OTDisplayName("Drill Product")]
    [DataContract]
    public class DrillProduct : ViewModelObject
    {
        private long _drillProductId;
        private DateTime _countingDate;
        private long _product;
        private long _store;

        /*Section="Field-DrillProductId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Drill Product Id", null)]
        [OTDisplayName("Drill Product Id")]
        [DataMember]
        public long DrillProductId
        {
            get
            {
                return _drillProductId;
            }
            set
            {
                _drillProductId = value;
            }
        }

        /*Section="Field-CountingDate"*/
        [OTRequired("Counting Date", null)]
        [OTDisplayName("Counting Date")]
        [DataMember]
        public DateTime CountingDate
        {
            get
            {
                return _countingDate;
            }
            set
            {
                _countingDate = value;
            }
        }

        /*Section="Field-Product"*/
        [UIHint("ProductList")]
        [OTRequired("Product", null)]
        [OTDisplayName("Product")]
        [DataMember]
        public long Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
            }
        }

        /*Section="Field-Store"*/
        [OTRequired("Store", null)]
        [OTDisplayName("Store")]
        [DataMember]
        public long Store
        {
            get
            {
                return _store;
            }
            set
            {
                _store = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _drillProductId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}