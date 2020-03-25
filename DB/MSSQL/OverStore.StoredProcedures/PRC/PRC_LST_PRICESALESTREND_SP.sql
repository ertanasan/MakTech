CREATE PROCEDURE PRC_LST_PRICESALESTREND_SP                       
 @Store INT = -1,         
 @Product INT = 131,        
 @StartDate DATE = NULL,        
 @EndDate DATE = NULL        
AS                          
BEGIN         
 -- Initializing parameters        
 IF @EndDate IS NULL        
 SET @EndDate = GETDATE() - 1        
        
 IF @StartDate IS NULL        
 SET @StartDate = GETDATE() - 31        
        
 -- Section: Main Query        
 SELECT @Product PRODUCT    
  , D.DATE_DT TRANSACTION_DT    
  , ROUND(SUM(SD.PRICE) / SUM(SD.QUANTITY), 2) WEIGHTEDAVGPRICE    
  , ISNULL(SUM(SD.PRICE),0) DAILYSALE    
  , ISNULL(SUM(SD.QUANTITY),0) DAILYQTY         
   FROM RPT_DATE D          
   LEFT JOIN SLS_STOREDAILYPRODUCT_SYN SD ON D.DATE_DT = SD.TRANSACTION_DT AND SD.PRODUCT = @Product AND (@Store IS NULL OR @Store = -1 OR SD.STORE = @Store)       
  WHERE DATE_DT BETWEEN @StartDate AND @EndDate     
  GROUP BY DATE_DT, SD.PRODUCT      
  ORDER BY D.DATE_DT DESC    
END