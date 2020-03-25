CREATE PROCEDURE RCL_LST_RECALCULATE_SP @StoreId INT AS    
BEGIN    
    
 IF OBJECT_ID('tempdb.dbo.#tmp', 'U') IS NOT NULL  DROP TABLE #tmp;     
  
 CREATE TABLE #tmp (STORERECID BIGINT, NETOFF_AMT NUMERIC(22,6), BANK_AMT NUMERIC(22,6), CURRENTADVANCE_AMT NUMERIC(22,6), DEFICITCYCLE_CNT INT)  
  
 DECLARE @rowno INT, @storeRecId BIGINT, @zet NUMERIC(22,6), @definedAdvance NUMERIC(22,6), @prevDefinedAdvance NUMERIC(22,6)  
 DECLARE @cash NUMERIC(22,6), @card NUMERIC(22,6), @expense NUMERIC(22,6)  
 DECLARE @expensereturn NUMERIC(22,6), @recovered NUMERIC(22,6)  
 DECLARE @adjustment NUMERIC(22,6), @netoff NUMERIC(22,6), @bank NUMERIC(22,6)  
 DECLARE @advance NUMERIC(22,6), @prevAdvance NUMERIC(22,6), @deficitcount INT, @prevDeficitCount INT  
       
 DECLARE rcl_cursor CURSOR FOR     
 SELECT row_number() over (order by RECONCILIATION_DT) rowno, STORERECID, ZET_AMT, DEFINEDADVANCE_AMT, CASH_AMT, CARD_AMT, EXPENSE_AMT, EXPENSERETURN_AMT, RECOVERED_AMT, ADJUSTMENT_AMT  
   FROM RCL_STORE  
  WHERE STORE = @StoreId  
    AND COMPLETE_FL = 'Y'
  ORDER BY RECONCILIATION_DT  
    
   
 SET NOCOUNT ON    
 OPEN rcl_cursor      
 FETCH NEXT FROM rcl_cursor INTO @rowno, @storeRecId, @zet, @definedAdvance, @cash, @card, @expense, @expensereturn, @recovered, @adjustment  
    
 WHILE @@FETCH_STATUS = 0      
 BEGIN      
   IF @rowno = 1     
   BEGIN    
     SET @prevDefinedAdvance = @definedAdvance  
     SET @prevAdvance = @definedAdvance  
     SET @prevDeficitCount = 0  
   END    
  
   SET @netoff = @cash+@card+@expense-@zet-ISNULL(@expensereturn,0)-ISNULL(@recovered,0)-@prevAdvance  
   SET @bank = @cash+@expense-ISNULL(@expensereturn,0)-@prevAdvance-@definedAdvance+@prevDefinedAdvance-ISNULL(@recovered,0)-isnull(@adjustment,0)  
   IF @netoff < 0 SET @bank = @bank - @netoff  
   SET @bank = ROUND(@bank,0)  
   SET @advance = @cash - @bank  
  
   IF @definedAdvance - @advance > 5   
     SET @deficitcount = @prevDeficitCount + 1  
   ELSE  
     SET @deficitcount = 0  
  
   INSERT INTO #tmp VALUES    
   (@storeRecId, @netoff, @bank, @advance, @deficitcount)    
    
   SET @prevAdvance = @advance  
   SET @prevDefinedAdvance = @definedAdvance  
   SET @prevDeficitCount = @deficitcount  
    
   FETCH NEXT FROM rcl_cursor INTO @rowno, @storeRecId, @zet, @definedAdvance, @cash, @card, @expense, @expensereturn, @recovered, @adjustment  
 END     
    
 CLOSE rcl_cursor      
 DEALLOCATE rcl_cursor     
 SET NOCOUNT OFF    
   
 /*UPDATE S  
    SET S.NETOFF_AMT = t.NETOFF_AMT  
      , S.BANK_AMT = t.BANK_AMT  
   , S.CURRENTADVANCE_AMT = t.CURRENTADVANCE_AMT  
   , S.DEFICITCYCLE_CNT = t.DEFICITCYCLE_CNT  */
 SELECT *   
   FROM #tmp t  
   JOIN RCL_STORE S ON t.STORERECID = S.STORERECID  
  WHERE t.NETOFF_AMT != S.NETOFF_AMT OR t.BANK_AMT != S.BANK_AMT OR t.CURRENTADVANCE_AMT != S.CURRENTADVANCE_AMT OR t.DEFICITCYCLE_CNT != S.DEFICITCYCLE_CNT  
   
       
END