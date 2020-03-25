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
    [RoutePrefix("api/Gamification/GamePlayer")]
    public class GamePlayerController : CRUDLApiController<Overtech.DataModels.Gamification.GamePlayer, IGamePlayerService, Overtech.ViewModels.Gamification.GamePlayer>
    {
        /*Section="Constructor"*/
        public GamePlayerController(
            ILoggerFactory loggerFactory,
            IGamePlayerService gamePlayerService)
            : base(loggerFactory, gamePlayerService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [Route("ReadPlayerId")]
        [OTControllerAction("Read")]
        public virtual GamePlayer ReadPlayerId(int userId, int organization, string userName)
        {
            return _dataService.readPlayerId(userId, organization, userName).Map<Overtech.DataModels.Gamification.GamePlayer, GamePlayer>();
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}