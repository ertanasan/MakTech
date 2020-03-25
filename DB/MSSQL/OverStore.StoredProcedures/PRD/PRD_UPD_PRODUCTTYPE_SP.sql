-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_PRODUCTTYPE_SP
    @ProductTypeId INT,
    @Name          VARCHAR(100),
    @ProductFamily INT,
    @Comment       VARCHAR(1000)
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
        COMMENT_DSC
    )
    SELECT
        PRODUCTTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
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

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_PRODUCTTYPE
       SET
           PRODUCTTYPE_NM = @Name,
           FAMILY = @ProductFamily,
           COMMENT_DSC = @Comment
     WHERE PRODUCTTYPEID = @ProductTypeId;

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
