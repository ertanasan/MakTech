﻿CREATE PROCEDURE [dbo].[WHS_LST_STOCKDIFF_SP] @StockTakingScheduleId INT AS
BEGIN
	SELECT STORE_NM+' - '+CONVERT(VARCHAR, COUNTING_DT, 104) COUNTING_NM, ST.STORE_NM, D.COUNTING_DT, D.LAGACTUAL_DT, 
		   CG.CATEGORY_NM, SG.SUBGROUP_NM, ISNULL(STGN.STOCKGROUP_NM, P.NAME_NM) STOCKGROUP_NM, P.PRODUCTID, 
		   P.CODE_NM PRODUCTCODE_NM, P.NAME_NM PRODUCT_NM, 
		   D.STOCK STOCK_QTY, D.COUNTING_QTY, D.COUNTING_QTY - D.STOCK COUNTDIFF_QTY, PR.PRICE_AMT, 
		   D.STOCK*PR.PRICE_AMT STOCKPRICE_AMT, D.COUNTING_QTY*PR.PRICE_AMT COUNTINGPRICE_AMT,
		   (D.COUNTING_QTY - D.STOCK)*PR.PRICE_AMT COUNTDIFF_AMT, 
		   CASE WHEN D.COUNTING_QTY > D.STOCK THEN (D.COUNTING_QTY - D.STOCK)*PR.PRICE_AMT ELSE 0 END OVERSTOCK_AMT,
		   CASE WHEN D.COUNTING_QTY > D.STOCK THEN 0 ELSE -1*(D.COUNTING_QTY - D.STOCK)*PR.PRICE_AMT END MISSINGSTOCK_AMT,
		   D.SALE_QTY, D.SALE_AMT, CASE WHEN D.SALE_AMT > 0 THEN (D.COUNTING_QTY - D.STOCK)*PR.PRICE_AMT / D.SALE_AMT ELSE 0 END SUCCESSKPI
	  FROM WHS_STOCKDIFF_VW D
	  JOIN STR_STORE ST ON D.STORE = ST.STOREID
	  JOIN PRD_PRODUCT P ON D.PRODUCT = P.PRODUCTID
	  LEFT JOIN PRD_STOCKGROUP STG ON P.PRODUCTID = STG.PRODUCTID
	  LEFT JOIN PRD_STOCKGROUPNAME STGN ON STG.STOCKGROUP = STGN.STOCKGROUPID
	  LEFT JOIN PRD_SUBGROUP SG ON P.SUBGROUP = SG.SUBGROUPID
	  LEFT JOIN PRD_CATEGORY CG ON SG.CATEGORY = CG.CATEGORYID
	  LEFT JOIN (SELECT PRODUCT, PRICE_AMT FROM PRC_PRODUCT WHERE PACKAGE = 1 AND DELETED_FL = 'N') PR ON P.PRODUCTID = PR.PRODUCT
	 WHERE STOCKTAKINGSCHEDULEID = @StockTakingScheduleId
	   AND P.PRODUCTID NOT IN (SELECT PRODUCT FROM PRD_PROPERTY WHERE PROPERTYTYPE = 6 AND VALUE_TXT = '1')
	   AND P.SUPERGROUP1 != 9
	 ORDER BY 3 DESC, COUNTING_NM
END