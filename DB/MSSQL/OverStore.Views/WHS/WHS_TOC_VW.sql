﻿CREATE VIEW WHS_TOC_VW AS
SELECT T.TOCID, T.STORE, ST.STORE_NM, T.PRODUCT, COALESCE(SGN.STOCKGROUP_NM, P.NAME_NM) PRODUCT_NM,  T.TOC_DT, 
	   T.GREENLIMIT_QTY, T.YELLOWLIMIT_QTY, T.REDLIMIT_QTY, T.REDREMNANT_QTY,
	   T.BUFFER_QTY, T.STOCK_QTY, T.SALE_QTY, T.INTAKE_QTY, T.PERIOD_NO, ISNULL(SUM(TD.ORDER_QTY),0) ORDER_QTY,
	   ISNULL(SUM(TD.ORDER_QTY * SP.PRICE_AMT),0) ORDERPRICE_AMT
  FROM WHS_TOC T
  JOIN STR_STORE ST ON T.STORE = ST.STOREID
  LEFT JOIN PRD_PRODUCT P ON T.PRODUCT = P.PRODUCTID
  LEFT JOIN PRD_STOCKGROUPNAME SGN ON T.PRODUCT = 10000+SGN.STOCKGROUPID 
  LEFT JOIN WHS_TOCDETAIL TD ON T.TOCID = TD.TOCID
  LEFT JOIN PRC_SALEPRICE_VW SP ON TD.DETAILPRODUCT = SP.PRODUCT
 GROUP BY T.TOCID, T.STORE, ST.STORE_NM, T.PRODUCT, COALESCE(SGN.STOCKGROUP_NM, P.NAME_NM),
	   T.TOC_DT, T.GREENLIMIT_QTY, T.YELLOWLIMIT_QTY, T.REDLIMIT_QTY, T.REDREMNANT_QTY,
	   T.BUFFER_QTY, T.STOCK_QTY, T.SALE_QTY, T.INTAKE_QTY, T.PERIOD_NO