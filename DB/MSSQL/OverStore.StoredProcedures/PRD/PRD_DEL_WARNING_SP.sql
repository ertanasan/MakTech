-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_WARNING_SP
    @WarningId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_WARNINGLOG
    (
        WARNINGID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        WARNING_TXT,
        COMMENT_DSC    )    
    SELECT
        WARNINGID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        WARNING_TXT,
        COMMENT_DSC
      FROM
        PRD_WARNING W (NOLOCK)
     WHERE
        W.WARNINGID = @WarningId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_WARNING
     WHERE WARNINGID = @WarningId;

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
