// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Sale;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Sale
{
    [ServiceContract]
    public interface ISaleDailySummaryService : ICRUDLServiceContract<Overtech.DataModels.Sale.SaleDailySummary>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        IEnumerable<SaleDailySummary> ListDate(DateTime transactionDate);

        [OperationContract]
        IEnumerable<SaleDailySummary> StoreZet(DateTime transactionDate, long storeId);

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

