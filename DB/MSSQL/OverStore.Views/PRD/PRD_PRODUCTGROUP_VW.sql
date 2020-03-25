﻿CREATE VIEW PRD_PRODUCTGROUP_VW AS
SELECT PRODUCTID, NAME_NM PRODUCT_NM, PRICE_AMT, PACKAGE_QTY
  FROM PRD_PRODUCT P (NOLOCK)
  JOIN PRC_SALEPRICE_VW SP ON P.PRODUCTID = SP.PRODUCT
  JOIN (SELECT PRODUCT, MAX(PACKAGE_QTY) PACKAGE_QTY FROM WHS_PRODUCTSHIPMENTUNIT (NOLOCK) WHERE SHIPMENTTYPE = 1 GROUP BY PRODUCT HAVING MAX(PACKAGE_QTY) != 0) SU ON SU.PRODUCT = P.PRODUCTID
 UNION ALL
SELECT 10000+SGN.STOCKGROUPID, STOCKGROUP_NM, AVG(PRICE_AMT), MAX(PACKAGE_QTY)
  FROM PRD_STOCKGROUPNAME SGN (NOLOCK) 
  JOIN PRD_STOCKGROUP SG (NOLOCK)  ON SG.STOCKGROUP = SGN.STOCKGROUPID
  JOIN PRC_SALEPRICE_VW SP ON SG.PRODUCTID = SP.PRODUCT
  JOIN (SELECT PRODUCT, MAX(PACKAGE_QTY) PACKAGE_QTY FROM WHS_PRODUCTSHIPMENTUNIT (NOLOCK)  WHERE SHIPMENTTYPE = 1 GROUP BY PRODUCT HAVING MAX(PACKAGE_QTY) != 0) SU ON SU.PRODUCT = SG.PRODUCTID
 GROUP BY SGN.STOCKGROUPID, STOCKGROUP_NM