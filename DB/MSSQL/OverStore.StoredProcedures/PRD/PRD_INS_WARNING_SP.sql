-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_INS_WARNING_SP
    @WarningId   INT,
    @WarningText VARCHAR(1000),
    @Comment     VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRD_WARNING
    (
        WARNINGID,
        WARNING_TXT,
        COMMENT_DSC
    )
    VALUES
    (
        @WarningId,
        @WarningText,
        @Comment
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

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @WarningId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @WarningText,
        @Comment);
/*Section="End"*/
END;
