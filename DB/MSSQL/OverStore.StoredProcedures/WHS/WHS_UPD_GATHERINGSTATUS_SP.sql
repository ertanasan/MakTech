-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_GATHERINGSTATUS_SP
    @GatheringStatusId INT,
    @StatusName        VARCHAR(100)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_GATHERINGSTATUSLOG
    (
        GATHERINGSTATUSID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        GATHERINGSTATUS_NM
    )    
    SELECT
        GATHERINGSTATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        GATHERINGSTATUS_NM
      FROM
        WHS_GATHERINGSTATUS G (NOLOCK)
     WHERE
        G.GATHERINGSTATUSID = @GatheringStatusId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_GATHERINGSTATUS
       SET
           GATHERINGSTATUS_NM = @StatusName
     WHERE GATHERINGSTATUSID = @GatheringStatusId;

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
