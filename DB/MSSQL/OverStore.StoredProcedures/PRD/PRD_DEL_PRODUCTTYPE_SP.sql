-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_PRODUCTTYPE_SP
    @ProductTypeId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_PRODUCTTYPELOG
    (
        PRODUCTTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PRODUCTTYPE_NM,
        FAMILY,
        COMMENT_DSC    )    
    SELECT
        PRODUCTTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PRODUCTTYPE_NM,
        FAMILY,
        COMMENT_DSC
      FROM
        PRD_PRODUCTTYPE P (NOLOCK)
     WHERE
        P.PRODUCTTYPEID = @ProductTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_PRODUCTTYPE
     WHERE PRODUCTTYPEID = @ProductTypeId;

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
