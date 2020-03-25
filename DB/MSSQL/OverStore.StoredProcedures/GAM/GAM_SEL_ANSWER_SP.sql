-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_SEL_ANSWER_SP
    @GamePlayAnswerId BIGINT
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Query"*/
    -- Select
    SELECT
           A.ANSWERID,
           A.ORGANIZATION,
           A.CREATE_DT,
           A.CREATEUSER,
           A.PLAY,
           A.QUESTION,
           A.ANSWERCHOICE,
           A.RESULT_FL      
      FROM GAM_ANSWER A (NOLOCK)
     WHERE A.ANSWERID = @GamePlayAnswerId     
       AND (@Organization IS NULL OR A.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
