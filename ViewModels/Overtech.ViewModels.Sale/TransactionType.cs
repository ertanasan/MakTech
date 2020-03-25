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
    [OTDisplayName("Transaction Type")]
    [DataContract]
    public class TransactionType : ViewModelObject
    {
        private long _transactionTypeId;
        private string _transactionName;

        /*Section="Field-TransactionTypeId"*/
        [OTRequired("Transaction Type Id", null)]
        [OTDisplayName("Transaction Type Id")]
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
        [OTRequired("Transaction Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Transaction Name")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _transactionTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}