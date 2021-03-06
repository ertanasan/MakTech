﻿CREATE PROCEDURE WHS_UPD_DRILLCOUNTSUMMARY_SP AS 
BEGIN

	EXEC WHS_UPD_DRILLCOUNTERRORS_SP

	IF OBJECT_ID('tempdb.dbo.#SONDAJ', 'U') IS NOT NULL  DROP TABLE #SONDAJ
	IF OBJECT_ID('tempdb.dbo.#SALES', 'U') IS NOT NULL  DROP TABLE #SALES
	IF OBJECT_ID('tempdb.dbo.#RESULT', 'U') IS NOT NULL  DROP TABLE #RESULT
	-- IF OBJECT_ID('tempdb.dbo.#STORES', 'U') IS NOT NULL  DROP TABLE #STORES

	-- SELECT Value STOREID INTO #STORES FROM dbo.[WHS_GETCHANGEDSTORES_FN](2);

	SELECT S.STOCKTAKINGSCHEDULEID SCHEDULEID,
		   CAST(S.PLANNED_DT AS DATE) COUNTING_DT, S.STORE, COALESCE(10000 + PP.STOCKGROUP, P.PRODUCTID) PRODUCT, ISNULL(CAST(10000+PP.STOCKGROUP AS varchar), P.CODE_NM) PRODUCTCODE_NM, 
		   ISNULL(PP.STOCKGROUP_NM, P.NAME_NM) PRODUCT_NM, MIN(ST.UPDATE_DT) MINCOUNTING_TM, MAX(ST.UPDATE_DT) MAXCOUNTING_TM, SUM(ST.COUNTINGVALUE_AMT) SONDAJSTOK,
		   (SELECT MAX(CAST(STL.ACTUAL_DT AS DATE)) FROM WHS_STOCKTAKINGSCHEDULE STL WHERE S.STORE = STL.STORE AND STL.ACTUAL_DT < CAST(S.PLANNED_DT AS DATE) AND STL.COUNTINGTYPE = 1 AND STL.STATUS = 2 AND STL.DELETED_FL = 'N') LASTCOUNTING_DT
	  INTO #SONDAJ
	  FROM WHS_STOCKTAKINGSCHEDULE S
	  JOIN WHS_STOCKTAKING ST ON S.STOCKTAKINGSCHEDULEID = ST.STOCKTAKINGSCHEDULE
	  JOIN PRD_PRODUCT P ON ST.PRODUCT = P.PRODUCTID
	  LEFT JOIN PRD_STOCKGROUP_VW PP ON USAGETYPE_CD = 1 AND P.PRODUCTID = PP.PRODUCTID 
	 WHERE S.COUNTINGTYPE = 2
	   AND S.DELETED_FL = 'N'
	   AND ST.DELETED_FL = 'N'
	 -- AND S.STORE IN (SELECT STOREID FROM #STORES)
	 GROUP BY S.STOCKTAKINGSCHEDULEID, CAST(S.PLANNED_DT AS DATE), S.STORE, COALESCE(10000 + PP.STOCKGROUP, P.PRODUCTID), 
			  ISNULL(CAST(10000+PP.STOCKGROUP AS varchar), P.CODE_NM), ISNULL(PP.STOCKGROUP_NM, P.NAME_NM) 
	HAVING MIN(ST.UPDATE_DT) IS NOT NULL

	SELECT SJ.SCHEDULEID, SJ.STORE, SJ.PRODUCT
		 , SUM(S.SALE_QTY-S.REFUND_QTY) SALE_QTY, SUM(S.SALE_AMT+S.REFUND_AMT) SALE_AMT
	  INTO #SALES
	  FROM SLS_PRODUCTSUMMARY_SYN S (NOLOCK) 
	  JOIN PRD_PRODUCT P (NOLOCK) ON S.PRODUCT = P.PRODUCTID
	  LEFT JOIN PRD_STOCKGROUP_VW PP ON USAGETYPE_CD = 1 AND P.PRODUCTID = PP.PRODUCTID 
	  JOIN #SONDAJ SJ ON S.TRANSACTION_DT > SJ.LASTCOUNTING_DT AND S.TRANSACTION_DT <= SJ.COUNTING_DT AND S.STORE = SJ.STORE AND COALESCE(10000 + PP.STOCKGROUP, P.PRODUCTID) = SJ.PRODUCT
	 GROUP BY SJ.SCHEDULEID, SJ.STORE, SJ.PRODUCT;

	WITH LASTCOUNTING AS (
	SELECT STORE, CAST(MAX(ACTUAL_DT) AS DATE) WHOLECOUNTING_DT FROM WHS_STOCKTAKINGSCHEDULE WHERE COUNTINGTYPE = 1 AND STATUS = 2 AND DELETED_FL = 'N' GROUP BY STORE),
	STORETRANSFER AS (
	SELECT TRANSACTION_DT, ISNULL(PP.PRODUCTID, P.PRODUCTID) PRODUCT, SUM(QUANTITY_QTY) QUANTITY
	  FROM INV_STOCKTRANSACTIONS_SYN ST
	  JOIN PRD_PRODUCT P ON ST.PRODUCT = P.PRODUCTID
	  LEFT JOIN PRD_PRODUCT PP ON P.PARENT = PP.PRODUCTID
	 WHERE WAREHOUSE = 1001
	   AND TRANSACTIONTYPE = 2
     GROUP BY TRANSACTION_DT, ISNULL(PP.PRODUCTID, P.PRODUCTID))
	SELECT S.*, COALESCE(CS.STOCK, ISNULL(WS.STOCK, 0) + ISNULL(TRN.QUANTITY, 0)) STOCK, LC.WHOLECOUNTING_DT,
		   -- (SONDAJSTOK-CASE WHEN COALESCE(CS.STOCK, ISNULL(WS.STOCK, 0) + ISNULL(TRN.QUANTITY, 0))<0 THEN 0 ELSE COALESCE(CS.STOCK, ISNULL(WS.STOCK, 0) + ISNULL(TRN.QUANTITY, 0)) END)*PR.PRICE_AMT DIFF_AMT, 
		   (SONDAJSTOK - COALESCE(CS.STOCK, ISNULL(WS.STOCK, 0) + ISNULL(TRN.QUANTITY, 0)) )*PR.PRICE_AMT DIFF_AMT, 
		   ST.STORE_NM, PR.PRICE_AMT, SS.SALE_QTY, SS.SALE_AMT
	  INTO #RESULT
	  FROM #SONDAJ S
	  JOIN STR_STOREWHINC_VW ST ON S.STORE = ST.STOREID -- AND ST.STOREID IN (SELECT STOREID FROM #STORES)
	  JOIN PRC_SALEPRICE_VW PR ON S.PRODUCT = PR.PRODUCT
	  LEFT JOIN INV_STOCKHIST_VW CS ON CAST(MINCOUNTING_TM-0.5 AS date) BETWEEN CS.START_DT AND CS.END_DT AND S.STORE = CS.STORE AND S.PRODUCT = CS.PRODUCT AND ST.STOREID != 999
	  LEFT JOIN INV_WAREHOUSESTOCK_VW WS ON CAST(MINCOUNTING_TM-0.5 AS date) BETWEEN WS.START_DT AND WS.END_DT AND WS.WAREHOUSE = 1001 AND ST.STOREID = 999 AND S.PRODUCT = WS.PRODUCT
	  LEFT JOIN STORETRANSFER TRN ON CAST(MINCOUNTING_TM AS date) = TRN.TRANSACTION_DT AND S.PRODUCT = TRN.PRODUCT
	  LEFT JOIN #SALES SS ON S.SCHEDULEID = SS.SCHEDULEID AND S.STORE = SS.STORE AND S.PRODUCT = SS.PRODUCT
	  LEFT JOIN LASTCOUNTING LC ON S.STORE = LC.STORE
	 ORDER BY MINCOUNTING_TM

	UPDATE DC
	   SET DC.STOCK = R.STOCK
	     , DC.SONDAJSTOK = R.SONDAJSTOK
		 , DC.DIFF_AMT = R.DIFF_AMT
		 , DC.SALE_QTY = R.SALE_QTY
		 , DC.SALE_AMT = R.SALE_AMT
    -- SELECT DC.*, R.STOCK, R.SONDAJSTOK, R.DIFF_AMT
	  FROM WHS_DRILLCOUNTSUMMARY DC
	  JOIN #RESULT R ON DC.SCHEDULEID = R.SCHEDULEID AND DC.PRODUCT = R.PRODUCT
	 WHERE ABS(DC.STOCK - R.STOCK) > 0.01 OR ABS(DC.SONDAJSTOK - R.SONDAJSTOK) > 0.01 OR 
		   ABS(DC.DIFF_AMT - R.DIFF_AMT) > 0.01 OR ABS(DC.SALE_QTY - R.SALE_QTY) > 0.01 OR 
		   ABS(DC.SALE_AMT - R.SALE_AMT) > 0.01

	 
	INSERT INTO WHS_DRILLCOUNTSUMMARY 
	SELECT R.*
	  FROM #RESULT R
	  LEFT JOIN WHS_DRILLCOUNTSUMMARY DC ON DC.SCHEDULEID = R.SCHEDULEID AND DC.PRODUCT = R.PRODUCT
	 WHERE DC.PRODUCT IS NULL

END