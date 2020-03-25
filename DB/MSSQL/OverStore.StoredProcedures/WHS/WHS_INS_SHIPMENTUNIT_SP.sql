-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_SHIPMENTUNIT_SP
    @ShipmentUnitId  INT OUT,
    @UnitName        VARCHAR(100),
    @PackageQuantity INT,
    @Comment         VARCHAR(200)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_SHIPMENTUNIT
    (
        UNIT_NM,
        PACKAGE_QTY,
        COMMENT_DSC
    )
    VALUES
    (
        @UnitName,
        @PackageQuantity,
        @Comment
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
    SELECT @ShipmentUnitId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO WHS_SHIPMENTUNITLOG
    (
        SHIPMENTUNITID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        UNIT_NM,
        PACKAGE_QTY,
        COMMENT_DSC
    )    
    VALUES
    (
        @ShipmentUnitId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @UnitName,
        @PackageQuantity,
        @Comment);
/*Section="End"*/
END;
