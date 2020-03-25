﻿CREATE PROCEDURE SLS_LST_STORECATEGORYSALE_SP @StoreId INT AS
BEGIN

	DECLARE @today DATE = dbo.STR_GETUSERCURRENTDATE_FN(); -- CAST(GETDATE() AS DATE)
	DECLARE @lastmonth DATE = CAST(DATEADD(MONTH,-1,@today) AS DATE)
	DECLARE @lastyear DATE = CAST(DATEADD(MONTH,-12,@today) AS DATE)

	IF OBJECT_ID('tempdb.dbo.#currentmonth', 'U') IS NOT NULL DROP TABLE #currentmonth;
	IF OBJECT_ID('tempdb.dbo.#lastmonth', 'U') IS NOT NULL DROP TABLE #lastmonth;
	IF OBJECT_ID('tempdb.dbo.#lastyear', 'U') IS NOT NULL DROP TABLE #lastyear;
	IF OBJECT_ID('tempdb.dbo.#allCategories', 'U') IS NOT NULL DROP TABLE allCategories;

	SELECT CATEGORY, CATEGORY_NM, SALE / SUM(SALE) OVER (PARTITION BY 1) CM_SALE_PCT, SALE CM_SALE
	  INTO #currentmonth
	  FROM (
	SELECT P.CATEGORY, P.CATEGORY_NM, SUM(PRICE) SALE
	  FROM SLS_STOREDAILYPRODUCT_SYN SD
	  JOIN PRD_PRODUCT_VW P ON SD.PRODUCT = P.PRODUCTID
	  JOIN RPT_DATE DT ON SD.TRANSACTION_DT = DT.DATE_DT
	  JOIN RPT_DATE DT2 ON DT2.YEARMONTH_NO = DT.YEARMONTH_NO
	 WHERE SD.STORE = @StoreId
	   AND DT2.DATE_DT = @today
	 GROUP BY P.CATEGORY, P.CATEGORY_NM) A
	/*
	SELECT CATEGORY, CATEGORY_NM, SALE / SUM(SALE) OVER (PARTITION BY 1) CM_SALE_PCT, SALE CM_SALE, CUSTOMER CM_CUSTOMER, SALE/CUSTOMER CM_AVGSALE
	  INTO #currentmonth
	  FROM (
	SELECT P.CATEGORY, P.CATEGORY_NM, SUM(PRICE) SALE, COUNT(DISTINCT S.SALEID) CUSTOMER
	  FROM SLS_SALEDETAIL SD
	  JOIN SLS_SALE S ON SD.SALE = S.SALEID
	  JOIN PRD_PRODUCT_VW P ON SD.PRODUCT = P.PRODUCTID
	  JOIN RPT_DATE DT ON S.TRANSACTION_DT = DT.DATE_DT
	  JOIN RPT_DATE DT2 ON DT2.YEARMONTH_NO = DT.YEARMONTH_NO
	 WHERE S.STORE = @StoreId
	   AND S.CANCELLED_FL = 'N'
	   AND SD.CANCEL_FL = 'N'
	   AND DT2.DATE_DT = @today
	 GROUP BY P.CATEGORY, P.CATEGORY_NM) A*/

	SELECT CATEGORY, CATEGORY_NM, SALE / SUM(SALE) OVER (PARTITION BY 1) LM_SALE_PCT, SALE LM_SALE
	  INTO #lastmonth
	  FROM (
	SELECT P.CATEGORY, P.CATEGORY_NM, SUM(PRICE) SALE
	  FROM SLS_STOREDAILYPRODUCT_SYN SD
	  JOIN PRD_PRODUCT_VW P ON SD.PRODUCT = P.PRODUCTID
	  JOIN RPT_DATE DT ON SD.TRANSACTION_DT = DT.DATE_DT
	  JOIN RPT_DATE DT2 ON DT2.YEARMONTH_NO = DT.YEARMONTH_NO
	 WHERE SD.STORE = @StoreId
	   AND DT2.DATE_DT = @lastmonth
	 GROUP BY P.CATEGORY, P.CATEGORY_NM) A

	/*
	SELECT CATEGORY, CATEGORY_NM, SALE / SUM(SALE) OVER (PARTITION BY 1) LM_SALE_PCT, SALE LM_SALE, CUSTOMER LM_CUSTOMER, SALE/CUSTOMER LM_AVGSALE
	  INTO #lastmonth
	  FROM (
	SELECT P.CATEGORY, P.CATEGORY_NM, SUM(PRICE) SALE, COUNT(DISTINCT S.SALEID) CUSTOMER
	  FROM SLS_SALEDETAIL SD
	  JOIN SLS_SALE S ON SD.SALE = S.SALEID
	  JOIN PRD_PRODUCT_VW P ON SD.PRODUCT = P.PRODUCTID
	  JOIN RPT_DATE DT ON S.TRANSACTION_DT = DT.DATE_DT
	  JOIN RPT_DATE DT2 ON DT2.YEARMONTH_NO = DT.YEARMONTH_NO
	 WHERE S.STORE = @StoreId
	   AND S.CANCELLED_FL = 'N'
	   AND SD.CANCEL_FL = 'N'
	   AND DT2.DATE_DT = @lastmonth
	 GROUP BY P.CATEGORY, P.CATEGORY_NM) A
	*/

	SELECT CATEGORY, CATEGORY_NM, SALE / SUM(SALE) OVER (PARTITION BY 1) LY_SALE_PCT, SALE LY_SALE
	  INTO #lastyear
	  FROM (
	SELECT P.CATEGORY, P.CATEGORY_NM, SUM(PRICE) SALE
	  FROM SLS_STOREDAILYPRODUCT_SYN SD
	  JOIN PRD_PRODUCT_VW P ON SD.PRODUCT = P.PRODUCTID
	  JOIN RPT_DATE DT ON SD.TRANSACTION_DT = DT.DATE_DT
	  JOIN RPT_DATE DT2 ON DT2.YEARMONTH_NO = DT.YEARMONTH_NO
	 WHERE SD.STORE = @StoreId
	   AND DT2.DATE_DT = @lastyear
	 GROUP BY P.CATEGORY, P.CATEGORY_NM) A

	 /*
	SELECT CATEGORY, CATEGORY_NM, SALE / SUM(SALE) OVER (PARTITION BY 1) LY_SALE_PCT, SALE LY_SALE, CUSTOMER LY_CUSTOMER, SALE/CUSTOMER LY_AVGSALE
	  INTO #lastyear
	  FROM (
	SELECT P.CATEGORY, P.CATEGORY_NM, SUM(PRICE) SALE, COUNT(DISTINCT S.SALEID) CUSTOMER
	  FROM SLS_SALEDETAIL SD
	  JOIN SLS_SALE S ON SD.SALE = S.SALEID
	  JOIN PRD_PRODUCT_VW P ON SD.PRODUCT = P.PRODUCTID
	  JOIN RPT_DATE DT ON S.TRANSACTION_DT = DT.DATE_DT
	  JOIN RPT_DATE DT2 ON DT2.YEARMONTH_NO = DT.YEARMONTH_NO
	 WHERE S.STORE = @StoreId
	   AND S.CANCELLED_FL = 'N'
	   AND SD.CANCEL_FL = 'N'
	   AND DT2.DATE_DT = @lastyear
	 GROUP BY P.CATEGORY, P.CATEGORY_NM) A */

	SELECT CATEGORY, CATEGORY_NM, 
		   SUM(CM_SALE_PCT) CM_SALE_PCT, SUM(CM_SALE) CM_SALE,
		   SUM(LM_SALE_PCT) LM_SALE_PCT, SUM(LM_SALE) LM_SALE,
		   SUM(LY_SALE_PCT) LY_SALE_PCT, SUM(LY_SALE) LY_SALE,
		   ROW_NUMBER() OVER (ORDER BY SUM(CM_SALE) DESC) ROWNO 
     INTO #allCategories
	  FROM (
	SELECT CATEGORY, CATEGORY_NM, CM_SALE_PCT, CM_SALE, 0 LM_SALE_PCT, 0 LM_SALE, 0 LY_SALE_PCT, 0 LY_SALE
      FROM #currentmonth
	 UNION ALL
	SELECT CATEGORY, CATEGORY_NM, 0, 0, LM_SALE_PCT, LM_SALE, 0, 0
      FROM #lastmonth
	 UNION ALL
	SELECT CATEGORY, CATEGORY_NM, 0, 0, 0, 0, LY_SALE_PCT, LY_SALE
      FROM #lastyear) A
	 GROUP BY CATEGORY, CATEGORY_NM

	 /*
	SELECT CATEGORY, CATEGORY_NM, 
		   SUM(CM_SALE_PCT) CM_SALE_PCT, SUM(CM_SALE) CM_SALE,
		   SUM(CM_CUSTOMER) CM_CUSTOMER, SUM(CM_AVGSALE) CM_AVGSALE,
		   SUM(LM_SALE_PCT) LM_SALE_PCT, SUM(LM_SALE) LM_SALE,
		   SUM(LM_CUSTOMER) LM_CUSTOMER, SUM(LM_AVGSALE) LM_AVGSALE,
		   SUM(LY_SALE_PCT) LY_SALE_PCT, SUM(LY_SALE) LY_SALE,
		   SUM(LY_CUSTOMER) LY_CUSTOMER, SUM(LY_AVGSALE) LY_AVGSALE
      FROM (
	SELECT CATEGORY, CATEGORY_NM, CM_SALE_PCT, CM_SALE, CM_CUSTOMER, CM_AVGSALE, 0 LM_SALE_PCT, 0 LM_SALE, 0 LM_CUSTOMER, 0 LM_AVGSALE
		 , 0 LY_SALE_PCT, 0 LY_SALE, 0 LY_CUSTOMER, 0 LY_AVGSALE
      FROM #currentmonth
	 UNION ALL
	SELECT CATEGORY, CATEGORY_NM, 0, 0, 0, 0, LM_SALE_PCT, LM_SALE, LM_CUSTOMER, LM_AVGSALE, 0, 0, 0, 0
      FROM #lastmonth
	 UNION ALL
	SELECT CATEGORY, CATEGORY_NM, 0, 0, 0, 0, 0, 0, 0, 0, LY_SALE_PCT, LY_SALE, LY_CUSTOMER, LY_AVGSALE
      FROM #lastyear) A
	 GROUP BY CATEGORY, CATEGORY_NM */

	 DECLARE @FirstRowsCount INT = 4;

	 SELECT CATEGORY, CATEGORY_NM, CM_SALE, CM_SALE_PCT, LM_SALE, LM_SALE_PCT, LY_SALE, LY_SALE_PCT, ROWNO
	   FROM #allCategories
	  WHERE ROWNO <= @FirstRowsCount	 
	 UNION
	 SELECT -1					CATEGORY
		  , 'Diğer Kategoriler'	CATEGORY_NM
		  , SUM(CM_SALE)		CM_SALE
		  , SUM(CM_SALE_PCT)	CM_SALE_PCT
		  , SUM(LM_SALE)		LM_SALE
		  , SUM(LM_SALE_PCT)	LM_SALE_PCT
		  , SUM(LY_SALE)		LY_SALE
		  , SUM(LY_SALE_PCT)	LY_SALE_PCT
		  , @FirstRowsCount + 1	ROWNO
	   FROM #allCategories
	  WHERE ROWNO > @FirstRowsCount
	 ORDER BY ROWNO 

END