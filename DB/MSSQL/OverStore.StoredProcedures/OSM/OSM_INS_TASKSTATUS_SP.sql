-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_INS_TASKSTATUS_SP
    @OverStoreTaskStatusId INT,
    @Status                VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO OSM_TASKSTATUS
    (
        TASKSTATUSID,
        STATUS_NM
    )
    VALUES
    (
        @OverStoreTaskStatusId,
        @Status
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
    VALUES
    (
        @OverStoreTaskStatusId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Status);
/*Section="End"*/
END;
