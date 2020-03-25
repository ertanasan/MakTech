CREATE PROCEDURE [dbo].[RCL_SEL_RECONCILIATIONINFO_SP]  
	@TransactionDate DATETIME,  
	@StoreID INT
AS

BEGIN  

	DECLARE @PreviousDayAdvance NUMERIC(26,2), @AssaignedAdvance numeric(26, 2);  
	DECLARE @LastReconciliationDate smalldatetime  
	DECLARE @Organization INT, @CashTotal numeric (26, 2)  
	DECLARE @CardTotal numeric (26, 2), @SaleTotal numeric (26, 2), @ZetCount INT, @MissingReconciliation VARCHAR(1);  
   
	SET @TransactionDate = CAST(@TransactionDate AS DATE);
	SET @MissingReconciliation = 'N';
   
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();  
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1  
    BEGIN  
      SET @Organization = NULL;  
    END  
  
	--Bugünden bir önceki mutabakat yapýlmýþ tarihi verir.  
	SELECT @LastReconciliationDate = ISNULL(MAX(R.TRANSACTION_DT), @TransactionDate)  
	FROM RCL_RECONCILIATION R (NOLOCK)   
	WHERE STORE = @StoreID   
		AND R.TRANSACTION_DT <= @TransactionDate   
		AND r.RECONCILIATED_FL = 'Y'  
		AND R.DELETED_FL = 'N';  
  
	SELECT @AssaignedAdvance = ST.ADVANCE_AMT   
	FROM  STR_STORE ST (NOLOCK)   
	WHERE ST.STOREID = @StoreID   
		AND ST.ACTIVE_FL = 'Y';
   
	SELECT @PreviousDayAdvance = R.EODADVANCE_AMT   
	FROM RCL_RECONCILIATION R (NOLOCK)   
	WHERE STORE = @StoreID   
		AND R.TRANSACTION_DT = @LastReconciliationDate   
		AND R.DELETED_FL = 'N';
    
	SELECT @ZetCount = COUNT(*)   
	FROM SLS_SALEZET Z (NOLOCK)  
	WHERE Z.STORE = @StoreID  
		AND Z.TRANSACTION_DT = @TransactionDate
		AND Z.DELETED_FL = 'N';

	IF (@TransactionDate > @LastReconciliationDate + 1)
	BEGIN
		SET @MissingReconciliation = 'Y';
	END 

	IF EXISTS (  
	SELECT * FROM RCL_RECONCILIATION R (NOLOCK)   
	WHERE TRANSACTION_DT = @TransactionDate   
		AND STORE = @StoreID   
		AND R.TRANSACTION_DT = @TransactionDate   
		AND R.DELETED_FL = 'N' /*AND (@Organization IS NULL OR R.ORGANIZATION = @Organization*/)   
 BEGIN  
  
--THROW 51000, 'The record does not exist.', 1;    
  
  SELECT  
		RECONCILIATIONID  
		,[EVENT]  
		,[ORGANIZATION]  
		,[DELETED_FL]  
		,[CREATE_DT]  
		,[UPDATE_DT]  
		,[CREATEUSER]  
		,[UPDATEUSER]  
		,[CREATECHANNEL]  
		,[CREATEBRANCH]  
		,[CREATESCREEN]  
		,[TRANSACTION_DT]  
		,[STORE]  
		,[PREVIOUSDAYADVANCE_AMT]  
		,[SALETOTAL_AMT]  
		,[CASHTOTAL_AMT]  
		,[CARDTOTAL_AMT]  
		,[TOBANK_AMT]  
		,[DIFFERENCE_AMT]  
		,[DIFFERENCE_DSC]  
		,[COMPLETED_AMT]  
		,[EODADVANCE_AMT]  
		,[RECONCILIATED_FL],  
		@LastReconciliationDate LASTRECONCILIATIONDATE,  
		@AssaignedAdvance ASSAIGNEDADVANCE,  
		@ZetCount ZETCOUNT,
		'N' MISSINGRECONCILIATION,
		APPROVED_FL
	FROM RCL_RECONCILIATION s (NOLOCK)  
	WHERE TRANSACTION_DT = @TransactionDate  
		AND STORE = @StoreID  
		AND s.DELETED_FL = 'N'  
		AND (@Organization IS NULL OR S.ORGANIZATION = @Organization);  
END  
 ELSE  
 BEGIN  

	/*
	SELECT @SaleTotal = ISNULL(SUM(sa.TOTAL_AMT), 0)
	  FROM SLS_SALE sa (NOLOCK) 
	 WHERE sa.STORE = @StoreID
	   AND SA.TRANSACTION_DT = @TransactionDate
	   AND SA.CANCELLED_FL = 'N';
	*/

	SELECT @SaleTotal = ISNULL(SUM(z.RECEIPTTOTAL_AMT), 0) + ISNULL(SUM(z.SLPTOTAL_AMT), 0) - ISNULL(SUM(Z.REFUND_AMT), 0)
	FROM  SLS_SALEZET z (NOLOCK) 
	WHERE z.STORE = @StoreID
		AND z.TRANSACTION_DT = @TransactionDate
		AND z.DELETED_FL = 'N'
		AND (@Organization IS NULL OR z.ORGANIZATION = @Organization);

     SELECT  
		0 RECONCILIATIONID,    
		NULL EVENT,  
		NULL ORGANIZATION,  
		NULL DELETED_FL,  
		NULL CREATE_DT,  
		NULL UPDATE_DT,  
		NULL CREATEUSER,  
		NULL UPDATEUSER,  
		NULL CREATECHANNEL,  
		NULL CREATEBRANCH,  
		NULL CREATESCREEN,  
		@TransactionDate TRANSACTION_DT,  
		@StoreID STORE,  
		ISNULL(@PreviousDayAdvance, @AssaignedAdvance) PREVIOUSDAYADVANCE_AMT,  
		@SaleTotal SALETOTAL_AMT,  
		0 CASHTOTAL_AMT,  
		0 CARDTOTAL_AMT,  
		0 TOBANK_AMT,  
		0 DIFFERENCE_AMT,  
		NULL DIFFERENCE_DSC,  
		0 COMPLETED_AMT,  
		0 EODADVANCE_AMT,  
		'N' RECONCILIATED_FL,  
		@LastReconciliationDate LASTRECONCILIATIONDATE,  
		@AssaignedAdvance ASSAIGNEDADVANCE,  
		@ZetCount ZETCOUNT,
		@MissingReconciliation MISSINGRECONCILIATION,
		'N' APPROVED_FL
 END  

END;  