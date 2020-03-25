-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_PACKAGETYPE_SP
    @ShipmentPackageTypeId INT OUT,
    @PackageTypeName       VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_PACKAGETYPE
    (
        PACKAGETYPE_NM
    )
    VALUES
    (
        @PackageTypeName
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
    SELECT @ShipmentPackageTypeId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO WHS_PACKAGETYPELOG
    (
        PACKAGETYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PACKAGETYPE_NM
    )    
    VALUES
    (
        @ShipmentPackageTypeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @PackageTypeName);
/*Section="End"*/
END;
