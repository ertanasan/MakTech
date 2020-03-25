-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_GATHERINGTYPE_SP
    @GatheringTypeId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_GATHERINGTYPELOG
    (
        GATHERINGTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        GATHERINGTYPE_NM    )    
    SELECT
        GATHERINGTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        GATHERINGTYPE_NM
      FROM
        WHS_GATHERINGTYPE G (NOLOCK)
     WHERE
        G.GATHERINGTYPEID = @GatheringTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_GATHERINGTYPE
     WHERE GATHERINGTYPEID = @GatheringTypeId;

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
