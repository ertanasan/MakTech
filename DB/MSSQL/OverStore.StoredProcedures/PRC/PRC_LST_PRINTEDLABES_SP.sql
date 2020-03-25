﻿CREATE PROCEDURE [dbo].[PRC_LST_PRINTEDLABES_SP] @StartDate DATE = NULL,  @EndDate DATE = NULL AS
BEGIN
  -- Initializing parameters
  IF @StartDate IS NULL SET @StartDate = DATEADD(DAY, -14, GETDATE());
  IF @EndDate IS NULL SET @EndDate = GETDATE()+1;
       
  -- Temp Tables
  IF OBJECT_ID('tempdb.dbo.#priceChanges', 'U') IS NOT NULL  DROP TABLE #priceChanges;
  IF OBJECT_ID('tempdb.dbo.#stores', 'U') IS NOT NULL  DROP TABLE #stores;
  SELECT * into #stores FROM dbo.STR_GETUSERSTORES_FN();
  -- SELECT * into #stores FROM STR_STORE;
      
  -- MainQuery                              
  SELECT C.STORE, ST.STORE_NM, COALESCE(PP.PRODUCTID, P.PRODUCTID) PRODUCT
       , SUM(CASE WHEN L.LABELPRINTID IS NOT NULL THEN 1 ELSE 0 END) PRINTED
	   , MIN(C.VERSION_TM) VERSION_TM
	   , MIN(L.CREATE_DT) PRINT_TM
	INTO #priceChanges
	FROM PRC_CURRENTPRICE C (NOLOCK)
	JOIN PRD_PRODUCT P ON C.PRODUCTCODE_NM = P.CODE_NM
	LEFT JOIN PRD_PRODUCT PP ON P.PRODUCTID = PP.PARENT
	JOIN #stores ST ON ST.STOREID = C.STORE AND ST.DELETED_FL = 'N' AND ST.ACTIVE_FL = 'Y'
	LEFT JOIN PRC_LABELPRINT L ON COALESCE(PP.PRODUCTID, P.PRODUCTID) = L.PRODUCT AND C.CURRENTPRICEID = L.CURRENTPRICE
   WHERE C.GROUP_CD = 1
     AND C.VERSION_TM BETWEEN @StartDate AND @EndDate
   GROUP BY C.STORE, ST.STORE_NM, COALESCE(PP.PRODUCTID, P.PRODUCTID)
        
  SELECT CP.STORE, CP.STORE_NM
       , COUNT(DISTINCT CP.PRODUCT) CHANGEDPRODUCT_CN
       , SUM(CASE WHEN CP.PRINTED > 0 THEN 1 ELSE 0 END) PRINTEDLABEL_CN
       , SUM(CASE WHEN CP.PRINTED = 0 THEN 1 ELSE 0 END) NOTPRINTEDLABELS
       -- , AVG( DATEDIFF(hh, CP.VERSION_TM, ISNULL(CP.PRINT_TM, GETDATE())) ) AVERAGEWAITINGTIME
    FROM #priceChanges CP
   GROUP BY CP.STORE, CP.STORE_NM
   ORDER BY NOTPRINTEDLABELS DESC

END