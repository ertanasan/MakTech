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

    [OTDisplayName("GameScore")]
    [DataContract]
    public class GameScore : ViewModelObject
    {
        [DataMember]
        public int PlayerId { get; set; }

        [DataMember]
        public string BranchName { get; set; }

        [DataMember]
        public string PlayerName { get; set; }

        [DataMember]
        public string DayGroup { get; set; }

        [DataMember]
        public int MaxScore { get; set; }

        [DataMember]
        public int MaxLevel { get; set; }

        [DataMember]
        public int QuestionCount { get; set; }

        [DataMember]
        public decimal AvgScore { get; set; }

        [DataMember]
        public int GameCount { get; set; }

        [DataMember]
        public int RowNumber { get; set; }

        public override long GetId()
        {
            return 1;
        }
    }

    [OTDisplayName("Game")]
    [DataContract]
    public class Game : ViewModelObject
    {
        private long _gameId;
        private string _gameName;
        private Nullable<int> _errorTolerance;

        /*Section="Field-GameId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Game Id", null)]
        [OTDisplayName("Game Id")]
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
        [OTRequired("Game Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Game Name")]
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
        [OTDisplayName("Error Tolerance")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _gameId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}