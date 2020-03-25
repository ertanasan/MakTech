﻿CREATE PROCEDURE [dbo].[WHS_LST_STOCKDIFFGROUP_SP] @StartDate DATE, @EndDate DATE, @StoreId INT = -1, @GroupId INT = -1 WITH RECOMPILE AS
BEGIN
	SELECT ST.STORE_NM, D.COUNTING_DT, D.LAGACTUAL_DT, 
		   CG.CATEGORY_NM, ISNULL(STGN.STOCKGROUP_NM, P.NAME_NM) STOCKGROUP_NM, 
		   SUM(D.STOCK) STOCK_QTY, SUM(D.COUNTING_QTY) COUNTING_QTY, SUM(D.COUNTING_QTY - D.STOCK) COUNTDIFF_QTY, 
		   SUM(D.STOCK*PR.PRICE_AMT) STOCKPRICE_AMT, SUM(D.COUNTING_QTY*PR.PRICE_AMT) COUNTINGPRICE_AMT,
		   SUM((D.COUNTING_QTY - D.STOCK)*PR.PRICE_AMT) COUNTDIFF_AMT, 
		   SUM(CASE WHEN D.COUNTING_QTY > D.STOCK THEN (D.COUNTING_QTY - D.STOCK)*PR.PRICE_AMT ELSE 0 END) OVERSTOCK_AMT,
		   SUM(CASE WHEN D.COUNTING_QTY > D.STOCK THEN 0 ELSE -1*(D.COUNTING_QTY - D.STOCK)*PR.PRICE_AMT END) MISSINGSTOCK_AMT,
		   SUM(SALE_QTY) SALE_QTY, SUM(SALE_AMT) SALE_AMT, 
		   CASE WHEN SUM(SALE_AMT) > 0 THEN SUM((D.COUNTING_QTY - D.STOCK)*PR.PRICE_AMT) / SUM(SALE_AMT) ELSE 0 END SUCCESSKPI
	  FROM WHS_COUNTINGSTOCKDIFF D
	  JOIN STR_STORE ST ON D.STORE = ST.STOREID
	  JOIN PRD_PRODUCT P ON D.PRODUCT = P.PRODUCTID
	  LEFT JOIN PRD_STOCKGROUP STG ON P.PRODUCTID = STG.PRODUCTID
	  LEFT JOIN PRD_STOCKGROUPNAME STGN ON STG.STOCKGROUP = STGN.STOCKGROUPID
	  LEFT JOIN PRD_SUBGROUP SG ON P.SUBGROUP = SG.SUBGROUPID
	  LEFT JOIN PRD_CATEGORY CG ON SG.CATEGORY = CG.CATEGORYID
	  LEFT JOIN (SELECT PRODUCT, PRICE_AMT FROM PRC_PRODUCT WHERE PACKAGE = 1 AND DELETED_FL = 'N') PR ON P.PRODUCTID = PR.PRODUCT
	 WHERE D.COUNTING_DT BETWEEN @StartDate AND @EndDate
	   AND (@StoreId = -1 OR D.STORE = @StoreId)
	   AND (@GroupId = -1 OR ISNULL(10000+STGN.STOCKGROUPID, P.PRODUCTID) = @GroupId)
	   AND P.PRODUCTID NOT IN (SELECT PRODUCT FROM PRD_PROPERTY WHERE PROPERTYTYPE = 6 AND VALUE_TXT = '1')
	   AND P.SUPERGROUP1 != 9
	 GROUP BY ST.STORE_NM, D.COUNTING_DT, D.LAGACTUAL_DT, CG.CATEGORY_NM, ISNULL(STGN.STOCKGROUP_NM, P.NAME_NM)
	 ORDER BY SALE_AMT DESC 
END