-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_PRODUCTSHIPMENTUNIT_SP
    @ProductShipmentUnitId INT,
    @Product               INT,
    @ShipmentType          INT,
    @PackageQuantity       NUMERIC(10,2),
    @PackageType           INT,
    @WarehouseLocation     VARCHAR(100)
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_PRODUCTSHIPMENTUNIT
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           PRODUCT = @Product,
           SHIPMENTTYPE = @ShipmentType,
           PACKAGE_QTY = @PackageQuantity,
           PACKAGETYPE = @PackageType,
           LOCATION_TXT = @WarehouseLocation
     WHERE PRODUCTSHIPMENTUNITID = @ProductShipmentUnitId     
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

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
