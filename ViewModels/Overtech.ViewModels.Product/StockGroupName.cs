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
    [OTDisplayName("Stock Group Name")]
    [DataContract]
    public class StockGroupsName : ViewModelObject
    {
        private long _stockGroupNameId;
        private string _stockGroupName;
        private Nullable<int> _usageType;

        /*Section="Field-StockGroupNameId"*/
        [OTRequired("Stock Group Name Id", null)]
        [OTDisplayName("Stock Group Name Id")]
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
        [OTRequired("Stock Group Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Stock Group Name")]
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
        [OTDisplayName("Usage Type")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _stockGroupNameId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}