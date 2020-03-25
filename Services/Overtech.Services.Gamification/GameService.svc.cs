// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Gamification;
using Overtech.ServiceContracts.Gamification;

/*Section="ClassHeader"*/
namespace Overtech.Services.Gamification
{
    [OTInspectorBehavior]
    public class GameService : CRUDLDataService<Overtech.DataModels.Gamification.Game>, IGameService
    {
        /*Section="Constructor-1"*/
        public GameService()
        {
        }

        /*Section="Constructor-2"*/
        internal GameService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-ListGameLevels"*/
        public IEnumerable<GameLevel> ListGameLevels(long gameId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmGame = dal.CreateParameter("Game", gameId);
                return dal.List<GameLevel>("GAM_LST_GAMELEVEL_SP", prmGame).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}