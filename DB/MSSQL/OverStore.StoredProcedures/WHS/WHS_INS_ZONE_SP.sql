-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_ZONE_SP
    @StorageZonesId INT OUT,
    @Location       VARCHAR(100),
    @ZoneName       VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_ZONE
    (
        LOCATION_TXT,
        ZONE_NM
    )
    VALUES
    (
        @Location,
        @ZoneName
    );

    /*Section="Check"*/
    -- Check the inserted row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @StorageZonesId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @StorageZonesId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Location,
        @ZoneName);
/*Section="End"*/
END;
