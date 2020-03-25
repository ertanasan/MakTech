-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_DEL_TASKTYPE_SP
    @OverStoreTaskTypeId INT
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
        TYPE_NM    )    
    SELECT
        TASKTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        TYPE_NM
      FROM
        OSM_TASKTYPE T (NOLOCK)
     WHERE
        T.TASKTYPEID = @OverStoreTaskTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM OSM_TASKTYPE
     WHERE TASKTYPEID = @OverStoreTaskTypeId;

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
