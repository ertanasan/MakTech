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
    public class NotificationGroupUserService : CRUDRDataService<Overtech.DataModels.Announcement.NotificationGroupUser>, INotificationGroupUserService
    {
        /*Section="Constructor-1"*/
        public NotificationGroupUserService()
        {
        }

        /*Section="Constructor-2"*/
        internal NotificationGroupUserService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public IEnumerable<DataModels.Announcement.NotificationGroupUser> ListAllGroupUsers()
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmGroup = dal.CreateParameter("NotificationGroup", null);
                IUniParameter prmUser = dal.CreateParameter("User", null);
                return dal.List<NotificationGroupUser>("ANN_LST_NOTIFICATIONGROUPUSER_SP", prmGroup, prmUser).ToList();
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}