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
    [RoutePrefix("api/Gamification/GameQuestion")]
    public class GameQuestionController : CRUDLApiController<Overtech.DataModels.Gamification.GameQuestion, IGameQuestionService, Overtech.ViewModels.Gamification.GameQuestion>
    {
        /*Section="Constructor"*/
        public GameQuestionController(
            ILoggerFactory loggerFactory,
            IGameQuestionService gameQuestionService)
            : base(loggerFactory, gameQuestionService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}