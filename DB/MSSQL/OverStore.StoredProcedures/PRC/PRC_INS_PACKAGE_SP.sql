-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_INS_PACKAGE_SP
    @PackageId   INT OUT,
    @PackageName VARCHAR(100),
    @PackageType INT,
    @Comment     VARCHAR(1000),
    @Image       BIGINT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRC_PACKAGE
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        PACKAGE_NM,
        TYPE,
        COMMENT_DSC,
        IMAGE
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @PackageName,
        @PackageType,
        @Comment,
        @Image
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
    SELECT @PackageId = SCOPE_IDENTITY();
/*Section="End"*/
END;
