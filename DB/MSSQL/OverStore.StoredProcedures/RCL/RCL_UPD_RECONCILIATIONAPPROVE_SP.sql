CREATE PROCEDURE RCL_UPD_RECONCILIATIONAPPROVE_SP
    @TransactionDate        DATETIME,
	@ReconciliationID		INT = 0
AS
BEGIN

	DECLARE @VRECID INT, @STORE INT, @CARDTOTAL_AMT NUMERIC(22, 6)

	SET @TransactionDate = CAST(@TransactionDate AS DATE)
	DECLARE @ErrorMessage VARCHAR;
	
	DECLARE R CURSOR FOR   
	SELECT RECONCILIATIONID, STORE, CARDTOTAL_AMT
	FROM RCL_RECONCILIATION
	WHERE TRANSACTION_DT = @TransactionDate 
		AND RECONCILIATIONID = CASE @ReconciliationID WHEN 0 THEN RECONCILIATIONID ELSE @ReconciliationID END
		AND RECONCILIATED_FL = 'Y' 
		AND ISNULL(APPROVED_FL, 'N') = 'N';--AND STORE IN (55);
    
	OPEN R
  
	FETCH NEXT FROM R
	INTO @VRECID, @STORE, @CARDTOTAL_AMT
  
	WHILE @@FETCH_STATUS = 0  
	BEGIN  

		/*		
		PRINT @RECONCILIATIONID;
		PRINT @STORE; 
		PRINT @TransactionDate;
		PRINT @CARDTOTAL_AMT;
		PRINT '---------------------'
		*/
	
		EXEC RCL_INS_ACCOUNTING_SP	@VRECID, @STORE, @TransactionDate, @CARDTOTAL_AMT;
		UPDATE RCL_RECONCILIATION SET APPROVED_FL = 'Y' WHERE RECONCILIATIONID = @VRECID;
			
		FETCH NEXT FROM R
		INTO @VRECID, @STORE, @CARDTOTAL_AMT  
	END   
	CLOSE R;  
	DEALLOCATE R;
END;

