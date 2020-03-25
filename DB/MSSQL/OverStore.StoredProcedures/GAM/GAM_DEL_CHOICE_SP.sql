-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_DEL_CHOICE_SP
    @QuestionChoiceId INT
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
        RIGHTANSWER_FL    )    
    SELECT
        CHOICEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM GAM_CHOICE
     WHERE CHOICEID = @QuestionChoiceId;

    /*Section="Check"*/
    -- Check the deleted/updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing deleted. Delete failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
