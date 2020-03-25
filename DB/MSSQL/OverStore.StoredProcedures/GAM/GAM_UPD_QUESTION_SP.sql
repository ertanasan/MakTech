-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_UPD_QUESTION_SP
    @GameQuestionId  INT,
    @QuestionText    VARCHAR(4000),
    @DifficultyLevel INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO GAM_QUESTIONLOG
    (
        QUESTIONID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        QUESTION_TXT,
        DIFFLEVEL_CD
    )    
    SELECT
        QUESTIONID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        QUESTION_TXT,
        DIFFLEVEL_CD
      FROM
        GAM_QUESTION Q (NOLOCK)
     WHERE
        Q.QUESTIONID = @GameQuestionId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE GAM_QUESTION
       SET
           QUESTION_TXT = @QuestionText,
           DIFFLEVEL_CD = @DifficultyLevel
     WHERE QUESTIONID = @GameQuestionId;

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
