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
    [OTDisplayName("Cash Register Brand")]
    [DataContract]
    public class CashRegisterBrand : ViewModelObject
    {
        private long _cashRegisterBrandId;
        private string _name;
        private string _description;

        /*Section="Field-CashRegisterBrandId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Cash Register Brand Id", null)]
        [OTDisplayName("Cash Register Brand Id")]
        [DataMember]
        public long CashRegisterBrandId
        {
            get
            {
                return _cashRegisterBrandId;
            }
            set
            {
                _cashRegisterBrandId = value;
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
            return _cashRegisterBrandId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public string PriceFilePath
        {
            get; set;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}