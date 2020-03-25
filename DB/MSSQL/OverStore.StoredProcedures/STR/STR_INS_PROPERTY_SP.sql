-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_PROPERTY_SP
    @Store         INT,
    @PropertyType  INT,
    @PropertyValue VARCHAR(1000),
    @PropertyId    INT OUT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_PROPERTY
    (
        STORE,
        PROPERTYTYPE,
        VALUE_TXT
    )
    VALUES
    (
        @Store,
        @PropertyType,
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
    SELECT @PropertyId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO STR_PROPERTYLOG
    (
        STORE,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PROPERTYTYPE,
        VALUE_TXT,
        PROPERTYID
    )    
    VALUES
    (
        @Store,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @PropertyType,
        @PropertyValue,
        @PropertyId);
/*Section="End"*/
END;
