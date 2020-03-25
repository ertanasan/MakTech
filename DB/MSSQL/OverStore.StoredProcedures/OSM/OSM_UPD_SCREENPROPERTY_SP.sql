-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_UPD_SCREENPROPERTY_SP
    @OverStoreScreenPropertyId INT,
    @Screen                    INT,
    @PropertyName              VARCHAR(100),
    @PropertyValue             VARCHAR(1000)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO OSM_SCREENPROPERTYLOG
    (
        SCREENPROPERTYID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        SCREEN,
        PROPERTY_NM,
        VALUE_TXT
    )    
    SELECT
        SCREENPROPERTYID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        SCREEN,
        PROPERTY_NM,
        VALUE_TXT
      FROM
        OSM_SCREENPROPERTY S (NOLOCK)
     WHERE
        S.SCREENPROPERTYID = @OverStoreScreenPropertyId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE OSM_SCREENPROPERTY
       SET
           SCREEN = @Screen,
           PROPERTY_NM = @PropertyName,
           VALUE_TXT = @PropertyValue
     WHERE SCREENPROPERTYID = @OverStoreScreenPropertyId;

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
