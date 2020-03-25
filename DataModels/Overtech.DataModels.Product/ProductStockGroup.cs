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
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "STOCKGROUP", HasAutoIdentity = true, DisplayName = "Product Stock Group", IdField = "StockGroupId")]
    [DataContract]
    public class ProductStockGroup : DataModelObject
    {
        private long _product;
        private long _stockGroup;
        private long _stockGroupId;

        /*Section="Field-Product"*/
        [OTDataField("PRODUCTID")]
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

        /*Section="Field-StockGroup"*/
        [OTDataField("STOCKGROUP")]
        [DataMember]
        public long StockGroup
        {
            get
            {
                return _stockGroup;
            }
            set
            {
                _stockGroup = value;
            }
        }

        /*Section="Field-StockGroupId"*/
        [OTDataField("STOCKGROUPID")]
        [DataMember]
        public long StockGroupId
        {
            get
            {
                return _stockGroupId;
            }
            set
            {
                _stockGroupId = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _stockGroupId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

