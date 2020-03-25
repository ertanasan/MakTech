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
namespace Overtech.ViewModels.Sale
{
    [OTDisplayName("Pos Trx Type")]
    [DataContract]
    public class PosTrxType : ViewModelObject
    {
        private long _posTrxTypeId;
        private string _trxType;

        /*Section="Field-PosTrxTypeId"*/
        [OTRequired("Pos Trx Type Id", null)]
        [OTDisplayName("Pos Trx Type Id")]
        [DataMember]
        public long PosTrxTypeId
        {
            get
            {
                return _posTrxTypeId;
            }
            set
            {
                _posTrxTypeId = value;
            }
        }

        /*Section="Field-TrxType"*/
        [OTRequired("Trx Type", null)]
        [OTStringLength(100)]
        [OTDisplayName("Trx Type")]
        [DataMember]
        public string TrxType
        {
            get
            {
                return _trxType;
            }
            set
            {
                _trxType = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _posTrxTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}