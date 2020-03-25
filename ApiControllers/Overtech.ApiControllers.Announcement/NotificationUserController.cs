// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System;
using System.Reflection;
using Overtech.Core.DataSource;
using Overtech.UI.DataSource;

using Overtech.Core;
using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Announcement;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Announcement
{
    [RoutePrefix("api/Announcement/NotificationUser")]
    public class NotificationUserController : OTRelationApiController<Overtech.DataModels.Announcement.NotificationUser, INotificationUserService, Overtech.ViewModels.Announcement.NotificationUser>
    {
        /*Section="Constructor"*/
        public NotificationUserController(
            ILoggerFactory loggerFactory,
            INotificationUserService notificationUserService)
            : base(loggerFactory, notificationUserService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [HttpPost]
        [Route("AddNotificationUsers")]
        [OTControllerAction("Create")]
        public void AddNotificationUsers([FromBody] Overtech.ViewModels.Announcement.NotificationUser viewModel)
        {
            _dataService.AddNotificationUsers(viewModel.Map<Overtech.DataModels.Announcement.NotificationUser, Overtech.ViewModels.Announcement.NotificationUser>());

        }

        [HttpGet]
        [Route("GetNotificationUser")]
        [OTControllerAction("Read")]
        public ViewModels.Announcement.NotificationUser GetNotificationUser(long notificationId, long userId)
        {
            return _dataService.GetNotificationUser(notificationId, userId).Map<Overtech.DataModels.Announcement.NotificationUser, Overtech.ViewModels.Announcement.NotificationUser>();

        }

        [HttpPut]
        [Route("TakeAction")]
        [OTControllerAction("Update")]
        public void TakeAction([FromBody] ViewModels.Announcement.NotificationUser viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mapperConfig = MapperConfig.Init();

                    mapperConfig.CreateMap<DataModels.Announcement.NotificationUser, ViewModels.Announcement.NotificationUser>();
                    DataModels.Announcement.NotificationUser dataModel = viewModel.Map<DataModels.Announcement.NotificationUser, ViewModels.Announcement.NotificationUser>(mapperConfig);

                    _dataService.TakeAction(dataModel, viewModel.action, viewModel.actionChoice, viewModel.actionComment);

                }
                catch (Exception ex)
                {
                    _logger.Error(PrepareExceptionMessage(MethodBase.GetCurrentMethod().Name), ex);
                    throw CreateUserException(ex);
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);
                throw CreateUserException(new OTException(OTErrors.ModelStateInvalid, true, null, errors));
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}