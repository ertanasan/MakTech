-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_DEL_PROPERTY_SP
    @PropertyId INT
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
        PROPERTYID    )    
    SELECT
        STORE,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM STR_PROPERTY
     WHERE PROPERTYID = @PropertyId;

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
