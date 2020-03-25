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
    [OTDataObject(Module = "Gamification", ModuleShortName = "GAM", Table = "PLAY", HasAutoIdentity = true, DisplayName = "Game Play", IdField = "GamePlayId")]
    [DataContract]
    public class GamePlay : DataModelObject
    {
        private long _gamePlayId;
        private long _organization;
        private DateTime _createDate;
        private long _createUser;
        private long _game;
        private long _player;
        private DateTime _startTime;
        private Nullable<DateTime> _endTime;
        private Nullable<int> _lastLevel;
        private Nullable<int> _questionCount;
        private int _score;
        private string _deviceInfo;

        /*Section="Field-GamePlayId"*/
        [OTDataField("PLAYID")]
        [DataMember]
        public long GamePlayId
        {
            get
            {
                return _gamePlayId;
            }
            set
            {
                _gamePlayId = value;
            }
        }

        
        /*Section="Field-Organization"*/
        [OTDataField("ORGANIZATION")]
        [DataMember]
        public long Organization
        {
            get
            {
                return _organization;
            }
            set
            {
                _organization = value;
            }
        }

        /*Section="Field-CreateDate"*/
        [OTDataField("CREATE_DT")]
        [ReadOnly(true)]
        [DataMember]
        public DateTime CreateDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
            }
        }

        /*Section="Field-CreateUser"*/
        [OTDataField("CREATEUSER")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateUser
        {
            get
            {
                return _createUser;
            }
            set
            {
                _createUser = value;
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

        /*Section="Field-Player"*/
        [OTDataField("PLAYER")]
        [DataMember]
        public long Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
            }
        }

        /*Section="Field-StartTime"*/
        [OTDataField("START_TM")]
        [DataMember]
        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        /*Section="Field-EndTime"*/
        [OTDataField("END_TM", Nullable = true)]
        [DataMember]
        public Nullable<DateTime> EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        }

        /*Section="Field-LastLevel"*/
        [OTDataField("LASTLEVEL_CD", Nullable = true)]
        [DataMember]
        public Nullable<int> LastLevel
        {
            get
            {
                return _lastLevel;
            }
            set
            {
                _lastLevel = value;
            }
        }

        /*Section="Field-QuestionCount"*/
        [OTDataField("QUESTION_CNT", Nullable = true)]
        [DataMember]
        public Nullable<int> QuestionCount
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

        /*Section="Field-Score"*/
        [OTDataField("SCORE_NO")]
        [DataMember]
        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
            }
        }

        /*Section="Field-DeviceInfo"*/
        [OTDataField("DEVICEINFO_TXT")]
        [DataMember]
        public string DeviceInfo
        {
            get
            {
                return _deviceInfo;
            }
            set
            {
                _deviceInfo = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _gamePlayId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

