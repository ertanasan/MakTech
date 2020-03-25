-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_UPD_CHOICE_SP
    @QuestionChoiceId INT,
    @Question         INT,
    @ChoiceText       VARCHAR(1000),
    @RightAnswer      VARCHAR(1)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
    SELECT
        CHOICEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        QUESTION,
        CHOICE_TXT,
        RIGHTANSWER_FL
      FROM
        GAM_CHOICE C (NOLOCK)
     WHERE
        C.CHOICEID = @QuestionChoiceId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE GAM_CHOICE
       SET
           QUESTION = @Question,
           CHOICE_TXT = @ChoiceText,
           RIGHTANSWER_FL = @RightAnswer
     WHERE CHOICEID = @QuestionChoiceId;

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
