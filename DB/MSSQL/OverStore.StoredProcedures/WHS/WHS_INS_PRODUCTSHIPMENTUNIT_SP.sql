-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_PRODUCTSHIPMENTUNIT_SP
    @ProductShipmentUnitId INT OUT,
    @Product               INT,
    @ShipmentType          INT,
    @PackageQuantity       NUMERIC(10,2),
    @PackageType           INT,
    @WarehouseLocation     VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_PRODUCTSHIPMENTUNIT
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        PRODUCT,
        SHIPMENTTYPE,
        PACKAGE_QTY,
        PACKAGETYPE,
        LOCATION_TXT
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @Product,
        @ShipmentType,
        @PackageQuantity,
        @PackageType,
        @WarehouseLocation
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
    SELECT @ProductShipmentUnitId = SCOPE_IDENTITY();
/*Section="End"*/
END;
