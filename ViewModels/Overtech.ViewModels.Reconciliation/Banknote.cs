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
    [OTDisplayName("Banknote")]
    [DataContract]
    public class Banknote : ViewModelObject
    {
        private long _banknoteId;
        private decimal _banknoteAmount;
        private bool _coinFlag;

        /*Section="Field-BanknoteId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Banknote Id", null)]
        [OTDisplayName("Banknote Id")]
        [DataMember]
        public long BanknoteId
        {
            get
            {
                return _banknoteId;
            }
            set
            {
                _banknoteId = value;
            }
        }

        /*Section="Field-BanknoteAmount"*/
        [OTRequired("Banknote Amount", null)]
        [OTDisplayName("Banknote Amount")]
        [DataMember]
        public decimal BanknoteAmount
        {
            get
            {
                return _banknoteAmount;
            }
            set
            {
                _banknoteAmount = value;
            }
        }

        /*Section="Field-CoinFlag"*/
        [OTDisplayName("Coin Flag")]
        [DataMember]
        public bool CoinFlag
        {
            get
            {
                return _coinFlag;
            }
            set
            {
                _coinFlag = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _banknoteId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}