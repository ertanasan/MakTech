-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_UPD_ACTION_SP
    @StoreActionId INT,
    @ActionName    VARCHAR(100)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
    SELECT
        ACTIONID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        ACTION_NM
      FROM
        STR_ACTION A (NOLOCK)
     WHERE
        A.ACTIONID = @StoreActionId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE STR_ACTION
       SET
           ACTION_NM = @ActionName
     WHERE ACTIONID = @StoreActionId;

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
