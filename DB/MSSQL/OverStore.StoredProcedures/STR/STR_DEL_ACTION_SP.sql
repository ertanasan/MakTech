-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_DEL_ACTION_SP
    @StoreActionId INT
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
        ACTION_NM    )    
    SELECT
        ACTIONID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        ACTION_NM
      FROM
        STR_ACTION A (NOLOCK)
     WHERE
        A.ACTIONID = @StoreActionId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM STR_ACTION
     WHERE ACTIONID = @StoreActionId;

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
