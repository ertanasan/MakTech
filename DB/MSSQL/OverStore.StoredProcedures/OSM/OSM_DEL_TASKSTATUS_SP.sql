-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_DEL_TASKSTATUS_SP
    @OverStoreTaskStatusId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO OSM_TASKSTATUSLOG
    (
        TASKSTATUSID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        STATUS_NM    )    
    SELECT
        TASKSTATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STATUS_NM
      FROM
        OSM_TASKSTATUS T (NOLOCK)
     WHERE
        T.TASKSTATUSID = @OverStoreTaskStatusId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM OSM_TASKSTATUS
     WHERE TASKSTATUSID = @OverStoreTaskStatusId;

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
