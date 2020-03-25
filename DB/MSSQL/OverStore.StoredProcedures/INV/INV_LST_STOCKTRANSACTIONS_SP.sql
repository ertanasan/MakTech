﻿CREATE PROCEDURE INV_LST_STOCKTRANSACTIONS_SP @StoreId INT, @ProductId INT, @CurrentStock NUMERIC(10,3) = 0 AS  
BEGIN  
  
  SELECT @CurrentStock = STOCK FROM INV_CURRENTSTOCK WHERE STORE = @StoreId AND PRODUCT = @ProductId 

  IF OBJECT_ID('tempdb..#DRILLCOUNT') IS NOT NULL DROP TABLE #DRILLCOUNT
  SELECT CASE WHEN MINHOUR BETWEEN 7 AND 10 THEN DATEADD(DAY, -1, PLANNED_DT) ELSE PLANNED_DT END  PLANNED_DT, COUNTINGVALUE_AMT
    INTO #DRILLCOUNT
    FROM (
  SELECT SS.PLANNED_DT, SUM(S.COUNTINGVALUE_AMT) COUNTINGVALUE_AMT, DATEPART(HOUR, MIN(S.UPDATE_DT)) MINHOUR
    FROM WHS_STOCKTAKINGSCHEDULE SS
    JOIN WHS_STOCKTAKING S ON SS.STOCKTAKINGSCHEDULEID = S.STOCKTAKINGSCHEDULE
	JOIN PRD_PRODUCT P ON S.PRODUCT = P.PRODUCTID
   WHERE COALESCE(P.PARENT, S.PRODUCT) = @ProductId
     AND SS.STORE = @StoreId
     AND SS.COUNTINGTYPE = 2
	 AND SS.DELETED_FL = 'N'
	 AND S.DELETED_FL = 'N'
     -- AND SS.STATUS = 2
     AND S.UPDATE_DT IS NOT NULL
   GROUP BY SS.PLANNED_DT) A

  IF @StoreId != 999
  BEGIN
	  SELECT STOREID, STORE_NM, CATEGORY_NM, PRODUCT_NM
		   , TRANSACTION_DT, TRANSACTIONTYPE_NM, QUANTITY_QTY
		   , @CurrentStock + ISNULL(SUM(-1*QUANTITY_QTY) OVER (ORDER BY TRANSACTION_DT DESC, ORDER_CD DESC ROWS BETWEEN UNBOUNDED PRECEDING AND 1 PRECEDING),0) STOCK
		   , DC.COUNTINGVALUE_AMT DRILLCOUNT_AMT
		FROM (
	  SELECT *, ROW_NUMBER() OVER (PARTITION BY TRANSACTION_DT ORDER BY TRANSACTION_DT DESC) ROWNO
	    FROM (
	  SELECT ST.STOREID, ST.STORE_NM, P.CATEGORY_NM, COALESCE(PP.NAME_NM, P.NAME_NM) PRODUCT_NM
		   , INV.TRANSACTION_DT, INV.TRANSACTIONTYPE_NM, SUM(INV.QUANTITY_QTY) QUANTITY_QTY, 1 ORDER_CD  
		FROM INV_STORETRANSACTIONS_VW INV
		JOIN STR_STORE ST ON INV.STORE = ST.STOREID
		JOIN PRD_PRODUCT_VW P ON INV.PRODUCT = P.PRODUCTID
		LEFT JOIN PRD_PRODUCT PP ON P.PARENT = PP.PRODUCTID
	   WHERE STORE = @StoreId AND COALESCE(P.PARENT, P.PRODUCTID) = @ProductId
	   GROUP BY ST.STOREID, ST.STORE_NM, P.CATEGORY_NM, COALESCE(PP.NAME_NM, P.NAME_NM)
		   , INV.TRANSACTION_DT, INV.TRANSACTIONTYPE_NM
	   UNION ALL
	  SELECT ST.STOREID, ST.STORE_NM, P.CATEGORY_NM, COALESCE(PP.NAME_NM, P.NAME_NM) PRODUCT_NM
		   , CDF.COUNTING_DT, 'Sayım Farkı', COUNTING_QTY - STOCK, 2 ORDER_CD  
	    FROM WHS_COUNTINGSTOCKDIFF CDF
		JOIN STR_STORE ST ON CDF.STORE = ST.STOREID
		JOIN PRD_PRODUCT_VW P ON CDF.PRODUCT = P.PRODUCTID
		LEFT JOIN PRD_PRODUCT PP ON P.PARENT = PP.PRODUCTID
	   WHERE CDF.STORE = @StoreId AND COALESCE(P.PARENT, P.PRODUCTID) = @ProductId) B ) A
		LEFT JOIN #DRILLCOUNT DC ON A.TRANSACTION_DT = DC.PLANNED_DT AND A.ROWNO = 1
	   ORDER BY TRANSACTION_DT DESC
  END
  ELSE 
  BEGIN
	  SELECT STOREID, STORE_NM, CATEGORY_NM, PRODUCT_NM
		   , TRANSACTION_DT, TRANSACTIONTYPE_NM, QUANTITY_QTY
		   , @CurrentStock + ISNULL(SUM(-1*QUANTITY_QTY) OVER (ORDER BY TRANSACTION_DT DESC ROWS BETWEEN UNBOUNDED PRECEDING AND 1 PRECEDING),0) STOCK
		   , DC.COUNTINGVALUE_AMT DRILLCOUNT_AMT
		FROM (
	  SELECT 999 STOREID, 'MERKEZ DEPO' STORE_NM, P.CATEGORY_NM, P.NAME_NM PRODUCT_NM
		   , INV.TRANSACTION_DT, TT.TRANSACTIONTYPE_NM, SUM(INV.QUANTITY_QTY) QUANTITY_QTY
		   , ROW_NUMBER() OVER (PARTITION BY INV.TRANSACTION_DT ORDER BY INV.TRANSACTION_DT DESC) ROWNO
		FROM INV_STOCKTRANSACTIONS_SYN INV
		JOIN PRD_PRODUCT_VW P ON INV.PRODUCT = P.PRODUCTID
		JOIN INV_TRANSACTIONTYPE_SYN TT ON INV.TRANSACTIONTYPE = TT.TRANSACTIONTYPEID
	   WHERE WAREHOUSE = 1001 
		 AND P.PRODUCTID = @ProductId
		 AND TRANSACTION_DT <= CAST(GETDATE() AS DATE)
	   GROUP BY P.CATEGORY_NM, P.NAME_NM, INV.TRANSACTION_DT, TT.TRANSACTIONTYPE_NM) A
		LEFT JOIN #DRILLCOUNT DC ON A.TRANSACTION_DT = DC.PLANNED_DT AND A.ROWNO = 1
	   ORDER BY TRANSACTION_DT DESC  
  END

END