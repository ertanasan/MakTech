﻿CREATE PROCEDURE [dbo].[SLS_LST_MISSINGZET_SP] @DayBefore INT = NULL AS
BEGIN

	IF OBJECT_ID('tempdb.dbo.#STORES', 'U') IS NOT NULL DROP TABLE #STORES;     
	SELECT * INTO #STORES FROM dbo.STR_GETUSERSTORES_FN();

	SET @DayBefore = ISNULL(@DayBefore, 3);

	SELECT ST.STOREID, ST.STORE_NM, A.CASHREGISTERID, RB.BRAND_NM, DT.DATE_DT TRANSACTION_DT
	  FROM STR_CASHREGISTER A
	  JOIN STR_CASHREGISTERMODEL RM ON RM.CASHREGISTERMODELID = A.CASHREGISTERMODEL
	  JOIN STR_CASHREGISTERBRAND RB ON RB.CASHREGISTERBRANDID = RM.BRAND
	  JOIN #STORES ST ON A.STORE = ST.STOREID AND ST.ACTIVE_FL = 'Y'
	  JOIN RPT_DATE DT ON DT.DATE_DT >= CAST(GETDATE() - @DayBefore AS DATE) AND DT.DATE_DT <= CAST(GETDATE()-0.875 AS DATE) 
	  LEFT JOIN (SELECT DISTINCT STORE, CASHREGISTER, TRANSACTION_DT FROM SLS_SALEZET WHERE DELETED_FL = 'N' AND TRANSACTION_DT >= CAST(GETDATE() - @DayBefore AS DATE)) B 
		ON A.STORE = B.STORE AND A.CASHREGISTERID = B.CASHREGISTER AND DT.DATE_DT = B.TRANSACTION_DT
	 WHERE A.DELETED_FL = 'N' AND B.STORE IS NULL

END