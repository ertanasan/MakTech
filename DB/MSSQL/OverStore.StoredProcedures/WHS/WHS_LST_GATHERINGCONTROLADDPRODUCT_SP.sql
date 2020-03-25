﻿CREATE PROCEDURE WHS_LST_GATHERINGCONTROLADDPRODUCT_SP @GatheringId BIGINT, @PalletNo INT AS
BEGIN
	IF OBJECT_ID('tempdb..#bannedProducts') IS NOT NULL DROP TABLE #bannedProducts
	SELECT PRODUCT INTO #bannedProducts FROM PRD_PROPERTY (NOLOCK) WHERE PROPERTYTYPE = 4 AND VALUE_TXT = '1'    

	SELECT P.*
	  FROM PRD_PRODUCT P
	  JOIN WHS_GATHERING G ON G.GATHERINGID = @GatheringId 
	  JOIN WHS_PRODUCTSHIPMENTUNIT (NOLOCK) S ON P.PRODUCTID = S.PRODUCT AND S.SHIPMENTTYPE = 1  
	  LEFT JOIN #bannedProducts BP  ON P.PRODUCTID = BP.PRODUCT  
	 WHERE P.DELETED_FL = 'N'
	   AND P.ACTIVE_FL = 'Y' AND PACKAGE_QTY != 0 AND P.SUPERGROUP3 NOT IN (1,3)
	   AND BP.PRODUCT IS NULL 
	   AND ((G.GATHERINGTYPE = 1 AND P.LOADORDER_TXT LIKE 'A%')
			OR
			(G.GATHERINGTYPE = 2 AND P.LOADORDER_TXT NOT LIKE 'A%'))
	   AND PRODUCTID NOT IN (
	SELECT SOD.PRODUCT
	  FROM WHS_GATHERING G
	  JOIN WHS_GATHERINGDETAIL GD ON G.GATHERINGID = GD.GATHERING AND GD.DELETED_FL = 'N'
	  JOIN WHS_STOREORDERDETAIL SOD ON GD.STOREORDERDETAIL = SOD.STOREORDERDETAILID
	 WHERE GATHERINGID = @GatheringId
	   AND G.DELETED_FL = 'N'
	   AND GD.PALLET_NO = @PalletNo)
END