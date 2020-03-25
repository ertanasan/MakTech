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
namespace Overtech.DataModels.Reconciliation
{
    [OTDataObject(Module = "Reconciliation", ModuleShortName = "RCL", Table = "VATGROUP", HasAutoIdentity = true, DisplayName = "Vat Group", IdField = "VatGroupId")]
    [DataContract]
    public class VatGroup : DataModelObject
    {
        private long _vatGroupId;
        private decimal _vatRate;

        /*Section="Field-VatGroupId"*/
        [OTDataField("VATGROUPID")]
        [DataMember]
        public long VatGroupId
        {
            get
            {
                return _vatGroupId;
            }
            set
            {
                _vatGroupId = value;
            }
        }

        /*Section="Field-VatRate"*/
        [OTDataField("VAT_RT")]
        [DataMember]
        public decimal VatRate
        {
            get
            {
                return _vatRate;
            }
            set
            {
                _vatRate = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _vatGroupId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

