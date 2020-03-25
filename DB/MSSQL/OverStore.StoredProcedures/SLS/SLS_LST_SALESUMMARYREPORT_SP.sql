CREATE PROCEDURE [dbo].[SLS_LST_SALESUMMARYREPORT_SP]    
	 @Store INT = -1,                  
	 @StartDate DATE = NULL,                  
	 @EndDate DATE = NULL,              
	 @AggregationFlag VARCHAR(1) = 'N' 
	 AS                  
BEGIN                  
   IF @AggregationFlag = '1' SET @AggregationFlag = 'Y' ELSE SET @AggregationFlag = 'N' 
   IF @StartDate IS NULL                   
   BEGIN                  
     Set @StartDate = CAST(GETDATE() AS DATE)                
     Set @EndDate = CAST(GETDATE() AS DATE)                
   END                  
   ELSE IF @EndDate IS NULL                  
   BEGIN                
     Set @EndDate = @StartDate                  
   END                
                   
   IF OBJECT_ID('tempdb.dbo.#STORES', 'U') IS NOT NULL DROP TABLE #STORES;                
   SELECT STOREID, STORE_NM INTO #STORES FROM dbo.STR_GETUSERSTORESALL_FN() WHERE @Store IS NULL OR @Store = -1  OR STOREID = @Store                
   --SELECT STOREID, STORE_NM INTO #STORES FROM STR_STORE WHERE @Store IS NULL OR @Store = -1  OR STOREID = @Store                
                
   IF @AggregationFlag = 'N'
   BEGIN              
    SELECT STORE        [STORE_ID]                  
		 , TRANSACTION_DT  [TRANSACTION_DATE]                  
		 , ST.STORE_NM  [STORE_NAME]                  
		 , SUM(SALE_AMT)  [SALE]                   
		 , SUM(SALE_QTY)  [SALE_QTY]            
		 , SUM(CASH_AMT)  [CASH]                 
		 , SUM(CASH_QTY)  [CASH_QTY]            
		 , SUM(CARD_AMT)  [CARD]            
		 , SUM(CARD_QTY)  [CARD_QTY]            
		 , SUM(REFUND_AMT) [REFUND]                   
		 , SUM(REFUND_QTY) [REFUND_QTY]            
		 , SUM(CANCELLED_AMT) [CANCELLED_TOTAL]                
		 , SUM(CANCELLED_QTY) [CANCELLED_QTY]              
      FROM SLS_STOREDAILYPAYMENT_SYN                   
	  JOIN #STORES ST ON STORE = ST.STOREID                 
	 WHERE TRANSACTION_DT BETWEEN @StartDate AND @EndDate            
       AND (@Store IS NULL OR @Store = -1 OR @Store = STORE)                      
	 GROUP BY STORE, TRANSACTION_DT, ST.STORE_NM                 
	 ORDER BY STORE, TRANSACTION_DT                
  END              
              
  ELSE --@selectDate = 1              
  BEGIN      
	WITH A AS (SELECT -1				[STORE_ID]
					, ' MAKBUL TOPLAM'	[STORE_NAME]
					, CONVERT(DATE,'20991231',112) TRANSACTION_DATE
					, SUM(SALE_AMT)		[SALE]                   
					, SUM(SALE_QTY)		[SALE_QTY]            
					, SUM(CASH_AMT)		[CASH]                 
					, SUM(CASH_QTY)		[CASH_QTY]
					, SUM(CARD_AMT)		[CARD]
					, SUM(CARD_QTY)		[CARD_QTY]
					, SUM(REFUND_AMT)	[REFUND]
					, SUM(REFUND_QTY)	[REFUND_QTY]
					, SUM(CANCELLED_AMT)	[CANCELLED_TOTAL]
					, SUM(CANCELLED_QTY)    [CANCELLED_QTY]
				 FROM SLS_STOREDAILYPAYMENT_SYN
				WHERE TRANSACTION_DT BETWEEN @StartDate AND @EndDate
			)
  SELECT * FROM A WHERE (@Store IS NULL OR @Store = -1)
  UNION ALL (      
		  SELECT STORE  [STORE_ID]          
		       , ST.STORE_NM  [STORE_NAME]                        
		       , CONVERT(DATE,'20991231',112) TRANSACTION_DATE
		       , SUM(SALE_AMT)   [SALE]                   
		       , SUM(SALE_QTY)   [SALE_QTY]            
		       , SUM(CASH_AMT)   [CASH]                 
		       , SUM(CASH_QTY)   [CASH_QTY]            
		       , SUM(CARD_AMT)   [CARD]            
		       , SUM(CARD_QTY)   [CARD_QTY]            
		       , SUM(REFUND_AMT)  [REFUND]                   
		       , SUM(REFUND_QTY)  [REFUND_QTY]            
		       , SUM(CANCELLED_AMT) [CANCELLED_TOTAL]                
		       , SUM(CANCELLED_QTY)    [CANCELLED_QTY]              
		    FROM SLS_STOREDAILYPAYMENT_SYN                
			JOIN #STORES ST ON STORE = ST.STOREID                   
		   WHERE TRANSACTION_DT BETWEEN @StartDate AND @EndDate          
			 AND (@Store IS NULL OR @Store = -1 OR @Store = STORE)          
		   GROUP BY STORE, ST.STORE_NM                  
		 )
   ORDER BY STORE_ID               
              
 END

END; 