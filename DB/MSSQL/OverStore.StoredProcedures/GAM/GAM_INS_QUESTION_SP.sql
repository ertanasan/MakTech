-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_INS_QUESTION_SP
    @GameQuestionId  INT OUT,
    @QuestionText    VARCHAR(4000),
    @DifficultyLevel INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO GAM_QUESTION
    (
        QUESTION_TXT,
        DIFFLEVEL_CD
    )
    VALUES
    (
        @QuestionText,
        @DifficultyLevel
    );

    /*Section="Check"*/
    -- Check the inserted row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @GameQuestionId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @GameQuestionId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @QuestionText,
        @DifficultyLevel);
/*Section="End"*/
END;
