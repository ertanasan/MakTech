// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Reconciliation;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Reconciliation
{
    [ServiceContract]
    public interface IReconciliationService : ICRUDLServiceContract<Overtech.DataModels.Reconciliation.Reconciliation>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Reconciliation.Reconciliation Find(string storeReconciliationId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        Overtech.DataModels.Reconciliation.Reconciliation ReconciliationDate(long storeId);

        [OperationContract]
        DataTable NotReconStores(DateTime startDate, DateTime endDate);

        [OperationContract]
        Overtech.DataModels.Reconciliation.Reconciliation ReadDetails(long storeId);

        [OperationContract]
        long SaveReconciliation(Overtech.DataModels.Reconciliation.Reconciliation rec);

        [OperationContract]
        IEnumerable<Overtech.DataModels.Reconciliation.Reconciliation> ReconciliationStoreDate(long storeId, DateTime startDate, DateTime endDate);

        [OperationContract]
        void Recalculate(long storeId);

        [OperationContract]
        long createZControlLog(ZControlLog rec);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

