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
    [RoutePrefix("api/Gamification/GameLevel")]
    public class GameLevelController : CRUDLApiController<Overtech.DataModels.Gamification.GameLevel, IGameLevelService, Overtech.ViewModels.Gamification.GameLevel>
    {

        private readonly IGameService _gameService;

        /*Section="Constructor"*/
        public GameLevelController(
            ILoggerFactory loggerFactory,
            IGameLevelService gameLevelService,
            IGameService gameService
)
            : base(loggerFactory, gameLevelService)
        {
            _gameService = gameService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public DataSourceResult ListByMaster([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request, long masterId)
        {
            IEnumerable<Overtech.DataModels.Gamification.GameLevel> dataModel = _gameService.ListGameLevels(masterId);
            IEnumerable<Overtech.ViewModels.Gamification.GameLevel> viewModel = dataModel.Map<Overtech.DataModels.Gamification.GameLevel, Overtech.ViewModels.Gamification.GameLevel>();
            return viewModel.ToDataSourceResult(request);
        }

        /*Section="Method-ListAllByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListAllByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Gamification.GameLevel> ListAllByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Gamification.GameLevel> dataModel = _gameService.ListGameLevels(masterId);
            IEnumerable<Overtech.ViewModels.Gamification.GameLevel> viewModel = dataModel.Map<Overtech.DataModels.Gamification.GameLevel, Overtech.ViewModels.Gamification.GameLevel>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}