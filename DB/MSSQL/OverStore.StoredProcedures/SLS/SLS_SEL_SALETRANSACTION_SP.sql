CREATE PROCEDURE [dbo].[SLS_SEL_SALETRANSACTION_SP]    
    @TransactionCode varchar(100)    
AS    
BEGIN    
    DECLARE @Organization INT;    
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();    
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1    
    BEGIN    
      SET @Organization = null;    
    END    
    
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
     WHERE S.TRANSACTION_TXT = @TransactionCode         
       AND (@Organization IS NULL OR S.ORGANIZATION = @Organization);    
    
END;