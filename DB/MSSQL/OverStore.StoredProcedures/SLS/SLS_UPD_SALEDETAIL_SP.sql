-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_UPD_SALEDETAIL_SP
    @SaleDetailId    BIGINT,
    @Event           INT,
    @Organization    INT,
    @SaleID          BIGINT,
    @TransactionID   VARCHAR(100),
    @TransactionDate DATETIME,
    @Barcode         VARCHAR(100),
    @ProductID       INT,
    @ProductCode     VARCHAR(100),
    @Store           INT,
    @Price           NUMERIC(22,6),
    @VATRate         NUMERIC(4,2),
    @Quantity        INT,
    @Unit            INT,
    @CancelFlag      VARCHAR(1),
    @UnitPrice       NUMERIC(22,6)
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE SLS_SALEDETAIL
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           SALE = @SaleID,
           TRANSACTION_TXT = @TransactionID,
           TRANSACTION_DT = @TransactionDate,
           BARCODE_TXT = @Barcode,
           PRODUCT = @ProductID,
           PRODUCTCODE_NM = @ProductCode,
           STORE = @Store,
           PRICE = @Price,
           VAT_RT = @VATRate,
           QUANTITY_QTY = @Quantity,
           UNIT = @Unit,
           CANCEL_FL = @CancelFlag,
           UNITPRICE_AMT = @UnitPrice
     WHERE SALEDETAILID = @SaleDetailId
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
