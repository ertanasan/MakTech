﻿CREATE VIEW INV_STOCK_VW AS  
WITH COUNTINGDATES AS   
(SELECT STORE, DATE_DT   
   FROM (SELECT STORE, ACTUAL_DT DATE_DT, ROW_NUMBER() OVER (PARTITION BY STORE ORDER BY ACTUAL_DT DESC) ROWNO  
		   FROM WHS_STOCKTAKINGSCHEDULE  
		  WHERE COUNTINGTYPE = 1  
		    AND DELETED_FL = 'N'
			AND STATUS = 2) A  
  WHERE ROWNO = 1)  
SELECT STORE, PRODUCT, MIN(COUNTING_DT) COUNTING_DT, MAX(COUNTINGVALUE_AMT) COUNTINGVALUE_AMT, SUM(QUANTITY_QTY) STOCK  
  FROM (  
SELECT STORE, PRODUCT, DATE_DT TRANSACTION_DT, DATE_DT COUNTING_DT, COUNTINGVALUE_AMT QUANTITY_QTY, COUNTINGVALUE_AMT   
  FROM WHS_STOCKTAKINGRESULT_VW  
 UNION ALL  
SELECT ST.STORE, ST.PRODUCT, ST.TRANSACTION_DT, DATE_DT, ST.QUANTITY_QTY, 0  
  FROM INV_STORETRANSACTIONS_VW ST  
  JOIN COUNTINGDATES CD ON ST.STORE = CD.STORE AND ST.TRANSACTION_DT > CD.DATE_DT) A  
 GROUP BY STORE, PRODUCT  