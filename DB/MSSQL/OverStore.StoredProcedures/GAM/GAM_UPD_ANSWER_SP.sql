-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_UPD_ANSWER_SP
    @GamePlayAnswerId BIGINT,
    @Organization     INT,
    @Play             BIGINT,
    @Question         INT,
    @AnswerChoice     INT,
    @ResultFlag       VARCHAR(1)
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE GAM_ANSWER
       SET
           PLAY = @Play,
           QUESTION = @Question,
           ANSWERCHOICE = @AnswerChoice,
           RESULT_FL = @ResultFlag
     WHERE ANSWERID = @GamePlayAnswerId     
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

    /*Section="Check"*/
    -- Check the updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing to update. Update failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
