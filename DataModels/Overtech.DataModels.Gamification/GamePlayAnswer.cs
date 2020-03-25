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
    [OTDataObject(Module = "Gamification", ModuleShortName = "GAM", Table = "ANSWER", HasAutoIdentity = true, DisplayName = "Game Play Answer", IdField = "GamePlayAnswerId")]
    [DataContract]
    public class GamePlayAnswer : DataModelObject
    {
        private long _gamePlayAnswerId;
        private long _organization;
        private DateTime _createDate;
        private long _createUser;
        private long _play;
        private long _question;
        private long _answerChoice;
        private bool _resultFlag;

        /*Section="Field-GamePlayAnswerId"*/
        [OTDataField("ANSWERID")]
        [DataMember]
        public long GamePlayAnswerId
        {
            get
            {
                return _gamePlayAnswerId;
            }
            set
            {
                _gamePlayAnswerId = value;
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

        /*Section="Field-Play"*/
        [OTDataField("PLAY")]
        [DataMember]
        public long Play
        {
            get
            {
                return _play;
            }
            set
            {
                _play = value;
            }
        }

        /*Section="Field-Question"*/
        [OTDataField("QUESTION")]
        [DataMember]
        public long Question
        {
            get
            {
                return _question;
            }
            set
            {
                _question = value;
            }
        }

        /*Section="Field-AnswerChoice"*/
        [OTDataField("ANSWERCHOICE")]
        [DataMember]
        public long AnswerChoice
        {
            get
            {
                return _answerChoice;
            }
            set
            {
                _answerChoice = value;
            }
        }

        /*Section="Field-ResultFlag"*/
        [OTDataField("RESULT_FL")]
        [DataMember]
        public bool ResultFlag
        {
            get
            {
                return _resultFlag;
            }
            set
            {
                _resultFlag = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _gamePlayAnswerId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

