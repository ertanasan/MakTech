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
    public class GamePlayService : CRUDLDataService<Overtech.DataModels.Gamification.GamePlay>, IGamePlayService
    {
        /*Section="Constructor-1"*/
        public GamePlayService()
        {
        }

        /*Section="Constructor-2"*/
        internal GamePlayService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<GameQuestion> listPlayLevelQuestions (long playId, int minDiffLevelCode, int maxDiffLevelCode, int questionCount)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prm_PlayId = dal.CreateParameter("PlayId", playId);
                IUniParameter prm_minDiffLevelCode = dal.CreateParameter("minDiffLevel", minDiffLevelCode);
                IUniParameter prm_maxDiffLevelCode = dal.CreateParameter("maxDiffLevel", maxDiffLevelCode);
                IUniParameter prm_questionCount = dal.CreateParameter("questionCount", questionCount);
                IEnumerable<GameQuestion> questionList = dal.List<GameQuestion>("GAM_LST_PLAYQUESTIONS_SP", prm_PlayId, prm_minDiffLevelCode, prm_maxDiffLevelCode, prm_questionCount).ToList();
                foreach (GameQuestion q in questionList)
                {
                    q.Choices = dal.List<QuestionChoice>(q.GameQuestionId).ToList();
                }
                return questionList;
            }
        }

        public IEnumerable<GameScore> ListScores()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.List<GameScore>("GAM_LST_GAMESCORE_SP").ToList();
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}