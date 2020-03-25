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
    [OTDataObject(Module = "Product", ModuleShortName = "PRD", Table = "STOCKGROUPNAME", HasAutoIdentity = false, DisplayName = "Stock Group Name", IdField = "StockGroupNameId")]
    [DataContract]
    public class StockGroupsName : DataModelObject
    {
        private long _stockGroupNameId;
        private string _stockGroupName;
        private Nullable<int> _usageType;

        /*Section="Field-StockGroupNameId"*/
        [OTDataField("STOCKGROUPID")]
        [DataMember]
        public long StockGroupNameId
        {
            get
            {
                return _stockGroupNameId;
            }
            set
            {
                _stockGroupNameId = value;
            }
        }

        /*Section="Field-StockGroupName"*/
        [OTDataField("STOCKGROUP_NM")]
        [DataMember]
        public string StockGroupName
        {
            get
            {
                return _stockGroupName;
            }
            set
            {
                _stockGroupName = value;
            }
        }

        /*Section="Field-UsageType"*/
        [OTDataField("USAGETYPE_CD", Nullable = true)]
        [DataMember]
        public Nullable<int> UsageType
        {
            get
            {
                return _usageType;
            }
            set
            {
                _usageType = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _stockGroupNameId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

