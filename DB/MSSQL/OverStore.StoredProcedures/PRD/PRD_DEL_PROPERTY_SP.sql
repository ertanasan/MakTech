-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_PROPERTY_SP
    @ProductPropertyId INT
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
        VALUE_TXT    )
    SELECT
        PROPERTYID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_PROPERTY
     WHERE PROPERTYID = @ProductPropertyId;

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
