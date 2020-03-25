-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_INS_CHOICE_SP
    @QuestionChoiceId INT OUT,
    @Question         INT,
    @ChoiceText       VARCHAR(1000),
    @RightAnswer      VARCHAR(1)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO GAM_CHOICE
    (
        QUESTION,
        CHOICE_TXT,
        RIGHTANSWER_FL
    )
    VALUES
    (
        @Question,
        @ChoiceText,
        @RightAnswer
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
    SELECT @QuestionChoiceId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO GAM_CHOICELOG
    (
        CHOICEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        QUESTION,
        CHOICE_TXT,
        RIGHTANSWER_FL
    )    
    VALUES
    (
        @QuestionChoiceId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Question,
        @ChoiceText,
        @RightAnswer);
/*Section="End"*/
END;
