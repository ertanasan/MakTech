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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "PRODUCTION", HasAutoIdentity = true, DisplayName = "Production", IdField = "ProductionId")]
    [DataContract]
    public class Production : DataModelObject
    {
        private long _productionId;
        private long _product;

        /*Section="Field-ProductionId"*/
        [OTDataField("PRODUCTIONID")]
        [DataMember]
        public long ProductionId
        {
            get
            {
                return _productionId;
            }
            set
            {
                _productionId = value;
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _productionId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("PRODUCT_NM", IsExtended = true)]
        [DataMember]
        public string ProductName { get; set; }
        #endregion Customized

            /*Section="ClassFooter"*/
        }
}

