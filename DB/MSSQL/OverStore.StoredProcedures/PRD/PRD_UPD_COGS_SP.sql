﻿CREATE PROCEDURE PRD_UPD_COGS_SP AS
BEGIN

IF OBJECT_ID('tempdb..#PURCHASES') IS NOT NULL DROP TABLE #PURCHASES
IF OBJECT_ID('tempdb..#COGS') IS NOT NULL DROP TABLE #COGS
IF OBJECT_ID('tempdb..#DATES') IS NOT NULL DROP TABLE #DATES
IF OBJECT_ID('tempdb..#RESULT') IS NOT NULL DROP TABLE #RESULT

SELECT *, (AMOUNT_AMT + CASE WHEN STOCK > 0 THEN STOCK * LAGPURCHASE_AMT ELSE 0 END) / (QUANTITY_QTY + CASE WHEN STOCK > 0 THEN STOCK ELSE 0 END) WEIGHTEDPURCHASE_AMT
  INTO #PURCHASES
  FROM (
SELECT *, ISNULL(LAG(PURCHASE_AMT) OVER (PARTITION BY PRODUCT ORDER BY ROWNO), PURCHASE_AMT) LAGPURCHASE_AMT, 
	   ISNULL(DATEADD(DAY, -1, LEAD(TRANSACTION_DT) OVER (PARTITION BY PRODUCT ORDER BY ROWNO)), CONVERT(DATE, '20991231', 112))  END_DT
  FROM (
SELECT ROW_NUMBER() OVER(PARTITION BY B.PRODUCT ORDER BY TRANSACTION_DT) ROWNO, B.*, ABS(PURCHASE_AMT - TOTALAVG) *100.0 / TOTALAVG CHANGEPCT, S.STOCK
  FROM (
SELECT *, AMOUNT_AMT/QUANTITY_QTY PURCHASE_AMT, SUM(AMOUNT_AMT) OVER (PARTITION BY PRODUCT) / SUM(QUANTITY_QTY) OVER (PARTITION BY PRODUCT) TOTALAVG
  FROM (
SELECT TRANSACTION_DT, COALESCE(PP.PRODUCTID, P.PRODUCTID) PRODUCT, COALESCE(PP.NAME_NM, P.NAME_NM) PRODUCTNAME, PR.PRICE_AMT, SUM(AMOUNT_AMT) AMOUNT_AMT, SUM(QUANTITY_QTY) QUANTITY_QTY
  FROM INV_STOCKTRANSACTIONS_SYN T
  JOIN PRD_PRODUCT P ON T.PRODUCT = P.PRODUCTID
  LEFT JOIN PRD_PRODUCT PP ON P.PARENT = PP.PRODUCTID
  LEFT JOIN (SELECT PRODUCT, PRICE_AMT FROM PRC_PRODUCT WHERE PACKAGE = 1 AND DELETED_FL = 'N') PR ON COALESCE(PP.PRODUCTID, P.PRODUCTID) = PR.PRODUCT
  LEFT JOIN PRD_COGSPRODUCTREL RR ON COALESCE(PP.PRODUCTID, P.PRODUCTID) = RR.SELLPRODUCT
 WHERE TRANSACTIONTYPE = 9
   AND TRANSACTION_DT > '2019-01-01'
   AND AMOUNT_AMT > 0
   AND RR.SELLPRODUCT IS NULL
   -- AND PR.PRICE_AMT IS NOT NULL
   -- AND COALESCE(PP.PRODUCTID, P.PRODUCTID) = 31
 GROUP BY TRANSACTION_DT, COALESCE(PP.PRODUCTID, P.PRODUCTID), COALESCE(PP.NAME_NM, P.NAME_NM), PR.PRICE_AMT) A ) B
 LEFT JOIN INV_WAREHOUSESTOCK2_VW S ON B.PRODUCT = S.PRODUCT AND DATEADD(DAY, -1, B.TRANSACTION_DT) BETWEEN S.START_DT AND S.END_DT AND S.WAREHOUSE = 1001) C ) D

SELECT PRODUCT, CASE WHEN ROWNO = 1 THEN CONVERT(DATE, '20190101', 112) ELSE TRANSACTION_DT END START_DT
	 , END_DT, PURCHASE_AMT LASTPURCHASE_AMT, WEIGHTEDPURCHASE_AMT
  INTO #COGS
  FROM #PURCHASES ORDER BY PRODUCT, ROWNO

SELECT DISTINCT RR.SELLPRODUCT, START_DT
  INTO #DATES
  FROM #COGS C
  JOIN PRD_COGSPRODUCTREL RR ON C.PRODUCT = RR.RELPRODUCT

INSERT INTO #COGS 
SELECT SELLPRODUCT PRODUCT, START_DT, DATEADD(DAY, -1, ISNULL(LEAD(START_DT) OVER (PARTITION BY SELLPRODUCT ORDER BY START_DT), CONVERT(DATE, '21000101', 112))) END_DT
	 , LASTPURCHASE_AMT, WEIGHTEDPURCHASE_AMT
  FROM (
SELECT D.*, SUM(C.LASTPURCHASE_AMT * RR.COEF) / SUM(RR.COEF) LASTPURCHASE_AMT, SUM(C.WEIGHTEDPURCHASE_AMT * RR.COEF) / SUM(RR.COEF) WEIGHTEDPURCHASE_AMT 
  FROM #DATES D
  JOIN PRD_COGSPRODUCTREL RR ON D.SELLPRODUCT = RR.SELLPRODUCT
  JOIN #COGS C ON D.START_DT BETWEEN C.START_DT AND C.END_DT AND C.PRODUCT = RR.RELPRODUCT
 -- WHERE D.SELLPRODUCT = 102
 GROUP BY D.SELLPRODUCT, D.START_DT) A
 ORDER BY 1, 2

SELECT C.PRODUCT, C.START_DT, C.END_DT, 
	   CASE WHEN DEFCOGS_AMT IS NOT NULL AND C.LASTPURCHASE_AMT / DEFCOGS_AMT < 0.5 THEN DEFCOGS_AMT ELSE C.LASTPURCHASE_AMT END LASTPURCHASE_AMT,
	   CASE WHEN DEFCOGS_AMT IS NOT NULL AND C.WEIGHTEDPURCHASE_AMT / DEFCOGS_AMT < 0.5 THEN DEFCOGS_AMT ELSE C.WEIGHTEDPURCHASE_AMT END WEIGHTEDPURCHASE_AMT
  INTO #RESULT
  FROM #COGS C
  -- JOIN PRD_PRODUCT P ON C.PRODUCT = P.PRODUCTID
  LEFT JOIN PRD_COGSDEFAULT DEF ON C.PRODUCT = DEF.PRODUCTID

TRUNCATE TABLE PRD_COGS
INSERT INTO PRD_COGS 
SELECT B.*
  FROM #RESULT B

/*
UPDATE A SET WEIGHTEDPURCHASE_AMT = B.WEIGHTEDPURCHASE_AMT, LASTPURCHASE_AMT = B.LASTPURCHASE_AMT
-- SELECT *
  FROM PRD_COGS A
  JOIN #RESULT B ON A.PRODUCT = B.PRODUCT AND A.START_DT = B.START_DT AND A.END_DT = B.END_DT
 WHERE A.WEIGHTEDPURCHASE_AMT != B.WEIGHTEDPURCHASE_AMT OR A.LASTPURCHASE_AMT != B.LASTPURCHASE_AMT

INSERT INTO PRD_COGS 
SELECT B.*
  FROM #RESULT B
  LEFT JOIN PRD_COGS A ON A.PRODUCT = B.PRODUCT AND A.START_DT = B.START_DT AND A.END_DT = B.END_DT
 WHERE A.PRODUCT IS NULL
*/

END