-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_SUPPLIER_SP
    @SupplierId   INT OUT,
    @SupplierName VARCHAR(100),
    @SupplierType INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_SUPPLIER
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        SUPPLIER_NM,
        SUPPLIERTYPE
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @SupplierName,
        @SupplierType
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
    SELECT @SupplierId = SCOPE_IDENTITY();
/*Section="End"*/
END;
