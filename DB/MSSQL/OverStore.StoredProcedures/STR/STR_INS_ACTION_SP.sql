-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_ACTION_SP
    @StoreActionId INT,
    @ActionName    VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_ACTION
    (
        ACTIONID,
        ACTION_NM
    )
    VALUES
    (
        @StoreActionId,
        @ActionName
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
    INSERT INTO STR_ACTIONLOG
    (
        ACTIONID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        ACTION_NM
    )    
    VALUES
    (
        @StoreActionId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @ActionName);
/*Section="End"*/
END;
