-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_PROPERTYTYPE_SP
    @PropertyTypeId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_PROPERTYTYPELOG
    (
        PROPERTYTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PROPERTYTYPE_NM,
        COMMENT_DSC    )    
    SELECT
        PROPERTYTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PROPERTYTYPE_NM,
        COMMENT_DSC
      FROM
        PRD_PROPERTYTYPE P (NOLOCK)
     WHERE
        P.PROPERTYTYPEID = @PropertyTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_PROPERTYTYPE
     WHERE PROPERTYTYPEID = @PropertyTypeId;

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
