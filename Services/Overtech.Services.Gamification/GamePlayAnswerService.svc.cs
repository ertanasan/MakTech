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
    public class GamePlayAnswerService : CRUDLDataService<Overtech.DataModels.Gamification.GamePlayAnswer>, IGamePlayAnswerService
    {
        /*Section="Constructor-1"*/
        public GamePlayAnswerService()
        {
        }

        /*Section="Constructor-2"*/
        internal GamePlayAnswerService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}