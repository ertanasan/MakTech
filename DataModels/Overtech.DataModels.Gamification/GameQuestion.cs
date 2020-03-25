// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Overtech.Core.Data;

/*Section="ClassHeader"*/
namespace Overtech.DataModels.Gamification
{
    [OTDataObject(Module = "Gamification", ModuleShortName = "GAM", Table = "QUESTION", HasAutoIdentity = true, DisplayName = "Game Question", IdField = "GameQuestionId")]
    [DataContract]
    public class GameQuestion : DataModelObject
    {
        private long _gameQuestionId;
        private string _questionText;
        private int _difficultyLevel;

        /*Section="Field-GameQuestionId"*/
        [OTDataField("QUESTIONID")]
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
        [OTDataField("QUESTION_TXT")]
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
        [OTDataField("DIFFLEVEL_CD")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _gameQuestionId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public IEnumerable<QuestionChoice> Choices { get; set; }
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

