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
    [OTDisplayName("Cash Register Model")]
    [DataContract]
    public class CashRegisterModel : ViewModelObject
    {
        private long _cashRegisterModelId;
        private long _brand;
        private string _name;
        private string _description;

        /*Section="Field-CashRegisterModelId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Cash Register Model Id", null)]
        [OTDisplayName("Cash Register Model Id")]
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
        [UIHint("CashRegisterBrandList")]
        [OTRequired("Brand", null)]
        [OTDisplayName("Brand")]
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
        [OTRequired("Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Name")]
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
        [OTStringLength(1000)]
        [OTDisplayName("Description")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _cashRegisterModelId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}