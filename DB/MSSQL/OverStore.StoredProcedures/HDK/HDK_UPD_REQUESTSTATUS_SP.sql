-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_UPD_REQUESTSTATUS_SP
    @RequestStatusId INT,
    @StatusName      VARCHAR(100)
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
        STATUS_NM
    )    
    SELECT
        REQUESTSTATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STATUS_NM
      FROM
        HDK_REQUESTSTATUS R (NOLOCK)
     WHERE
        R.REQUESTSTATUSID = @RequestStatusId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE HDK_REQUESTSTATUS
       SET
           STATUS_NM = @StatusName
     WHERE REQUESTSTATUSID = @RequestStatusId;

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
