// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.OverStoreMain;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.OverStoreMain
{
    [ServiceContract]
    public interface IOverStoreTaskService : ICRUDLServiceContract<Overtech.DataModels.OverStoreMain.OverStoreTask>
    {
        /*Section="Method-CreateTaskDocument"*/
        [OperationContract]
        void CreateTaskDocument(TaskDocument taskDocument);

        /*Section="Method-ReadTaskDocument"*/
        [OperationContract]
        TaskDocument ReadTaskDocument(long overStoreTask, long document);

        /*Section="Method-DeleteTaskDocument"*/
        [OperationContract]
        void DeleteTaskDocument(long overStoreTask, long document);

        /*Section="Method-ListTaskDocuments"*/
        [OperationContract]
        IEnumerable<TaskDocument> ListTaskDocuments(long overStoreTaskId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        void TakeAction(DataModels.OverStoreMain.OverStoreTask dataObject, long actionId, string choice, string comment);

        [OperationContract]
        void UpdateStatus(long taskId, long statusId);

        [OperationContract]
        int GetAssignmentType(long taskId);

        [OperationContract]
        long GetTaskResponsibleId(long taskId);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

