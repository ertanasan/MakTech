// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Gamification;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Gamification
{
    [ServiceContract]
    public interface IGameService : ICRUDLServiceContract<Overtech.DataModels.Gamification.Game>
    {

        /*Section="Method-ListGameLevels"*/
        [OperationContract]
        IEnumerable<GameLevel> ListGameLevels(long gameId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

