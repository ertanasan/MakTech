CREATE PROCEDURE SLS_LST_SALE_SP @TransactionDate DATE, @StoreId INT AS
BEGIN
    SELECT
           S.SALEID,
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
           S.TRANSACTION_TXT,
           S.STORE,
           S.CASHIER_NM,
           S.CASHREGISTER,
           S.TRANSACTION_DT,
           S.TRANSACTION_TM,
           S.TOTALVAT_AMT,
           S.TOTAL_AMT,
           S.PRODUCTDISCOUNT_AMT,
           S.SALEDISCOUNT_AMT,
           S.PRODUCT_CNT,
           S.DURATION_CNT,
           S.CANCELLED_FL,
           S.TRANSACTIONTYPE
      FROM SLS_SALE S (NOLOCK)
     WHERE DELETED_FL = 'N'
	   AND S.TRANSACTION_DT = @TransactionDate
	   AND S.STORE = @StoreId
     ORDER BY TRANSACTION_TM;

END;
