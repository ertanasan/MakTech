CREATE PROCEDURE SLS_INS_SALEZET_SP  
    @SaleDailySummaryId BIGINT OUT,  
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
    SET NOCOUNT OFF  

    UPDATE SLS_SALEZET  
       SET UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           RECEIPT_CNT = @ReceiptCount,
           RECEIPTTOTAL_AMT = @ReceiptTotal,
           REFUND_CNT = @RefundCount,
           REFUND_AMT = @RefundAmount,
           CASH_AMT = @CashAmount,
           CARD_AMT = @CardAmount,
           SLPTOTAL_AMT = @SlpTotal,
           SLP_CNT = @SlpCount,
		   @SaleDailySummaryId = SALEZETID
     WHERE STORE = @StoreID
	   AND TRANSACTION_DT = @TransactionDate
	   AND ZET_NO = @ZetNo
	   AND CASHREGISTER = @CashRegister
	   AND DELETED_FL = 'N'
  
    IF @@ROWCOUNT = 0  
    BEGIN  
		INSERT INTO SLS_SALEZET
		(  
		    EVENT,
		    ORGANIZATION,
		    DELETED_FL,
		    CREATE_DT,
		    CREATEUSER,
		    CREATECHANNEL,
		    CREATEBRANCH,
		    CREATESCREEN,
		    STORE,
		    TRANSACTION_DT,
		    ZET_NO,
		    RECEIPT_CNT,
		    RECEIPTTOTAL_AMT,
		    REFUND_CNT,
		    REFUND_AMT,
		    CASH_AMT,
		    CARD_AMT,
		    CASHREGISTER,
		    SLPTOTAL_AMT,
		    SLP_CNT
		)
		VALUES
		(
		    @Event,
		    @Organization,
		    'N',
		    GETDATE(),
		    dbo.SYS_GETCURRENTUSER_FN(),
		    dbo.SYS_GETCURRENTCHANNEL_FN(),
		    dbo.SYS_GETCURRENTBRANCH_FN(),
		    dbo.SYS_GETCURRENTSCREEN_FN(),
		    @StoreID,
		    CAST(@TransactionDate AS DATE),
		    @ZetNo,
		    @ReceiptCount,
		    @ReceiptTotal,
		    @RefundCount,
		    @RefundAmount,
		    @CashAmount,
		    @CardAmount,
		    @CashRegister,
		    @SlpTotal,
		    @SlpCount
		);
  
		IF @@ROWCOUNT = 0  
		BEGIN  
		    SET NOCOUNT ON;  
		    THROW 100001, 'Nothing inserted. Transaction failed.', 1;  
		    RETURN;  
		END;  
		SELECT @SaleDailySummaryId = SCOPE_IDENTITY();  
    END;  

	SET NOCOUNT ON;  

END;  