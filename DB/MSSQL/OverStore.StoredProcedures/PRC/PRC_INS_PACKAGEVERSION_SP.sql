-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_INS_PACKAGEVERSION_SP
    @PackageVersionId INT OUT,
    @Package          INT,
    @VersionDate      DATETIME,
    @ActiveFlag       VARCHAR(1),
    @Comment          VARCHAR(1000),
    @ActivationTime   DATETIME
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRC_PACKAGEVERSION
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        PACKAGE,
        VERSION_DT,
        ACTIVE_FL,
        COMMENT_DSC,
        ACTIVATION_TM
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @Package,
        @VersionDate,
        @ActiveFlag,
        @Comment,
        @ActivationTime
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
    SELECT @PackageVersionId = SCOPE_IDENTITY();
/*Section="End"*/
END;
