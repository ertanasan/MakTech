CREATE PROCEDURE RCL_LST_RECONCILIATION_SP  
 @TransactionDate DATETIME = NULL AS  
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
    -- Select all  
 SET @TransactionDate = CAST(@TransactionDate AS DATE)  
    
  
  SELECT    
     R.RECONCILIATIONID,  
           R.EVENT,  
           R.ORGANIZATION,  
           R.DELETED_FL,  
           R.CREATE_DT,  
           R.UPDATE_DT,  
           R.CREATEUSER,  
           R.UPDATEUSER,  
           R.CREATECHANNEL,  
           R.CREATEBRANCH,  
           R.CREATESCREEN,  
           R.TRANSACTION_DT,  
           ISNULL(R.STORE, ST.STOREID) STORE,  
           R.PREVIOUSDAYADVANCE_AMT,  
           R.SALETOTAL_AMT,  
           R.CASHTOTAL_AMT,  
           R.CARDTOTAL_AMT,  
           R.TOBANK_AMT,  
           R.DIFFERENCE_AMT,  
           R.DIFFERENCE_DSC,  
           R.COMPLETED_AMT,  
           R.EODADVANCE_AMT,  
     ISNULL(r.RECONCILIATED_FL, 'N') RECONCILIATED_FL,  
     ISNULL(r.APPROVED_FL, 'N') APPROVED_FL  
     FROM STR_STORE ST (NOLOCK)  
  LEFT JOIN RCL_RECONCILIATION R (NOLOCK) ON ST.STOREID = R.STORE   
  AND R.DELETED_FL = 'N'  
  AND R.TRANSACTION_DT = ISNULL(@TransactionDate, R.TRANSACTION_DT)  
     WHERE (@Organization IS NULL OR R.ORGANIZATION = @Organization)  
    
  ORDER BY RECONCILIATED_FL DESC, st.STORE_NM;  
  
/*Section="End"*/  
END;  
  