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
    [OTDisplayName("Game Play")]
    [DataContract]
    public class GamePlay : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Game Play Id", null)]
        [OTDisplayName("Game Play Id")]
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
        [ScaffoldColumn(false)]
        [OTRequired("Organization", null)]
        [OTDisplayName("Organization")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Date")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Create User")]
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

        /*Section="Field-Player"*/
        [UIHint("GamePlayerList")]
        [OTRequired("Player", null)]
        [OTDisplayName("Player")]
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
        [OTRequired("Start Time", null)]
        [OTDisplayName("Start Time")]
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
        [OTDisplayName("End Time")]
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
        [OTDisplayName("Last Level")]
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
        [OTDisplayName("Question Count")]
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
        [OTRequired("Score", null)]
        [OTDisplayName("Score")]
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
        [OTDisplayName("DeviceInfo")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _gamePlayId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}