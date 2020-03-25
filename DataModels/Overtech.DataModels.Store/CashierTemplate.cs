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
namespace Overtech.DataModels.Store
{
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "CASHIERTEMPLATE", HasAutoIdentity = false, DisplayName = "Cashier Template", IdField = "CashierTemplateId")]
    [DataContract]
    public class CashierTemplate : DataModelObject
    {
        private long _cashierTemplateId;
        private string _cashierTemplateName;

        /*Section="Field-CashierTemplateId"*/
        [OTDataField("CASHIERTEMPLATEID")]
        [DataMember]
        public long CashierTemplateId
        {
            get
            {
                return _cashierTemplateId;
            }
            set
            {
                _cashierTemplateId = value;
            }
        }

        /*Section="Field-CashierTemplateName"*/
        [OTDataField("CASHIERTEMPLATE_NM")]
        [DataMember]
        public string CashierTemplateName
        {
            get
            {
                return _cashierTemplateName;
            }
            set
            {
                _cashierTemplateName = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _cashierTemplateId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

