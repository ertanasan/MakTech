-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_ZONE_SP
    @StorageZonesId INT,
    @Location       VARCHAR(100),
    @ZoneName       VARCHAR(100)
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
        ZONE_NM
    )    
    SELECT
        ZONEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        LOCATION_TXT,
        ZONE_NM
      FROM
        WHS_ZONE Z (NOLOCK)
     WHERE
        Z.ZONEID = @StorageZonesId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_ZONE
       SET
           LOCATION_TXT = @Location,
           ZONE_NM = @ZoneName
     WHERE ZONEID = @StorageZonesId;

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
