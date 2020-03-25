-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_GATHERINGTYPE_SP
    @GatheringTypeId   INT,
    @GatheringTypeName VARCHAR(100)
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
        GATHERINGTYPE_NM
    )
    SELECT
        GATHERINGTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        GATHERINGTYPE_NM
      FROM
        WHS_GATHERINGTYPE G (NOLOCK)
     WHERE
        G.GATHERINGTYPEID = @GatheringTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_GATHERINGTYPE
       SET
           GATHERINGTYPE_NM = @GatheringTypeName
     WHERE GATHERINGTYPEID = @GatheringTypeId;

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
