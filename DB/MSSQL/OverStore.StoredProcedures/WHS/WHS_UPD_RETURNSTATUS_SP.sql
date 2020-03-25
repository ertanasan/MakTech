-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_RETURNSTATUS_SP
    @ReturnStatusId INT,
    @StatusName     VARCHAR(100)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_RETURNSTATUSLOG
    (
        RETURNSTATUSID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        STATUS_NM
    )    
    SELECT
        RETURNSTATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STATUS_NM
      FROM
        WHS_RETURNSTATUS R (NOLOCK)
     WHERE
        R.RETURNSTATUSID = @ReturnStatusId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_RETURNSTATUS
       SET
           STATUS_NM = @StatusName
     WHERE RETURNSTATUSID = @ReturnStatusId;

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
