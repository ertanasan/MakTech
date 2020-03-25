﻿CREATE PROCEDURE INV_RPT_STOCKAGE_SP @StoreId INT = -1, @ProductId INT = -1 AS
BEGIN
	IF OBJECT_ID('tempdb..#STOCK') IS NOT NULL DROP TABLE #STOCK
	IF OBJECT_ID('tempdb..#PRD_STOCKAGE') IS NOT NULL DROP TABLE #PRD_STOCKAGE
	
	SELECT STORE, COALESCE(10000 + SG.STOCKGROUP, CS.PRODUCT) PRODUCT, SUM(STOCK) STOCK, 
		   SUM(AVGDAILYSALE) AVGDAILYSALE, SUM(MAXDAILYSALE) MAXDAILYSALE
	  INTO #STOCK
	  FROM INV_CURRENTSTOCK CS
	  LEFT JOIN PRD_STOCKGROUP_VW SG ON CS.PRODUCT = SG.PRODUCTID AND USAGETYPE_CD = 1
	 WHERE (@StoreId = -1 OR STORE = @StoreId)
	   AND (@ProductId = -1 OR CS.PRODUCT = @ProductId)
	 GROUP BY STORE, COALESCE(10000 + SG.STOCKGROUP, CS.PRODUCT);

	WITH INTAKE AS (
	SELECT ST.STOREID, COALESCE(10000 + SG.STOCKGROUP, TR.PRODUCT) PRODUCT, TR.TRANSACTION_DT, SUM(QUANTITY_QTY) QUANTITY_QTY
	  FROM INV_STOCKTRANSACTIONS_SYN TR
	  JOIN INV_TRANSACTIONTYPE_SYN T ON TR.TRANSACTIONTYPE = T.TRANSACTIONTYPEID
	  JOIN STR_STORE ST ON TR.WAREHOUSE = ST.STOREID
	  LEFT JOIN PRD_STOCKGROUP_VW SG ON TR.PRODUCT = SG.PRODUCTID AND USAGETYPE_CD = 1
	 WHERE T.COEFFICIENT_QTY = 1
	   AND TR.TRANSACTION_DT <= CAST(GETDATE() AS DATE)
	 GROUP BY ST.STOREID, COALESCE(10000 + SG.STOCKGROUP, TR.PRODUCT), TR.TRANSACTION_DT) 
	-- SELECT STORE, PRODUCT, STOCK, AVGDAILYSALE, MAXDAILYSALE, SUM(COEFF) / STOCK
	  --FROM (
	SELECT *, CASE WHEN QUANTITY_QTY + INTAKETOTAL <= STOCK THEN QUANTITY_QTY ELSE STOCK - INTAKETOTAL END * DATEDIFF(DAY, TRANSACTION_DT, GETDATE()) COEFF
	  INTO #PRD_STOCKAGE
	  FROM (
	SELECT *, SUM(ISNULL(LAGQUANTITY,0)) OVER (PARTITION BY STORE, PRODUCT ORDER BY TRANSACTION_DT DESC ROWS UNBOUNDED PRECEDING) INTAKETOTAL
	  FROM (
	SELECT S.*, T.TRANSACTION_DT, T.QUANTITY_QTY, LAG(T.QUANTITY_QTY) OVER (PARTITION BY S.STORE, S.PRODUCT ORDER BY T.TRANSACTION_DT DESC) LAGQUANTITY
	  FROM #STOCK S
	  LEFT JOIN INTAKE T ON S.STORE = T.STOREID AND S.PRODUCT = T.PRODUCT
	 WHERE AVGDAILYSALE > 0) A ) B
	 WHERE INTAKETOTAL < STOCK 


	DECLARE @today DATE = GETDATE()
	SELECT ST.STORE_NM, COALESCE(SG.STOCKGROUP_NM, P.NAME_NM) PRODUCT_NM, 
		   STOCK, AVGDAILYSALE, MAXDAILYSALE, SUM(COEFF) / STOCK AVGSTOCKAGE,
		   DATEDIFF(DAY, MIN(TRANSACTION_DT), @today) MAXSTOCKAGE,
		   DATEDIFF(DAY, MAX(TRANSACTION_DT), @today) MINSTOCKAGE
	  FROM #PRD_STOCKAGE S
	  JOIN STR_STORE ST ON S.STORE = ST.STOREID 
	  LEFT JOIN PRD_PRODUCT P ON S.PRODUCT = P.PRODUCTID
	  LEFT JOIN PRD_STOCKGROUPNAME SG ON S.PRODUCT = 10000+SG.STOCKGROUPID
	 GROUP BY STORE_NM, COALESCE(SG.STOCKGROUP_NM, P.NAME_NM), 
		   STOCK, AVGDAILYSALE, MAXDAILYSALE
END