// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using Overtech.Core.DataSource;
using Overtech.UI.DataSource;

using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Helpdesk;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Helpdesk
{
    [RoutePrefix("api/Helpdesk/RequestDefinition")]
    public class RequestDefinitionController : CRUDLApiController<Overtech.DataModels.Helpdesk.RequestDefinition, IRequestDefinitionService, Overtech.ViewModels.Helpdesk.RequestDefinition>
    {

        private readonly IRequestGroupService _requestGroupService;

        /*Section="Constructor"*/
        public RequestDefinitionController(
            ILoggerFactory loggerFactory,
            IRequestDefinitionService requestDefinitionService,
            IRequestGroupService requestGroupService
)
            : base(loggerFactory, requestDefinitionService)
        {
            _requestGroupService = requestGroupService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public DataSourceResult ListByMaster([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request, long masterId)
        {
            IEnumerable<Overtech.DataModels.Helpdesk.RequestDefinition> dataModel = _requestGroupService.ListRequestDefinitions(masterId);
            IEnumerable<Overtech.ViewModels.Helpdesk.RequestDefinition> viewModel = dataModel.Map<Overtech.DataModels.Helpdesk.RequestDefinition, Overtech.ViewModels.Helpdesk.RequestDefinition>();
            return viewModel.ToDataSourceResult(request);
        }

        /*Section="Method-ListAllByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListAllByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Helpdesk.RequestDefinition> ListAllByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Helpdesk.RequestDefinition> dataModel = _requestGroupService.ListRequestDefinitions(masterId);
            IEnumerable<Overtech.ViewModels.Helpdesk.RequestDefinition> viewModel = dataModel.Map<Overtech.DataModels.Helpdesk.RequestDefinition, Overtech.ViewModels.Helpdesk.RequestDefinition>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}