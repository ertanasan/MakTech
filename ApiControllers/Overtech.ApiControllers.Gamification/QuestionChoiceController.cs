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
using Overtech.ServiceContracts.Gamification;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Gamification
{
    [RoutePrefix("api/Gamification/QuestionChoice")]
    public class QuestionChoiceController : CRUDLApiController<Overtech.DataModels.Gamification.QuestionChoice, IQuestionChoiceService, Overtech.ViewModels.Gamification.QuestionChoice>
    {

        private readonly IGameQuestionService _gameQuestionService;

        /*Section="Constructor"*/
        public QuestionChoiceController(
            ILoggerFactory loggerFactory,
            IQuestionChoiceService questionChoiceService,
            IGameQuestionService gameQuestionService
)
            : base(loggerFactory, questionChoiceService)
        {
            _gameQuestionService = gameQuestionService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public DataSourceResult ListByMaster([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request, long masterId)
        {
            IEnumerable<Overtech.DataModels.Gamification.QuestionChoice> dataModel = _gameQuestionService.ListQuestionChoices(masterId);
            IEnumerable<Overtech.ViewModels.Gamification.QuestionChoice> viewModel = dataModel.Map<Overtech.DataModels.Gamification.QuestionChoice, Overtech.ViewModels.Gamification.QuestionChoice>();
            return viewModel.ToDataSourceResult(request);
        }

        /*Section="Method-ListAllByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListAllByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Gamification.QuestionChoice> ListAllByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Gamification.QuestionChoice> dataModel = _gameQuestionService.ListQuestionChoices(masterId);
            IEnumerable<Overtech.ViewModels.Gamification.QuestionChoice> viewModel = dataModel.Map<Overtech.DataModels.Gamification.QuestionChoice, Overtech.ViewModels.Gamification.QuestionChoice>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}