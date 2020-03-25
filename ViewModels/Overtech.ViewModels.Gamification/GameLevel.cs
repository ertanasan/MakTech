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
    [OTDisplayName("Game Level")]
    [DataContract]
    public class GameLevel : ViewModelObject
    {
        private long _gameLevelId;
        private long _game;
        private string _levelName;
        private int _questionCount;
        private int _minDifficultyLevel;
        private int _maxDifficultyLevel;
        private int _duration;
        private Nullable<int> _levelErrorTolerance;
        private int _pointofRightAnswer;
        private int _levelCode;

        /*Section="Field-GameLevelId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Game Level Id", null)]
        [OTDisplayName("Game Level Id")]
        [DataMember]
        public long GameLevelId
        {
            get
            {
                return _gameLevelId;
            }
            set
            {
                _gameLevelId = value;
            }
        }

        /*Section="Field-Game"*/
        [UIHint("GameList")]
        [OTRequired("Game", null)]
        [OTDisplayName("Game")]
        [DataMember]
        public long Game
        {
            get
            {
                return _game;
            }
            set
            {
                _game = value;
            }
        }

        /*Section="Field-LevelName"*/
        [OTRequired("Level Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Level Name")]
        [DataMember]
        public string LevelName
        {
            get
            {
                return _levelName;
            }
            set
            {
                _levelName = value;
            }
        }

        /*Section="Field-QuestionCount"*/
        [OTRequired("Question Count", null)]
        [OTDisplayName("Question Count")]
        [DataMember]
        public int QuestionCount
        {
            get
            {
                return _questionCount;
            }
            set
            {
                _questionCount = value;
            }
        }

        /*Section="Field-MinDifficultyLevel"*/
        [OTRequired("Min Difficulty Level", null)]
        [OTDisplayName("Min Difficulty Level")]
        [DataMember]
        public int MinDifficultyLevel
        {
            get
            {
                return _minDifficultyLevel;
            }
            set
            {
                _minDifficultyLevel = value;
            }
        }

        /*Section="Field-MaxDifficultyLevel"*/
        [OTRequired("Max Difficulty Level", null)]
        [OTDisplayName("Max Difficulty Level")]
        [DataMember]
        public int MaxDifficultyLevel
        {
            get
            {
                return _maxDifficultyLevel;
            }
            set
            {
                _maxDifficultyLevel = value;
            }
        }

        /*Section="Field-Duration"*/
        [OTRequired("Duration", null)]
        [OTDisplayName("Duration")]
        [DataMember]
        public int Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
            }
        }

        /*Section="Field-LevelErrorTolerance"*/
        [OTDisplayName("Level Error Tolerance")]
        [DataMember]
        public Nullable<int> LevelErrorTolerance
        {
            get
            {
                return _levelErrorTolerance;
            }
            set
            {
                _levelErrorTolerance = value;
            }
        }

        /*Section="Field-PointofRightAnswer"*/
        [OTRequired("Point of Right Answer", null)]
        [OTDisplayName("Point of Right Answer")]
        [DataMember]
        public int PointofRightAnswer
        {
            get
            {
                return _pointofRightAnswer;
            }
            set
            {
                _pointofRightAnswer = value;
            }
        }

        /*Section="Field-LevelCode"*/
        [OTRequired("Level Code", null)]
        [OTDisplayName("Level Code")]
        [DataMember]
        public int LevelCode
        {
            get
            {
                return _levelCode;
            }
            set
            {
                _levelCode = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _gameLevelId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}