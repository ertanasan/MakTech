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
    [OTDataObject(Module = "Gamification", ModuleShortName = "GAM", Table = "PLAYER", HasAutoIdentity = true, DisplayName = "Game Player", IdField = "GamePlayerId")]
    [DataContract]
    public class GamePlayer : DataModelObject
    {
        private long _gamePlayerId;
        private string _playerName;
        private Nullable<long> _branch;

        /*Section="Field-GamePlayerId"*/
        [OTDataField("PLAYERID")]
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
        [OTDataField("PLAYER_NM")]
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
        [OTDataField("BRANCH", Nullable = true)]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _gamePlayerId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

