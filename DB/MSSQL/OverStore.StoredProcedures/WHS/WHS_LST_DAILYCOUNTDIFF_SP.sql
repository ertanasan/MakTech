﻿CREATE PROCEDURE WHS_LST_DAILYCOUNTDIFF_SP @StartDate DATE, @EndDate DATE AS    
BEGIN    
 IF OBJECT_ID('tempdb.dbo.#DAILYSTOCK', 'U') IS NOT NULL  DROP TABLE #DAILYSTOCK    
 IF OBJECT_ID('tempdb.dbo.#MULTIPLECOUNTING', 'U') IS NOT NULL  DROP TABLE #MULTIPLECOUNTING    
 IF OBJECT_ID('tempdb.dbo.#RESULT', 'U') IS NOT NULL  DROP TABLE #RESULT    
     
 SELECT STORE, PRODUCT, TRANSACTION_DT START_DT,     
		ISNULL(DATEADD(DAY,-1,LEAD(TRANSACTION_DT) OVER (PARTITION BY STORE, PRODUCT ORDER BY TRANSACTION_DT)),CONVERT(DATE,'20991231',112)) END_DT,    
		SUM(STOCK) OVER (PARTITION BY STORE, PRODUCT ORDER BY TRANSACTION_DT ROWS UNBOUNDED PRECEDING) STOCK    
   INTO #DAILYSTOCK    
   FROM (    
 SELECT STORE, PRODUCT, CONVERT(DATE, '20190420', 112) TRANSACTION_DT, STOCK    
   FROM INV_STOCKDATE_FN('2019-04-20')    
  UNION ALL    
 SELECT STORE, PRODUCT, CAST(INV.TRANSACTION_DT AS DATE), SUM(QUANTITY_QTY) QUANTITY    
   FROM INV_STORETRANSACTIONS_VW INV    
  WHERE INV.TRANSACTION_DT > CAST('2019-04-20' AS DATE)    
  GROUP BY STORE, PRODUCT, INV.TRANSACTION_DT) A;    
    
 SELECT *    
   INTO #MULTIPLECOUNTING    
   FROM (    
 SELECT *, LAG(STOCK_DT) OVER (PARTITION BY PRODUCT, STORE ORDER BY STOCK_DT) LAGSTOCK_DT    
	  , LAG(COUNTINGVALUE) OVER (PARTITION BY PRODUCT, STORE ORDER BY STOCK_DT) LAGCOUNTINGVALUE    
   FROM (    
 SELECT *, COUNT(*) OVER (PARTITION BY PRODUCT, STORE) ADET    
   FROM (    
 SELECT T.PRODUCT, T.STORE, CAST(T.COUNTING_DT-0.1 AS DATE) COUNTING_DT, SUM(T.COUNTINGVALUE_AMT) COUNTINGVALUE, CAST(MAX(T.UPDATE_DT)-0.5 AS DATE) STOCK_DT    
   FROM WHS_STOCKTAKINGSCHEDULE ST    
   JOIN WHS_STOCKTAKING T ON ST.STOCKTAKINGSCHEDULEID = T.STOCKTAKINGSCHEDULE    
  WHERE ST.COUNTINGTYPE = 2    
    AND ST.PLANNED_DT BETWEEN @StartDate AND @EndDate    
    AND ST.DELETED_FL = 'N'    
    AND T.DELETED_FL = 'N'    
  GROUP BY T.PRODUCT, T.STORE, CAST(T.COUNTING_DT-0.1 AS DATE)     
 HAVING NOT DATEPART(HOUR, MAX(T.UPDATE_DT)) BETWEEN 10 AND 20 ) A) B    
  WHERE B.ADET > 1 ) C    
  WHERE LAGSTOCK_DT IS NOT NULL AND LAGSTOCK_DT != STOCK_DT
  ORDER BY STORE, PRODUCT     
    
 SELECT C.STORE, C.PRODUCT, C.LAGSTOCK_DT, C.LAGCOUNTINGVALUE, C.STOCK_DT, C.COUNTINGVALUE,     
        SUM(CASE WHEN T.QUANTITY_QTY > 0 THEN T.QUANTITY_QTY ELSE 0 END) INTAKE,    
        SUM(CASE WHEN T.QUANTITY_QTY < 0 THEN -1*T.QUANTITY_QTY ELSE 0 END) SALE    
   INTO #RESULT    
   FROM #MULTIPLECOUNTING C    
   LEFT JOIN INV_STORETRANSACTIONS_VW T ON C.STORE = T.STORE AND C.PRODUCT = T.PRODUCT AND T.TRANSACTION_DT > C.LAGSTOCK_DT AND T.TRANSACTION_DT <= C.STOCK_DT    
  GROUP BY C.STORE, C.PRODUCT, C.LAGSTOCK_DT, C.LAGCOUNTINGVALUE, C.STOCK_DT, C.COUNTINGVALUE    
    
 SELECT ST.STORE_NM, P.CODE_NM, P.NAME_NM, R.LAGSTOCK_DT, R.LAGCOUNTINGVALUE,     
        R.STOCK_DT, R.COUNTINGVALUE, INTAKE GIRIS, SALE SATIS,     
        LAGCOUNTINGVALUE + INTAKE - SALE CALCULATEDVALUE, LAGCOUNTINGVALUE + INTAKE - SALE - COUNTINGVALUE DIFF,    
        DS.STOCK MAKTECHSTOCK    
   FROM #RESULT R    
   JOIN STR_STORE ST ON R.STORE = ST.STOREID    
   JOIN PRD_PRODUCT P ON R.PRODUCT = P.PRODUCTID    
   LEFT JOIN #DAILYSTOCK DS ON R.STORE = DS.STORE AND R.PRODUCT = DS.PRODUCT AND R.STOCK_DT BETWEEN DS.START_DT AND DS.END_DT    
  ORDER BY ABS(LAGCOUNTINGVALUE + INTAKE - SALE - COUNTINGVALUE) DESC
END