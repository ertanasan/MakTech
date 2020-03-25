-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_DEL_ATTRIBUTE_SP
    @RequestAttributeId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO HDK_ATTRIBUTELOG
    (
        ATTRIBUTEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        ATTRIBUTE_NM,
        REQUESTGROUP,
        REQUESTDEFINITION,
        ATTRIBUTETYPE,
        EDITABLE_FL,
        REQUIRED_FL,
        DISPLAYORDER_NO    )
    SELECT
        ATTRIBUTEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        ATTRIBUTE_NM,
        REQUESTGROUP,
        REQUESTDEFINITION,
        ATTRIBUTETYPE,
        EDITABLE_FL,
        REQUIRED_FL,
        DISPLAYORDER_NO
      FROM
        HDK_ATTRIBUTE A (NOLOCK)
     WHERE
        A.ATTRIBUTEID = @RequestAttributeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM HDK_ATTRIBUTE
     WHERE ATTRIBUTEID = @RequestAttributeId;

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
