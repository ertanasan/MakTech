// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Core.Application;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Announcement;
using Overtech.ServiceContracts.Announcement;

// Usings for Document operations
using Overtech.Mutual.DocumentManagement;
using Overtech.DataModels.Document;
using Overtech.Mutual.Parameter;
using Overtech.Core.DependencyInjection;

/*Section="ClassHeader"*/
namespace Overtech.Services.Announcement
{
    [OTInspectorBehavior]
    public class NotificationService : CRUDLDataService<Overtech.DataModels.Announcement.Notification>, INotificationService
    {
        IParameterReader _parameterReader;
        IOTResolver _resolver;

        NotificationUserService _notificationUserService;
        /*Section="Constructor-1"*/
        public NotificationService(
            NotificationUserService notificationUserService,
            IParameterReader parameterReader,
            IOTResolver resolver)
        {
            _notificationUserService = notificationUserService;
            _parameterReader = parameterReader;
            _resolver = resolver;
        }

        /*Section="Constructor-2"*/
        internal NotificationService(IDAL dal)
            : base(dal)
        {
        }
        

        /*Section="Method-ListNotificationUsers"*/
        public IEnumerable<NotificationUser> ListNotificationUsers(long notificationId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmNotification = dal.CreateParameter("Notification", notificationId);
                IUniParameter prmUser = dal.CreateParameter("User", null);
                return dal.List<NotificationUser>("ANN_LST_NOTIFICATIONUSER_SP", prmNotification, prmUser).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public override void Delete(long notificationId)
        {
            var notificationUserList = ListNotificationUsers(notificationId);

            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    _notificationUserService.DeleteNotificationUsers(notificationUserList, dal);
                    dal.Delete<Notification>(notificationId);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public void PublishNotification(DataModels.Announcement.Notification notification)
        {
            if (notification.NotificationStatus == 1)
            {
                var notificationUserList = ListNotificationUsers(notification.NotificationId);
                using (IDAL dal = this.DAL)
                {
                    dal.BeginTransaction();
                    try
                    {
                        // Update The Status Of Notification
                        notification.NotificationStatus = 2;
                        dal.Update<Notification>(notification);

                        // Publish Notification To Each User In The List
                        _notificationUserService.PublishNotificationForUser(notificationUserList, dal);

                        dal.CommitTransaction();
                    }
                    catch (Exception e)
                    {
                        dal.RollbackTransaction();
                        throw;
                    }
                }
            }
            else
            {
                throw new System.InvalidOperationException("Notification is already published");
            }
        }

        public IEnumerable<DataModels.Announcement.Notification> GetUserNotifications(string isSystemNotificationsIncluded)
        {
            using (IDAL dal = this.DAL)
            {
                var userId = OTApplication.Context.User.Id;
                IUniParameter prmType = dal.CreateParameter("IncludeSystemType", isSystemNotificationsIncluded);
                var notifications = dal.List<Notification>("ANN_LST_NOTIFICATION_SP", prmType).ToList();

                IUniParameter prmNotification = dal.CreateParameter("Notification", null);
                IUniParameter prmUser = dal.CreateParameter("User", userId);
                var notificationUserList = dal.List<NotificationUser>("ANN_LST_NOTIFICATIONUSER_SP", prmNotification, prmUser).Where(n => n.IsRead == true).ToList();

                return notifications.Where(a => notificationUserList.Select(n => n.Notification).ToList().IndexOf(a.NotificationId) != -1);
            }
        }

        public override Notification Create(Notification dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    updateDataObjectDocument(dataObject, dal);
                    dal.Create(dataObject);
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

        public override void Update(Notification dataObject)
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

        private void updateDataObjectDocument(Notification dataObject, IDAL dal)
        {
            var documentOperations = new DocumentOperations(dal, this._resolver);
            var documentType = documentOperations.ReadDocumentTypeByName("Notification Attachment");
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

        public void CreateLogForDownload(long documentId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmDocument = dal.CreateParameter("Document", documentId);
                    dal.ExecuteNonQuery("OSM_INS_DOCUMENTDOWNLOADLOG_SP", prmDocument);
                    dal.CommitTransaction();
                }
                catch (Exception)
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