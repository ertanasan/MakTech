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
    [OTDataObject(Module = "Sale", ModuleShortName = "SLS", Table = "TRANSACTIONTYPE", HasAutoIdentity = false, DisplayName = "Transaction Type", IdField = "TransactionTypeId")]
    [DataContract]
    public class TransactionType : DataModelObject
    {
        private long _transactionTypeId;
        private string _transactionName;

        /*Section="Field-TransactionTypeId"*/
        [OTDataField("TRANSACTIONTYPEID")]
        [DataMember]
        public long TransactionTypeId
        {
            get
            {
                return _transactionTypeId;
            }
            set
            {
                _transactionTypeId = value;
            }
        }

        /*Section="Field-TransactionName"*/
        [OTDataField("TRANSACTION_NM")]
        [DataMember]
        public string TransactionName
        {
            get
            {
                return _transactionName;
            }
            set
            {
                _transactionName = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _transactionTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

