-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_INS_SALE_SP
    @SalesId         BIGINT OUT,
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
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO SLS_SALE
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        TRANSACTION_TXT,
        STORE,
        CASHIER_NM,
        CASHREGISTER,
        TRANSACTION_DT,
        TRANSACTION_TM,
        TOTALVAT_AMT,
        TOTAL_AMT,
        PRODUCTDISCOUNT_AMT,
        SALEDISCOUNT_AMT,
        PRODUCT_CNT,
        DURATION_CNT,
        CANCELLED_FL,
        TRANSACTIONTYPE
    )
    VALUES
    (
        1045, -- @Event,
        1, -- @Organization,
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @TransactionCode,
        @Store,
        @CashierCode,
        @CashRegister,
        @TransactionDate,
        @TransactionTime,
        @VATAmount,
        @Total,
        @ProductDiscount,
        @TotalDiscount,
        @ProductCount,
        @ProcessDuration,
        @Cancelled,
        @TransactionType
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
    SELECT @SalesId = SCOPE_IDENTITY();
/*Section="End"*/
END;