﻿CREATE PROCEDURE SLS_RPT_TURNOVERPREMIUM_SP @today DATE = NULL AS
BEGIN
	
	IF @today IS NULL SET @today = CAST(GETDATE() AS DATE)

	DECLARE @month INT = LEFT(CONVERT(VARCHAR, @today, 112), 6)
	DECLARE @month1 INT = LEFT(CONVERT(VARCHAR, DATEADD(MONTH, -1, @today), 112), 6)
	DECLARE @month2 INT = LEFT(CONVERT(VARCHAR, DATEADD(MONTH, -2, @today), 112), 6)
	DECLARE @month3 INT = LEFT(CONVERT(VARCHAR, DATEADD(MONTH, -3, @today), 112), 6)
	DECLARE @month4 INT = LEFT(CONVERT(VARCHAR, DATEADD(MONTH, -12, @today), 112), 6)

	IF OBJECT_ID('tempdb.dbo.#SALES', 'U') IS NOT NULL DROP TABLE #SALES;

	SELECT STORE, DT.YEARMONTH_NO
		 , COUNT(DISTINCT DT.DATE_DT) DAY_CNT
		 , SUM(SALE_AMT + REFUND_AMT) SALE_AMT
		 , SUM((SALE_AMT + REFUND_AMT) * 100.0 / (100.0 + P.SALEVAT_RT)) SALENOVAT_AMT
	  INTO #SALES
	  FROM SLS_PRODUCTSUMMARY_SYN PS
	  JOIN RPT_DATE DT ON PS.TRANSACTION_DT = DT.DATE_DT
	  JOIN PRD_PRODUCT P ON PS.PRODUCT = P.PRODUCTID
	 WHERE DT.YEARMONTH_NO IN (@month, @month1, @month2, @month3, @month4)
	 GROUP BY STORE, DT.YEARMONTH_NO

	SELECT B.BRANCH_NM REGION_NM, RM.MANAGER_NM, ST.STOREID, ST.STORE_NM, ST.OPENING_DT
		 , SUM(CASE WHEN S.YEARMONTH_NO = @month THEN S.DAY_CNT ELSE 0 END) MONTHDAY_CNT
		 , SUM(CASE WHEN S.YEARMONTH_NO = @month THEN S.SALENOVAT_AMT ELSE 0 END) MONTHNOVAT_AMT
		 , SUM(CASE WHEN S.YEARMONTH_NO = @month THEN S.SALE_AMT ELSE 0 END) MONTHSALE_AMT
		 , SUM(CASE WHEN S.YEARMONTH_NO = @month4 THEN S.DAY_CNT ELSE 0 END) LASTYEARMONTHDAY_CNT
		 , SUM(CASE WHEN S.YEARMONTH_NO = @month4 THEN S.SALENOVAT_AMT ELSE 0 END) LASTYEARNOVAT_AMT
		 , SUM(CASE WHEN S.YEARMONTH_NO = @month4 THEN S.SALE_AMT ELSE 0 END) LASTYEARSALE_AMT
		 , SUM(CASE WHEN S.YEARMONTH_NO = @month3 THEN S.DAY_CNT ELSE 0 END) MONTH3DAY_CNT
		 , SUM(CASE WHEN S.YEARMONTH_NO = @month3 THEN S.SALENOVAT_AMT ELSE 0 END) MONTH3NOVAT_AMT
		 , SUM(CASE WHEN S.YEARMONTH_NO = @month3 THEN S.SALE_AMT ELSE 0 END) MONTH3SALE_AMT
		 , SUM(CASE WHEN S.YEARMONTH_NO = @month2 THEN S.DAY_CNT ELSE 0 END) MONTH2DAY_CNT
		 , SUM(CASE WHEN S.YEARMONTH_NO = @month2 THEN S.SALENOVAT_AMT ELSE 0 END) MONTH2NOVAT_AMT
		 , SUM(CASE WHEN S.YEARMONTH_NO = @month2 THEN S.SALE_AMT ELSE 0 END) MONTH2SALE_AMT
		 , SUM(CASE WHEN S.YEARMONTH_NO = @month1 THEN S.DAY_CNT ELSE 0 END) MONTH1DAY_CNT
		 , SUM(CASE WHEN S.YEARMONTH_NO = @month1 THEN S.SALENOVAT_AMT ELSE 0 END) MONTH1NOVAT_AMT
		 , SUM(CASE WHEN S.YEARMONTH_NO = @month1 THEN S.SALE_AMT ELSE 0 END) MONTH1SALE_AMT
	  FROM STR_STORE ST
	  LEFT JOIN #SALES S ON ST.STOREID = S.STORE
	  LEFT JOIN STR_REGIONMANAGERS RM ON ST.REGIONMANAGER = RM.REGIONMANAGERSID
	  LEFT JOIN SEC_USER U ON RM.USERID = U.USERID
	  LEFT JOIN ORG_BRANCH B ON U.BRANCH = B.BRANCHID
	 WHERE ST.ACTIVE_FL = 'Y'
	 GROUP BY B.BRANCH_NM, RM.MANAGER_NM, ST.STOREID, ST.STORE_NM, ST.OPENING_DT
END