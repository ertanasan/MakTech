using Overtech.Core.Logger;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Overtech.UI.Web;
using Overtech.Service.Authorization;
using Overtech.Core.DataSource;
using Overtech.UI.DataSource;
using Overtech.UI.Data.Annotations;
using Overtech.Core.Data;
using Overtech.API.BPM;
using Overtech.Core.Application;
using Overtech.Shared.OverStore.BPM;
using Overtech.ApiControllers.BPMCore;

namespace Overtech.ApiControllers.Warehouse
{
    [RoutePrefix("api/Warehouse/OverStoreInbox")]
    public class OverStoreInboxController : OTApiController<Overtech.DataModels.Security.User, Overtech.ServiceContracts.Security.IUserService, Overtech.ViewModels.Security.User>
    {
        public OverStoreInboxController(
            ILoggerFactory loggerFactory,
            Overtech.ServiceContracts.Security.IUserService userService)
            : base(loggerFactory, userService)
        {

        }

        [HttpGet]
        [AllowAuthenticated]
        [Route("List")]
        [OTControllerAction("List")]
        public DataSourceResult List([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request)
        {

            ActionOperations actionOperations = new ActionOperations(OTApplication.Context.User.Id);
            IEnumerable<Overtech.Shared.BPM.InboxItem> inboxItems = actionOperations.ListPendingActions(null);
            inboxItems.Localize(item => item.ProcessDefinitionName).ToList();

            IMapperConfig mapperConfig = MapperConfig.Init();
            mapperConfig.CreateMap<Overtech.Shared.BPM.InboxItem, OverStoreInboxItem>();
            IMapper mapper = mapperConfig.CreateMapper();

            IEnumerable<OverStoreInboxItem> mayaInboxItems = inboxItems.Select(item => new OverStoreInboxItem(item, mapper)).OrderByDescending(item => item.ActionId).ToList();

            return mayaInboxItems.ToDataSourceResult(request);
        }

        [HttpGet]
        [AllowAuthenticated]
        [Route("ListInboxSummary")]
        [OTControllerAction("List")]
        public InboxSummary ListInboxSummary()
        {
            IEnumerable<Overtech.Shared.BPM.InboxItem> source = (new ActionOperations(OTApplication.Context.User.Id)).ListPendingActions(null);
            IEnumerable<Overtech.Shared.BPM.InboxItem> InboxItemList = (from m in source
                                                    orderby m.ActionStartDate descending
                                                    select m).Take(10).ToList();
            return new InboxSummary
            {
                InboxItemList = InboxItemList,
                Count = source.Count()
            };
        }


    }
}
