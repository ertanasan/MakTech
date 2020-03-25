-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_ZONE_SP
    @StorageZonesId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_ZONELOG
    (
        ZONEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        LOCATION_TXT,
        ZONE_NM    )    
    SELECT
        ZONEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        LOCATION_TXT,
        ZONE_NM
      FROM
        WHS_ZONE Z (NOLOCK)
     WHERE
        Z.ZONEID = @StorageZonesId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_ZONE
     WHERE ZONEID = @StorageZonesId;

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
