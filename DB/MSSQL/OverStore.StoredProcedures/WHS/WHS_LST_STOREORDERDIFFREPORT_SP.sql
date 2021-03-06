﻿CREATE PROCEDURE [dbo].[WHS_LST_STOREORDERDIFFREPORT_SP] @Store INT = -1, @StartDate DATE = NULL, @EndDate DATE = NULL, @Product INT = -1 AS        
BEGIN      

  -- DECLARE @BinVar varbinary(20);  
  -- SET @BinVar = 0x00000001000000CA0000000300000001000000DE000000000000000000000000;
  -- SET CONTEXT_INFO @BinVar;  
  -- 
  -- DECLARE @StartDate DATE = '2019-05-01'
  -- DECLARE @EndDate DATE = '2019-05-14'
  -- DECLARE @Store INT = 123
  -- DECLARE @Product INT = 149
	
  IF OBJECT_ID('tempdb.dbo.#mikro', 'U') IS NOT NULL  DROP TABLE #mikro;
  IF OBJECT_ID('tempdb.dbo.#maktech', 'U') IS NOT NULL  DROP TABLE #maktech;
  IF OBJECT_ID('tempdb.dbo.#orders', 'U') IS NOT NULL  DROP TABLE #orders;
  IF OBJECT_ID('tempdb.dbo.#details', 'U') IS NOT NULL  DROP TABLE #details;
  IF OBJECT_ID('tempdb.dbo.#stores', 'U') IS NOT NULL  DROP TABLE #stores;

  SELECT * INTO #stores FROM dbo.STR_GETUSERSTORES_FN();

  SELECT sth_giris_depo_no STORE
	   , S.STORE_NM
       , sth_evrakno_sira STOREORDER
	   , P.PRODUCTID PRODUCT
	   , SUM(sth_miktar) QUANTITY
	   , MAX(sth_tarih) SHIPMENT_DT
    INTO #mikro
	FROM MIK_TRANSACTION_VW MQ
	JOIN PRD_PRODUCT P ON MQ.sth_stok_kod COLLATE Turkish_100_CI_AS = P.CODE_NM
	JOIN #stores S ON MQ.sth_giris_depo_no = S.STOREID
   WHERE sth_evraktip = 2 AND sth_evrakno_seri = 'OMS'
	 AND sth_tarih BETWEEN @StartDate AND @EndDate
	 AND (ISNULL(@Store, -1) = -1 OR sth_giris_depo_no = @Store)
   GROUP BY sth_giris_depo_no, S.STORE_NM, sth_evrakno_sira, P.PRODUCTID
  

  SELECT SOD.STOREORDERDETAILID, SOD.STOREORDER, ST.STOREID STORE, ST.STORE_NM, CAST(SO.SHIPMENT_DT AS DATE) SHIPMENTDT_PLANNED
  	   , CAST(SOH.HISTORY_TM + 1 AS DATE) SHIPMENTDT_ACTUAL, SOH2.HISTORY_TM INTAKE_TM, SOD.PRODUCT, SOD.ORDERUNIT_QTY, SOD.ORDERUNIT_QTY * SOD.SHIPPED_QTY SHIPPED_QTY
  	   , SOD.INTAKE_QTY * SOD.ORDERUNIT_QTY INTAKE_QTY, SOH.USERFULL_NM SHIPPEDUSER, SOH2.USERFULL_NM INTAKEUSER
	INTO #maktech
    FROM WHS_STOREORDERDETAIL SOD
    JOIN WHS_STOREORDER SO ON SOD.STOREORDER = SO.STOREORDERID
	JOIN (SELECT DISTINCT STOREORDER FROM #mikro) M ON SO.STOREORDERID = M.STOREORDER
    JOIN #stores ST ON SO.STORE = ST.STOREID
    JOIN (SELECT STOREORDER, HISTORY_TM, U.USERFULL_NM, ROW_NUMBER() OVER (PARTITION BY STOREORDER ORDER BY HISTORY_TM DESC) ROWNO
  		  FROM WHS_STOREORDERHISTORY H
  		  JOIN SEC_USER U ON H.CREATEUSER = U.USERID
  		 WHERE STATUS = 5) SOH2 ON SO.STOREORDERID = SOH2.STOREORDER AND SOH2.ROWNO = 1
    JOIN (SELECT STOREORDER, HISTORY_TM, U.USERFULL_NM, ROW_NUMBER() OVER (PARTITION BY STOREORDER ORDER BY HISTORY_TM DESC) ROWNO
  		  FROM WHS_STOREORDERHISTORY H
  		  JOIN SEC_USER U ON H.CREATEUSER = U.USERID
  		 WHERE STATUS = 4) SOH ON SO.STOREORDERID = SOH.STOREORDER AND SOH.ROWNO = 1
   WHERE SO.STATUS = 5
     AND (ISNULL(@Store, -1) = -1 OR SO.STORE = @Store)

  SELECT M1.*, M2.SHIPMENTDT_PLANNED, SHIPMENTDT_ACTUAL, INTAKE_TM, SHIPPEDUSER, INTAKEUSER
    INTO #orders
    FROM (SELECT DISTINCT STORE, STORE_NM, STOREORDER, SHIPMENT_DT SHIPMENTDT_MIKRO FROM #mikro) M1
	JOIN (SELECT DISTINCT STORE, STORE_NM, STOREORDER, SHIPMENTDT_PLANNED, SHIPMENTDT_ACTUAL, SHIPPEDUSER, INTAKEUSER, INTAKE_TM FROM #maktech) M2 ON M1.STOREORDER = M2.STOREORDER 

  SELECT COALESCE(M1.STOREORDER, M2.STOREORDER) STOREORDER,
		 M2.STOREORDERDETAILID,
		 COALESCE(M1.PRODUCT, M2.PRODUCT) PRODUCT,
	     M2.ORDERUNIT_QTY,
         M2.SHIPPED_QTY,
	     ISNULL(M1.QUANTITY,0) MIKRO_QTY,
	     M2.INTAKE_QTY,
	     M2.INTAKE_QTY - ISNULL(M1.QUANTITY,0) [QUANTITY_DIFFERENCE]
    INTO #details
    FROM (SELECT * FROM #mikro WHERE STOREORDER IN (SELECT DISTINCT STOREORDER FROM #maktech)) M1
	FULL OUTER JOIN #maktech M2 ON M1.STOREORDER = M2.STOREORDER AND M1.PRODUCT = M2.PRODUCT
   WHERE (ISNULL(@Product, -1) = -1 OR COALESCE(M1.PRODUCT, M2.PRODUCT) = @Product)

  SELECT O.STOREORDER,
         O.STORE,
         O.STORE_NM,
         O.SHIPMENTDT_PLANNED,
	     O.SHIPMENTDT_ACTUAL,
		 O.INTAKE_TM,
	     O.SHIPMENTDT_MIKRO,
         P.CODE_NM,
         P.NAME_NM,
	     P.CATEGORY_NM,
	     P.UNIT_NM,
	     P.UNITPRICE_AMT UNIT_SALE_PRICE,
	     D.ORDERUNIT_QTY,
         D.SHIPPED_QTY,
	     D.MIKRO_QTY,
	     D.INTAKE_QTY,
	     ROUND(D.QUANTITY_DIFFERENCE,1) QUANTITY_DIFFERENCE,
	     O.SHIPPEDUSER,
	     O.INTAKEUSER,
		 ISNULL(NT.INTAKESTATUSTYPE_NM, '-') DECISION
    FROM #orders O
	JOIN #details D ON O.STOREORDER = D.STOREORDER
	JOIN PRD_PRODUCT_VW P ON D.PRODUCT = P.PRODUCTID
	LEFT JOIN WHS_INTAKESTATUS NS ON D.STOREORDERDETAILID = NS.STOREORDERDETAIL
	LEFT JOIN WHS_INTAKESTATUSTYPE NT ON NS.INTAKESTATUSTYPE = NT.INTAKESTATUSTYPEID
   WHERE ROUND(QUANTITY_DIFFERENCE,1) != 0
END