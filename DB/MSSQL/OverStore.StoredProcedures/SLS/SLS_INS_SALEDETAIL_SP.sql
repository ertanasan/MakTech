-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_INS_SALEDETAIL_SP
    @SaleDetailId    BIGINT OUT,
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
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO SLS_SALEDETAIL
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        SALE,
        TRANSACTION_TXT,
        TRANSACTION_DT,
        BARCODE_TXT,
        PRODUCT,
        PRODUCTCODE_NM,
        STORE,
        PRICE,
        VAT_RT,
        QUANTITY_QTY,
        UNIT,
        CANCEL_FL,
        UNITPRICE_AMT
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
        @SaleID,
        @TransactionID,
        @TransactionDate,
        @Barcode,
        @ProductID,
        @ProductCode,
        @Store,
        @Price,
        @VATRate,
        @Quantity,
        @Unit,
        @CancelFlag,
        @UnitPrice
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
    SELECT @SaleDetailId = SCOPE_IDENTITY();
/*Section="End"*/
END;
