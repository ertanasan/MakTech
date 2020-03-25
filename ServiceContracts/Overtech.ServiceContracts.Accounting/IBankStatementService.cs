// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Accounting;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Accounting
{
    [ServiceContract]
    public interface IBankStatementService : ICRUDLServiceContract<Overtech.DataModels.Accounting.BankStatement>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized

        [OperationContract]
        string LoadBankStatementFile(byte[] formData, string bankName);

        [OperationContract]
        IEnumerable<BankStatement> ListDay(DateTime transactionDate);

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

