-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_INS_TASKTYPE_SP
    @OverStoreTaskTypeId INT,
    @TaskType            VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO OSM_TASKTYPE
    (
        TASKTYPEID,
        TYPE_NM
    )
    VALUES
    (
        @OverStoreTaskTypeId,
        @TaskType
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
    INSERT INTO OSM_TASKTYPELOG
    (
        TASKTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        TYPE_NM
    )    
    VALUES
    (
        @OverStoreTaskTypeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @TaskType);
/*Section="End"*/
END;
