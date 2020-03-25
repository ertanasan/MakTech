-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_PROPERTYTYPE_SP
    @StorePropertyId INT OUT,
    @PropertyName    VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_PROPERTYTYPE
    (
        PROPERTYTYPE_NM
    )
    VALUES
    (
        @PropertyName
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
    SELECT @StorePropertyId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO STR_PROPERTYTYPELOG
    (
        PROPERTYTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PROPERTYTYPE_NM
    )
    VALUES
    (
        @StorePropertyId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @PropertyName);
/*Section="End"*/
END;
