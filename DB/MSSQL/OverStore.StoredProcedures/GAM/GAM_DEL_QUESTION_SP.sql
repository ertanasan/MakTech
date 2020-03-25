-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_DEL_QUESTION_SP
    @GameQuestionId INT
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
        DIFFLEVEL_CD    )    
    SELECT
        QUESTIONID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        QUESTION_TXT,
        DIFFLEVEL_CD
      FROM
        GAM_QUESTION Q (NOLOCK)
     WHERE
        Q.QUESTIONID = @GameQuestionId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM GAM_QUESTION
     WHERE QUESTIONID = @GameQuestionId;

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
