-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_INS_BARCODE_SP
    @ProductBarcodeId INT OUT,
    @Product          INT,
    @BarcodeType      INT,
    @BarcodeText      VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRD_BARCODE
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        PRODUCT,
        BARCODETYPE,
        BARCODE_TXT
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @Product,
        @BarcodeType,
        @BarcodeText
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
    SELECT @ProductBarcodeId = SCOPE_IDENTITY();
/*Section="End"*/
END;
