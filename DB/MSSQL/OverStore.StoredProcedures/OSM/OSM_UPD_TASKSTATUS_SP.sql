-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_UPD_TASKSTATUS_SP
    @OverStoreTaskStatusId INT,
    @Status                VARCHAR(100)
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
        STATUS_NM
    )    
    SELECT
        TASKSTATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STATUS_NM
      FROM
        OSM_TASKSTATUS T (NOLOCK)
     WHERE
        T.TASKSTATUSID = @OverStoreTaskStatusId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE OSM_TASKSTATUS
       SET
           STATUS_NM = @Status
     WHERE TASKSTATUSID = @OverStoreTaskStatusId;

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
