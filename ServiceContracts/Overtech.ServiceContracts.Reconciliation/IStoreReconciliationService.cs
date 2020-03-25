// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Data;

using Overtech.Core.Contract;
using Overtech.DataModels.Reconciliation;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Reconciliation
{
    [ServiceContract]
    public interface IStoreReconciliationService : ICRUDLServiceContract<Overtech.DataModels.Reconciliation.StoreReconciliation>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized

        [OperationContract]
        void DeleteReconciliation(long reconciliationID);

        [OperationContract]
        IEnumerable<StoreReconciliationIncome> ListReconciliationIncome(DateTime transactionDate);

        [OperationContract]
        StoreReconciliation GetReconciliation(DateTime transactionDate);

        [OperationContract]
        IEnumerable<StoreReconciliation> ListReconciliation(DateTime transactionDate);

        [OperationContract]
        void SaveReconciliation(StoreReconciliation storeTotal);

        [OperationContract]
        void ApproveReconciliations(DateTime transactionDate, int reconciliationID);

        [OperationContract]
        DataTable GetReconciliationStoreData(int dayGroup);

        //[OperationContract]
        //byte[] ExportReconciliationList(IEnumerable<StoreReconciliation> reconciliations);

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

