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
    public class GameQuestionService : CRUDLDataService<Overtech.DataModels.Gamification.GameQuestion>, IGameQuestionService
    {
        /*Section="Constructor-1"*/
        public GameQuestionService()
        {
        }

        /*Section="Constructor-2"*/
        internal GameQuestionService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-ListQuestionChoices"*/
        public IEnumerable<QuestionChoice> ListQuestionChoices(long gameQuestionId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmQuestion = dal.CreateParameter("Question", gameQuestionId);
                return dal.List<QuestionChoice>("GAM_LST_CHOICE_SP", prmQuestion).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}