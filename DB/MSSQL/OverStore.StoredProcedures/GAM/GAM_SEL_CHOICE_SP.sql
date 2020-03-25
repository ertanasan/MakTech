-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_SEL_CHOICE_SP
    @QuestionChoiceId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           C.CHOICEID,
           C.QUESTION,
           C.CHOICE_TXT,
           C.RIGHTANSWER_FL      
      FROM GAM_CHOICE C (NOLOCK)
     WHERE C.CHOICEID = @QuestionChoiceId;

    /*Section="End"*/
END;
