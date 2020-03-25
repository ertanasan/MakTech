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
    [OTDisplayName("Game Player")]
    [DataContract]
    public class GamePlayer : ViewModelObject
    {
        private long _gamePlayerId;
        private string _playerName;
        private Nullable<long> _branch;

        /*Section="Field-GamePlayerId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Game Player Id", null)]
        [OTDisplayName("Game Player Id")]
        [DataMember]
        public long GamePlayerId
        {
            get
            {
                return _gamePlayerId;
            }
            set
            {
                _gamePlayerId = value;
            }
        }

        /*Section="Field-PlayerName"*/
        [OTRequired("Player Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Player Name")]
        [DataMember]
        public string PlayerName
        {
            get
            {
                return _playerName;
            }
            set
            {
                _playerName = value;
            }
        }

        /*Section="Field-Branch"*/
        [UIHint("BranchList")]
        [OTDisplayName("Branch")]
        [DataMember]
        public Nullable<long> Branch
        {
            get
            {
                return _branch;
            }
            set
            {
                _branch = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _gamePlayerId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}