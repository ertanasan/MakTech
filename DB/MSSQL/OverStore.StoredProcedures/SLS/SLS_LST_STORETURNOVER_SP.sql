﻿CREATE PROCEDURE SLS_LST_STORETURNOVER_SP AS
BEGIN

	IF OBJECT_ID('tempdb.dbo.#TY', 'U') IS NOT NULL  DROP TABLE #TY
	IF OBJECT_ID('tempdb.dbo.#TYP', 'U') IS NOT NULL  DROP TABLE #TYP
	IF OBJECT_ID('tempdb.dbo.#LY', 'U') IS NOT NULL  DROP TABLE #LY
	IF OBJECT_ID('tempdb.dbo.#LYP', 'U') IS NOT NULL  DROP TABLE #LYP

	DECLARE @today DATE = CAST(GETDATE()-1 AS DATE)
	SELECT STORE
		 , SUM(TURNOVER) CY_TURNOVER, SUM(CASE WHEN CMCY = 'CM' THEN TURNOVER ELSE 0 END) CM_TURNOVER
		 , SUM(RECEIPT_CNT) CY_RECEIPTCOUNT, SUM(CASE WHEN CMCY = 'CM' THEN RECEIPT_CNT ELSE 0 END) CM_RECEIPTCOUNT
		 , COUNT(*) CY_DAYCOUNT, SUM(CASE WHEN CMCY = 'CM' THEN 1 ELSE 0 END) CM_DAYCOUNT
	  INTO #TY
	  FROM (
		SELECT S.STORE, D.DATE_DT, CASE WHEN D2.YEARMONTH_NO = D.YEARMONTH_NO THEN 'CM' ELSE 'CY' END CMCY
			 , SUM(S.TOTAL_AMT) TURNOVER, COUNT(*) RECEIPT_CNT
		  FROM SLS_SALE S (NOLOCK)
		  JOIN RPT_DATE D ON S.TRANSACTION_DT = D.DATE_DT
		  JOIN RPT_DATE D2 ON D2.DATE_DT = @today AND D2.YEAR_NO = D.YEAR_NO
		 WHERE S.CANCELLED_FL = 'N'
		   AND S.DELETED_FL = 'N'
		   AND D.DATE_DT <= @today
		 GROUP BY S.STORE, D.DATE_DT, CASE WHEN D2.YEARMONTH_NO = D.YEARMONTH_NO THEN 'CM' ELSE 'CY' END) A
	 GROUP BY STORE

	SELECT STORE, SUM(PRODUCT_CNT) CY_PRODUCTCOUNT, SUM(CASE WHEN CMCY = 'CM' THEN PRODUCT_CNT ELSE 0 END) CM_PRODUCTCOUNT
	  INTO #TYP
	  FROM (
		SELECT S.STORE, D.DATE_DT, CASE WHEN D2.YEARMONTH_NO = D.YEARMONTH_NO THEN 'CM' ELSE 'CY' END CMCY, COUNT(*) PRODUCT_CNT
		  FROM SLS_SALEDETAIL S (NOLOCK)
		  JOIN RPT_DATE D ON S.TRANSACTION_DT = D.DATE_DT
		  JOIN RPT_DATE D2 ON D2.DATE_DT = @today AND D2.YEAR_NO = D.YEAR_NO
		 WHERE S.CANCEL_FL = 'N'
		   AND S.DELETED_FL = 'N'
		   AND D.DATE_DT <= @today
		 GROUP BY S.STORE, D.DATE_DT, CASE WHEN D2.YEARMONTH_NO = D.YEARMONTH_NO THEN 'CM' ELSE 'CY' END) A
	 GROUP BY STORE

	DECLARE @lastyear DATE = DATEADD(YEAR, -1, CAST(GETDATE()-1 AS DATE))
	SELECT STORE
	     , SUM(TURNOVER) LY_TURNOVER, SUM(CASE WHEN LMLY = 'LM' THEN TURNOVER ELSE 0 END) LM_TURNOVER
	     , SUM(RECEIPT_CNT) LY_RECEIPTCOUNT, SUM(CASE WHEN LMLY = 'LM' THEN RECEIPT_CNT ELSE 0 END) LM_RECEIPTCOUNT
		 , COUNT(*) LY_DAYCOUNT, SUM(CASE WHEN LMLY = 'LM' THEN 1 ELSE 0 END) LM_DAYCOUNT
	  INTO #LY
	  FROM (
		SELECT S.STORE, D.DATE_DT, CASE WHEN D2.YEARMONTH_NO = D.YEARMONTH_NO THEN 'LM' ELSE 'LY' END LMLY
			 , SUM(S.TOTAL_AMT) TURNOVER, COUNT(*) RECEIPT_CNT
		  FROM SLS_SALE S (NOLOCK)
		  JOIN RPT_DATE D ON S.TRANSACTION_DT = D.DATE_DT
		  JOIN RPT_DATE D2 ON D2.DATE_DT = @lastyear AND D2.YEAR_NO = D.YEAR_NO
		 WHERE S.CANCELLED_FL = 'N'
		   AND S.DELETED_FL = 'N'
		   AND D.DATE_DT <= @lastyear
		 GROUP BY S.STORE, D.DATE_DT, CASE WHEN D2.YEARMONTH_NO = D.YEARMONTH_NO THEN 'LM' ELSE 'LY' END) A
	 GROUP BY STORE

	SELECT STORE, SUM(PRODUCT_CNT) LY_PRODUCTCOUNT, SUM(CASE WHEN LMLY = 'LM' THEN PRODUCT_CNT ELSE 0 END) LM_PRODUCTCOUNT
	  INTO #LYP
	  FROM (
		SELECT S.STORE, D.DATE_DT, CASE WHEN D2.YEARMONTH_NO = D.YEARMONTH_NO THEN 'LM' ELSE 'LY' END LMLY, COUNT(*) PRODUCT_CNT
		  FROM SLS_SALEDETAIL S (NOLOCK)
		  JOIN RPT_DATE D ON S.TRANSACTION_DT = D.DATE_DT
		  JOIN RPT_DATE D2 ON D2.DATE_DT = @lastyear AND D2.YEAR_NO = D.YEAR_NO
		 WHERE S.CANCEL_FL = 'N'
		   AND S.DELETED_FL = 'N'
		   AND D.DATE_DT <= @lastyear
		 GROUP BY S.STORE, D.DATE_DT, CASE WHEN D2.YEARMONTH_NO = D.YEARMONTH_NO THEN 'LM' ELSE 'LY' END) A
	 GROUP BY STORE

    SELECT BRANCH_NM, MANAGER_NM, STOREID, STORE_NM, OPENING_DT
		 , CM_TURNOVER, CM_DAYCOUNT, CM_RECEIPTCOUNT, CM_FBU
		 , LM_TURNOVER, LM_DAYCOUNT, LM_RECEIPTCOUNT, LM_FBU
		 , CY_TURNOVER, CY_DAYCOUNT, CY_RECEIPTCOUNT, CY_FBU
		 , LY_TURNOVER, LY_DAYCOUNT, LY_RECEIPTCOUNT, LY_FBU
		 , CASE WHEN MONTHLYGROWTH > 10 THEN NULL ELSE MONTHLYGROWTH END MONTHLYGROWTH
		 , CASE WHEN ANNUALGROWTH > 10 THEN NULL ELSE ANNUALGROWTH END ANNUALGROWTH
		 , AVGMONTHLYGROWTH, AVGANNUALGROWTH
      FROM (
	SELECT B.BRANCH_NM, RM.MANAGER_NM, ST.STOREID, ST.STORE_NM, ST.OPENING_DT
		 , TY.CM_TURNOVER CM_TURNOVER, CM_DAYCOUNT, CM_RECEIPTCOUNT, CASE WHEN CM_RECEIPTCOUNT > 0 THEN ISNULL(CM_PRODUCTCOUNT,0)*1.0/CM_RECEIPTCOUNT ELSE 0 END CM_FBU
		 , LY.LM_TURNOVER LM_TURNOVER, LM_DAYCOUNT, LM_RECEIPTCOUNT, CASE WHEN LM_RECEIPTCOUNT > 0 THEN ISNULL(LM_PRODUCTCOUNT,0)*1.0/LM_RECEIPTCOUNT ELSE 0 END LM_FBU
		 , TY.CY_TURNOVER CY_TURNOVER, CY_DAYCOUNT, CY_RECEIPTCOUNT, CASE WHEN CY_RECEIPTCOUNT > 0 THEN ISNULL(CY_PRODUCTCOUNT,0)*1.0/CY_RECEIPTCOUNT ELSE 0 END CY_FBU
		 , LY.LY_TURNOVER LY_TURNOVER, LY_DAYCOUNT, LY_RECEIPTCOUNT, CASE WHEN LY_RECEIPTCOUNT > 0 THEN ISNULL(LY_PRODUCTCOUNT,0)*1.0/LY_RECEIPTCOUNT ELSE 0 END LY_FBU
		 , CASE WHEN CM_DAYCOUNT > 0 AND LM_DAYCOUNT * 1.0 / CM_DAYCOUNT > 0.8 THEN ((CM_TURNOVER / CM_DAYCOUNT) / (LM_TURNOVER / LM_DAYCOUNT)) - 1 ELSE NULL END MONTHLYGROWTH
		 , CASE WHEN CY_DAYCOUNT > 0 AND LY_DAYCOUNT * 1.0 / CY_DAYCOUNT > 0.8 THEN ((CY_TURNOVER / CY_DAYCOUNT) / (LY_TURNOVER / LY_DAYCOUNT)) - 1 ELSE NULL END ANNUALGROWTH
		 , ((SUM(CASE WHEN CM_DAYCOUNT > 0 AND LM_DAYCOUNT * 1.0 / CM_DAYCOUNT > 0.8 THEN CM_TURNOVER ELSE 0 END) OVER (PARTITION BY 1) /
			 SUM(CASE WHEN CM_DAYCOUNT > 0 AND LM_DAYCOUNT * 1.0 / CM_DAYCOUNT > 0.8 THEN CM_DAYCOUNT ELSE 0 END) OVER (PARTITION BY 1) ) /
			(SUM(CASE WHEN CM_DAYCOUNT > 0 AND LM_DAYCOUNT * 1.0 / CM_DAYCOUNT > 0.8 THEN LM_TURNOVER ELSE 0 END) OVER (PARTITION BY 1) /
			 SUM(CASE WHEN CM_DAYCOUNT > 0 AND LM_DAYCOUNT * 1.0 / CM_DAYCOUNT > 0.8 THEN LM_DAYCOUNT ELSE 0 END) OVER (PARTITION BY 1) )) - 1 AVGMONTHLYGROWTH
		 , ((SUM(CASE WHEN CY_DAYCOUNT > 0 AND LY_DAYCOUNT * 1.0 / CY_DAYCOUNT > 0.8 THEN CY_TURNOVER ELSE 0 END) OVER (PARTITION BY 1) /
			 SUM(CASE WHEN CY_DAYCOUNT > 0 AND LY_DAYCOUNT * 1.0 / CY_DAYCOUNT > 0.8 THEN CY_DAYCOUNT ELSE 0 END) OVER (PARTITION BY 1) ) /
			(SUM(CASE WHEN CY_DAYCOUNT > 0 AND LY_DAYCOUNT * 1.0 / CY_DAYCOUNT > 0.8 THEN LY_TURNOVER ELSE 0 END) OVER (PARTITION BY 1) /
			 SUM(CASE WHEN CY_DAYCOUNT > 0 AND LY_DAYCOUNT * 1.0 / CY_DAYCOUNT > 0.8 THEN LY_DAYCOUNT ELSE 0 END) OVER (PARTITION BY 1) )) - 1 AVGANNUALGROWTH
	  FROM STR_STORE ST
	  LEFT JOIN STR_REGIONMANAGERS RM ON ST.REGIONMANAGER = RM.REGIONMANAGERSID
	  LEFT JOIN SEC_USER U ON RM.USERID = U.USERID
	  LEFT JOIN ORG_BRANCH B ON U.BRANCH = B.BRANCHID
	  LEFT JOIN #TY TY ON ST.STOREID = TY.STORE
	  LEFT JOIN #LY LY ON ST.STOREID = LY.STORE
	  LEFT JOIN #TYP TYP ON ST.STOREID = TYP.STORE
	  LEFT JOIN #LYP LYP ON ST.STOREID = LYP.STORE
	 WHERE ST.DELETED_FL = 'N'
	   AND ST.ACTIVE_FL = 'Y') A

END