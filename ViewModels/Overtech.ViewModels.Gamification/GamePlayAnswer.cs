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
    [OTDisplayName("Game Play Answer")]
    [DataContract]
    public class GamePlayAnswer : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Game Play Answer Id", null)]
        [OTDisplayName("Game Play Answer Id")]
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

        /*Section="Field-Play"*/
        [UIHint("GamePlayList")]
        [OTRequired("Play", null)]
        [OTDisplayName("Play")]
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
        [UIHint("GameQuestionList")]
        [OTRequired("Question", null)]
        [OTDisplayName("Question")]
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
        [UIHint("QuestionChoiceList")]
        [OTRequired("Answer Choice", null)]
        [OTDisplayName("Answer Choice")]
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
        [OTRequired("Result Flag", null)]
        [OTDisplayName("Result Flag")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _gamePlayAnswerId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}