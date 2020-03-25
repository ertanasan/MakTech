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
using Overtech.ViewModels.Gamification;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Gamification
{
    [RoutePrefix("api/Gamification/GamePlay")]
    public class GamePlayController : CRUDLApiController<Overtech.DataModels.Gamification.GamePlay, IGamePlayService, Overtech.ViewModels.Gamification.GamePlay>
    {
        /*Section="Constructor"*/
        public GamePlayController(
            ILoggerFactory loggerFactory,
            IGamePlayService gamePlayService)
            : base(loggerFactory, gamePlayService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        IMapperConfig mapperConfig = MapperConfig.Init().CreateMap<Overtech.DataModels.Gamification.GameQuestion, Overtech.ViewModels.Gamification.GameQuestion>()
                                        .CreateMap<Overtech.DataModels.Gamification.QuestionChoice, Overtech.ViewModels.Gamification.QuestionChoice>();

        [HttpGet]
        [Route("PlayQuestions")]
        [OTControllerAction("List")]
        public virtual IEnumerable<GameQuestion> ListPlayLevelQuestions(long playId, int minDiffLevelCode, int maxDiffLevelCode, int questionCount)
        {
            return _dataService.listPlayLevelQuestions(playId, minDiffLevelCode, maxDiffLevelCode, questionCount).Map<Overtech.DataModels.Gamification.GameQuestion, GameQuestion>(mapperConfig);
        }

        [HttpGet]
        [Route("ListScores")]
        [OTControllerAction("List")]
        public virtual IEnumerable<GameScore> ListScores()
        {
            return _dataService.ListScores().Map<Overtech.DataModels.Gamification.GameScore, GameScore>();
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}