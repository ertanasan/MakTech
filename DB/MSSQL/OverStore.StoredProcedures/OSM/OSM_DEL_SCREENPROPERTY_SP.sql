-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_DEL_SCREENPROPERTY_SP
    @OverStoreScreenPropertyId INT
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
        VALUE_TXT    )    
    SELECT
        SCREENPROPERTYID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM OSM_SCREENPROPERTY
     WHERE SCREENPROPERTYID = @OverStoreScreenPropertyId;

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
