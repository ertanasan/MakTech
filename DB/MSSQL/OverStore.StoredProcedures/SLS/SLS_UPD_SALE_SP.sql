-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_UPD_SALE_SP
    @SalesId         BIGINT,
    @Event           INT,
    @Organization    INT,
    @TransactionCode VARCHAR(100),
    @Store           INT,
    @CashierCode     VARCHAR(100),
    @CashRegister    INT,
    @TransactionDate DATETIME,
    @TransactionTime DATETIME,
    @VATAmount       NUMERIC(22,6),
    @Total           NUMERIC(22,6),
    @ProductDiscount NUMERIC(22,6),
    @TotalDiscount   NUMERIC(22,6),
    @ProductCount    INT,
    @ProcessDuration INT,
    @Cancelled       VARCHAR(1),
    @TransactionType INT
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
    UPDATE SLS_SALE
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           TRANSACTION_TXT = @TransactionCode,
           STORE = @Store,
           CASHIER_NM = @CashierCode,
           CASHREGISTER = @CashRegister,
           TRANSACTION_DT = @TransactionDate,
           TRANSACTION_TM = @TransactionTime,
           TOTALVAT_AMT = @VATAmount,
           TOTAL_AMT = @Total,
           PRODUCTDISCOUNT_AMT = @ProductDiscount,
           SALEDISCOUNT_AMT = @TotalDiscount,
           PRODUCT_CNT = @ProductCount,
           DURATION_CNT = @ProcessDuration,
           CANCELLED_FL = @Cancelled,
           TRANSACTIONTYPE = @TransactionType
     WHERE SALEID = @SalesId
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
