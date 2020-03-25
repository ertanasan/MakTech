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
    [RoutePrefix("api/Announcement/NotificationStore")]
    public class NotificationStoreController : OTRelationApiController<Overtech.DataModels.Announcement.NotificationStore, INotificationStoreService, Overtech.ViewModels.Announcement.NotificationStore>
    {
        /*Section="Constructor"*/
        public NotificationStoreController(
            ILoggerFactory loggerFactory,
            INotificationStoreService notificationStoreService)
            : base(loggerFactory, notificationStoreService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [HttpPost]
        [Route("AddNotificationStores")]
        [OTControllerAction("Create")]
        public void CreateStorePackage([FromBody] Overtech.ViewModels.Announcement.NotificationStore viewModel)
        {
            _dataService.AddNotificationStores(viewModel.Map<Overtech.DataModels.Announcement.NotificationStore, Overtech.ViewModels.Announcement.NotificationStore>());

        }

        [HttpGet]
        [Route("GetNotificationStore")]
        [OTControllerAction("Read")]
        public ViewModels.Announcement.NotificationStore GetNotificationStore(long notificationId, long storeId)
        {
            return _dataService.GetNotificationStore(notificationId, storeId).Map<Overtech.DataModels.Announcement.NotificationStore, Overtech.ViewModels.Announcement.NotificationStore>();

        }

        [HttpPut]
        [Route("TakeAction")]
        [OTControllerAction("Update")]
        public void TakeAction([FromBody] ViewModels.Announcement.NotificationStore viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mapperConfig = MapperConfig.Init();

                    mapperConfig.CreateMap<DataModels.Announcement.NotificationStore, ViewModels.Announcement.NotificationStore>();
                    DataModels.Announcement.NotificationStore dataModel = viewModel.Map<DataModels.Announcement.NotificationStore, ViewModels.Announcement.NotificationStore>(mapperConfig);

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