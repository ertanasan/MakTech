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
namespace Overtech.ViewModels.Finance
{
    [OTDisplayName("Contract Parameter")]
    [DataContract]
    public class ContractParameter : ViewModelObject
    {
        private long _contractParameterId;
        private string _parameterName;
        private string _value;

        /*Section="Field-ContractParameterId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Contract Parameter Id", null)]
        [OTDisplayName("Contract Parameter Id")]
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
        [OTRequired("Parameter Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Parameter Name")]
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
        [OTRequired("Value", null)]
        [OTDisplayName("Value")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _contractParameterId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}