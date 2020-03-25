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
    public interface IGamePlayService : ICRUDLServiceContract<Overtech.DataModels.Gamification.GamePlay>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        IEnumerable<GameQuestion> listPlayLevelQuestions(long playId, int minDiffLevelCode, int maxDiffLevelCode, int questionCount);

        [OperationContract]
        IEnumerable<GameScore> ListScores();
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

