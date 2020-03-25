﻿CREATE PROCEDURE [dbo].[RCL_LST_EXPENSEREPORTDETAIL_SP] @StartDate DATE, @EndDate DATE, @StoreList VARCHAR(MAX), @ExpenseTypeList VARCHAR(MAX), @ManagerList VARCHAR(MAX) AS
BEGIN

  SELECT STOREID 
    INTO #stores 
    FROM STR_STORE
   WHERE @StoreList IS NULL OR LEN(@StoreList) = 0 OR STOREID IN (SELECT [Value] FROM [dbo].[SYS_SPLITTOINTEGERS_FN] (@StoreList,','))

  SELECT EXPENSETYPEID, EXPENSETYPE_NM
    INTO #expensetypes
    FROM RCL_EXPENSETYPE
   WHERE @ExpenseTypeList IS NULL OR LEN(@ExpenseTypeList) = 0 OR EXPENSETYPEID IN (SELECT [Value] FROM [dbo].[SYS_SPLITTOINTEGERS_FN] (@ExpenseTypeList,','))

  SELECT REGIONMANAGERSID
    INTO #managers
    FROM STR_REGIONMANAGERS
   WHERE @ManagerList IS NULL OR LEN(@ManagerList) = 0 OR REGIONMANAGERSID IN (SELECT [Value] FROM [dbo].[SYS_SPLITTOINTEGERS_FN] (@ManagerList,','))

  SELECT *, ROW_NUMBER() OVER (ORDER BY EXPENSE_AMT DESC) ROWNO
    FROM (
  SELECT RM.MANAGER_NM, S.STORE_NM, ET.EXPENSETYPE_NM, E.EXPENSE_DT, E.EXPENSE_AMT
    FROM RCL_EXPENSE E
	JOIN STR_STORE S ON E.STORE = S.STOREID
	JOIN ORG_BRANCH B ON S.BRANCH = B.BRANCHID
	JOIN SEC_USER U ON B.PARENT = U.BRANCH
	JOIN STR_REGIONMANAGERS RM ON RM.USERID = U.USERID
	JOIN #stores ST ON E.STORE = ST.STOREID
	JOIN #expensetypes ET ON E.EXPENSETYPE = ET.EXPENSETYPEID
	JOIN #managers M ON RM.REGIONMANAGERSID = M.REGIONMANAGERSID
   WHERE EXPENSE_DT BETWEEN @StartDate AND @EndDate
     AND E.OPEN_FL = 'N'
	 AND E.DELETED_FL = 'N'
	 AND B.DELETED_FL = 'N'
	 AND U.DELETED_FL = 'N') A
END
