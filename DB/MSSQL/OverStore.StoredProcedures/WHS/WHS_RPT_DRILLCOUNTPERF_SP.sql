﻿CREATE PROCEDURE [dbo].[WHS_RPT_DRILLCOUNTPERF_SP] @today DATE = NULL AS
BEGIN

	-- DECLARE @today DATE = null
	IF OBJECT_ID('tempdb.dbo.#RESULTS', 'U') IS NOT NULL DROP TABLE #RESULTS;
	IF OBJECT_ID('tempdb.dbo.#YESTERDAYRESULTS', 'U') IS NOT NULL DROP TABLE #YESTERDAYRESULTS;
	
	CREATE TABLE #RESULTS
	( BRANCH_NM VARCHAR(100), MANAGER_NM VARCHAR(100), STORE INT, STORE_NM VARCHAR(100), LASTCOUNTING_DT DATE, MINUSSTOCKCOUNT INT, 
	  STOCKSURPLUS_AMT NUMERIC(22,6), STOCKDEFICIT_AMT NUMERIC(22,6), PRODUCT_CNT INT, SUCCESSKPI NUMERIC(12,6), RISKRATIO NUMERIC(12,6), 
	  MONTHKPIRANK INT, NOTCOUNTEDPRODUCT_CNT INT, DAYSPASSED INT, GRADE VARCHAR(10))

	CREATE TABLE #YESTERDAYRESULTS
	( BRANCH_NM VARCHAR(100), MANAGER_NM VARCHAR(100), STORE INT, STORE_NM VARCHAR(100), LASTCOUNTING_DT DATE, MINUSSTOCKCOUNT INT, 
	  STOCKSURPLUS_AMT NUMERIC(22,6), STOCKDEFICIT_AMT NUMERIC(22,6), PRODUCT_CNT INT, SUCCESSKPI NUMERIC(12,6), RISKRATIO NUMERIC(12,6), 
	  MONTHKPIRANK INT, NOTCOUNTEDPRODUCT_CNT INT, DAYSPASSED INT, GRADE VARCHAR(10))

	IF (@today IS NULL) SET @today = CAST(GETDATE() - 1 AS DATE)
	DECLARE @yesterday DATE = DATEADD(DAY, -1, @today);

	INSERT INTO #RESULTS
	Exec WHS_RPT_DRILLCOUNTPERFCALC_SP @today

	INSERT INTO #YESTERDAYRESULTS
	Exec WHS_RPT_DRILLCOUNTPERFCALC_SP @yesterday

	SELECT R.*, YR.SUCCESSKPI YESTERDAYKPI, YR.GRADE YESTERDAYGRADE
	  FROM #RESULTS R
	  LEFT JOIN #YESTERDAYRESULTS YR ON R.STORE = YR.STORE
	 ORDER BY LEFT(R.GRADE,1) DESC, CAST(SUBSTRING(R.GRADE,2,10) AS INT) DESC
	
END