﻿CREATE PROCEDURE TOC_RPT_ORDERSUGGESTIONCOMP_SP @StoreOrderId BIGINT AS
BEGIN
	DECLARE @StoreId INT, @OrderDate DATE
	SELECT @StoreId = STORE, @OrderDate = ORDER_DT FROM WHS_STOREORDER WHERE STOREORDERID = @StoreOrderId 
	
	IF OBJECT_ID('tempdb..#suggestion') IS NOT NULL DROP TABLE #suggestion
	SELECT * INTO #suggestion FROM [dbo].[WHS_TOCSUGGESTION_FN] (@StoreId, @OrderDate)

	SELECT SO.STORE, SO.ORDER_DT, COALESCE(SG.STOCKGROUP_NM, P.NAME_NM) PRODUCT_NM, SUM(SOD.ORDER_QTY) ORDER_QTY, ISNULL(SUM(SOD.SUGGESTION_QTY),0) SUGGESTION_QTY
		 , DATE_DT, NEXT_DT, DIFF, PRICE_AMT, GREENLIMIT_QTY, YELLOWLIMIT_QTY, REDLIMIT_QTY, STOCK_QTY, SALE_QTY, TS.INTAKE_QTY, TS.SUGGESTION_QTY CALCSUGGESTION_QTY, PACKAGE_QTY
	  FROM WHS_STOREORDER SO
	  JOIN WHS_STOREORDERDETAIL SOD ON SO.STOREORDERID = SOD.STOREORDER
	  JOIN PRD_PRODUCT P ON SOD.PRODUCT = P.PRODUCTID
	  LEFT JOIN PRD_STOCKGROUP_VW SG ON P.PRODUCTID = SG.PRODUCTID AND USAGETYPE_CD = 1
	  LEFT JOIN #suggestion TS ON COALESCE(10000 + SG.STOCKGROUP, P.PRODUCTID) = TS.PRODUCT AND SO.STORE = TS.STORE
	 WHERE STOREORDERID = @StoreOrderId -- 74663
	   AND P.SUPERGROUP1 != 9
	 GROUP BY SO.STORE, SO.ORDER_DT, COALESCE(SG.STOCKGROUP_NM, P.NAME_NM) 
	  , DATE_DT, NEXT_DT, DIFF, PRICE_AMT, GREENLIMIT_QTY, YELLOWLIMIT_QTY, REDLIMIT_QTY, STOCK_QTY, SALE_QTY, TS.INTAKE_QTY, TS.SUGGESTION_QTY, PACKAGE_QTY
END