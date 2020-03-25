-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_UPD_SALEZET_SP
    @SaleDailySummaryId BIGINT,
    @Event              INT,
    @Organization       INT,
    @StoreID            INT,
    @TransactionDate    DATETIME,
    @ZetNo              INT,
    @ReceiptCount       INT,
    @ReceiptTotal       NUMERIC(22,6),
    @RefundCount        INT,
    @RefundAmount       NUMERIC(22,6),
    @CashAmount         NUMERIC(22,6),
    @CardAmount         NUMERIC(22,6),
    @CashRegister       INT,
    @SlpTotal           NUMERIC(22,6),
    @SlpCount           INT
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

	INSERT INTO SLS_SALEZETLOG
    (
        SALEZETID, LOG_DT, LOGUSER, LOGOPERATION_CD, LOGCHANNEL, LOGBRANCH, LOGSCREEN, EVENT, ORGANIZATION, DELETED_FL, CREATE_DT, UPDATE_DT, 
		CREATEUSER, UPDATEUSER, CREATECHANNEL, CREATEBRANCH, CREATESCREEN, STORE, TRANSACTION_DT, ZET_NO, RECEIPT_CNT, RECEIPTTOTAL_AMT, 
		REFUND_CNT, REFUND_AMT, CASH_AMT, CARD_AMT, CASHREGISTER, SLPTOTAL_AMT, SLP_CNT, TRANSACTION_TM
	)
    SELECT
        S.SALEZETID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        EVENT, ORGANIZATION, DELETED_FL, CREATE_DT, UPDATE_DT, 
		CREATEUSER, UPDATEUSER, CREATECHANNEL, CREATEBRANCH, CREATESCREEN, STORE, TRANSACTION_DT, ZET_NO, RECEIPT_CNT, RECEIPTTOTAL_AMT, 
		REFUND_CNT, REFUND_AMT, CASH_AMT, CARD_AMT, CASHREGISTER, SLPTOTAL_AMT, SLP_CNT, TRANSACTION_TM
      FROM
        SLS_SALEZET S (NOLOCK)
     WHERE
        S.SALEZETID = @SaleDailySummaryId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE SLS_SALEZET
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           STORE = @StoreID,
           TRANSACTION_DT = CAST(@TransactionDate AS DATE),
		   TRANSACTION_TM = @TransactionDate,
           ZET_NO = @ZetNo,
           RECEIPT_CNT = @ReceiptCount,
           RECEIPTTOTAL_AMT = @ReceiptTotal,
           REFUND_CNT = @RefundCount,
           REFUND_AMT = @RefundAmount,
           CASH_AMT = @CashAmount,
           CARD_AMT = @CardAmount,
           CASHREGISTER = @CashRegister,
           SLPTOTAL_AMT = @SlpTotal,
           SLP_CNT = @SlpCount
     WHERE SALEZETID = @SaleDailySummaryId
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