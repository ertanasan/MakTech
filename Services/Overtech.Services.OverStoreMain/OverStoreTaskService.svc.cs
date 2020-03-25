// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.OverStoreMain;
using Overtech.ServiceContracts.OverStoreMain;

// Process usings:
using Overtech.Mutual.Parameter;
using Overtech.Mutual.Security;
using Overtech.Core.DependencyInjection;
using Overtech.API.BPM;
using Overtech.Core.Application;
using Overtech.DataModels.Security;

// Document usings:
using Overtech.Mutual.DocumentManagement;
using Overtech.DataModels.Document;

/*Section="ClassHeader"*/
namespace Overtech.Services.OverStoreMain
{
    [OTInspectorBehavior]
    public class OverStoreTaskService : CRUDLDataService<Overtech.DataModels.OverStoreMain.OverStoreTask>, IOverStoreTaskService
    {
        IParameterReader _parameterReader;
        IOTResolver _resolver;

        /*Section="Constructor-1"*/
        public OverStoreTaskService(IParameterReader parameterReader, IOTResolver resolver)
        {
            _parameterReader = parameterReader;
            _resolver = resolver;
        }

        /*Section="Constructor-2"*/
        internal OverStoreTaskService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-CreateTaskDocument"*/
        public void CreateTaskDocument(TaskDocument taskDocument)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmOverStoreTask = dal.CreateParameter("OverStoreTask", taskDocument.OverStoreTask);
                    IUniParameter prmDocument = dal.CreateParameter("Document", taskDocument.Document);
                    dal.ExecuteNonQuery("OSM_INS_TASKDOCUMENT_SP", prmOverStoreTask, prmDocument);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        /*Section="Method-ReadTaskDocument"*/
        public TaskDocument ReadTaskDocument(long overStoreTask, long document)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmOverStoreTask = dal.CreateParameter("OverStoreTask", overStoreTask);
                IUniParameter prmDocument = dal.CreateParameter("Document", document);
                return dal.Read<TaskDocument>("OSM_SEL_TASKDOCUMENT_SP", prmOverStoreTask, prmDocument);
            }
        }

        /*Section="Method-DeleteTaskDocument"*/
        public void DeleteTaskDocument(long overStoreTask, long document)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmOverStoreTask = dal.CreateParameter("OverStoreTask", overStoreTask);
                    IUniParameter prmDocument = dal.CreateParameter("Document", document);
                    dal.ExecuteNonQuery("OSM_DEL_TASKDOCUMENT_SP", prmOverStoreTask, prmDocument);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        /*Section="Method-ListTaskDocuments"*/
        public IEnumerable<TaskDocument> ListTaskDocuments(long overStoreTaskId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmOverStoreTask = dal.CreateParameter("OverStoreTask", overStoreTaskId);
                IUniParameter prmDocument = dal.CreateParameter("Document", null);
                return dal.List<TaskDocument>("OSM_LST_TASKDOCUMENT_SP", prmOverStoreTask, prmDocument).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public override OverStoreTask Create(OverStoreTask dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    dataObject.Organization = OTApplication.Context.Organization.Id;
                    dataObject.Event = 1058;//_parameterReader.ReadEventId("Task");

                    updateDataObjectDocument(dataObject, dal);
                    dataObject.OverStoreTaskId = dal.Create(dataObject);

                    startSuggestionProcess(dataObject, dal);

                    dal.CommitTransaction();
                    return dataObject;
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        private void startSuggestionProcess(DataModels.OverStoreMain.OverStoreTask dataModel, IDAL dal)
        {

            int processDefinitionId = _parameterReader.ReadPublicParameter<int>("GorevTakipSureci", 2021);
            var processInstanceRef = dataModel.OverStoreTaskId.ToString();


            IProcessInstance processInstance = new ProcessInstance(processDefinitionId, OTApplication.Context.User.Id);

            //Set Process Variables
            processInstance.AddProcessVariable("createUser", OTApplication.Context.User.Id);
            processInstance.AddProcessVariable("taskId", dataModel.OverStoreTaskId);
            processInstance.AddProcessVariable("screenReference", "AppMainModule#OverStoreTaskListComponent#" + processInstanceRef);
            processInstance.AddProcessVariable("responsibleType", dataModel.ResponsibleType);
            //switch(dataModel.ResponsibleType)
            //{
            //    case 1:
            //        processInstance.AddProcessVariable("responsibleUser", dataModel.ResponsibleUser);
            //        break;
            //    case 2:
            //        processInstance.AddProcessVariable("responsibleGroup", dataModel.ResponsibleGroup);
            //        break;
            //    case 3:
            //        processInstance.AddProcessVariable("responsibleBranch", dataModel.ResponsibleBranch);
            //        break;
            //}

            //Set Action Varibles
            // processInstance.AddActionVariable("user", OTApplication.Context.User.Id);
            //processInstance.AddActionVariable("description", dataModel.Description);

            //Start Process
            var processId = processInstance.Start(processInstanceRef);
            dataModel.ProcessInstance = processId;
            dal.Update(dataModel);
        }

        public void UpdateStatus(long taskId, long statusId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    OverStoreTask task = dal.Read<OverStoreTask>(taskId);
                    task.Status = statusId;
                    dal.Update(task);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public int GetAssignmentType(long taskId)
        {
            using (IDAL dal = this.DAL)
            {
                OverStoreTask task = dal.Read<DataModels.OverStoreMain.OverStoreTask>(taskId);
                return task.ResponsibleType;
            }
            
        }

        public long GetTaskResponsibleId(long taskId)
        {
            using (IDAL dal = this.DAL)
            {
                OverStoreTask task = dal.Read<DataModels.OverStoreMain.OverStoreTask>(taskId);
                switch (task.ResponsibleType)
                {
                    case 1:
                        return task.ResponsibleUser.Value;
                    case 2:
                        return task.ResponsibleGroup.Value;
                    case 3:
                        return task.ResponsibleBranch.Value;
                    default:
                        return task.ResponsibleUser.Value;
                }
            }
        }

        public void TakeAction(DataModels.OverStoreMain.OverStoreTask dataObject, long actionId, string choice, string comment)
        {
            using (IDAL dal = this.DAL)
            {

                dal.BeginTransaction();
                try
                {
                    // var originalObject = dal.Read<DataModels.OverStoreMain.OverStoreTask>(dataObject.OverStoreTaskId);
                    
                    IActionOperations actionOperations = new Overtech.API.BPM.ActionOperations(OTApplication.Context.User.Id);
                    IAction action = new Overtech.API.BPM.Action(actionId, OTApplication.Context.User.Id);
                    
                    dal.Update(dataObject);
                    action.Commit(choice, comment);

                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public override void Delete(long objectId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    // Get processInstanceNo of the sugggestion
                    var processInstance = dal.Read<OverStoreTask>(objectId).ProcessInstance;

                    // Delete via DAL 
                    dal.Delete<OverStoreTask>(objectId);

                    // Kill process via ProcessOperations
                    if (processInstance != null)
                    {
                        ProcessOperations processOperations = new ProcessOperations(OTApplication.Context.User.Id);
                        processOperations.Cancel(processInstance.Value);
                    }

                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public override void Update(DataModels.OverStoreMain.OverStoreTask dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    updateDataObjectDocument(dataObject, dal);
                    dal.Update(dataObject);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        private void updateDataObjectDocument(DataModels.OverStoreMain.OverStoreTask dataObject, IDAL dal)
        {
            var documentOperations = new DocumentOperations(dal, this._resolver);
            var documentType = documentOperations.ReadDocumentTypeByName("Task");
            var tempDocumentTypeId = _parameterReader.ReadSystemParameter<long>("TempDocumentType");
            var defaultRepositoryId = _parameterReader.ReadSystemParameter<long>("Default Document Repository Id");
            var defaultRepository = dal.Read<Repository>(defaultRepositoryId);

            foreach (var document in dataObject.DocumentList)
            {
                if (document.DocumentType == tempDocumentTypeId)
                {
                    document.DocumentType = documentType.DocumentTypeId;
                    dal.Update(document);
                    documentOperations.ChangeRepository(document, defaultRepository, false);
                }
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}