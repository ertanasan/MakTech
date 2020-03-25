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
    [OTDataObject(Module = "Gamification", ModuleShortName = "GAM", Table = "CHOICE", HasAutoIdentity = true, DisplayName = "Question Choice", IdField = "QuestionChoiceId", MasterField = "Question")]
    [DataContract]
    public class QuestionChoice : DataModelObject
    {
        private long _questionChoiceId;
        private long _question;
        private string _choiceText;
        private bool _rightAnswer;

        /*Section="Field-QuestionChoiceId"*/
        [OTDataField("CHOICEID")]
        [DataMember]
        public long QuestionChoiceId
        {
            get
            {
                return _questionChoiceId;
            }
            set
            {
                _questionChoiceId = value;
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

        /*Section="Field-ChoiceText"*/
        [OTDataField("CHOICE_TXT")]
        [DataMember]
        public string ChoiceText
        {
            get
            {
                return _choiceText;
            }
            set
            {
                _choiceText = value;
            }
        }

        /*Section="Field-RightAnswer"*/
        [OTDataField("RIGHTANSWER_FL")]
        [DataMember]
        public bool RightAnswer
        {
            get
            {
                return _rightAnswer;
            }
            set
            {
                _rightAnswer = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _questionChoiceId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

