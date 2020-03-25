﻿CREATE PROCEDURE SLS_FIX_WNCMISSINGDETAILSALL_SP AS  
BEGIN  
 IF OBJECT_ID('tempdb..#DETAIL') IS NOT NULL DROP TABLE #DETAIL  
 IF OBJECT_ID('tempdb..#MASTER') IS NOT NULL DROP TABLE #MASTER  
  
 DECLARE @StartDate DATE = CAST(GETDATE()-7 AS DATE)  
 DECLARE @EndDate DATE = CAST(GETDATE()-1 AS DATE)  
 IF DATEPART(HOUR, GETDATE()) >= 21  
 BEGIN  
  SET @EndDate = CAST(GETDATE() AS DATE)  
 END  
  
 SELECT SD.STORE, SD.TRANSACTION_DT, SUM(PRICE) TOTALDETAIL_AMT  
   INTO #DETAIL  
   FROM SLS_SALE S (NOLOCK)  
   JOIN SLS_SALEDETAIL SD (NOLOCK) ON S.SALEID = SD.SALE  
   JOIN STR_STORE_VW ST ON SD.STORE = ST.STOREID  
  WHERE SD.TRANSACTION_DT BETWEEN @StartDate AND @EndDate  
    AND ST.TERMINAL = 'Wincor'  
    AND SD.CANCEL_FL = 'N'  
    AND S.CANCELLED_FL = 'N'  
  GROUP BY SD.STORE, SD.TRANSACTION_DT  
  
 SELECT S.STORE, S.TRANSACTION_DT, SUM(TOTAL_AMT) TOTAL_AMT  
   INTO #MASTER  
   FROM SLS_SALE S (NOLOCK)  
   JOIN STR_STORE_VW ST ON S.STORE = ST.STOREID  
  WHERE S.TRANSACTION_DT BETWEEN @StartDate AND @EndDate  
    AND S.CANCELLED_FL = 'N'  
    AND ST.TERMINAL = 'Wincor'  
  GROUP BY S.STORE, S.TRANSACTION_DT  
  
 DECLARE cur_stores CURSOR FOR   
 SELECT DISTINCT CAST(M.STORE AS VARCHAR(100)), CAST(CAST(M.TRANSACTION_DT AS DATE) AS varchar(100))   
   FROM #MASTER M  
   JOIN #DETAIL D ON M.STORE = D.STORE AND M.TRANSACTION_DT = D.TRANSACTION_DT  
   JOIN STR_STORE_VW ST ON M.STORE = ST.STOREID  
  WHERE M.TOTAL_AMT != D.TOTALDETAIL_AMT  
    AND ST.TERMINAL = 'Wincor'  
  
 DECLARE @StoreIdTxt VARCHAR(100), @TransactionDateTxt VARCHAR(100)  
 OPEN cur_stores    
 FETCH NEXT FROM cur_stores INTO @StoreIdTxt, @TransactionDateTxt  
  
 WHILE @@FETCH_STATUS = 0    
 BEGIN    
    
  EXEC SLS_FIX_WNCMISSINGDETAILS_SP @StoreIdTxt, @TransactionDateTxt  
  
  FETCH NEXT FROM cur_stores INTO @StoreIdTxt, @TransactionDateTxt  
  
 END   
  
 CLOSE cur_stores
 DEALLOCATE cur_stores
END