-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_PACKAGE_SP
    @PackageId     INT,
    @Name          VARCHAR(100),
    @ParentPackage INT,
    @Amount        NUMERIC(22,6),
    @Description   VARCHAR(1000)
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
        COMMENT_DSC
    )
    SELECT
        PACKAGEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
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

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_PACKAGE
       SET
           PACKAGE_NM = @Name,
           PARENTPACKAGE = @ParentPackage,
           AMOUNT_AMT = @Amount,
           COMMENT_DSC = @Description
     WHERE PACKAGEID = @PackageId;

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
