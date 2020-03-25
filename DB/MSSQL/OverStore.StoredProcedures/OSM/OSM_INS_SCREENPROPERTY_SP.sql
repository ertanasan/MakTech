-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_INS_SCREENPROPERTY_SP
    @OverStoreScreenPropertyId INT OUT,
    @Screen                    INT,
    @PropertyName              VARCHAR(100),
    @PropertyValue             VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO OSM_SCREENPROPERTY
    (
        SCREEN,
        PROPERTY_NM,
        VALUE_TXT
    )
    VALUES
    (
        @Screen,
        @PropertyName,
        @PropertyValue
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
    SELECT @OverStoreScreenPropertyId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @OverStoreScreenPropertyId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Screen,
        @PropertyName,
        @PropertyValue);
/*Section="End"*/
END;
