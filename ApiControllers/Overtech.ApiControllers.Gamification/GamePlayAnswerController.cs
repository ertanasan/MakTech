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
    [RoutePrefix("api/Gamification/GamePlayAnswer")]
    public class GamePlayAnswerController : CRUDLApiController<Overtech.DataModels.Gamification.GamePlayAnswer, IGamePlayAnswerService, Overtech.ViewModels.Gamification.GamePlayAnswer>
    {
        /*Section="Constructor"*/
        public GamePlayAnswerController(
            ILoggerFactory loggerFactory,
            IGamePlayAnswerService gamePlayAnswerService)
            : base(loggerFactory, gamePlayAnswerService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}