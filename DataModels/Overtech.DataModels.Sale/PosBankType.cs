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
    [OTDataObject(Module = "Sale", ModuleShortName = "SLS", Table = "POSBANKTYPE", HasAutoIdentity = false, DisplayName = "Pos Bank Type", IdField = "PosBankTypeId")]
    [DataContract]
    public class PosBankType : DataModelObject
    {
        private long _posBankTypeId;
        private string _bankType;

        /*Section="Field-PosBankTypeId"*/
        [OTDataField("POSBANKTYPEID")]
        [DataMember]
        public long PosBankTypeId
        {
            get
            {
                return _posBankTypeId;
            }
            set
            {
                _posBankTypeId = value;
            }
        }

        /*Section="Field-BankType"*/
        [OTDataField("BANKTYPE_NM")]
        [DataMember]
        public string BankType
        {
            get
            {
                return _bankType;
            }
            set
            {
                _bankType = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _posBankTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

