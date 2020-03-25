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
namespace Overtech.DataModels.Finance
{
    [OTDataObject(Module = "Finance", ModuleShortName = "FIN", Table = "CONTRACTPARAMETER", HasAutoIdentity = true, DisplayName = "Contract Parameter", IdField = "ContractParameterId")]
    [DataContract]
    public class ContractParameter : DataModelObject
    {
        private long _contractParameterId;
        private string _parameterName;
        private string _value;

        /*Section="Field-ContractParameterId"*/
        [OTDataField("CONTRACTPARAMETERID")]
        [DataMember]
        public long ContractParameterId
        {
            get
            {
                return _contractParameterId;
            }
            set
            {
                _contractParameterId = value;
            }
        }

        /*Section="Field-ParameterName"*/
        [OTDataField("PARAMETER_NM")]
        [DataMember]
        public string ParameterName
        {
            get
            {
                return _parameterName;
            }
            set
            {
                _parameterName = value;
            }
        }

        /*Section="Field-Value"*/
        [OTDataField("VALUE_TXT")]
        [DataMember]
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _contractParameterId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

