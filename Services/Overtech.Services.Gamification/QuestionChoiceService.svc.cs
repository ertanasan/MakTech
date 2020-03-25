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
    public class QuestionChoiceService : CRUDLDataService<Overtech.DataModels.Gamification.QuestionChoice>, IQuestionChoiceService
    {
        /*Section="Constructor-1"*/
        public QuestionChoiceService()
        {
        }

        /*Section="Constructor-2"*/
        internal QuestionChoiceService(IDAL dal)
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