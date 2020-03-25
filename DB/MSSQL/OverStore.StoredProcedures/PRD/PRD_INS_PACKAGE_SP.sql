-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_INS_PACKAGE_SP
    @PackageId     INT,
    @Name          VARCHAR(100),
    @ParentPackage INT,
    @Amount        NUMERIC(22,6),
    @Description   VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRD_PACKAGE
    (
        PACKAGEID,
        PACKAGE_NM,
        PARENTPACKAGE,
        AMOUNT_AMT,
        COMMENT_DSC
    )
    VALUES
    (
        @PackageId,
        @Name,
        @ParentPackage,
        @Amount,
        @Description
    );

    /*Section="Check"*/
    -- Check the inserted row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @PackageId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Name,
        @ParentPackage,
        @Amount,
        @Description);
/*Section="End"*/
END;
