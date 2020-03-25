﻿CREATE PROCEDURE WHS_SEL_WDORDERWIDGET_SP @GatheringDate DATE = NULL AS
BEGIN
 IF @GatheringDate IS NULL
 BEGIN
  SELECT @GatheringDate  = MAX(DATE_DT)
    FROM RPT_DATE
   WHERE DATE_DT <= CAST(GETDATE() AS DATE)
     AND DAYOFWEEK_NO != 7
 END

 DECLARE @nextWorkingDay DATE
 SELECT @nextWorkingDay = MIN(DATE_DT)
   FROM RPT_DATE
  WHERE DATE_DT > CAST(GETDATE() AS DATE)
    AND DAYOFWEEK_NO != 7

 SELECT CODE_NM PRODUCTCODE, NAME_NM PRODUCTNAME, HEAVY_FL,
     SUM(CASE WHEN GATHERED_QTY = 0 THEN 1 ELSE 0 END) NOTGATHEREDSTORE_CNT,
     SUM(CASE WHEN GATHERED_QTY > 0 THEN 1 ELSE 0 END) GATHEREDSTORE_CNT,
     SUM(CASE WHEN GATHERED_QTY = 0 THEN ORDER_QTY ELSE 0 END) NOTGATHERED_QTY,
     SUM(CASE WHEN GATHERED_QTY > 0 THEN GATHERED_QTY ELSE 0 END) GATHERED_QTY
   INTO #PRODUCTGATHERING
   FROM (
 SELECT P.PRODUCTID, P.CODE_NM, P.NAME_NM, STOREORDER,
     CASE WHEN P.LOADORDER_TXT LIKE 'A%' THEN 1 ELSE 0 END HEAVY_FL,
     SUM(GATHERED_QTY*SOD.ORDERUNIT_QTY) GATHERED_QTY,
     SUM(ORDER_QTY*SOD.ORDERUNIT_QTY) ORDER_QTY
   FROM WHS_GATHERINGDETAIL GD (NOLOCK)
   JOIN WHS_STOREORDERDETAIL SOD (NOLOCK) ON GD.STOREORDERDETAIL = SOD.STOREORDERDETAILID
   JOIN PRD_PRODUCT P (NOLOCK) ON SOD.PRODUCT = P.PRODUCTID
  WHERE GATHERING_TM >= @GatheringDate
    AND GATHERING_TM < DATEADD(DAY, 1, @GatheringDate)
    AND GD.DELETED_FL = 'N'
    AND SOD.DELETED_FL = 'N'
  GROUP BY P.PRODUCTID, P.CODE_NM, P.NAME_NM, STOREORDER, CASE WHEN P.LOADORDER_TXT LIKE 'A%' THEN 1 ELSE 0 END
 HAVING SUM(ORDER_QTY) > 0) A
  GROUP BY CODE_NM, NAME_NM, HEAVY_FL
  ORDER BY 6 DESC

 IF OBJECT_ID('tempdb.dbo.#ORDERS', 'U') IS NOT NULL DROP TABLE #ORDERS;
 SELECT STOREORDERID, STORE, STATUS, ORDER_DT, SHIPMENT_DT
   , CASE WHEN SHIPMENT_DT < @nextWorkingDay THEN 'Y' ELSE 'N' END OLDORDER_FL
   INTO #ORDERS
   FROM WHS_STOREORDER SO
   JOIN WHS_STOREORDERDETAIL SD ON SO.STOREORDERID = SD.STOREORDER AND SD.DELETED_FL = 'N'
   JOIN PRD_PRODUCT P ON SD.PRODUCT = P.PRODUCTID
   LEFT JOIN (SELECT STOREORDER, MIN(HISTORY_TM) MAXHISTORY_TM FROM WHS_STOREORDERHISTORY WHERE STATUS = 4 GROUP BY STOREORDER) SOH ON SO.STOREORDERID = SOH.STOREORDER
  WHERE SO.DELETED_FL = 'N'
    AND SO.CREATE_DT >= GETDATE()-7
    AND (SO.SHIPMENT_DT = @nextWorkingDay OR (STATUS = 3 AND SO.SHIPMENT_DT < @nextWorkingDay) OR MAXHISTORY_TM >= @GatheringDate)
  GROUP BY STOREORDERID, STORE, STATUS, ORDER_DT, SHIPMENT_DT
  
 IF OBJECT_ID('tempdb.dbo.#GATHERING', 'U') IS NOT NULL DROP TABLE #GATHERING;
 SELECT STOREORDERID, G.GATHERINGID, GATHERINGTYPE, GATHERINGSTATUS, GATHERINGUSER, U.USERFULL_NM
   , SUM(CASE WHEN ISNULL(GD.GATHERING_TM, @GatheringDate ) >= @GatheringDate THEN
     CASE WHEN GATHERED_QTY IS NOT NULL THEN ISNULL(GATHERED_QTY, 0) * ORDERUNIT_QTY * SP.PRICE_AMT
     ELSE SHIPPED_QTY * ORDERUNIT_QTY * SP.PRICE_AMT END
      ELSE 0 END) ORDERPRICE_AMT
   , SUM(CASE WHEN ISNULL(GD.GATHERING_TM, @GatheringDate ) >= @GatheringDate THEN ISNULL(GATHERED_QTY, 0) * ORDERUNIT_QTY * SP.PRICE_AMT ELSE 0 END) GATHEREDPRICE_AMT
   , SUM(CASE WHEN ISNULL(GD.GATHERING_TM, @GatheringDate ) >= @GatheringDate THEN
     CASE WHEN GATHERED_QTY IS NOT NULL THEN ISNULL(GATHERED_QTY, 0)
     ELSE SHIPPED_QTY END
      ELSE 0 END) ORDERPACKAGE_QTY
   , SUM(CASE WHEN ISNULL(GD.GATHERING_TM, @GatheringDate ) >= @GatheringDate THEN ISNULL(GATHERED_QTY, 0) ELSE 0 END) GATHEREDPACKAGE_QTY
   INTO #GATHERING
   FROM #ORDERS O
   JOIN WHS_GATHERING G ON O.STOREORDERID = G.STOREORDER
   JOIN WHS_GATHERINGDETAIL GD ON G.GATHERINGID = GD.GATHERING
   JOIN WHS_STOREORDERDETAIL SOD ON GD.STOREORDERDETAIL = SOD.STOREORDERDETAILID
   JOIN PRD_PRODUCT P ON SOD.PRODUCT = P.PRODUCTID
   LEFT JOIN SEC_USER U ON G.GATHERINGUSER = U.USERID
   LEFT JOIN PRC_SALEPRICE_VW SP ON P.PRODUCTID = SP.PRODUCT
  WHERE G.DELETED_FL = 'N'
    AND GD.DELETED_FL = 'N'
  GROUP BY STOREORDERID, G.GATHERINGID, GATHERINGTYPE, GATHERINGSTATUS, GATHERINGUSER, U.USERFULL_NM;
    
 WITH GATHERING AS (
 SELECT SUM(CASE WHEN GATHERINGTYPE = 1 THEN ORDERPRICE_AMT ELSE 0 END) HEAVYORDERPRICE_AMT
      , SUM(CASE WHEN GATHERINGTYPE = 2 THEN ORDERPRICE_AMT ELSE 0 END) LIGHTORDERPRICE_AMT
      , SUM(CASE WHEN GATHERINGTYPE = 1 THEN GATHEREDPRICE_AMT ELSE 0 END) HEAVYGATHEREDPRICE_AMT
      , SUM(CASE WHEN GATHERINGTYPE = 2 THEN GATHEREDPRICE_AMT ELSE 0 END) LIGHTGATHEREDPRICE_AMT
      , SUM(CASE WHEN GATHERINGTYPE = 1 THEN ORDERPACKAGE_QTY ELSE 0 END) HEAVYORDERPACKAGE_QTY
      , SUM(CASE WHEN GATHERINGTYPE = 2 THEN ORDERPACKAGE_QTY ELSE 0 END) LIGHTORDERPACKAGE_QTY
      , SUM(CASE WHEN GATHERINGTYPE = 1 THEN GATHEREDPACKAGE_QTY ELSE 0 END) HEAVYGATHEREDPACKAGE_QTY
      , SUM(CASE WHEN GATHERINGTYPE = 2 THEN GATHEREDPACKAGE_QTY ELSE 0 END) LIGHTGATHEREDPACKAGE_QTY
   FROM #GATHERING ),
 PRODUCT AS (
 SELECT SUM(CASE WHEN HEAVY_FL = 1 AND (NOTGATHERED_QTY * 100.0 / (NOTGATHERED_QTY + GATHERED_QTY)) > 25 THEN 1 ELSE 0 END) NOTGATHEREDHEAVYPRODUCT_CNT
   , SUM(CASE WHEN HEAVY_FL = 1 THEN 1 ELSE 0 END) HEAVYPRODUCT_CNT
   , SUM(CASE WHEN HEAVY_FL = 0 AND (NOTGATHERED_QTY * 100.0 / (NOTGATHERED_QTY + GATHERED_QTY)) > 25 THEN 1 ELSE 0 END) NOTGATHEREDLIGHTPRODUCT_CNT
   , SUM(CASE WHEN HEAVY_FL = 0 THEN 1 ELSE 0 END) LIGHTPRODUCT_CNT
   FROM #PRODUCTGATHERING)

  SELECT *
    FROM GATHERING, PRODUCT
END