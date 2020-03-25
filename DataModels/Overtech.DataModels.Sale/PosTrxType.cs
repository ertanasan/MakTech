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
namespace Overtech.DataModels.Sale
{
    [OTDataObject(Module = "Sale", ModuleShortName = "SLS", Table = "POSTRXTYPE", HasAutoIdentity = false, DisplayName = "Pos Trx Type", IdField = "PosTrxTypeId")]
    [DataContract]
    public class PosTrxType : DataModelObject
    {
        private long _posTrxTypeId;
        private string _trxType;

        /*Section="Field-PosTrxTypeId"*/
        [OTDataField("POSTRXTYPEID")]
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
        [OTDataField("TRXTYPE_NM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _posTrxTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

