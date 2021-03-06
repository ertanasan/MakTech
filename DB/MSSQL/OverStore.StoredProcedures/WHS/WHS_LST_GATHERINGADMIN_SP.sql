﻿CREATE PROCEDURE [dbo].[WHS_LST_GATHERINGADMIN_SP] @ShipmentDate DATE = NULL WITH RECOMPILE AS
BEGIN

	DECLARE @nextWorkingDay DATE
	SELECT @nextWorkingDay = MIN(DATE_DT)
	  FROM RPT_DATE
	 WHERE DATE_DT > CAST(GETDATE() AS DATE)
	   AND DAYOFWEEK_NO != 7

	SET @ShipmentDate = ISNULL(@ShipmentDate, @nextWorkingDay);

	WITH STOREORDERDETAIL AS (
	SELECT STOREORDER, COUNT(*) PRODUCT_CNT, SUM(D.ORDER_QTY * D.ORDERUNIT_QTY * SP.PRICE_AMT) ORDERPRICE_AMT
	  FROM WHS_STOREORDERDETAIL D
	  LEFT JOIN PRC_SALEPRICE_VW SP ON D.PRODUCT = SP.PRODUCT
	 WHERE ORDER_QTY > 0 AND DELETED_FL = 'N' GROUP BY STOREORDER),
	GATHERING AS (
	SELECT STOREORDER, COUNT(*) TYPE_CNT, SUM(CASE WHEN GATHERINGSTATUS = 9 THEN 1 ELSE 0 END) GATHEREDTYPE_CNT
	  FROM WHS_GATHERING
	 WHERE DELETED_FL = 'N' GROUP BY STOREORDER),
	GATHERINGPALLET AS (
	SELECT G.STOREORDER, COUNT(DISTINCT CAST(GP.GATHERING AS VARCHAR)+'-'+CAST(GP.PALLET_NO AS VARCHAR)) PALLET_CNT
		 , SUM(CASE WHEN GP.GATHERINGPALLETSTATUS = 9 THEN 1 ELSE 0 END) CONTROLLEDPALLET_CNT
	  FROM WHS_GATHERING G
	  JOIN WHS_GATHERINGPALLET2_VW GP ON G.GATHERINGID = GP.GATHERING
	 GROUP BY G.STOREORDER),
	GATHERINGDETAIL AS (
	SELECT G.STOREORDER, SUM(GATHERED_QTY * SOD.ORDERUNIT_QTY * SP.PRICE_AMT) GATHERINGPRICE_AMT
		 , SUM(CASE WHEN ISNULL(GD.GATHERED_QTY, 0) > 0 THEN 1 ELSE 0 END) GATHEREDPRODUCT_CNT
		 , SUM(CONTROL_QTY * SOD.ORDERUNIT_QTY * SP.PRICE_AMT) CONTROLPRICE_AMT
		 , SUM(CASE WHEN ISNULL(GD.CONTROL_QTY, 0) > 0 THEN 1 ELSE 0 END) CONTROLLEDPRODUCT_CNT
	  FROM WHS_GATHERING G
	  JOIN WHS_GATHERINGDETAIL GD ON G.GATHERINGID = GD.GATHERING
	  JOIN WHS_STOREORDERDETAIL SOD ON GD.STOREORDERDETAIL = SOD.STOREORDERDETAILID
	  LEFT JOIN PRC_SALEPRICE_VW SP ON SOD.PRODUCT = SP.PRODUCT
	 WHERE GD.DELETED_FL = 'N'
	   AND SOD.DELETED_FL = 'N'
	 GROUP BY G.STOREORDER)
	SELECT STOREORDERID, ST.STORE_NM, ST.ADDRESS_TXT, ORDERCODE_NM, ORDER_DT, SHIPMENT_DT, STATUS, PRODUCT_CNT, ORDERPRICE_AMT
		 , GP.PALLET_CNT, G.TYPE_CNT, G.GATHEREDTYPE_CNT, GATHERINGPRICE_AMT, GATHEREDPRODUCT_CNT, GP.PALLET_CNT CONTROLPALLET_CNT
		 , CONTROLLEDPALLET_CNT, CONTROLPRICE_AMT, CONTROLLEDPRODUCT_CNT
		 , CASE WHEN STATUS >= 4 THEN 40 
		   ELSE CASE WHEN G.TYPE_CNT = G.GATHEREDTYPE_CNT
				THEN CASE WHEN GP.PALLET_CNT = CONTROLLEDPALLET_CNT THEN 30 ELSE 20 END
				ELSE 10 END
		   END GATHERINGSTATUS_CD
	  FROM WHS_STOREORDER SO
	  JOIN STR_STORE ST ON SO.STORE = ST.STOREID
	  JOIN STOREORDERDETAIL SOD ON SO.STOREORDERID = SOD.STOREORDER
	  LEFT JOIN GATHERING G ON SO.STOREORDERID = G.STOREORDER		
	  LEFT JOIN GATHERINGPALLET GP ON SO.STOREORDERID = GP.STOREORDER
	  LEFT JOIN GATHERINGDETAIL GD ON SO.STOREORDERID = GD.STOREORDER
	 WHERE SHIPMENT_DT = @ShipmentDate
	   AND STATUS != 9
END