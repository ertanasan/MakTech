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
    [OTDataObject(Module = "Reconciliation", ModuleShortName = "RCL", Table = "BANKNOTE", HasAutoIdentity = true, DisplayName = "Banknote", IdField = "BanknoteId")]
    [DataContract]
    public class Banknote : DataModelObject
    {
        private long _banknoteId;
        private decimal _banknoteAmount;
        private bool _coinFlag;

        /*Section="Field-BanknoteId"*/
        [OTDataField("BANKNOTEID")]
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
        [OTDataField("BANKNOTE_AMT")]
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
        [OTDataField("COIN_FL")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _banknoteId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

