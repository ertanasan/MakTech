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
namespace Overtech.ViewModels.Reconciliation
{
    [OTDisplayName("Vat Group")]
    [DataContract]
    public class VatGroup : ViewModelObject
    {
        private long _vatGroupId;
        private decimal _vatRate;

        /*Section="Field-VatGroupId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Vat Group Id", null)]
        [OTDisplayName("Vat Group Id")]
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
        [OTRequired("Vat Rate", null)]
        [OTDisplayName("Vat Rate")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _vatGroupId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}