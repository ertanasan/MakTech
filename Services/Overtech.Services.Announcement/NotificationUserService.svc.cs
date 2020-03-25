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
using Overtech.Mutual.Parameter;
using Overtech.Core.DependencyInjection;
using Overtech.API.BPM;
using Overtech.Core.Application;
using Overtech.DataModels.Security;
using Overtech.Core.BPM;

/*Section="ClassHeader"*/
namespace Overtech.Services.Announcement
{
    [OTInspectorBehavior]
    public class NotificationUserService : CRUDRDataService<Overtech.DataModels.Announcement.NotificationUser>, INotificationUserService
    {
        IParameterReader _parameterReader;
        IOTResolver _resolver;

        /*Section="Constructor-1" IsCustomized=true*/
        public NotificationUserService(IParameterReader parameterReader, IOTResolver resolver)
        {
            _parameterReader = parameterReader;
            _resolver = resolver;
        }

        /*Section="Constructor-2"*/
        internal NotificationUserService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public void AddNotificationUsers(NotificationUser notificationUser)
        {
            using (IDAL dal = this.DAL)
            {
                try
                {
                    dal.BeginTransaction();

                    IUniParameter prmNotificationId = dal.CreateParameter("Notification", notificationUser.Notification);
                    IUniParameter prmUserId = dal.CreateParameter("User", null);
                    IEnumerable<NotificationUser> notificationUserList = dal.List<NotificationUser>("ANN_LST_NOTIFICATIONUSER_SP", prmNotificationId, prmUserId).ToList();
                    var notificationUserIds = notificationUserList.Select(x => x.User).ToArray();

                    foreach (int userId in notificationUser.UserList)
                    {
                        if (notificationUserIds.Contains(userId) == false)
                        {
                            notificationUser.User = userId;
                            dal.Create<NotificationUser>(notificationUser);
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

        public NotificationUser GetNotificationUser(long notificationId, long userId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmNotificationId = dal.CreateParameter("Notification", notificationId);
                IUniParameter prmUserId = dal.CreateParameter("User", userId);
                return dal.Read<NotificationUser>("ANN_SEL_NOTIFICATIONUSER_SP", prmNotificationId, prmUserId);
            }
        }

        public void DeleteNotificationUsers(IEnumerable<DataModels.Announcement.NotificationUser> notificationUsers, IDAL dal)
        {
            foreach(DataModels.Announcement.NotificationUser notUser in notificationUsers)
            {
                // Kill process via ProcessOperations
                if (notUser.ProcessInstance != null)
                {
                    ProcessOperations processOperations = new ProcessOperations(OTApplication.Context.User.Id);
                    if (processOperations.GetInstanceStatus(notUser.ProcessInstance.Value) != Overtech.Core.BPM.InstanceStatus.Canceled)
                    {
                        try
                        {
                            processOperations.Cancel(notUser.ProcessInstance.Value);
                        } 
                        catch {}
                    }
                }

                // Delete NotificationUser
                IUniParameter prmNotification = dal.CreateParameter("Notification", notUser.Notification);
                IUniParameter prmUser = dal.CreateParameter("User", notUser.User);
                dal.ExecuteNonQuery("ANN_DEL_NOTIFICATIONUSER_SP", prmNotification, prmUser);
            }
        }

        public void PublishNotificationForUser(IEnumerable<DataModels.Announcement.NotificationUser> notificationUserList, IDAL dal)
        {
            foreach (DataModels.Announcement.NotificationUser notificationUser in notificationUserList)
            {
                if (notificationUser.ProcessInstance == null)
                {
                    startNotificationUserProcess(notificationUser, dal);
                }
            }
        }

        private void startNotificationUserProcess(DataModels.Announcement.NotificationUser dataModel, IDAL dal)
        {

            int processDefinitionId = _parameterReader.ReadPublicParameter<int>("SubeDuyuruSureci", 2010);
            var user = dal.Read<User>(dataModel.User);
            var processInstanceRef = 'N' + dataModel.Notification.ToString() + 'U' + dataModel.User.ToString();
            // var processInstanceRef = dataModel.Notification.ToString();
            // var branch = dal.Read<Branch>(store.OrganizationBranch);
            IProcessInstance processInstance = new ProcessInstance(processDefinitionId, OTApplication.Context.User.Id);

            // Set Process Variables
            processInstance.AddProcessVariable("user", OTApplication.Context.User.Id);
            processInstance.AddProcessVariable("screenReference", "Announcement#NotificationListComponent#" + processInstanceRef);
            // processInstance.AddProcessVariable("branch", user.Branch);
            processInstance.AddProcessVariable("branchUser", dataModel.User);
            processInstance.AddProcessVariable("notification", dataModel.Notification);


            // Set Action Varibles
            processInstance.AddActionVariable("user", OTApplication.Context.User.Id);
            //processInstance.AddActionVariable("description", dataModel.Description);

            // Start Process
            var processId = processInstance.Start(processInstanceRef);

            // Assing ProcessInstanceID to NotificationUser;
            dataModel.ProcessInstance = processId;
            IUniParameter prmNotificationId = dal.CreateParameter("Notification", dataModel.Notification);
            IUniParameter prmUserId = dal.CreateParameter("User", dataModel.User);
            IUniParameter prmProcessInstance = dal.CreateParameter("ProcessInstance", processId);
            dal.ExecuteNonQuery("ANN_UPD_NOTIFICATIONUSER_SP", prmNotificationId, prmUserId, prmProcessInstance);
        }


        public void TakeAction(DataModels.Announcement.NotificationUser dataObject, long actionId, string choice, string comment)
        {
            // var originalObject = GetNotificationUser(dataObject.Notification, dataObject.User);

            IActionOperations actionOperations = new Overtech.API.BPM.ActionOperations(OTApplication.Context.User.Id);
            var actionInfo = actionOperations.GetActionInfo(actionId);
            IAction action = new Overtech.API.BPM.Action(actionId, OTApplication.Context.User.Id);

            using (IDAL dal = this.DAL)
            {

                dal.BeginTransaction();
                try
                {
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