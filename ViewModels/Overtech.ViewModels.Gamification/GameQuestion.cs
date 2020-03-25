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
    [OTDisplayName("Game Question")]
    [DataContract]
    public class GameQuestion : ViewModelObject
    {
        private long _gameQuestionId;
        private string _questionText;
        private int _difficultyLevel;

        /*Section="Field-GameQuestionId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Game Question Id", null)]
        [OTDisplayName("Game Question Id")]
        [DataMember]
        public long GameQuestionId
        {
            get
            {
                return _gameQuestionId;
            }
            set
            {
                _gameQuestionId = value;
            }
        }

        /*Section="Field-QuestionText"*/
        [OTRequired("Question Text", null)]
        [OTDisplayName("Question Text")]
        [DataMember]
        public string QuestionText
        {
            get
            {
                return _questionText;
            }
            set
            {
                _questionText = value;
            }
        }

        /*Section="Field-DifficultyLevel"*/
        [OTRequired("DifficultyLevel", null)]
        [OTDisplayName("DifficultyLevel")]
        [DataMember]
        public int DifficultyLevel
        {
            get
            {
                return _difficultyLevel;
            }
            set
            {
                _difficultyLevel = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _gameQuestionId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public IEnumerable<QuestionChoice> Choices { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}