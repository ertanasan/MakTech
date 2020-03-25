-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_WARNING_SP
    @WarningId INT,
    @Warning   VARCHAR(1000),
    @Comment   VARCHAR(1000)
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
        COMMENT_DSC
    )    
    SELECT
        WARNINGID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        WARNING_TXT,
        COMMENT_DSC
      FROM
        PRD_WARNING W (NOLOCK)
     WHERE
        W.WARNINGID = @WarningId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_WARNING
       SET
           WARNING_TXT = @Warning,
           COMMENT_DSC = @Comment
     WHERE WARNINGID = @WarningId;

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
