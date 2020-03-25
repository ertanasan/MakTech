// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Announcement;
using Overtech.ServiceContracts.Announcement;
using Overtech.DataModels.Store;
using Overtech.Mutual.Parameter;
using Overtech.Core.DependencyInjection;
using Overtech.DataModels.Organization;
using Overtech.API.BPM;
using Overtech.Core.Application;

/*Section="ClassHeader"*/
namespace Overtech.Services.Announcement
{
    [OTInspectorBehavior]
    public class NotificationStoreService : CRUDRDataService<Overtech.DataModels.Announcement.NotificationStore>, INotificationStoreService
    {

        IParameterReader _parameterReader;
        IOTResolver _resolver;

        /*Section="Constructor-1", IsCustomized=true*/
        public NotificationStoreService(IParameterReader parameterReader, IOTResolver resolver)
        {
            this._parameterReader = parameterReader;
            _resolver = resolver;
        }

        /*Section="Constructor-2"*/
        internal NotificationStoreService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public void AddNotificationStores(NotificationStore notificationStore)
        {
            using (IDAL dal = this.DAL)
            {
                try
                {
                    dal.BeginTransaction();

                    IUniParameter prmNotificationId = dal.CreateParameter("Notification", notificationStore.Notification);
                    IUniParameter prmStoreId = dal.CreateParameter("Store", null);
                    IEnumerable<NotificationStore> notStores = dal.List<NotificationStore>("ANN_LST_NOTIFICATIONSTORE_SP", prmNotificationId, prmStoreId).ToList();
                    var notStoreIds = notStores.Select(x => x.Store).ToArray();

                    foreach (int storeId in notificationStore.StoreList)
                    {
                        if (notStoreIds.Contains(storeId) == false) 
                        {
                            notificationStore.Store = storeId;
                            dal.Create<NotificationStore>(notificationStore);
                        }
                    }
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
        }

        public NotificationStore GetNotificationStore(long notificationId, long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmNotificationId = dal.CreateParameter("Notification", notificationId);
                IUniParameter prmStoreId = dal.CreateParameter("Store", storeId);
                return dal.List<NotificationStore>("ANN_SEL_NOTIFICATIONSTORE_SP", prmNotificationId, prmStoreId).ToList().First();
            }
        }

        public void UpdateNotificationStore(NotificationStore dataModel, IDAL dal)
        {

            //using (IDAL dal = this.DAL)
            //{
            //dal.BeginTransaction();
            try
            {
                IUniParameter prmNotificationId = dal.CreateParameter("Notification", dataModel.Notification);
                IUniParameter prmStoreId = dal.CreateParameter("Store", dataModel.Store);
                IUniParameter prmProcessInstance = dal.CreateParameter("ProcessInstance", dataModel.ProcessInstance);
                dal.ExecuteNonQuery("ANN_UPD_NOTIFICATIONSTORE_SP", prmNotificationId, prmStoreId, prmProcessInstance);
                //dal.CommitTransaction();
            }
            catch (Exception e)
            {
                //dal.RollbackTransaction();
                throw;
            }
            //}
        }

        public void PublishNotificationForStore(DataModels.Announcement.NotificationStore dataModel)
        {
            using (IDAL dal = this.DAL)
            {
                try
                {
                    dal.BeginTransaction();
                    startNotificationStoreProcess(dataModel, dal);
                    dal.CommitTransaction();
                }
                catch(Exception ex)
                {
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
        }

        private void startNotificationStoreProcess(DataModels.Announcement.NotificationStore dataModel, IDAL dal)
        {

            int processDefinitionId = _parameterReader.ReadPublicParameter<int>("SubeDuyuruSureci", 2010);
            var store = dal.Read<Store>(dataModel.Store);
            var processInstanceRef = 'N' + dataModel.Notification.ToString() + 'S' + dataModel.Store.ToString();
            // var processInstanceRef = dataModel.Notification.ToString();
            // var branch = dal.Read<Branch>(store.OrganizationBranch);
            IProcessInstance processInstance = new ProcessInstance(processDefinitionId, OTApplication.Context.User.Id);
            //Set Process Variables
            processInstance.AddProcessVariable("user", OTApplication.Context.User.Id);
            processInstance.AddProcessVariable("screenReference", "Announcement#NotificationListComponent#" + processInstanceRef);
            processInstance.AddProcessVariable("branch", store.OrganizationBranch);
            processInstance.AddProcessVariable("store", dataModel.Store);
            processInstance.AddProcessVariable("notification", dataModel.Notification);


            //Set Action Varibles
            processInstance.AddActionVariable("user", OTApplication.Context.User.Id);
            //processInstance.AddActionVariable("description", dataModel.Description);

            //Start Process
            var processId = processInstance.Start(processInstanceRef);
            dataModel.ProcessInstance = processId;
            // dal.Update(dataModel);
            UpdateNotificationStore(dataModel, dal);
        }


        public void TakeAction(DataModels.Announcement.NotificationStore dataObject, long actionId, string choice, string comment)
        {
            var originalObject = GetNotificationStore(dataObject.Notification, dataObject.Store);

            IActionOperations actionOperations = new Overtech.API.BPM.ActionOperations(OTApplication.Context.User.Id);

            var actionInfo = actionOperations.GetActionInfo(actionId);

            IAction action = new Overtech.API.BPM.Action(actionId, OTApplication.Context.User.Id);

            using (IDAL dal = this.DAL)
            {

                dal.BeginTransaction();
                try
                {
                    
                    // dal.Update(originalObject);
                    UpdateNotificationStore(originalObject, dal);

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
        #endregion Customized

        /*Section="ClassFooter"*/

    }
}