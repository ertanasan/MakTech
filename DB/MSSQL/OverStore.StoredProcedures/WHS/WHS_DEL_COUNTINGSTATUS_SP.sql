-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_COUNTINGSTATUS_SP
    @CountingStatusId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_COUNTINGSTATUSLOG
    (
        COUNTINGSTATUSID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        COUNTINGSTATUS_NM    )    
    SELECT
        COUNTINGSTATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        COUNTINGSTATUS_NM
      FROM
        WHS_COUNTINGSTATUS C (NOLOCK)
     WHERE
        C.COUNTINGSTATUSID = @CountingStatusId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_COUNTINGSTATUS
     WHERE COUNTINGSTATUSID = @CountingStatusId;

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
