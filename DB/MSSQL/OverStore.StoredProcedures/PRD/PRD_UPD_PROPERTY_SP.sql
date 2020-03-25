-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_PROPERTY_SP
    @ProductPropertyId INT,
    @PropertyType      INT,
    @Product           INT,
    @Value             VARCHAR(100)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
    SELECT
        PROPERTYID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PROPERTYTYPE,
        PRODUCT,
        VALUE_TXT
      FROM
        PRD_PROPERTY P (NOLOCK)
     WHERE
        P.PROPERTYID = @ProductPropertyId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_PROPERTY
       SET
           PROPERTYTYPE = @PropertyType,
           PRODUCT = @Product,
           VALUE_TXT = @Value
     WHERE PROPERTYID = @ProductPropertyId;

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
