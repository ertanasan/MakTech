﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_DEL_PROPERTYTYPE_SP
    @StorePropertyId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO STR_PROPERTYTYPELOG
    (
        PROPERTYTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PROPERTYTYPE_NM    )
    SELECT
        PROPERTYTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PROPERTYTYPE_NM
      FROM
        STR_PROPERTYTYPE P (NOLOCK)
     WHERE
        P.PROPERTYTYPEID = @StorePropertyId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM STR_PROPERTYTYPE
     WHERE PROPERTYTYPEID = @StorePropertyId;

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
