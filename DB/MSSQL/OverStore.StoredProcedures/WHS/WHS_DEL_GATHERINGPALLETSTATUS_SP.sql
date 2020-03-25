-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_GATHERINGPALLETSTATUS_SP
    @StatusId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_GATHERINGPALLETSTATUSLOG
    (
        GATHERINGPALLETSTATUSID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        STATUS_NM    )    
    SELECT
        GATHERINGPALLETSTATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STATUS_NM
      FROM
        WHS_GATHERINGPALLETSTATUS G (NOLOCK)
     WHERE
        G.GATHERINGPALLETSTATUSID = @StatusId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_GATHERINGPALLETSTATUS
     WHERE GATHERINGPALLETSTATUSID = @StatusId;

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
