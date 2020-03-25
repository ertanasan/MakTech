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
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "CASHREGISTERMODEL", HasAutoIdentity = true, DisplayName = "Cash Register Model", IdField = "CashRegisterModelId")]
    [DataContract]
    public class CashRegisterModel : DataModelObject
    {
        private long _cashRegisterModelId;
        private long _brand;
        private string _name;
        private string _description;

        /*Section="Field-CashRegisterModelId"*/
        [OTDataField("CASHREGISTERMODELID")]
        [DataMember]
        public long CashRegisterModelId
        {
            get
            {
                return _cashRegisterModelId;
            }
            set
            {
                _cashRegisterModelId = value;
            }
        }

        /*Section="Field-Brand"*/
        [OTDataField("BRAND")]
        [DataMember]
        public long Brand
        {
            get
            {
                return _brand;
            }
            set
            {
                _brand = value;
            }
        }

        /*Section="Field-Name"*/
        [OTDataField("MODEL_NM")]
        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /*Section="Field-Description"*/
        [OTDataField("COMMENT_DSC")]
        [DataMember]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _cashRegisterModelId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

