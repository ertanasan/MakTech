﻿CREATE PROCEDURE RCL_LST_EXPENSECHART_SP @StoreList VARCHAR(MAX), @ExpenseTypeList VARCHAR(MAX), @ManagerList VARCHAR(MAX) AS
BEGIN

  -- DECLARE @StoreList VARCHAR(MAX), @ExpenseTypeList VARCHAR(MAX), @ManagerList VARCHAR(MAX)
  -- SET @StoreList = '11,'
  -- SET @ExpenseTypeList = NULL
  -- SET @ManagerList = NULL

  IF OBJECT_ID('tempdb.dbo.#stores', 'U') IS NOT NULL DROP TABLE #stores;      
  IF OBJECT_ID('tempdb.dbo.#expensetypes', 'U') IS NOT NULL DROP TABLE #expensetypes;      
  IF OBJECT_ID('tempdb.dbo.#managers', 'U') IS NOT NULL DROP TABLE #managers;      

  SELECT STOREID 
    INTO #stores 
    FROM STR_STORE
   WHERE @StoreList IS NULL OR LEN(@StoreList) = 0 OR STOREID IN (SELECT [Value] FROM [dbo].[SYS_SPLITTOINTEGERS_FN] (@StoreList,','))

  SELECT EXPENSETYPEID
    INTO #expensetypes
    FROM RCL_EXPENSETYPE
   WHERE @ExpenseTypeList IS NULL OR LEN(@ExpenseTypeList) = 0 OR EXPENSETYPEID IN (SELECT [Value] FROM [dbo].[SYS_SPLITTOINTEGERS_FN] (@ExpenseTypeList,','))

  SELECT REGIONMANAGERSID
    INTO #managers
    FROM STR_REGIONMANAGERS
   WHERE @ManagerList IS NULL OR LEN(@ManagerList) = 0 OR REGIONMANAGERSID IN (SELECT [Value] FROM [dbo].[SYS_SPLITTOINTEGERS_FN] (@ManagerList,','))

  DECLARE @StartDate DATE = CAST(GETDATE() - 180 AS DATE)
  IF @StartDate < CONVERT(DATE, '20190401', 112) SET @StartDate = CONVERT(DATE, '20190401', 112)
  DECLARE @EndDate DATE = CAST(GETDATE() AS DATE);

  WITH WEEKS AS (
  SELECT YEARWEEK_NO, MAX(DATE_DT) MAX_DT
    FROM RPT_DATE
   WHERE DATE_DT BETWEEN @StartDate AND @EndDate
   GROUP BY YEARWEEK_NO),
  EXPENSES AS (
  SELECT DT.YEARWEEK_NO, MAX(DT.DATE_DT) EXPENSE_DT, SUM(ISNULL(E.EXPENSE_AMT,0)) EXPENSE_AMT
    FROM RCL_EXPENSE E
	JOIN RPT_DATE DT ON CAST(E.EXPENSE_DT AS date) = DT.DATE_DT
	JOIN #stores ST ON E.STORE = ST.STOREID
	JOIN STR_STORE SST ON ST.STOREID = SST.STOREID
	JOIN #expensetypes ET ON E.EXPENSETYPE = ET.EXPENSETYPEID
	JOIN #managers M ON SST.REGIONMANAGER = M.REGIONMANAGERSID
   WHERE E.DELETED_FL = 'N'
     AND DT.DATE_DT BETWEEN @StartDate AND @EndDate
   GROUP BY DT.YEARWEEK_NO)

  SELECT W.YEARWEEK_NO, MAX_DT EXPENSE_DT, ISNULL(E.EXPENSE_AMT, 0) EXPENSE_AMT
    FROM WEEKS W 
	LEFT JOIN EXPENSES E ON W.YEARWEEK_NO = E.YEARWEEK_NO
   ORDER BY 1
 
END