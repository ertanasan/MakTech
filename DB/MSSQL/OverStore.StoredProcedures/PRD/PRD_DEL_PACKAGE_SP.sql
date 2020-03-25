-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_PACKAGE_SP
    @PackageId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_PACKAGELOG
    (
        PACKAGEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PACKAGE_NM,
        PARENTPACKAGE,
        AMOUNT_AMT,
        COMMENT_DSC    )
    SELECT
        PACKAGEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PACKAGE_NM,
        PARENTPACKAGE,
        AMOUNT_AMT,
        COMMENT_DSC
      FROM
        PRD_PACKAGE P (NOLOCK)
     WHERE
        P.PACKAGEID = @PackageId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_PACKAGE
     WHERE PACKAGEID = @PackageId;

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
