CREATE PROCEDURE [dbo].[SLS_LST_CHECKSTOREZET_SP]  
    @StoreId INT  
  , @TransactionDate DATE
  , @CashRegisterId INT
  , @ZetNo INT
AS  
BEGIN  
    /*Section="Organization"*/  
    -- Get the caller organization from session context  
    DECLARE @Organization INT;  
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();  
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1  
    BEGIN  
      -- Current organization is system. This is a batch or system process.  
      SET @Organization = null;  
    END  
  
    /*Section="Query"*/  
    -- Select  
    SELECT S.SALEZETID,  
           S.EVENT,  
           S.ORGANIZATION,  
           S.DELETED_FL,  
           S.CREATE_DT,  
           S.UPDATE_DT,  
           S.CREATEUSER,  
           S.UPDATEUSER,  
           S.CREATECHANNEL,  
           S.CREATEBRANCH,  
           S.CREATESCREEN,  
           S.STORE,  
           S.TRANSACTION_DT,  
           S.ZET_NO,  
           S.RECEIPT_CNT,  
           S.RECEIPTTOTAL_AMT,  
           S.REFUND_CNT,  
           S.REFUND_AMT,  
           S.CASH_AMT,  
           S.CARD_AMT,  
		   S.CASHREGISTER,  
		   S.SLPTOTAL_AMT,  
		   S.SLP_CNT  
      FROM SLS_SALEZET S
     WHERE S.STORE = @StoreId
       AND S.TRANSACTION_DT = CAST(@TransactionDate AS DATE)
	   AND S.CASHREGISTER = @CashRegisterId
	   AND S.ZET_NO = @ZetNo
	   AND S.DELETED_FL = 'N'
       AND (@Organization IS NULL OR S.ORGANIZATION = @Organization);  
  
    /*Section="End"*/  
END;  