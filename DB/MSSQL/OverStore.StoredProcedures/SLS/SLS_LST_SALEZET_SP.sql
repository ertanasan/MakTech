CREATE PROCEDURE SLS_LST_SALEZET_SP @TransactionDate DATE
AS
BEGIN
    SELECT
           S.SALEZETID,
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
      FROM SLS_SALEZET S (NOLOCK)
     WHERE S.TRANSACTION_DT = @TransactionDate
       AND DELETED_FL = 'N'
	 ORDER BY S.CASHREGISTER;

END;
