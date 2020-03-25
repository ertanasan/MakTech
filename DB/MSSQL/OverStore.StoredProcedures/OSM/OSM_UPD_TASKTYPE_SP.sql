-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_UPD_TASKTYPE_SP
    @OverStoreTaskTypeId INT,
    @TaskType            VARCHAR(100)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
    SELECT
        TASKTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        TYPE_NM
      FROM
        OSM_TASKTYPE T (NOLOCK)
     WHERE
        T.TASKTYPEID = @OverStoreTaskTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE OSM_TASKTYPE
       SET
           TYPE_NM = @TaskType
     WHERE TASKTYPEID = @OverStoreTaskTypeId;

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
