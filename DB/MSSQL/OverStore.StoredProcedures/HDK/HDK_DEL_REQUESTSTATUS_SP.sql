-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_DEL_REQUESTSTATUS_SP
    @RequestStatusId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO HDK_REQUESTSTATUSLOG
    (
        REQUESTSTATUSID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        STATUS_NM    )    
    SELECT
        REQUESTSTATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STATUS_NM
      FROM
        HDK_REQUESTSTATUS R (NOLOCK)
     WHERE
        R.REQUESTSTATUSID = @RequestStatusId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM HDK_REQUESTSTATUS
     WHERE REQUESTSTATUSID = @RequestStatusId;

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
