﻿CREATE VIEW INV_STOCKHIST_VW AS
  SELECT STORE, PRODUCT
	   , DATEADD(DAY,1,ISNULL(LAG(TRANSACTION_DT) OVER (PARTITION BY STORE, PRODUCT ORDER BY TRANSACTION_DT), '2001-01-01')) START_DT
	   , TRANSACTION_DT END_DT
  	   , SUM(STOCK) OVER (PARTITION BY STORE, PRODUCT ORDER BY TRANSACTION_DT DESC ROWS UNBOUNDED PRECEDING) STOCK
    FROM (
  SELECT STORE, PRODUCT, TRANSACTION_DT, SUM(STOCK) STOCK
    FROM (
   SELECT STORE, PRODUCT, CAST('2050-12-31' AS DATE) TRANSACTION_DT, STOCK
     FROM INV_CURRENTSTOCK
	UNION ALL
   SELECT ST.STOREID, COALESCE(10000+PP.STOCKGROUP, P.PRODUCTID) PRODUCTID
        , DATEADD(DAY, -1, INV.TRANSACTION_DT), -1*INV.QUANTITY_QTY
	 FROM INV_STORETRANSACTIONS_VW INV
	 JOIN STR_STORE ST ON INV.STORE = ST.STOREID
	 JOIN (SELECT STORE, MIN(ACTUAL_DT) MINCOUNTINGDATE FROM WHS_STOCKTAKINGSCHEDULE WHERE COUNTINGTYPE = 1 AND STATUS = 2 GROUP BY STORE) SS ON ST.STOREID = SS.STORE AND INV.TRANSACTION_DT > MINCOUNTINGDATE
	 JOIN PRD_PRODUCT P ON INV.PRODUCT = P.PRODUCTID
	 LEFT JOIN PRD_STOCKGROUP_VW PP ON USAGETYPE_CD = 1 AND P.PRODUCTID = PP.PRODUCTID
    UNION ALL
   SELECT CDF.STORE, COALESCE(10000+PP.STOCKGROUP, P.PRODUCTID) 
		, DATEADD(DAY, -1, CDF.COUNTING_DT), STOCK - COUNTING_QTY 
     FROM WHS_COUNTINGSTOCKDIFF CDF
	 JOIN PRD_PRODUCT P ON CDF.PRODUCT = P.PRODUCTID
	 LEFT JOIN PRD_STOCKGROUP_VW PP ON USAGETYPE_CD = 1 AND P.PRODUCTID = PP.PRODUCTID ) B 
   GROUP BY STORE, PRODUCT, TRANSACTION_DT) A