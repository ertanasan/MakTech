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
    [RoutePrefix("api/Helpdesk/RequestDetail")]
    public class RequestDetailController : CRUDLApiController<Overtech.DataModels.Helpdesk.RequestDetail, IRequestDetailService, Overtech.ViewModels.Helpdesk.RequestDetail>
    {

        private readonly IHelpdeskRequestService _helpdeskRequestService;

        /*Section="Constructor"*/
        public RequestDetailController(
            ILoggerFactory loggerFactory,
            IRequestDetailService requestDetailService,
            IHelpdeskRequestService helpdeskRequestService
)
            : base(loggerFactory, requestDetailService)
        {
            _helpdeskRequestService = helpdeskRequestService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public DataSourceResult ListByMaster([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request, long masterId)
        {
            IEnumerable<Overtech.DataModels.Helpdesk.RequestDetail> dataModel = _helpdeskRequestService.ListRequestDetails(masterId);
            IEnumerable<Overtech.ViewModels.Helpdesk.RequestDetail> viewModel = dataModel.Map<Overtech.DataModels.Helpdesk.RequestDetail, Overtech.ViewModels.Helpdesk.RequestDetail>();
            return viewModel.ToDataSourceResult(request);
        }

        /*Section="Method-ListAllByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListAllByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Helpdesk.RequestDetail> ListAllByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Helpdesk.RequestDetail> dataModel = _helpdeskRequestService.ListRequestDetails(masterId);
            IEnumerable<Overtech.ViewModels.Helpdesk.RequestDetail> viewModel = dataModel.Map<Overtech.DataModels.Helpdesk.RequestDetail, Overtech.ViewModels.Helpdesk.RequestDetail>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}