﻿CREATE PROCEDURE WHS_LST_DASHBOARD_SP AS
BEGIN

	DECLARE @nextWorkingDay DATE  
	SELECT @nextWorkingDay = MIN(DATE_DT)  
	  FROM RPT_DATE  
	 WHERE DATE_DT > CAST(GETDATE() AS DATE)  
	   AND DAYOFWEEK_NO != 7  

	DECLARE @currentDay DATE  
	SELECT @currentDay  = MAX(DATE_DT)  
	  FROM RPT_DATE  
	 WHERE DATE_DT <= CAST(GETDATE() AS DATE)  
	   AND DAYOFWEEK_NO != 7  

	IF OBJECT_ID('tempdb.dbo.#ORDERS', 'U') IS NOT NULL DROP TABLE #ORDERS;
	SELECT STOREORDERID, STORE, STATUS, ORDER_DT, SHIPMENT_DT
		 , SUM(CASE WHEN STATUS < 4 THEN ORDER_QTY * ORDERUNIT_QTY * WEIGHT_AMT / 1000.0 ELSE SHIPPED_QTY * ORDERUNIT_QTY * WEIGHT_AMT / 1000.0 END) ORDERWEIGHT
		 , SUM(CASE WHEN LOADORDER_TXT LIKE 'A%' THEN CASE WHEN STATUS < 4 THEN ORDER_QTY * ORDERUNIT_QTY * WEIGHT_AMT / 1000.0 ELSE SHIPPED_QTY * ORDERUNIT_QTY * WEIGHT_AMT / 1000.0 END ELSE 0 END) HEAVYORDERWEIGHT
		 , SUM(CASE WHEN LOADORDER_TXT NOT LIKE 'A%' THEN CASE WHEN STATUS < 4 THEN ORDER_QTY * ORDERUNIT_QTY * WEIGHT_AMT / 1000.0 ELSE SHIPPED_QTY * ORDERUNIT_QTY * WEIGHT_AMT / 1000.0 END ELSE 0 END) LIGHTORDERWEIGHT
		 , CASE WHEN SHIPMENT_DT < @nextWorkingDay THEN 'Y' ELSE 'N' END OLDORDER_FL
	  INTO #ORDERS
	  FROM WHS_STOREORDER SO
	  JOIN WHS_STOREORDERDETAIL SD ON SO.STOREORDERID = SD.STOREORDER AND SD.DELETED_FL = 'N'
	  JOIN PRD_PRODUCT P ON SD.PRODUCT = P.PRODUCTID
	  LEFT JOIN (SELECT STOREORDER, MIN(HISTORY_TM) MAXHISTORY_TM FROM WHS_STOREORDERHISTORY WHERE STATUS = 4 GROUP BY STOREORDER) SOH ON SO.STOREORDERID = SOH.STOREORDER
	 WHERE SO.DELETED_FL = 'N'
	   AND SO.CREATE_DT >= GETDATE()-7
	   AND (SO.SHIPMENT_DT = @nextWorkingDay OR (STATUS = 3 AND SO.SHIPMENT_DT < @nextWorkingDay) OR MAXHISTORY_TM >= @currentDay)
	 GROUP BY STOREORDERID, STORE, STATUS, ORDER_DT, SHIPMENT_DT

	IF OBJECT_ID('tempdb.dbo.#GATHERING', 'U') IS NOT NULL DROP TABLE #GATHERING;
	SELECT STOREORDERID, G.GATHERINGID, GATHERINGTYPE, GATHERINGSTATUS, GATHERINGUSER, U.USERFULL_NM
		 , SUM(CASE WHEN ISNULL(GD.GATHERING_TM, @currentDay ) >= @currentDay THEN 
					CASE WHEN GATHERED_QTY IS NOT NULL THEN ISNULL(GATHERED_QTY, 0) * ORDERUNIT_QTY * WEIGHT_AMT / 1000.0
					WHEN STATUS < 4 THEN ORDER_QTY * ORDERUNIT_QTY * WEIGHT_AMT / 1000.0 
					ELSE SHIPPED_QTY * ORDERUNIT_QTY * WEIGHT_AMT / 1000.0 END
			   ELSE 0 END) ORDERWEIGHT
		 , SUM(CASE WHEN ISNULL(GD.GATHERING_TM, @currentDay ) >= @currentDay THEN ISNULL(GATHERED_QTY, 0) * ORDERUNIT_QTY * WEIGHT_AMT / 1000.0 ELSE 0 END) GATHEREDWEIGHT
		 , COUNT(DISTINCT CASE WHEN ISNULL(GD.GATHERING_TM, @currentDay ) >= @currentDay THEN GD.PALLET_NO END) GATHEREDPALLET_CNT
		 , SUM(CASE WHEN ISNULL(GD.GATHERING_TM, @currentDay ) >= @currentDay THEN 
					CASE WHEN GATHERED_QTY IS NOT NULL THEN ISNULL(GATHERED_QTY, 0) * ORDERUNIT_QTY * SP.PRICE_AMT
					WHEN STATUS < 4 THEN ORDER_QTY * ORDERUNIT_QTY * SP.PRICE_AMT
					ELSE SHIPPED_QTY * ORDERUNIT_QTY * SP.PRICE_AMT END
			   ELSE 0 END) ORDERPRICE
		 , SUM(CASE WHEN ISNULL(GD.GATHERING_TM, @currentDay ) >= @currentDay THEN ISNULL(GATHERED_QTY, 0) ELSE 0 END) GATHEREDPACKAGE_QTY
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
	   -- AND ISNULL(GD.GATHERING_TM, @currentDay ) >= @currentDay 
	 GROUP BY STOREORDERID, G.GATHERINGID, GATHERINGTYPE, GATHERINGSTATUS, GATHERINGUSER, U.USERFULL_NM

	IF OBJECT_ID('tempdb.dbo.#CONTROL', 'U') IS NOT NULL DROP TABLE #CONTROL;
	SELECT G.STOREORDER, G.GATHERINGTYPE, P.CONTROLUSER, U.USERFULL_NM, ISNULL(COUNT(*),0) CONTROLPALLET_CNT, ISNULL(SUM(CASE WHEN GATHERINGPALLETSTATUS = 9 THEN 1 ELSE 0 END),0) CONTROLLEDPALLET_CNT
	  INTO #CONTROL
	  FROM WHS_GATHERINGPALLET2_VW P
	  JOIN WHS_GATHERING G ON P.GATHERING = G.GATHERINGID
	  LEFT JOIN SEC_USER U ON P.CONTROLUSER = U.USERID
	 WHERE (P.CONTROLSTART_TM >= @currentDay OR G.GATHERINGSTART_TM >= @currentDay)
	 GROUP BY G.STOREORDER, G.GATHERINGTYPE, P.CONTROLUSER, U.USERFULL_NM

   
	SELECT O.STOREORDERID, O.STORE, O.STATUS, O.ORDER_DT, O.SHIPMENT_DT, O.OLDORDER_FL, ISNULL(O.ORDERWEIGHT, 0) ORDERWEIGHT 
  	     , COALESCE(G.HEAVYORDERWEIGHT, O.HEAVYORDERWEIGHT, 0) HEAVYORDERWEIGHT
  	     , COALESCE(G.LIGHTORDERWEIGHT, O.LIGHTORDERWEIGHT, 0) LIGHTORDERWEIGHT
  	     , ISNULL(G.HEAVYGATHEREDWEIGHT, 0) HEAVYGATHEREDWEIGHT
  	     , ISNULL(G.LIGHTGATHEREDWEIGHT, 0) LIGHTGATHEREDWEIGHT
  	     , ISNULL(G.WAITINGHEAVYORDER_CNT, 0) WAITINGHEAVYORDER_CNT
  	     , ISNULL(G.WAITINGLIGHTORDER_CNT, 0) WAITINGLIGHTORDER_CNT
  	     , ISNULL(C.WAITINGHEAVYCONTROLPALLET_CNT, 0) WAITINGHEAVYCONTROLPALLET_CNT
  	     , ISNULL(C.WAITINGLIGHTCONTROLPALLET_CNT, 0) WAITINGLIGHTCONTROLPALLET_CNT
		 , ISNULL(G.ORDERPRICE, 0) ORDERPRICE
      FROM #ORDERS O
	  LEFT JOIN (SELECT STOREORDERID
				      , SUM(CASE WHEN GATHERINGTYPE = 1 THEN ORDERWEIGHT ELSE 0 END) HEAVYORDERWEIGHT
				      , SUM(CASE WHEN GATHERINGTYPE = 2 THEN ORDERWEIGHT ELSE 0 END) LIGHTORDERWEIGHT  
				      , SUM(CASE WHEN GATHERINGTYPE = 1 THEN GATHEREDWEIGHT ELSE 0 END) HEAVYGATHEREDWEIGHT
				      , SUM(CASE WHEN GATHERINGTYPE = 2 THEN GATHEREDWEIGHT ELSE 0 END) LIGHTGATHEREDWEIGHT  
				      , SUM(CASE WHEN GATHERINGTYPE = 1 AND USERFULL_NM IS NULL THEN GATHEREDPALLET_CNT ELSE 0 END) WAITINGHEAVYORDER_CNT  
				      , SUM(CASE WHEN GATHERINGTYPE = 2 AND USERFULL_NM IS NULL THEN GATHEREDPALLET_CNT ELSE 0 END) WAITINGLIGHTORDER_CNT  
					  , SUM(ORDERPRICE) ORDERPRICE
				   FROM #GATHERING
				  GROUP BY STOREORDERID) G ON O.STOREORDERID = G.STOREORDERID
	  LEFT JOIN (SELECT STOREORDER
				      , SUM(CASE WHEN GATHERINGTYPE = 1 THEN CONTROLPALLET_CNT - CONTROLLEDPALLET_CNT ELSE 0 END) WAITINGHEAVYCONTROLPALLET_CNT
				      , SUM(CASE WHEN GATHERINGTYPE = 2 THEN CONTROLPALLET_CNT - CONTROLLEDPALLET_CNT ELSE 0 END) WAITINGLIGHTCONTROLPALLET_CNT  
			       FROM #CONTROL
				  GROUP BY STOREORDER) C ON O.STOREORDERID = C.STOREORDER
	 ORDER BY SHIPMENT_DT 

	SELECT USERFULL_NM, GATHERINGTYPE, 
		   ISNULL(SUM(GATHEREDWEIGHT),0) GATHEREDWEIGHT, 
		   ISNULL(SUM(GATHEREDPALLET_CNT),0) GATHEREDPALLET_CNT,
		   COUNT(DISTINCT CASE WHEN GATHEREDPALLET_CNT > 0 THEN STOREORDERID END) ORDER_CNT,
		   ISNULL(SUM(GATHEREDPACKAGE_QTY),0) GATHEREDPACKAGE_QTY
	  FROM #GATHERING 
	 WHERE USERFULL_NM IS NOT NULL
	 GROUP BY USERFULL_NM, GATHERINGTYPE ORDER BY 3 DESC

	SELECT GATHERINGTYPE, CONTROLUSER, USERFULL_NM
	     , SUM(CONTROLPALLET_CNT) CONTROLPALLET_CNT 
	     , SUM(CONTROLLEDPALLET_CNT) CONTROLLEDPALLET_CNT 
      FROM #CONTROL 
     WHERE USERFULL_NM IS NOT NULL  
     GROUP BY GATHERINGTYPE, CONTROLUSER, USERFULL_NM
     ORDER BY CONTROLLEDPALLET_CNT DESC

END