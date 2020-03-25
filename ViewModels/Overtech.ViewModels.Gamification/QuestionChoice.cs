// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Overtech.Core.Data;
using Overtech.UI.Data.Annotations;

/*Section="ClassHeader"*/
namespace Overtech.ViewModels.Gamification
{
    [OTDisplayName("Question Choice")]
    [DataContract]
    public class QuestionChoice : ViewModelObject
    {
        private long _questionChoiceId;
        private long _question;
        private string _choiceText;
        private bool _rightAnswer;

        /*Section="Field-QuestionChoiceId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Question Choice Id", null)]
        [OTDisplayName("Question Choice Id")]
        [DataMember]
        public long QuestionChoiceId
        {
            get
            {
                return _questionChoiceId;
            }
            set
            {
                _questionChoiceId = value;
            }
        }

        /*Section="Field-Question"*/
        [UIHint("GameQuestionList")]
        [OTRequired("Question", null)]
        [OTDisplayName("Question")]
        [DataMember]
        public long Question
        {
            get
            {
                return _question;
            }
            set
            {
                _question = value;
            }
        }

        /*Section="Field-ChoiceText"*/
        [OTRequired("Choice Text", null)]
        [OTDisplayName("Choice Text")]
        [DataMember]
        public string ChoiceText
        {
            get
            {
                return _choiceText;
            }
            set
            {
                _choiceText = value;
            }
        }

        /*Section="Field-RightAnswer"*/
        [OTRequired("Right Answer", null)]
        [OTDisplayName("Right Answer")]
        [DataMember]
        public bool RightAnswer
        {
            get
            {
                return _rightAnswer;
            }
            set
            {
                _rightAnswer = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _questionChoiceId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}