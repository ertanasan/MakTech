-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_SEL_QUESTION_SP
    @GameQuestionId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           Q.QUESTIONID,
           Q.QUESTION_TXT,
           Q.DIFFLEVEL_CD      
      FROM GAM_QUESTION Q (NOLOCK)
     WHERE Q.QUESTIONID = @GameQuestionId;

    /*Section="End"*/
END;
