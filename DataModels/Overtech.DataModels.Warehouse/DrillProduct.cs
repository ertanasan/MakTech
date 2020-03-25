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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "DRILLPRODUCT", HasAutoIdentity = true, DisplayName = "Drill Product", IdField = "DrillProductId")]
    [DataContract]
    public class DrillProduct : DataModelObject
    {
        private long _drillProductId;
        private DateTime _countingDate;
        private long _product;
        private long _store;

        /*Section="Field-DrillProductId"*/
        [OTDataField("DRILLPRODUCTID")]
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
        [OTDataField("COUNTING_DT")]
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
        [OTDataField("PRODUCT")]
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
        [OTDataField("STORE")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _drillProductId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

