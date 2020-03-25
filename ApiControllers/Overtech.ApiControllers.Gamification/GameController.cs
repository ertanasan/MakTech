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
    [RoutePrefix("api/Gamification/Game")]
    public class GameController : CRUDLApiController<Overtech.DataModels.Gamification.Game, IGameService, Overtech.ViewModels.Gamification.Game>
    {
        /*Section="Constructor"*/
        public GameController(
            ILoggerFactory loggerFactory,
            IGameService gameService)
            : base(loggerFactory, gameService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}