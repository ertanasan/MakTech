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
using Overtech.ViewModels.Helpdesk;
using System;
using Overtech.Core;
using Overtech.Shared.BPM;
using System.Data;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Helpdesk
{
    [RoutePrefix("api/Helpdesk/HelpdeskRequest")]
    public class HelpdeskRequestController : CRUDLApiController<Overtech.DataModels.Helpdesk.HelpdeskRequest, IHelpdeskRequestService, Overtech.ViewModels.Helpdesk.HelpdeskRequest>
    {
        IMapperConfig mapperConfig = MapperConfig.Init().CreateMap<Overtech.DataModels.Helpdesk.HelpdeskRequest, Overtech.ViewModels.Helpdesk.HelpdeskRequest>()
                                            .CreateMap<Overtech.DataModels.Helpdesk.RequestDetail, Overtech.ViewModels.Helpdesk.RequestDetail>();
        /*Section="Constructor"*/
        public HelpdeskRequestController(
            ILoggerFactory loggerFactory,
            IHelpdeskRequestService helpdeskRequestService)
            : base(loggerFactory, helpdeskRequestService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public override HelpdeskRequest Create([FromBody] HelpdeskRequest viewModel)
        {
            DataModels.Helpdesk.HelpdeskRequest dmrec = viewModel.Map<Overtech.DataModels.Helpdesk.HelpdeskRequest, HelpdeskRequest>(mapperConfig);
            return _dataService.CreateRequest(dmrec).Map<Overtech.DataModels.Helpdesk.HelpdeskRequest, HelpdeskRequest>(mapperConfig);
            // return base.Create(viewModel);
        }

        public override HelpdeskRequest Read(long id)
        {
            return _dataService.ReadRequest(id).Map<Overtech.DataModels.Helpdesk.HelpdeskRequest, HelpdeskRequest>(mapperConfig);
        }

        [HttpPut]
        [Route("TakeAction")]
        [OTControllerAction("Update")]
        public void TakeAction([FromBody] ViewModels.Helpdesk.HelpdeskRequest viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mapperConfig = MapperConfig.Init();

                    mapperConfig.CreateMap<DataModels.Helpdesk.HelpdeskRequest, ViewModels.Helpdesk.HelpdeskRequest>();
                    DataModels.Helpdesk.HelpdeskRequest dataModel = viewModel.Map<DataModels.Helpdesk.HelpdeskRequest, ViewModels.Helpdesk.HelpdeskRequest>(mapperConfig);

                    _dataService.TakeAction(dataModel, viewModel.action, viewModel.actionChoice, viewModel.actionComment);

                }
                catch (Exception ex)
                {
                    _logger.Error(PrepareExceptionMessage(System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
                    throw CreateUserException(ex);
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);
                throw CreateUserException(new OTException(OTErrors.ModelStateInvalid, true, null, errors));
            }
        }

        [HttpGet]
        [Route("ListFiltered")]
        [OTControllerAction("List")]
        public IEnumerable<HelpdeskRequest> ListFiltered(Boolean OpenFlag, DateTime StartDate, DateTime EndDate)
        {
            return _dataService.ListFiltered(OpenFlag, StartDate, EndDate).Map<DataModels.Helpdesk.HelpdeskRequest, HelpdeskRequest>();
        }

        [HttpGet]
        [Route("UserTask")]
        [OTControllerAction("Read")]
        public RequestBPM UserTask(long ProcessInstanceId)
        {
            return _dataService.UserTask(ProcessInstanceId).Map<DataModels.Helpdesk.RequestBPM, RequestBPM>();
        }

        [HttpGet]
        [Route("TaskDashboard")]
        [OTControllerAction("List")]
        public IEnumerable<DataSourceResult> TaskDashboard()
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSet dtReport = null;
            dtReport = _dataService.TaskDashboard();
            IEnumerable<DataSourceResult> result = (new[] { 
                dtReport.Tables[0].ToDataSourceResult(request), 
                dtReport.Tables[1].ToDataSourceResult(request),
                dtReport.Tables[2].ToDataSourceResult(request),
                dtReport.Tables[3].ToDataSourceResult(request)});
            return result;
        }
        #endregion Customized
    }
        /*Section="ClassFooter"*/
        
}