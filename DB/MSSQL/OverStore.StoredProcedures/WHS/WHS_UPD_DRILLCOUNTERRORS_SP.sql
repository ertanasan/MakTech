﻿CREATE PROCEDURE [dbo].[WHS_UPD_DRILLCOUNTERRORS_SP] AS
BEGIN
  DECLARE @bcDate DATE = CONVERT(DATE, '20190430', 112)

  INSERT INTO TMP_SONDAJUPDATE
  SELECT ST.STOCKTAKINGID, S.STORE, ST.PRODUCT, P.NAME_NM, ST.ZONE, ST.COUNTINGVALUE_AMT, 0 , 0, 
		 ST.COUNTINGVALUE_AMT*PR.PRICE_AMT COUNTINGPRICE
    FROM WHS_STOCKTAKINGSCHEDULE S
    JOIN WHS_STOCKTAKING ST ON S.STOCKTAKINGSCHEDULEID = ST.STOCKTAKINGSCHEDULE
    JOIN PRD_PRODUCT P ON ST.PRODUCT = P.PRODUCTID
    LEFT JOIN PRC_SALEPRICE_VW PR ON P.PRODUCTID = PR.PRODUCT
    LEFT JOIN PRD_STOCKGROUP_VW SG ON ST.PRODUCT = SG.PRODUCTID AND SG.USAGETYPE_CD = 1
   WHERE S.PLANNED_DT > @bcDate 
     AND S.COUNTINGTYPE = 2
	 AND S.STORE != 999
     AND ((ZONE = 1 AND ST.COUNTINGVALUE_AMT*PR.PRICE_AMT >= 15000) OR (ZONE = 3 AND ST.COUNTINGVALUE_AMT*PR.PRICE_AMT >= 10000) OR (ZONE = 2 AND ST.COUNTINGVALUE_AMT*PR.PRICE_AMT >= 5000) )
   
  UPDATE ST 
     SET ST.COUNTINGVALUE_AMT= ST.COUNTINGVALUE_AMT/1000.0
    FROM WHS_STOCKTAKINGSCHEDULE S
    JOIN WHS_STOCKTAKING ST ON S.STOCKTAKINGSCHEDULEID = ST.STOCKTAKINGSCHEDULE
    JOIN PRD_PRODUCT P ON ST.PRODUCT = P.PRODUCTID
    LEFT JOIN PRC_SALEPRICE_VW PR ON P.PRODUCTID = PR.PRODUCT
    LEFT JOIN PRD_STOCKGROUP_VW SG ON ST.PRODUCT = SG.PRODUCTID AND SG.USAGETYPE_CD = 1
   WHERE S.PLANNED_DT > @bcDate 
     AND S.COUNTINGTYPE = 2
	 AND S.STORE != 999
     AND ((ZONE = 1 AND ST.COUNTINGVALUE_AMT*PR.PRICE_AMT >= 15000) OR (ZONE = 3 AND ST.COUNTINGVALUE_AMT*PR.PRICE_AMT >= 10000) OR (ZONE = 2 AND ST.COUNTINGVALUE_AMT*PR.PRICE_AMT >= 5000) )
END