-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_INS_SALEPAYMENT_SP
    @SalePaymentId    BIGINT OUT,
    @Event            INT,
    @Organization     INT,
    @SaleID           BIGINT,
    @TransactionID    VARCHAR(100),
    @TransactionDate  DATETIME,
    @Store            INT,
    @PaymentType      VARCHAR(10),
    @PaidAmount       NUMERIC(22,6),
    @RefundAmount     NUMERIC(22,6),
    @PosBankType      INT,
    @PosTrxType       INT,
    @CreditCardNo     VARCHAR(100),
    @IsDebitCard      VARCHAR(1),
    @CreditCardAmount NUMERIC(22,6)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO SLS_SALEPAYMENT
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
        STORE,
        PAYMENTTYPE_TXT,
        PAID_AMT,
        REFUND_AMT,
        POSBANKTYPE,
        POSTRXTYPE,
        ACCNO_TXT,
        DEBITCARD_FL,
        CARD_AMT
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
        @Store,
        @PaymentType,
        @PaidAmount,
        @RefundAmount,
        @PosBankType,
        @PosTrxType,
        @CreditCardNo,
        @IsDebitCard,
        @CreditCardAmount
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
    SELECT @SalePaymentId = SCOPE_IDENTITY();
/*Section="End"*/
END;
