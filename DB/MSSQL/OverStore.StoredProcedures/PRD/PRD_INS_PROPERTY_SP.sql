-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_INS_PROPERTY_SP
    @ProductPropertyId INT OUT,
    @PropertyType      INT,
    @Product           INT,
    @Value             VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRD_PROPERTY
    (
        PROPERTYTYPE,
        PRODUCT,
        VALUE_TXT
    )
    VALUES
    (
        @PropertyType,
        @Product,
        @Value
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
    SELECT @ProductPropertyId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO PRD_PROPERTYLOG
    (
        PROPERTYID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PROPERTYTYPE,
        PRODUCT,
        VALUE_TXT
    )
    VALUES
    (
        @ProductPropertyId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @PropertyType,
        @Product,
        @Value);
/*Section="End"*/
END;
