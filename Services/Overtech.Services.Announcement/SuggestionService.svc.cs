// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Announcement;
using Overtech.ServiceContracts.Announcement;
using Overtech.Mutual.Parameter;
using Overtech.Mutual.Security;
using Overtech.Core.DependencyInjection;
using Overtech.API.BPM;
using Overtech.Core.Application;
using Overtech.DataModels.Security;

/*Section="ClassHeader"*/
namespace Overtech.Services.Announcement
{
    [OTInspectorBehavior]
    public class SuggestionService : CRUDLDataService<Overtech.DataModels.Announcement.Suggestion>, ISuggestionService
    {
        IParameterReader _parameterReader;
        IOTResolver _resolver;

        /*Section="Constructor-1"*/
        public SuggestionService(IParameterReader parameterReader, IOTResolver resolver)
        {
            _parameterReader = parameterReader;
            _resolver = resolver;
        }

        /*Section="Constructor-2"*/
        internal SuggestionService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public IEnumerable<Suggestion> ListAdmin(bool suggestionAdmin)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmAdmin = dal.CreateParameter("SuggestionAdmin", suggestionAdmin ? 'Y' : 'N');
                return dal.List<Overtech.DataModels.Announcement.Suggestion>("ANN_LST_SUGGESTION_SP", prmAdmin).ToList();
            }
        }

        public override Suggestion Create(Suggestion dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    dataObject.Organization = OTApplication.Context.Organization.Id;
                    // dataObject.Event = _parameterReader.ReadEventId("Make Suggestion");
                    dataObject.SuggestionId = dal.Create(dataObject);

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
            // return base.Create(dataObject);
        }

        private void startSuggestionProcess(DataModels.Announcement.Suggestion dataModel, IDAL dal)
        {

            int processDefinitionId = _parameterReader.ReadPublicParameter<int>("OneriSureci", 2011);
            var processInstanceRef = dataModel.SuggestionId.ToString();
            GroupOperations gop = new GroupOperations(dal);
            Group suggestionAdminGroup = gop.FindGroup("Öneri Değerlendirme Kullanıcıları");
            IProcessInstance processInstance = new ProcessInstance(processDefinitionId, OTApplication.Context.User.Id);

            //Set Process Variables
            processInstance.AddProcessVariable("user", OTApplication.Context.User.Id);
            processInstance.AddProcessVariable("screenReference", "Announcement#SuggestionListComponent#" + processInstanceRef);
            processInstance.AddProcessVariable("suggestionAdminGroup", suggestionAdminGroup.GroupId);
            processInstance.AddProcessVariable("suggestionId", dataModel.SuggestionId);


            //Set Action Varibles
            processInstance.AddActionVariable("user", OTApplication.Context.User.Id);
            //processInstance.AddActionVariable("description", dataModel.Description);

            //Start Process
            var processId = processInstance.Start(processInstanceRef);
            dataModel.ProcessInstance = processId;
            dal.Update(dataModel);
        }

        public void UpdateStatus(long suggestionId, long statusId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    Suggestion s = dal.Read<Suggestion>(suggestionId);
                    s.Status = statusId;
                    dal.Update(s);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public void TakeAction(DataModels.Announcement.Suggestion dataObject, long actionId, string choice, string comment)
        {
             

            using (IDAL dal = this.DAL)
            {

                dal.BeginTransaction();
                try
                {

                    // var originalObject = dal.Read<DataModels.Announcement.Suggestion>(dataObject.SuggestionId);

                    IActionOperations actionOperations = new Overtech.API.BPM.ActionOperations(OTApplication.Context.User.Id);
                    var actionInfo = actionOperations.GetActionInfo(actionId);
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
                    var processInstance = dal.Read<Suggestion>(objectId).ProcessInstance;

                    // Delete via DAL 
                    dal.Delete<Suggestion>(objectId);

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

        public IEnumerable<SuggestionHistory> ListHistoryData(long suggestionId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmId = dal.CreateParameter("Id", suggestionId);
                return dal.List<SuggestionHistory>("ANN_LST_SUGGESTIONHISTORY_SP", prmId).ToList();
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}