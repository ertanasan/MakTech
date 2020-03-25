// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Web;
using Overtech.Core.Contract;
using Overtech.DataModels.Accounting;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Accounting
{
    [ServiceContract]
    public interface IBankPosTransactionsService : ICRUDLServiceContract<Overtech.DataModels.Accounting.BankPosTransactions>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        string LoadBankPOSFile(byte[] formData);

        [OperationContract]
        string ZiraatLoadBankPOSFile(byte[] formData);

        [OperationContract]
        IEnumerable<BankPosTransactions> ListDay(DateTime blockedDate);

        [OperationContract]
        void MikroTransfer(DateTime BlockedDate, long[] BankPosTransactionsIdList);

        [OperationContract]
        void CancelMikroTransfer(DateTime BlockedDate);

        [OperationContract]
        void ClearDate(DateTime BlockedDate);

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

