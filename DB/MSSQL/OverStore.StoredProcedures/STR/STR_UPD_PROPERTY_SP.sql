-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_UPD_PROPERTY_SP
    @Store         INT,
    @PropertyType  INT,
    @PropertyValue VARCHAR(1000),
    @PropertyId    INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
    SELECT
        STORE,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PROPERTYTYPE,
        VALUE_TXT,
        PROPERTYID
      FROM
        STR_PROPERTY P (NOLOCK)
     WHERE
        P.PROPERTYID = @PropertyId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE STR_PROPERTY
       SET
           STORE = @Store,
           PROPERTYTYPE = @PropertyType,
           VALUE_TXT = @PropertyValue
     WHERE PROPERTYID = @PropertyId;

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
