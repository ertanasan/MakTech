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
    [OTDataObject(Module = "Gamification", ModuleShortName = "GAM", Table = "GAMELEVEL", HasAutoIdentity = true, DisplayName = "Game Level", IdField = "GameLevelId", MasterField = "Game")]
    [DataContract]
    public class GameLevel : DataModelObject
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
        [OTDataField("GAMELEVELID")]
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
        [OTDataField("GAME")]
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
        [OTDataField("LEVEL_NM")]
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
        [OTDataField("QUESTION_CNT")]
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
        [OTDataField("MINDIFFLEVEL_CD")]
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
        [OTDataField("MAXDIFFLEVEL_CD")]
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
        [OTDataField("DURATION_CNT")]
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
        [OTDataField("ERRTOLERANCE_CNT", Nullable = true)]
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
        [OTDataField("POINTOFRIGHTANSWER_NO")]
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
        [OTDataField("LEVEL_CD")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _gameLevelId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

