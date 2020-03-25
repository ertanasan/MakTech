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
    [RoutePrefix("api/Helpdesk/RequestAdditionalInfo")]
    public class RequestAdditionalInfoController : CRUDLApiController<Overtech.DataModels.Helpdesk.RequestAdditionalInfo, IRequestAdditionalInfoService, Overtech.ViewModels.Helpdesk.RequestAdditionalInfo>
    {

        private readonly IHelpdeskRequestService _helpdeskRequestService;

        /*Section="Constructor"*/
        public RequestAdditionalInfoController(
            ILoggerFactory loggerFactory,
            IRequestAdditionalInfoService requestAdditionalInfoService,
            IHelpdeskRequestService helpdeskRequestService
)
            : base(loggerFactory, requestAdditionalInfoService)
        {
            _helpdeskRequestService = helpdeskRequestService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public DataSourceResult ListByMaster([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request, long masterId)
        {
            IEnumerable<Overtech.DataModels.Helpdesk.RequestAdditionalInfo> dataModel = _helpdeskRequestService.ListRequestAdditionalInfoes(masterId);
            IEnumerable<Overtech.ViewModels.Helpdesk.RequestAdditionalInfo> viewModel = dataModel.Map<Overtech.DataModels.Helpdesk.RequestAdditionalInfo, Overtech.ViewModels.Helpdesk.RequestAdditionalInfo>();
            return viewModel.ToDataSourceResult(request);
        }

        /*Section="Method-ListAllByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListAllByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Helpdesk.RequestAdditionalInfo> ListAllByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Helpdesk.RequestAdditionalInfo> dataModel = _helpdeskRequestService.ListRequestAdditionalInfoes(masterId);
            IEnumerable<Overtech.ViewModels.Helpdesk.RequestAdditionalInfo> viewModel = dataModel.Map<Overtech.DataModels.Helpdesk.RequestAdditionalInfo, Overtech.ViewModels.Helpdesk.RequestAdditionalInfo>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}