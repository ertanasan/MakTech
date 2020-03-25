// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System;
using System.Reflection;
using System.Data;
using Overtech.Core.DataSource;
using Overtech.UI.DataSource;

using Overtech.Core;
using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Announcement;
using System.Web.Http.ModelBinding;
using Overtech.ViewModels.Announcement;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Announcement
{
    [RoutePrefix("api/Announcement/Suggestion")]
    public class SuggestionController : CRUDLApiController<Overtech.DataModels.Announcement.Suggestion, ISuggestionService, Overtech.ViewModels.Announcement.Suggestion>
    {
        /*Section="Constructor"*/
        public SuggestionController(
            ILoggerFactory loggerFactory,
            ISuggestionService suggestionService)
            : base(loggerFactory, suggestionService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        IMapperConfig mapperConfig = MapperConfig.Init().CreateMap<Overtech.DataModels.Announcement.SuggestionHistory, Overtech.ViewModels.Announcement.SuggestionHistory>()
                                            .CreateMap<Overtech.DataModels.Announcement.SuggestionHistory, Overtech.ViewModels.Announcement.SuggestionHistory>();

        [HttpGet]
        [Route("List")]
        [OTControllerAction("List")]
        public DataSourceResult List(bool suggestionAdmin, [ModelBinder(typeof(WebApiDataSourceRequestModelBinder))] DataSourceRequest request)
        {
            // DataSourceResult result;
            // DataTable dtReport = null;
            DataSourceResult result;
            result = _dataService.ListAdmin(suggestionAdmin).Map<Overtech.DataModels.Announcement.Suggestion, Overtech.ViewModels.Announcement.Suggestion>().ToDataSourceResult(request);
            return result;
            // dtReport = _dataService.List(suggestionAdmin);
            // result = dtReport.ToDataSourceResult(request);
            // return result;
        }

        [HttpPut]
        [Route("TakeAction")]
        [OTControllerAction("Update")]
        public void TakeAction([FromBody] ViewModels.Announcement.Suggestion viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mapperConfig = MapperConfig.Init();

                    mapperConfig.CreateMap<DataModels.Announcement.Suggestion, ViewModels.Announcement.Suggestion>();
                    DataModels.Announcement.Suggestion dataModel = viewModel.Map<DataModels.Announcement.Suggestion, ViewModels.Announcement.Suggestion>(mapperConfig);

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

        [HttpGet]
        [OTControllerAction("List")]
        [Route("ListHistoryData")]
        public IEnumerable<Overtech.ViewModels.Announcement.SuggestionHistory> ListHistoryData(long suggestionId)
        {
            return _dataService.ListHistoryData(suggestionId).Map<DataModels.Announcement.SuggestionHistory, ViewModels.Announcement.SuggestionHistory>(mapperConfig);
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}