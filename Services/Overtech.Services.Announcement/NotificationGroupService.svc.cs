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

/*Section="ClassHeader"*/
namespace Overtech.Services.Announcement
{
    [OTInspectorBehavior]
    public class NotificationGroupService : CRUDLDataService<Overtech.DataModels.Announcement.NotificationGroup>, INotificationGroupService
    {
        /*Section="Constructor-1"*/
        public NotificationGroupService()
        {
        }

        /*Section="Constructor-2"*/
        internal NotificationGroupService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Announcement.NotificationGroup Find(string groupName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmGroupName = dal.CreateParameter("GroupName", groupName);
                return dal.Read<Overtech.DataModels.Announcement.NotificationGroup>("ANN_SEL_FINDNOTIFICATIONGROUP_SP", prmGroupName);
            }
        }

        /*Section="Method-CreateNotificationGroupUser"*/
        public void CreateNotificationGroupUser(NotificationGroupUser notificationGroupUser)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmNotificationGroup = dal.CreateParameter("NotificationGroup", notificationGroupUser.NotificationGroup);
                    IUniParameter prmUser = dal.CreateParameter("User", notificationGroupUser.User);
                    dal.ExecuteNonQuery("ANN_INS_NOTIFICATIONGROUPUSER_SP", prmNotificationGroup, prmUser);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        /*Section="Method-ReadNotificationGroupUser"*/
        public NotificationGroupUser ReadNotificationGroupUser(long notificationGroup, long user)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmNotificationGroup = dal.CreateParameter("NotificationGroup", notificationGroup);
                IUniParameter prmUser = dal.CreateParameter("User", user);
                return dal.Read<NotificationGroupUser>("ANN_SEL_NOTIFICATIONGROUPUSER_SP", prmNotificationGroup, prmUser);
            }
        }

        /*Section="Method-DeleteNotificationGroupUser"*/
        public void DeleteNotificationGroupUser(long notificationGroup, long user)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmNotificationGroup = dal.CreateParameter("NotificationGroup", notificationGroup);
                    IUniParameter prmUser = dal.CreateParameter("User", user);
                    dal.ExecuteNonQuery("ANN_DEL_NOTIFICATIONGROUPUSER_SP", prmNotificationGroup, prmUser);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        /*Section="Method-ListNotificationGroupUsers"*/
        public IEnumerable<NotificationGroupUser> ListNotificationGroupUsers(long notificationGroupId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmNotificationGroup = dal.CreateParameter("NotificationGroup", notificationGroupId);
                IUniParameter prmUser = dal.CreateParameter("User", null);
                return dal.List<NotificationGroupUser>("ANN_LST_NOTIFICATIONGROUPUSER_SP", prmNotificationGroup, prmUser).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}