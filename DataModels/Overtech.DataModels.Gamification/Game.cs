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
    [OTDataObject(Module = "Gamification", ModuleShortName = "GAM", Table = "GAMESCORE", HasAutoIdentity = false, DisplayName = "GameScore", IdField = "GameScoreId")]
    [DataContract]
    public class GameScore : DataModelObject
    {

        [OTDataField("PLAYERID")]
        [DataMember]
        public int PlayerId { get; set; }

        [OTDataField("BRANCH_NM")]
        [DataMember]
        public string BranchName { get; set; }

        [OTDataField("PLAYER_NM")]
        [DataMember]
        public string PlayerName { get; set; }

        [OTDataField("DAYGROUP")]
        [DataMember]
        public string DayGroup { get; set; }

        [OTDataField("MAXSCORE")]
        [DataMember]
        public int MaxScore { get; set; }

        [OTDataField("MAXLEVEL")]
        [DataMember]
        public int MaxLevel { get; set; }

        [OTDataField("QUESTION_CNT")]
        [DataMember]
        public int QuestionCount { get; set; }

        [OTDataField("AVGSCORE")]
        [DataMember]
        public decimal AvgScore { get; set; }

        [OTDataField("GAME_CNT")]
        [DataMember]
        public int GameCount { get; set; }

        [OTDataField("ROWNO")]
        [DataMember]
        public int RowNumber { get; set; }

        public override void SetId(long id)
        {
        }
    }

    [OTDataObject(Module = "Gamification", ModuleShortName = "GAM", Table = "GAME", HasAutoIdentity = true, DisplayName = "Game", IdField = "GameId")]
    [DataContract]
    public class Game : DataModelObject
    {
        private long _gameId;
        private string _gameName;
        private Nullable<int> _errorTolerance;

        /*Section="Field-GameId"*/
        [OTDataField("GAMEID")]
        [DataMember]
        public long GameId
        {
            get
            {
                return _gameId;
            }
            set
            {
                _gameId = value;
            }
        }

        /*Section="Field-GameName"*/
        [OTDataField("GAME_NM")]
        [DataMember]
        public string GameName
        {
            get
            {
                return _gameName;
            }
            set
            {
                _gameName = value;
            }
        }

        /*Section="Field-ErrorTolerance"*/
        [OTDataField("ERRTOLERANCE_CNT", Nullable = true)]
        [DataMember]
        public Nullable<int> ErrorTolerance
        {
            get
            {
                return _errorTolerance;
            }
            set
            {
                _errorTolerance = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _gameId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

