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
namespace Overtech.ViewModels.Store
{
    [OTDisplayName("Cashier Template")]
    [DataContract]
    public class CashierTemplate : ViewModelObject
    {
        private long _cashierTemplateId;
        private string _cashierTemplateName;

        /*Section="Field-CashierTemplateId"*/
        [OTRequired("Cashier Template Id", null)]
        [OTDisplayName("Cashier Template Id")]
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
        [OTRequired("Cashier Template Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Cashier Template Name")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _cashierTemplateId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}