-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_COUNTINGSTATUS_SP
    @CountingStatusId   INT,
    @CountingStatusName VARCHAR(100)
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
        COUNTINGSTATUS_NM
    )    
    SELECT
        COUNTINGSTATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        COUNTINGSTATUS_NM
      FROM
        WHS_COUNTINGSTATUS C (NOLOCK)
     WHERE
        C.COUNTINGSTATUSID = @CountingStatusId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_COUNTINGSTATUS
       SET
           COUNTINGSTATUS_NM = @CountingStatusName
     WHERE COUNTINGSTATUSID = @CountingStatusId;

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
