-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_LST_QUESTION_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           Q.QUESTIONID,
           Q.QUESTION_TXT,
           Q.DIFFLEVEL_CD
      FROM GAM_QUESTION Q (NOLOCK)
     ORDER BY QUESTIONID;

/*Section="End"*/
END;
