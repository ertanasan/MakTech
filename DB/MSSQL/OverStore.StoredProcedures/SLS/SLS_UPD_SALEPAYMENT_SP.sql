-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_UPD_SALEPAYMENT_SP
    @SalePaymentId    BIGINT,
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
    UPDATE SLS_SALEPAYMENT
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           SALE = @SaleID,
           TRANSACTION_TXT = @TransactionID,
           TRANSACTION_DT = @TransactionDate,
           STORE = @Store,
           PAYMENTTYPE_TXT = @PaymentType,
           PAID_AMT = @PaidAmount,
           REFUND_AMT = @RefundAmount,
           POSBANKTYPE = @PosBankType,
           POSTRXTYPE = @PosTrxType,
           ACCNO_TXT = @CreditCardNo,
           DEBITCARD_FL = @IsDebitCard,
           CARD_AMT = @CreditCardAmount
     WHERE SALEPAYMENTID = @SalePaymentId
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
