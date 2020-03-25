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
    [RoutePrefix("api/Helpdesk/AttributeChoice")]
    public class AttributeChoiceController : CRUDLApiController<Overtech.DataModels.Helpdesk.AttributeChoice, IAttributeChoiceService, Overtech.ViewModels.Helpdesk.AttributeChoice>
    {

        private readonly IRequestAttributeService _requestAttributeService;

        /*Section="Constructor"*/
        public AttributeChoiceController(
            ILoggerFactory loggerFactory,
            IAttributeChoiceService attributeChoiceService,
            IRequestAttributeService requestAttributeService
)
            : base(loggerFactory, attributeChoiceService)
        {
            _requestAttributeService = requestAttributeService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public DataSourceResult ListByMaster([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request, long masterId)
        {
            IEnumerable<Overtech.DataModels.Helpdesk.AttributeChoice> dataModel = _requestAttributeService.ListAttributeChoices(masterId);
            IEnumerable<Overtech.ViewModels.Helpdesk.AttributeChoice> viewModel = dataModel.Map<Overtech.DataModels.Helpdesk.AttributeChoice, Overtech.ViewModels.Helpdesk.AttributeChoice>();
            return viewModel.ToDataSourceResult(request);
        }

        /*Section="Method-ListAllByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListAllByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Helpdesk.AttributeChoice> ListAllByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Helpdesk.AttributeChoice> dataModel = _requestAttributeService.ListAttributeChoices(masterId);
            IEnumerable<Overtech.ViewModels.Helpdesk.AttributeChoice> viewModel = dataModel.Map<Overtech.DataModels.Helpdesk.AttributeChoice, Overtech.ViewModels.Helpdesk.AttributeChoice>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}