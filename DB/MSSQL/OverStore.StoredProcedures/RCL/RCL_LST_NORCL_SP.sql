﻿CREATE PROCEDURE RCL_LST_NORCL_SP @StartDate DATE, @EndDate DATE AS
BEGIN

  IF OBJECT_ID('tempdb.dbo.#rec', 'U') IS NOT NULL  DROP TABLE #rec;
  IF OBJECT_ID('tempdb.dbo.#stores', 'U') IS NOT NULL  DROP TABLE #stores;
  
  SELECT ROW_NUMBER() OVER (PARTITION BY D.DATE_DT ORDER BY ST.STOREID) ROWNO, ST.STOREID, ST.STORE_NM, D.DATE_DT
    INTO #stores
    FROM STR_STORE ST
	JOIN dbo.STR_GETUSERSTORES_FN() US ON ST.STOREID = US.STOREID
    JOIN RPT_DATE D ON D.DATE_DT BETWEEN @StartDate AND @EndDate -- DATEADD(MONTH, -1, CAST(GETDATE()-1 AS date)) AND CAST(GETDATE()-1 AS date)
	LEFT JOIN RCL_DAYSOFF O ON ST.STOREID = O.STORE AND D.DATE_DT = OFFDAY_DT
   WHERE D.DATE_DT BETWEEN ST.OPENING_DT AND ISNULL(ST.CLOSING_DT, CONVERT(DATE, '20991231', 112))
     AND ST.DELETED_FL = 'N'
	 -- AND ST.STOREID != 152
	 AND O.DAYSOFFID IS NULL
   ORDER BY 4 DESC, 1 DESC
  
  SELECT *
    INTO #rec
    FROM (
  SELECT STORE, TRANSACTION_DT, TOBANK_AMT, CARDTOTAL_AMT
    FROM (
  select STORE, TRANSACTION_DT, TOBANK_AMT, CARDTOTAL_AMT, ROW_NUMBER() OVER (PARTITION BY STORE, TRANSACTION_DT ORDER BY CREATE_DT DESC) ROWNO
    from RCL_RECONCILIATION R
   WHERE R.TRANSACTION_DT BETWEEN @StartDate AND @EndDate -- BETWEEN DATEADD(MONTH, -1, CAST(GETDATE()-1 AS date)) AND CAST(GETDATE()-1 AS date)
     AND DELETED_FL = 'N') A
   WHERE ROWNO = 1
   UNION ALL
  SELECT STORE, RECONCILIATION_DT, BANK_AMT, CARD_AMT
    FROM RCL_STORE
   WHERE RECONCILIATION_DT BETWEEN @StartDate AND @EndDate -- BETWEEN DATEADD(MONTH, -1, CAST(GETDATE()-1 AS date)) AND CAST(GETDATE()-1 AS date)
     AND DELETED_FL = 'N'
     AND COMPLETE_FL = 'Y') AA
  
  SELECT DISTINCT S.STOREID, S.STORE_NM, S.DATE_DT
    FROM #stores S
    LEFT JOIN #rec R ON S.STOREID = R.STORE AND S.DATE_DT = R.TRANSACTION_DT
   WHERE R.STORE IS NULL
   ORDER BY 3 DESC

END