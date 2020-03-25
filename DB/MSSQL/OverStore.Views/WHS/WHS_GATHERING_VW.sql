﻿CREATE VIEW WHS_GATHERING_VW AS
SELECT A.STOREORDER, A.GATHERINGID, A.GATHERINGTYPE, A.GATHERINGTYPE_NM, A.GATHERINGSTATUS, A.GATHERINGSTATUS_NM, A.GATHERINGUSER_NM, A.GATHERINGSTART_TM, A.GATHERINGEND_TM
     , GATHEREDPALLET_NO GATHERINGPALLET_CNT, SUM(GD.GATHERED_QTY * SOD.ORDERUNIT_QTY * SP.PRICE_AMT) GATHERINGPRICE_AMT
	 , GATHEREDPRODUCT_CNT
  FROM (
SELECT STOREORDER, G.GATHERINGID, G.GATHERINGTYPE, GATHERINGTYPE_NM, G.GATHERINGSTATUS, GS.GATHERINGSTATUS_NM, U1.USERFULL_NM GATHERINGUSER_NM, GATHERINGSTART_TM, GATHERINGEND_TM
	 , ROW_NUMBER() OVER (PARTITION BY STOREORDER, GATHERINGTYPE ORDER BY G.CREATE_DT DESC) ROWNO
  FROM WHS_GATHERING G 
  JOIN WHS_GATHERINGSTATUS GS ON G.GATHERINGSTATUS = GS.GATHERINGSTATUSID
  JOIN WHS_GATHERINGTYPE GT ON G.GATHERINGTYPE = GT.GATHERINGTYPEID
  LEFT JOIN SEC_USER U1 ON G.GATHERINGUSER = U1.USERID) A
  JOIN WHS_GATHERINGDETAIL GD ON A.GATHERINGID = GD.GATHERING
  JOIN WHS_STOREORDERDETAIL SOD ON GD.STOREORDERDETAIL = SOD.STOREORDERDETAILID
  LEFT JOIN (SELECT GATHERING, COUNT(DISTINCT PALLET_NO) GATHEREDPALLET_NO, COUNT(*) GATHEREDPRODUCT_CNT FROM WHS_GATHERINGDETAIL WHERE ISNULL(GATHERED_QTY,0) > 0 GROUP BY GATHERING) GDSUM ON A.GATHERINGID = GDSUM.GATHERING 
  LEFT JOIN PRC_SALEPRICE_VW SP ON SOD.PRODUCT = SP.PRODUCT
 WHERE A.ROWNO = 1
 GROUP BY A.STOREORDER, A.GATHERINGID, A.GATHERINGTYPE, A.GATHERINGTYPE_NM, A.GATHERINGSTATUS, A.GATHERINGSTATUS_NM, 
 A.GATHERINGUSER_NM, A.GATHERINGSTART_TM, A.GATHERINGEND_TM, GATHEREDPALLET_NO, GATHEREDPRODUCT_CNT