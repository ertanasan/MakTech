-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_LST_CHOICE_SP
    @Question INT = NULL
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           C.CHOICEID,
           C.QUESTION,
           C.CHOICE_TXT,
           C.RIGHTANSWER_FL
      FROM GAM_CHOICE C (NOLOCK)
     WHERE (@Question IS NULL OR C.QUESTION = @Question)
     ORDER BY CHOICEID;

/*Section="End"*/
END;
