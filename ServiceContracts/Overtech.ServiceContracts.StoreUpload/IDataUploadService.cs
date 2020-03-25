// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Sale;
using Overtech.DataModels.StoreUpload;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.StoreUpload
{
    [ServiceContract]
    public interface IDataUploadService : ICRUDLServiceContract<Overtech.DataModels.StoreUpload.DataUpload>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.

        [OperationContract]
        IEnumerable<DataUpload> ListNewToProcess();

        [OperationContract]
        void ProcessFile(DataUpload upload);

        [OperationContract]
        SaleDailySummary GetZetData(int cashRegisterId, DateTime transactionDate);

        [OperationContract]
        SaleDailySummary CheckStoreZet(int storeId, DateTime transactionDate);

        [OperationContract]
        IEnumerable<StoreMissingDays> GetMissingDays(long storeId);


        [OperationContract]
        void InsertStoreTraceLog(int storeId, string traceText);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

